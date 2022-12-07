using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public int Status { get; set; }
        public string Address { get; set; }
        public IEnumerable<LineItemDto> Items { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserEmail { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }

    }
}

