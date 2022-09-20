using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            BooksTransactions = new HashSet<BooksTransaction>();
        }

        public int UserId { get; set; }
        [DataType(DataType.Text)]
      
        public string? UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string? Email { get; set; }
   
        public string? Password { get; set; }

        public virtual ICollection<BooksTransaction> BooksTransactions { get; set; }
    }
}
