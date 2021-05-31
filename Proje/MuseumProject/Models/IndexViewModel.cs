using MuseumProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MuseumProject.Models
{
    public class IndexViewModel
    {
        public Admin Admin { get; set; }
        public List<Category> Category { get; set; }
        public List<Collection> Collection { get; set; }
        public List<Message> Message { get; set; }
    }
}