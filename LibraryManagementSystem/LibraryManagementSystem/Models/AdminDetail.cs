using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public partial class AdminDetail
    {
        public int AdminId { get; set; }
        public string? AdminName { get; set; }
        public string? AdminEmail { get; set; }
        public string? AdminPassword { get; set; }
    }

}
