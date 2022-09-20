using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public partial class BooksTransaction
    {
        public int TransId { get; set; }
        public int? BookId { get; set; }
        public int? UserId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Status { get; set; }

        public virtual BooksAvailable? Book { get; set; }
        public virtual UserDetail? User { get; set; }
    }
}
