using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "Thor: Ragnarok",
                         ReleaseDate = DateTime.Parse("2017-11-3"),
                         Genre = "Action/SciFi",
                         Rating = "PG-13",
                         Price = 9.99M
                     },

                     new Movie
                     {
                         Title = "Pitch Perfect",
                         ReleaseDate = DateTime.Parse("2012-9-28"),
                         Genre = "Comedy",
                         Rating = "PG-13",
                         Price = 4.99M
                     },

                     new Movie
                     {
                         Title = "The Sandlot",
                         ReleaseDate = DateTime.Parse("1993-4-1"),
                         Genre = "Drama",
                         Rating = "PG",
                         Price = 2.99M
                     },

                   new Movie
                   {
                       Title = "Clueless",
                       ReleaseDate = DateTime.Parse("1995-7-19"),
                       Genre = "Teen Romance",
                       Rating = "PG-13",
                       Price = 3.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
