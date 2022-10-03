using System;
using System.Collections.Generic;
using System.Text;

namespace ArandaSoft.PruebaTecnica.Entities.DTOs
{
    public class ProductFilterDTO
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OrderBy { get; set; }
        public string OrderColumn { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
    }
}
