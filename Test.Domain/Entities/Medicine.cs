using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Entities
{
    public class Medicine: IEntity<int>
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public decimal Price { get;set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
}
