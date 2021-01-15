using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using Geolocation;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class MariaDbPodzielSieKsiazkaRepo : IPodzielSieKsiazkaRepo
    {

        private readonly PodzielSieKsiazkaContext _context;

        public MariaDbPodzielSieKsiazkaRepo(PodzielSieKsiazkaContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books
                .Include(p=>p.Owner)
                .ToList();
        }

        public IEnumerable<Book> GetBooksByLocation(double longitude, double latitude, double radius)
        {
            CoordinateBoundaries boundaries = new CoordinateBoundaries(latitude, longitude, radius,DistanceUnit.Kilometers);

            double minLatitude = boundaries.MinLatitude;
            double maxLatitude = boundaries.MaxLatitude;
            double minLongitude = boundaries.MinLongitude;
            double maxLongitude = boundaries.MaxLongitude;

            return  _context.Books
                .Where(x => x.Latitude >= minLatitude && x.Latitude <= maxLatitude)
                .Where(x => x.Longitude >= minLongitude && x.Longitude <= maxLongitude)
                .Include(p => p.Owner)
                .ToList();
        }


        public Book GetBookById(int id)
        {
            return _context.Books
                .Include(p=>p.Owner)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Book> GetAllBooksByCategory(CategoryOfBook category)
        {
            return _context.Books
                .Include(p => p.Owner)
                .Where(p => p.Category == category)
                .ToList();
        }

        public void AddBook(Book book)
        {
            if (book == null)throw new ArgumentNullException(nameof(book));
            _context.Books.Add(book);
        }

        public User GetUserById(int id)
        {
            return _context.Users
                .Include(p => p.Books)
                .FirstOrDefault(p=>p.Id == id);
        }

        public User GetUserByLoginId(string loginId)
        {
            return _context.Users
                .Include(p => p.Books)
                .FirstOrDefault(p=>p.LoginId == loginId);
        }

        public void AddUser(User user)
        {
            if (user == null)throw new ArgumentNullException(nameof(user));

            _context.Users.Add(user);
        }

        public Transaction GetTransactionById(int id)
        {
            return _context.Transactions
                .Include(p => p.Book)
                .Include(p => p.Customer)
                .Include(p => p.Book.Owner)
                .FirstOrDefault(p => p.Id == id);
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            _context.Transactions.Add(transaction);
        }

        public IEnumerable<Transaction> GetAllTransactionsByUserId(int id)
        {
            return _context.Transactions
                .Include(p => p.Customer)
                .Include(p=> p.Book)
                .Include(p => p.Book.Owner)
                .Where(p => p.Customer.Id == id | p.Book.UserId == id)
                .ToList();
        }
    }
}