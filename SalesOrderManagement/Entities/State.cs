using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Api.Entities
{
    public class State
    {
        public State()
        {
            this.Building = new HashSet<Building>();
        }
        public int StateId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Building> Building { get; set; }
    }
}
