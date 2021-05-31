using MuseumProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuseumProject.Models
{
    public class AddCollectionViewModel
    {
        public IEnumerable<SelectListItem> SelectedCategory { get; set; }

        public Collection Collection { get; set; }

    }
}