using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TheListLibrary;

namespace Shopping_List
{

    class program
    {
           static TheListLibrary.ListUsers us =new TheListLibrary.ListUsers();
        static TheListLibrary.Itemfunctionality item1= new TheListLibrary.Itemfunctionality();
        static ConsoleMenuelement[] menuElements = new ConsoleMenuelement[5];

        static void Main(string[] args)
        {

       

            display();

        }

        public static void display()
        {
     //      us.LoadUsers();
          menuElements[0] = new ConsoleMenuelement("Sign Up", signup);
            menuElements[1] = new ConsoleMenuelement("Login", login);
            ConsoleMenu consoleMenu = new ConsoleMenu("Welcome to E-Shopping List", menuElements);
            consoleMenu.RunMenu();
         
        }

        public static void ItemMenu()
        {
           //Array.Clear(menuElements, 0, menuElements.Length);
            menuElements[0] = new ConsoleMenuelement("Add Item", additem);
            menuElements[1] = new ConsoleMenuelement("Remove Item", removeitem);
            menuElements[2] = new ConsoleMenuelement("Update Item", updateitem);
            menuElements[3] = new ConsoleMenuelement("Mark as bought", done);
            menuElements[4] = new ConsoleMenuelement("View the list", viewlist);
            ConsoleMenu consoleMenu = new ConsoleMenu("Choose an option:", menuElements);
            consoleMenu.RunMenu();
        }
        public static void signup()
        {
           
            Console.Clear();
            us.LoadUsers();
            us.SignUp();
            us.SaveUsers();
          
            while(!us.isDone())
            {
                us.LoadUsers();
                us.SignUp();
                us.SaveUsers();
               
            }
            Array.Clear(menuElements, 0, menuElements.Length);
            menuElements[0] = new ConsoleMenuelement("Login", login);
            Console.Clear();

            ConsoleMenu consoleMenu = new ConsoleMenu("Sign up done login:", menuElements);
            consoleMenu.RunMenu();
           
        }
        public static void login()
        {
        //  Array.Clear(menuElements, 0, menuElements.Length);

            Console.Clear();
         us.LoadUsers();
            us.Login();

            while (!us.isDone())
            {
                us.LoadUsers();
                us.Login();
            }
            Thread.Sleep(2000);
            Console.Clear();
            ItemMenu();
        
        }

        public static void additem()
        {
            Console.Clear();
            item1.LoadShoppingList();
            item1.AddItem();
            while (!item1.IsDone())
            {
                item1.LoadShoppingList();
                item1.AddItem();
                item1.SaveShoppingList();

            }
            Console.WriteLine("");
          
            item1.SaveShoppingList();
            Thread.Sleep(2000);
            Console.Clear();
            ItemMenu();
        }


        public static void removeitem()
        {
            Console.Clear();
            item1.LoadShoppingList();
            item1.ViewShoppingList();
            item1.RemoveItem();
            while (!item1.IsDone())
            {
                item1.LoadShoppingList();
                item1.ViewShoppingList();  
                item1.RemoveItem();
                item1.SaveShoppingList();
            }
            Console.WriteLine("");
            item1.SaveShoppingList();
            Thread.Sleep(2000);
            Console.Clear();
            ItemMenu();
        }

        public static void updateitem()
        {
            Console.Clear();
            item1.LoadShoppingList();
            us.LoadUsers();
            item1.ViewShoppingList();
            item1.UpdateItem();
            while (!item1.IsDone())
            {
                item1.LoadShoppingList();
                us.LoadUsers();
                item1.ViewShoppingList();
                item1.UpdateItem();
            }
            item1.SaveShoppingList();
            Thread.Sleep(2000);
            Console.Clear();
            ItemMenu();
        }

        public static void done()
        {
            Console.Clear();
            item1.LoadShoppingList();
            item1.ViewShoppingList();
            item1.MarkAsDone();
            while (!item1.IsDone())
            {   
                item1.LoadShoppingList();
                    item1.ViewShoppingList();
                item1.MarkAsDone();
            }
            item1.SaveShoppingList();
            Thread.Sleep(2000);
            Console.Clear();
            ItemMenu();
        }

        public static void viewlist()
        {
            
            Console.Clear();
            item1.LoadShoppingList();
            item1.ViewShoppingList();
            Console.WriteLine();    
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Console.Clear();
            ItemMenu();
        }
    }
}
