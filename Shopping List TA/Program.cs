//all items available
Dictionary<string, decimal> items = new Dictionary<string, decimal>();
items.Add("Apples", 1.99m);
items.Add("Cookies", 4.67m);
items.Add("Donuts", 12.00m);
items.Add("Peanut Butter", 3.99m);
items.Add("Almonds", 16.00m);
items.Add("Kale", 4.50m);
items.Add("Avocados", 6.00m);
items.Add("Bread", 3.99m);

bool runProgram = true;
//our shopping cart
Dictionary<string, decimal> shoppingCart = new Dictionary<string, decimal>();
Console.WriteLine("Welcome to Buy-A-Lot. Please buy a lot.");
while (runProgram)
{
    //ensure shopping cart empty at beginning of each loop.
    shoppingCart.Clear();

    //list all items
    Console.WriteLine(string.Format("{0,-15}{1,15}{2,15}","Index", "Item", "Price"));
    Console.WriteLine(string.Format("{0,-15}{1,15}{2,15}", "_____","____", "_____"));
    int num = 1;
    foreach (KeyValuePair<string,decimal> i in items.OrderByDescending(key => key.Value))
    {
        Console.WriteLine(string.Format("{0,-15}{1,15}{2,15}", num, i.Key, i.Value));
        num++;
    }

    //prompts user to choose items, adds to shopping carts and determines if they want to continue
    bool shopping = false;
   
    while(true)
    {
        Console.WriteLine("Would you like to use numbers to buy items?");
        shopping = Continue();
            break;

    }
    if (!shopping)
    {
        while (true)
        {
            while (true)
            {
                Console.WriteLine("Enter the name of the item you would like to purchase.");
                string response = Console.ReadLine().ToLower().Trim();
                if (items.Keys.Any(n => n.ToLower().Equals(response)))
                {
                    string i = items.Keys.First(i => i.ToLower().Equals(response));
                    shoppingCart.Add(i, items[i]);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid response. Please check spelling and use no letters or numbers.");
                }
            }
            
            Console.WriteLine("Would you like to buy a lot more? y/n");
            if (!Continue())
            {
                break;
            }
        }
    }
    if (shopping)
    {
        while (true)
        {
            int input = 0;
            while (true)
            {
                Console.WriteLine("Enter the number of the item you would like to purchase.");
                

                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine($"Please only enter a number between 1 and {items.Count}");
                }
                if (input < 1 || input > items.Count)
                {
                    Console.WriteLine($"Please only enter a number between 1 and {items.Count}");
                }
                else
                {
                    break;
                }
            }
            
            int itemNumber = input - 1;
            string item = items.OrderByDescending(key => key.Value).ElementAt(itemNumber).Key;
            shoppingCart.Add(item, items[item]);
            Console.WriteLine("Would you like to buy a lot more? y/n");
            if (!Continue())
            {
                break;
            }
        }
    }
    

    //show shopping cart
    //list all items
    Console.WriteLine(string.Format("{0,15}{1,15}", "Item", "Price"));
    Console.WriteLine(string.Format("{0,15}{1,15}", "____", "_____"));
    decimal total = 0;
    decimal max = decimal.MinValue;
    decimal min = decimal.MaxValue;
    string maxItem = "";
    string minItem = "";
    foreach (KeyValuePair<string, decimal> item in shoppingCart.OrderByDescending(key => key.Value))
    {
        Console.WriteLine(string.Format("{0,15}{1,15}", item.Key, item.Value));
        total += item.Value;

        if (item.Value>max)
        {
            max= item.Value;
            maxItem= item.Key;
        }
        if(item.Value < min)
        {
            min = item.Value;
            minItem= item.Key;
        }

    }
    Console.WriteLine($"Your total is {total}");
    Console.WriteLine($"Your most expensive items was {maxItem} at {max}");
    Console.WriteLine($"Your least expsenive item was {minItem} at {min}");

    Console.WriteLine("Would you like to buy a lot more? y/n");
    runProgram=Continue();
    if(!runProgram)
    {
        Console.WriteLine("Goodbye");
    }

}

static bool Continue()
{
    while (true)
    {
        string x = Console.ReadLine().ToLower().Trim();
        if (x == "y")
        {
            return true;
        }
        else if (x == "n")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Invalid response. Please try again. y/n");
        }
    }

}
