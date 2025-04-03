using System;
using System.Collections.Generic;
using c_sharp_apps_Masarwa_Shadi.SportApp;

namespace c_sharp_apps_Masarwa_Shadi.PokerGame.users
{
    public class Users
    {
        private List<User> users = new List<User>();
        public List<User> UsersList { get => users; set => users = value; }
        public void AddUser()
        {
            Screen.Clean();
            Console.WriteLine("Add User");
            Console.WriteLine("========");
            Console.Write("Enter User Name: ");
            string uName = Console.ReadLine();
            Console.WriteLine("Enter user role from menu (defalt player): ");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Player");
            Console.WriteLine("0. Cancel");
            Console.WriteLine("---------------");
            Console.Write("Enter Choice: ");
            char ch = Console.ReadKey().KeyChar;
            Console.WriteLine();
            User_Role role = User_Role.PLAYER; // Default role
            int choice = ch - 48;
            switch (choice)
            {
                case 1:
                    role = User_Role.ADMIN;
                    break;
                case 2:
                    role = User_Role.MANAGER;
                    break;
                case 3:
                    role = User_Role.PLAYER;
                    break;
            }
            User user = new User(uName, role);
            users.Add(user);
            Console.WriteLine();
            Console.WriteLine($"User (Name: {uName}, Role: {role}) added succesfuly!!!");
            Console.WriteLine($"{users.Count} users in system");
            Console.ReadKey();
        }
    }
}
