using System;
using System.Collections.Generic;
using System.Text;

namespace Tselevik.Models
{
    public enum MenuItemType
    {
        Tasks,
        Categories,
        Goals,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
