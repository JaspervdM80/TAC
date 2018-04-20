﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class NavigationItem
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public bool Active { get; set; }

        public NavigationItem(string Title, string URL, bool Active)
        {
            this.Title = Title;
            this.URL = URL;
            this.Active = Active;
        }
    }
}