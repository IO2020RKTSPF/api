using System.Collections;
using System.Collections.Generic;
using api.Models;

namespace api.Data
{
    public interface IPodzielSieKsiazkaRepo
    {
        bool SaveChanges();

        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);

        User GetUserById(int id);
        User GetUserByLoginId(string loginId);
        void AddUser(User user);

        Transaction GetTransactionById(int id);
    }
}
