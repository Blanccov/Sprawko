using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testscik
{
    internal class Product
    {
        private string _name;
        private decimal _price;

        public Product(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name))
                _name = "default name";
            else
                _name = name;
            if(price<0)
                price = 0;
            _price = price;
        }

        public string Name
        {
            get { return _name; }
        }
        public decimal Price
        { get { return _price; } }

        public override string ToString()
        {
            return $" | Name: {Name} | Price: {Price} | ";
        }
    }
}
