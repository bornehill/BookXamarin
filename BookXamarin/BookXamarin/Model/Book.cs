using System;
using System.Collections.Generic;
using System.Text;

namespace BookXamarin.Model
{
    public class Book
    {
        public string Author { get; set; }
        public string Country { get; set; }
        public string ImageLink { get; set; }
        public string Language { get; set; }
        public string Link { get; set; }
        public int Pages { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
