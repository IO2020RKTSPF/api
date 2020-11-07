using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
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

        public Book GetBookById(int id)
        {
            return _context.Books
                .Include(p=>p.Owner)
                .FirstOrDefault(p => p.Id == id);
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
    }
}