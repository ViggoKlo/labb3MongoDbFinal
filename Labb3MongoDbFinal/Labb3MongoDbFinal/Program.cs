using DataAccess.Managers;
using DataAccess.Models;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.Text;

CartManager cartManager = new CartManager();
CustomerManager customerManager = new CustomerManager();

Customer currentCustomer = new Customer();

Cart currentCart = new Cart();

while (true)
{
    Console.WriteLine("Welcome! Press '1' to log in or '2' to create an account");

    ConsoleKeyInfo newOrLogin = Console.ReadKey();

    Console.Clear();

    if(newOrLogin.KeyChar.ToString() == "1")
    {
        Console.WriteLine("please enter your username");

        string UName = Console.ReadLine();

        Console.Clear();

        Console.WriteLine("please enter your password");

        string Pass = Console.ReadLine();

        Console.Clear();

        currentCustomer = customerManager.GetByUsernameAndPassword(UName, Pass);

        if (currentCustomer == null)
        {
            Console.WriteLine("Wrong username or password");

            continue;
        }
        else
        {
            Console.WriteLine("Logged in as:");

            Console.WriteLine(currentCustomer.Username);

            

            currentCart = cartManager.GetById(currentCustomer.Id);
        }
    }
    else
    {
        Console.WriteLine("please enter a username");

        string UName = Console.ReadLine();

        Console.Clear();

        Console.WriteLine("please enter a password");

        string Pass = Console.ReadLine();

        Console.Clear();

        currentCustomer.Id = Guid.NewGuid();
        currentCustomer.Username = UName;
        currentCustomer.Password = Pass;

        

        currentCart.CustomerId = currentCustomer.Id;

        cartManager.add(currentCart);

        customerManager.add(currentCustomer);
    }

    while (true)
    {
        Console.WriteLine("Press '1' to shop, '2' to see your cart, '3' to check out and empty your cart, or any other key to log out");

        ConsoleKeyInfo seeCartShopOrCheckout = Console.ReadKey();

        Console.Clear();

        if (seeCartShopOrCheckout.KeyChar == '1')
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the store! Press '1' to buy sausages (20 kr each), '2' to buy bread (15 kr each),'3' to buy ketchup (25 kr each), or any other key to cancel");

                ConsoleKeyInfo whatBuy = Console.ReadKey();

                Console.Clear();

                if (whatBuy.KeyChar.ToString() == "1")
                {
                    while (true)
                    {
                        Console.WriteLine("How many?");

                        string amountSausage = Console.ReadLine();

                        if (Regex.IsMatch(amountSausage, @"^\d+$") && amountSausage != null)
                        {
                            currentCart.SausageAmount += int.Parse(amountSausage);

                            cartManager.update(currentCart);

                            break;
                        }
                        else
                        {
                            Console.Clear();

                            Console.WriteLine("Invalid input, please only use numbers");

                            Console.WriteLine(" ");

                            continue;
                        }
                    }
                }
                else if (whatBuy.KeyChar.ToString() == "2")
                {
                    while (true)
                    {
                        Console.WriteLine("How many?");

                        string amountBread = Console.ReadLine();

                        if (Regex.IsMatch(amountBread, @"^\d+$") && amountBread != null)
                        {
                            currentCart.BreadAmount += int.Parse(amountBread);

                            cartManager.update(currentCart);

                            break;
                        }
                        else
                        {
                            Console.Clear();

                            Console.WriteLine("Invalid input, please only use numbers");

                            Console.WriteLine(" ");

                            continue;
                        }
                    }
                }
                else if (whatBuy.KeyChar.ToString() == "3")
                {
                    while (true)
                    {
                        Console.WriteLine("How many?");

                        string amountKetchup = Console.ReadLine();

                        if (Regex.IsMatch(amountKetchup, @"^\d+$") && amountKetchup != null)
                        {
                            currentCart.KetchupAmount += int.Parse(amountKetchup);

                            cartManager.update(currentCart);

                            break;
                        }
                        else
                        {
                            Console.Clear();

                            Console.WriteLine("Invalid input, please only use numbers");

                            Console.WriteLine(" ");

                            continue;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }
        else if (seeCartShopOrCheckout.KeyChar == '2')
        {
            Console.WriteLine("Sausage (20kr each):");
            Console.WriteLine(currentCart.SausageAmount);
            Console.WriteLine(" ");

            Console.WriteLine("Bread (15kr each:");
            Console.WriteLine(currentCart.BreadAmount);
            Console.WriteLine(" ");

            Console.WriteLine("Ketchup (25kr each):");
            Console.WriteLine(currentCart.KetchupAmount);
            Console.WriteLine(" ");

            int sausageTotal = currentCart.SausageAmount * 20;
            int breadTotal = currentCart.BreadAmount * 15;
            int ketchupTotal = currentCart.KetchupAmount * 25;

            Console.WriteLine("Total:");
            Console.Write(sausageTotal += breadTotal += ketchupTotal);
            Console.WriteLine("kr");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            Console.Clear();

            continue;
        }
        else if (seeCartShopOrCheckout.KeyChar == '3')
        {
            Console.Clear();

            Console.Write("Thank you for visiting the store! You owe:");

            int sausageTotal = currentCart.SausageAmount * 20;
            int breadTotal = currentCart.BreadAmount * 15;
            int ketchupTotal = currentCart.KetchupAmount * 25;

            Console.Write(sausageTotal += breadTotal += ketchupTotal);
            Console.WriteLine("kr");

            currentCart.SausageAmount = 0;

            currentCart.BreadAmount = 0;

            currentCart.KetchupAmount = 0;

            cartManager.update(currentCart);
        }

        else
        {
            break;
        }
    }

   

}







