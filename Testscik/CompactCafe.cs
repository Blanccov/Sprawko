using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testscik
{
    internal class CompactCafe : AbstractVendingMachine
    {

        private decimal moneyAmount;
        private readonly string machineName;
        private readonly int width;
        private readonly int height;
        private readonly int length;
        private Dictionary<string, Product> products;
        private string _history;

        String[] alfabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public CompactCafe(string machineName, int width, int height, int length)
        {
            this.machineName= machineName;
            this.width = width;
            this.height = height;
            this.length = length;
            this.products = new Dictionary<string, Product>();
        }

        public override string ToString()
        {
            return $"name: {machineName}\n size: {width} x {height} x {length}\n count: {products.Count}\n";
        }

        public String MachineName
        {
            get { return machineName; }
        }
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        public int Length
        {
            get { return length; }
        }
        public Decimal MoneyAmount
        {
            get { return moneyAmount; }
        }

        public override void AddMoney(decimal amount)
        {
            try
            {
                if (amount == 20 || amount == 50 || amount == 100 || amount == 200 || amount == 500)
                {
                    moneyAmount += amount;
                    Console.WriteLine($"Aktualny stan portfela: {moneyAmount}");
                    _history += $"Wpłacono:{amount} \n";
                    SaveHistory();
                }
                else
                {
                    throw new Exception("wrong coin");
                }
            }
            catch
            {
                Console.WriteLine("Zła kwota");
            }
        }

        public override void AddProduct(Product product)
        {
            try
            {
                
                if(products.Count < 26)
                {
                    for(int i=0; i< alfabet.Length; i++)
                    {
                        if (!products.ContainsKey(alfabet[i]))
                        {
                            products.Add(alfabet[i], product);
                            
                            break;
                        }
                    }
                }
                else
                {
                    throw new Exception("Full Machine");
                }


            }catch(Exception e)
            {
                Console.WriteLine("Bad");
            }
        }
        public void AddProduct(Product product, string code)
        {
            try
            {
                if (!products.ContainsKey(code) && products.Count < 26)
                {
                    products.Add(code, product);
              
                }
                else
                {
                    throw new Exception("Full Machine or code already taken");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void BuyProduct(string porductCode)
        {
            try
            {

                if (products.ContainsKey(porductCode))
                {
                    Product product= products[porductCode];
                    if(moneyAmount >= product.Price)
                    {
                        products.Remove(porductCode);
                        moneyAmount -= product.Price;
                        _history += $"Kupiono produkt: {porductCode} \n";
                        SaveHistory();
                        Console.WriteLine($"Kupiono produkt: {porductCode}");
                    }
                    else
                    {
                        throw new Exception("No Money");
                    }
                }
                else
                {
                    throw new Exception("Nie ma takiego produktu");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void ReturnCoins()
        {
            try
            {
                Console.WriteLine($"Zwrócono resztę: {moneyAmount}");
                _history += $"Zwrócono resztę:{moneyAmount} \n";
                SaveHistory();
                moneyAmount= 0;


            }
            catch(Exception e) { Console.WriteLine(e.Message); }
        }

        public void ShowProduct()
        {
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }

        public void SaveHistory()
        {
            using (StreamWriter writer = new StreamWriter("history.txt", true))
            {
                writer.WriteLine(DateTime.Now + "\n " + _history);
            }
        }
        public void LoadHistory()
        {
            if (File.Exists("history.txt"))
            {
                using (StreamReader reader = new StreamReader("history.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("Plik historii nie istnieje.");
            }
        }
    }
}
