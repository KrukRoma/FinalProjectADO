using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace FinalProjectADO.Net1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Menu menu = new Menu(); 

            while (true)
            {
                Console.WriteLine("Select an action:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        menu.RegisterUser();
                        break;
                    case "2":
                        menu.LoginUser();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

     

    }
}


