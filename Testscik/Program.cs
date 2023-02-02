using Testscik;

CompactCafe compactCafe = new CompactCafe("CompactCafe", 77, 81, 97);

compactCafe.AddProduct(new Product("Kawusia", 200));
compactCafe.AddProduct(new Product("Kawusia2", 100));
compactCafe.AddProduct(new Product("Kawusia3", 220));
compactCafe.AddProduct(new Product("Kawusia4", 250));
compactCafe.AddProduct(new Product("Kawusia5", 150));

while (true)
{
    Console.WriteLine("\n1. Pokaż produkty");
    Console.WriteLine("2. Wrzuć monete");
    Console.WriteLine("3. Kup produkt");
    Console.WriteLine("4. Pokaż ilość wrzuconych monet");
    Console.WriteLine("5. Wyciąg monety");
    Console.WriteLine("6. Wyjście");

    String choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("Pokaż produkty\n");
            Console.WriteLine(compactCafe.ToString());
            compactCafe.ShowProduct();
            break;

        case "2":
            Console.WriteLine("Wrzuć monete\n");
            Console.WriteLine("Wrzuć monete w GROSZACH:");
            Decimal coin = Decimal.Parse(Console.ReadLine());
            compactCafe.AddMoney(coin);
            break;

        case"3":
            Console.WriteLine("Kup produkt\n");
            String code = Console.ReadLine();
            compactCafe.BuyProduct(code);
            break;

        case "4":
            Console.WriteLine("Pokaż ilość wrzuconych monet\n");
            Console.WriteLine(compactCafe.MoneyAmount);
            break;

        case"5":
            Console.WriteLine("Wyciąg monety\n");
            compactCafe.ReturnCoins();
            break;

        case "6":
            Console.WriteLine("Wyjście\n");
            return;

        case "3721":
            Console.WriteLine("Dodaj Produkt\n");
            Console.WriteLine("Podaj nazwe: ");
            String name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("niepodano nazwy");
            }
            Console.WriteLine("Podaj cene: ");
            Decimal price = Decimal.Parse(Console.ReadLine());

            if(price == null || price < 0)
            {
                Console.WriteLine("nieprawidłowa cena");
            }
            compactCafe.AddProduct(new Product(name, price));
            break;

        case "2137":
            Console.WriteLine("Historia: \n");
            compactCafe.LoadHistory();
            break;

        default:
            Console.WriteLine("Wybrano nieprawidłową opcje");
            break;
    }
}