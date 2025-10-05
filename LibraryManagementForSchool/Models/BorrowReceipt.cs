﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementForSchool.Models
{
    public class BorrowReceipt
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int TotalBooks { get; set; }
        public ICollection<BorrowReceiptDetail> Details { get; set; } = new List<BorrowReceiptDetail>();
        public ICollection<ReturnedBooks> ReturnedBooks { get; set; }
    }

}
