using System.Collections;
using System.Collections.Generic;
using api.Models;

namespace api.Data
{
    public interface IPodzielSieKsiazkaRepo
    {
        bool SaveChanges();

        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByLocation(double longitude, double latitude, double radius);
        Book GetBookById(int id);
        IEnumerable<Book> GetAllBooksByCategory(CategoryOfBook category);
        void AddBook(Book book);
        User GetUserById(int id);
        User GetUserByLoginId(string loginId);
        void AddUser(User user);

        Transaction GetTransactionById(int id);
        void AddTransaction(Transaction transaction);
        IEnumerable<Transaction> GetAllTransactionsByUserId(int id);
    }
}
