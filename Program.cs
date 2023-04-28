using System.Diagnostics;
using System.Xml.Schema;

namespace Assignment6
{
    class Furniture
    {
        public double Height { get; set; }
        public double width { get; set; }
        public String color { get; set; }
        public double quantity { get; set; }
        public double price { get; set; }

        public void Accept()
        {
            Console.WriteLine("Enter the height: ");
            Height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the Width: ");
            width = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the color: ");
            color = Console.ReadLine();

            Console.WriteLine("Enter the Quantity: ");
            quantity = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the price: ");
            price = Convert.ToDouble(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine("Height: " + Height);
            Console.WriteLine("Width: " + width);
            Console.WriteLine("Color: " + color);
            Console.WriteLine("Quantity: " + quantity);
            Console.WriteLine("Price : " + price);
        }

        public double TotalCost()
        {
            return quantity * price;
        }



    }
    class Bookshelf : Furniture
    {
        public int numberofshelves { get; set; }

        public void Accept()
        {
            base.Accept();
            Console.WriteLine("Enter No.of shelves: ");
            numberofshelves = Convert.ToInt32(Console.ReadLine());

        }

        public void Display()
        {
            Console.WriteLine("BookShelf Details:");
            base.Display();
            Console.WriteLine("Number of shelves : " + numberofshelves);
        }


    }
    class Diningtable : Furniture
    {
        public int numberoflegs { get; set; }

        public void Accept()
        {
            base.Accept();
            Console.WriteLine("Enter the Number of legs : ");
            numberoflegs = Convert.ToInt32(Console.ReadLine());
        }

        public new  void Display()
        {
            Console.WriteLine("Diningtable Details:");
            base.Display();
            Console.WriteLine("Number of legs : " + numberoflegs);
        }

    }
    internal class Program
    {
        static void AcceptStockdetails(Furniture[] stock)
        {
            Console.WriteLine("Select the type of Furniture: ");
            Console.WriteLine("1.Bookshelves");
            Console.WriteLine("2.Dining table");

            for (int i = 0; i < stock.Length; i++)
            {
                Console.WriteLine($"Enter the type of furniture" + (i + 1));
                String furnitureType = Console.ReadLine();

                if (furnitureType == "Bookshelves")
                {
                    Bookshelf bookshelf = new Bookshelf();
                    bookshelf.Accept();
                    stock[i] = bookshelf;
                }
                else if (furnitureType == "Diningtable")
                {
                    Diningtable diningtable = new Diningtable();
                    diningtable.Accept();
                    stock[i] = diningtable;
                }
                else
                {
                    Console.WriteLine("Invalid furniture type entered. Please try again.");
                    i--;
                    continue;
                }
                Console.WriteLine($"Furniture #{i + 1} details accepted.");
                Console.WriteLine();
            }


        }
        static double TotalStockPrice(Furniture[] stock)
        {
            double totalStockValue = 0;



            for (int i = 0; i < stock.Length; i++)
            {
                totalStockValue += stock[i].price * stock[i].quantity;
            }



            return totalStockValue;
        }
        static int ShowStockDetails(Furniture[] stock)
        {
            int i = 0;
            foreach (Furniture f in stock)
            {
                Console.WriteLine($"Furniture details {++i}:");
                f.Display();
                Console.WriteLine("----------------------------------------------------------------");
            }
            return 1;
        }
        static void Main(string[] args)
        {
            Furniture[] stock = new Furniture[2];



            while (true)
            {
                Console.WriteLine("1:Accept Stock Details");
                Console.WriteLine("2:Display Total Stock Value");
                Console.WriteLine("3: Show all Stock Details");
                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());



                switch (choice)
                {
                    case 1:
                        AcceptStockdetails(stock);
                        break;
                    case 2:
                        Console.WriteLine($"Total Stock Value = {TotalStockPrice(stock)}");
                        break;
                    case 3:
                        Console.WriteLine(ShowStockDetails(stock));
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
