using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechLibrary.Data;
using TechLibrary.Domain;
using TechLibrary.Models;

namespace TechLibrary.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int bookid);
        Task<List<Book>> GetBooksByPage(int bookid);
        Task<List<Book>> SearchBooks(string keyword);
        Task<Book> UpdateBook(int bookid, string desc);
    }

    public class BookService : IBookService
    {
        private readonly DataContext _dataContext;

        public BookService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var queryable = _dataContext.Books.AsQueryable();

            return await queryable.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int bookid)
        {
            return await _dataContext.Books.SingleOrDefaultAsync(x => x.BookId == bookid);
        }

        public async Task<List<Book>> GetBooksByPage(int pageid)
        {
            var queryable = _dataContext.Books.Where(x => x.BookId > (pageid*10 - 9) && x.BookId <= (pageid*10));
            return await queryable.ToListAsync();
        }

        public async Task<List<Book>> SearchBooks(string keyword)
        {
            var queryable = _dataContext.Books.Where(x => x.Title.Contains(keyword) ||
                                                          x.ShortDescr.Contains(keyword));
            return await queryable.ToListAsync();
        }

        public async Task<Book> UpdateBook(int bookid, string desc)
        {
            var book = await _dataContext.Books.SingleOrDefaultAsync(x => x.BookId == bookid);
            book.LongDescr = desc;
            _dataContext.Update(book);
            return book;
        }
    }
}
