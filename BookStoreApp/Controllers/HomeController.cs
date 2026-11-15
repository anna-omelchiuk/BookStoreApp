using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext appContext;

        public HomeController(ApplicationContext context)
        {
            appContext = context;
        }

        public async Task<IActionResult> Index(string? genre)
        {
            IQueryable<Book> booksQuery = appContext.Books.Include(b => b.Images).Include(b => b.Comments);

            if (!string.IsNullOrEmpty(genre))
            {
                booksQuery = booksQuery.Where(b => b.Genre == genre);
            }

            ViewBag.SelectedGenre = genre;
            var books = await booksQuery.ToListAsync();
            return View(books);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
                return NotFound();

            var book = await appContext.Books.Include(b => b.Images).Include(b => b.Comments.OrderByDescending(c => c.CreatedAt)).FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) 
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int bookId, string userName, string text)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(text))
            {
                var comment = new Comment
                {
                    BookId = bookId,
                    UserName = userName.Trim(),
                    Text = text.Trim(),
                    CreatedAt = DateTime.Now
                };

                appContext.Comments.Add(comment);
                await appContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id = bookId });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book, string imageUrlsRaw)
        {
            if (!string.IsNullOrWhiteSpace(imageUrlsRaw))
            {
                var urls = imageUrlsRaw.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var url in urls)
                {
                    var cleanUrl = url.Trim();
                    if (!string.IsNullOrEmpty(cleanUrl))
                    {
                        book.Images.Add(new BookImage { ImageUrl = cleanUrl });
                    }
                }
            }

            appContext.Books.Add(book);
            await appContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddImages(int bookId, string imageUrlsRaw)
        {
            if (!string.IsNullOrWhiteSpace(imageUrlsRaw))
            {
                var urls = imageUrlsRaw.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var url in urls)
                {
                    var cleanUrl = url.Trim();
                    if (!string.IsNullOrEmpty(cleanUrl))
                    {
                        appContext.BookImages.Add(new BookImage
                        {
                            BookId = bookId,
                            ImageUrl = cleanUrl
                        });
                    }
                }
                await appContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id = bookId });
        }
    }
}
