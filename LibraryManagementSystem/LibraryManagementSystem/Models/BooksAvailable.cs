using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public partial class BooksAvailable
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? ImageUrl { get; set; }
        public string? BookDescription { get; set; }
    }
}
