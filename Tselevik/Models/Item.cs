using System;

namespace Tselevik.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public string Date { get; set; }
        public int Importance { get; set; }
        public string Category { get; set; }
    }
}