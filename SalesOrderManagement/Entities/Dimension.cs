using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Api.Entities
{
    public class Dimension
    {
        public int DimensionId { get; set; }
        [StringLength(10)]
        public string Width { get; set; }
        [StringLength(10)]
        public string Height { get; set; }
    }
}
