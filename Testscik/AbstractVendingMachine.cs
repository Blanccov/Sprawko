using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testscik
{
    internal abstract class AbstractVendingMachine
    {
        public abstract void AddProduct(Product product);
        public abstract void BuyProduct(string porductCode);
        public abstract void AddMoney(decimal amount);
        public abstract void ReturnCoins();
    }
}
