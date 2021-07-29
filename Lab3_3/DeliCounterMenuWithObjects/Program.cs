using System;
using System.Collections.Generic;

namespace DeliCounterMenuWithObjects
{
    class MenuItem
    {
        public string name;
        public decimal price;
        public int quantity;

        public void Sell(int howMany)
        {
            quantity = quantity - howMany;
        }
    }

    class Program
    {
        static bool KeepGoing()
        {
            while (true)
            {
                Console.Write("\nContinue? (y/n): ");
                string response = Console.ReadLine();
                response = response.ToLower();

                if (response == "y" || response == "yes")
                {
                    return true;
                }
                else if (response == "n" || response == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("\nPlease enter y or n.");
                }
            }

        }

        static void Main(string[] args)
        {

            MenuItem item1 = new MenuItem();
            item1.name = "apple";
            item1.price = 2.0m;
            item1.quantity = 8;

            MenuItem item2 = new MenuItem();
            item2.name = "fig";
            item2.price = 3.6m;
            item2.quantity = 15;

            MenuItem item3 = new MenuItem();
            item3.name = "kiwi";
            item3.price = 4.85m;
            item3.quantity = 10;

            MenuItem item4 = new MenuItem();
            item4.name = "banana";
            item4.price = 1.36m;
            item4.quantity = 12;

            Dictionary<string, MenuItem> Items = new Dictionary<string, MenuItem>();
            Items[item1.name] = item1;
            Items[item2.name] = item2;
            Items[item3.name] = item3;
            Items[item4.name] = item4;

            Console.WriteLine("Deli Counter Menu");
            Console.WriteLine("\n\nItem\t\t\tPrice\t\t\tQuantity");
            Console.WriteLine("==============================================================");

            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Key}\t\t\t{item.Value.price}\t\t\t{item.Value.quantity}");
            }

            do
            {
                Console.WriteLine("\nEnter \"A\" for adding a new item.");
                Console.WriteLine("Enter \"R\" for removing an item.");
                Console.WriteLine("Enter \"C\" for changing an item.");
                Console.WriteLine("Enter \"S\" for selling an item(or multiple items).");
                Console.WriteLine("Enter \"Q\" to quit.");

                string choice = Console.ReadLine();
                choice = choice.ToUpper();

                while (choice != "A" && choice != "R" && choice != "C" && choice != "S" && choice != "Q")
                {
                    Console.WriteLine("\nPlease enter \"A\" or \"R\" or \"C\" or \"S\" or \"Q\"");
                    choice = Console.ReadLine();
                    choice = choice.ToUpper();
                }
                if (choice == "A")
                {
                    Console.Write("\nPlease enter the item name: ");
                    string itemName = Console.ReadLine();
                    itemName = itemName.ToLower();

                    bool itemExists = Items.ContainsKey(itemName);

                    while (itemExists)
                    {
                        Console.Write($"\n{itemName} already exists. Please enter some other item name: ");
                        itemName = Console.ReadLine();
                        itemName = itemName.ToLower();
                        itemExists = Items.ContainsKey(itemName);
                    }

                    Console.Write("\nPlease enter item price: ");
                    string priceString = Console.ReadLine();
                    decimal itemPrice;
                    decimal.TryParse(priceString, out itemPrice);

                    Console.Write("\nPlease enter the quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    MenuItem item5 = new MenuItem();
                    item5.name = itemName;
                    item5.price = itemPrice;
                    item5.quantity = quantity;

                    Items[item5.name] = item5;
                }
                else if (choice == "R")
                {
                    Console.Write("\nWhich item you want to remove?:");
                    string itemRem = Console.ReadLine();
                    itemRem = itemRem.ToLower();

                    bool itemExists = Items.ContainsKey(itemRem);

                    while (itemExists == false)
                    {
                        Console.Write($"\n{itemRem} does not exist. Please enter some other item name: ");
                        itemRem = Console.ReadLine();
                        itemRem = itemRem.ToLower();
                        itemExists = Items.ContainsKey(itemRem);
                    }

                    Items.Remove(itemRem);
                }
                else if (choice == "C")
                {
                    Console.Write("\nEnter the item name: ");
                    string itemName = Console.ReadLine();
                    itemName = itemName.ToLower();

                    Console.WriteLine($"\nCurrent price of {itemName} is ${Items[itemName].price}");
                    Console.Write($"\nEnter new price of {itemName}: ");

                    string stringPrice = Console.ReadLine();
                    decimal newPrice;
                    decimal.TryParse(stringPrice, out newPrice);

                    Items[itemName].price = newPrice;

                    Console.WriteLine($"\nCurrent quantity of {itemName} is {Items[itemName].quantity}");
                    Console.Write($"\nEnter new quantity of {itemName}: ");

                    int newQuantity = int.Parse(Console.ReadLine());

                    Items[itemName].quantity = newQuantity;

                }
                else if (choice == "S")
                {
                    Console.Write("\nWhich item you want to sell?");
                    string itemName = Console.ReadLine();


                    bool itemExists = Items.ContainsKey(itemName);

                    while (itemExists == false)
                    {
                        Console.Write($"\n{itemName} does not exist. Please enter some other item name: ");
                        itemName = Console.ReadLine();
                        itemName = itemName.ToLower();
                        itemExists = Items.ContainsKey(itemName);
                    }

                    Console.Write("\nEnter the quatity you want to sell: ");
                    int soldQuantity = int.Parse(Console.ReadLine());

                    


                   while (soldQuantity > Items[itemName].quantity)
                   {
                        Console.WriteLine($"\nSorry, available quantiy of {itemName} is just {Items[itemName].quantity}");
                        Console.Write("\nEnter the quatity you want to sell: ");
                         soldQuantity = int.Parse(Console.ReadLine());

                   }

                    Items[itemName].Sell(soldQuantity);

                }
                else
                {
                    Console.WriteLine("\nThank you!");

                }


                Console.WriteLine("\n\nItem\t\t\tPrice\t\t\tQuantity");
                Console.WriteLine("==============================================================");

                foreach (var item in Items)
                {
                    Console.WriteLine($"{item.Key}\t\t\t{item.Value.price}\t\t\t{item.Value.quantity}");
                }

            } while (KeepGoing() == true);

            Console.WriteLine("\n Goodbye!");

        }
    }
}
