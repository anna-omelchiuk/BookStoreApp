using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Components
{
    public class GenreStatsViewComponent : ViewComponent
    {
        private readonly ApplicationContext appContext;

        public GenreStatsViewComponent(ApplicationContext context)
        {
            appContext = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? selectedGenre)
        {
            var stats = await appContext.Books.GroupBy(b => b.Genre)
            .Select(g => new GenreStatItem
            {
                Genre = g.Key,
                Count = g.Count()
            }).ToListAsync();

            ViewBag.SelectedGenre = selectedGenre;
            ViewBag.TotalCount = await appContext.Books.CountAsync();
            return View(stats);
        }
    }

    public class GenreStatItem
    {
        public string Genre { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}