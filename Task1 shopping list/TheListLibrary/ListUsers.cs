using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheListLibrary
{
   public class ListUsers
    {
        public Dictionary<string, string> users = new Dictionary<string, string>();
        public string jsonUsers = "users.json";
        public string currentUser = "";
        public static string loggeduser;
        public  bool done = false;

        public void SignUp()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            if (users.ContainsKey(username))
            {

                Console.WriteLine("This username already exists. Please choose another one.");
                Console.WriteLine();



                return;
            }

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            users.Add(username, password);
         
            Console.WriteLine("Successfully signed up. Please log in.");
            done = true;
            isDone();

        }

        public void Login()
        {
            done = false;
            isDone();
            if (currentUser != "")
            {
                Console.WriteLine("You are already logged in as " + currentUser);
                return;
            }

            Console.Write("Enter your username: ");
            string us;
            loggeduser = Console.ReadLine();

            if (!users.ContainsKey(loggeduser))
            {
                Console.WriteLine("This username does not exist. Please try again.");
                Console.WriteLine();
                return;
            }

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (users[loggeduser] != password)
            {
                Console.WriteLine("Incorrect password. Please try again.");
                return;
            }

            currentUser = loggeduser;
            Console.WriteLine("Successfully logged in as " + currentUser);
            done = true;
            isDone();
        }


        public void LoadUsers()
        {
            if (File.Exists(jsonUsers))
            {
                string json = File.ReadAllText(jsonUsers);
                users = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
        }

        public void SaveUsers()
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(jsonUsers, json);
        }

        public bool isDone()
        {
            bool Isddone = done;
            return Isddone;
        }
    }
}
