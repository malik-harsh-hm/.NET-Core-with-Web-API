using DotNetCore.New.API.Models;
using System;

namespace DotNetCore.New.API
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public bool Liked { get; set; }
        public double DailyRentalRate { get; set; }
        public int NumberInStock { get; set; }

    }
}
