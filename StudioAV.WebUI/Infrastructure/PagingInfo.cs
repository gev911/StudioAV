using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudioAV.WebUI.Infrastructure
{
    public class PagingInfo
    {
        public int CorrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get { return TotalItems / ItemsPerPage; } }
    }
}