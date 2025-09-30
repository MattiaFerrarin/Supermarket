using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class Product : DatabaseItem
    {
        public override string Name { get; set; }
        public string Code { get; set; }
        public float Cost { get; set; }
        public Product(string name, string code, float cost) 
        {
            Name = name;
            Code = code;
            Cost = cost;
        }
    }
}
