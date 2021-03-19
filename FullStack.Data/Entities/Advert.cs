using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.Data.Entities
{
    public class Advert
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
