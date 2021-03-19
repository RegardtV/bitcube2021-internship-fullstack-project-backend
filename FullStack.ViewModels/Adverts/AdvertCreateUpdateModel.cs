using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.ViewModels.Adverts
{
    public class AdvertCreateUpdateModel
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public string Date { get; set; }
        public string State { get; set; }
    }
}
