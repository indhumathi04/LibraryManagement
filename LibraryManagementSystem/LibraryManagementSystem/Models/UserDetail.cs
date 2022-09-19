using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public partial class UserDetail
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
