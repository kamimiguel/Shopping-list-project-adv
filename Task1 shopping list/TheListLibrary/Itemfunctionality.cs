using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheListLibrary
{
   public class Itemfunctionality : ListUsers
    {
        public List<Item> shoppingList = new List<Item>();
        public string jsonFile = "shopping_list.json";
        public  bool Done = false;

        public void AddItem()
        {

            if (string.IsNullOrWhiteSpace(loggeduser))
            {
                Console.WriteLine("Please log in first to add items to the shopping list.");
                return;
            }

            Console.Write("Enter an Item name: ");
            string name = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(name)) // Avoid nullity
            {
                Console.WriteLine("Item name cannot be empty. Please try again.");
                return;
            }
            if (shoppingList.Exists(doesexists => doesexists.Name.Equals(name, StringComparison.OrdinalIgnoreCase))) //avoiding duplicate using any method through lamda
            {
                Console.WriteLine("Item is already in the shopping list. Please enter a different item name.");
                Console.WriteLine("");
                return;
            }

            Console.Write("Enter item quantity: ");
            string quantity;
            quantity = Console.ReadLine();
            if (quantity == "")
            {
                Console.WriteLine("Quantinty can't be null. Pleasetry again.");
                return;
            }

            Item item = new Item { Name = name, Quantity = quantity, Bought = false, Addedby = ListUsers.loggeduser };
            shoppingList.Add(item);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Successfully added " + name + " to the shopping list.");
            Done = true;
            IsDone();
        }

        public void RemoveItem()
        {
            if (string.IsNullOrWhiteSpace(loggeduser))
             {
                 Console.WriteLine("Please log in first to remove items from the shopping list.");
                 return;
            }
            

            Console.Write("Enter item name to remove: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                Item item = shoppingList.Find(i => i.Name == name);
                if (item != null)
                {
                   if (item.Addedby == loggeduser)
                   {
                        shoppingList.Remove(item);
                        Console.WriteLine("Successfully removed " + name + " from the shopping list.");
                        Done = true;
                        IsDone();
                   }

               }
                else
                {
                    Console.WriteLine("This item is not on your list. Try again");
                    Console.WriteLine();    
                   Done = false;
                    IsDone();
                }
            }
          
            else
            {
                Console.WriteLine("The field can't be left blank");
                Console.WriteLine();
                Done = false;
               IsDone();
            }
        }

        public void UpdateItem()
        {
            if (string.IsNullOrWhiteSpace(loggeduser))
            {
                Console.WriteLine("Please log in first to update items on the shopping list.");
                return;
            }

            Console.Write("Enter item name to update: ");
            string name = Console.ReadLine();
            Item item = shoppingList.Find(i => i.Name == name);
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (item != null)
                {
                    if (item.Addedby == loggeduser)
                    {
                        Console.Write("Enter new quantity: ");
                        string quantity;
                        quantity = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(quantity))
                        {

                            Console.WriteLine("Quantinty can't be null. Please try again.");
                            Done = false;
                            IsDone();
                        }
                        else
                        {
                            item.Quantity = quantity;
                            Console.WriteLine("Successfully updated " + name + " on the shopping list.");
                            Done = true;
                            IsDone();
                        }
                    }

                
                }
                else
                {
                    Console.WriteLine("This item is not on your list. Try again");
                    Done = false;
                    IsDone();
                }
            }
            else
            {
                Console.WriteLine("Item name can't be left blank");
                Done = false;
                IsDone();
            }
        }

        public void MarkAsDone()
        {
            if (string.IsNullOrWhiteSpace(loggeduser))
            {
                Console.WriteLine("Please log in first to mark items as done on the shopping list.");
                return;
            }

            Console.Write("Enter item name to mark as done: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                Item item = shoppingList.Find(i => i.Name == name);
                if (item != null)
                {
                    if (item.Addedby == loggeduser)
                    {
                        item.Bought = true;
                        Console.WriteLine("Successfully marked " + name + " as a bought item on the shopping list.");
                        Done = true;
                        IsDone();
                    }
                   

                }
                else
                {
                    Console.WriteLine("This item is not on your list. Try again");
                    Done = false;
                    IsDone();
                }
            }
            else
            {
                Console.WriteLine("Item name can't be left blank");
                Done = false;
                IsDone();
            }
        }

        public void ViewShoppingList()
        {
            if (string.IsNullOrWhiteSpace(loggeduser))
            {
                Console.WriteLine("Please log in first to view the shopping list.");
                return;
            }

            Console.WriteLine("Shopping List:");
            Console.WriteLine();
            foreach (var item in shoppingList)
            {

                if (item.Addedby == loggeduser)
                {
                    Console.WriteLine("- " + item.Name + "|" + "Quantity:" +" " + item.Quantity + "" + (item.Bought ? "|" + "(Bought)" : ""));
                    Done = true;
                    IsDone();
                }


            }
            if (!Done)
            {
                Done = false;
                IsDone();
                Console.WriteLine("No item to show");
                Console.WriteLine();
            }
        }
        public void LoadShoppingList()
        {
            if (File.Exists(jsonFile))
            {
                string json = File.ReadAllText(jsonFile);
                shoppingList = JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }

        public void SaveShoppingList()
        {
            string json = JsonConvert.SerializeObject(shoppingList);
            File.WriteAllText(jsonFile, json);
        }

        public bool IsDone()
        {
            bool Isddone = Done;
            return Isddone;
        }

    }
}
