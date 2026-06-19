using System;
using System.Linq;

namespace Assignment2
{
    class Program
    {
        // Shared context used by all the CRUD methods below
        static AppDBContext context = new AppDBContext();

        static void Main(string[] args)
        {
            TestDatabase();

            Console.WriteLine("\nDone. Press any key to exit...");
            Console.ReadKey();
        }

        static void TestDatabase()
        {
            // List all users first
            ListAllUsers();

            // Add a new user
            AddUser();
            ListAllUsers();

            // Update a user
            UpdateUser();
            ListAllUsers();

            // Delete a user
            DeleteUser();
            ListAllUsers();
        }

        // 1. List all of the users
        static void ListAllUsers()
        {
            Console.WriteLine("\n--- All Users ---");
            var users = context.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.UserId}, Name: {user.Name}, Email: {user.EmailAddress}, Phone: {user.PhoneNumber}");
            }
        }

        // 2. Add a new User
        static void AddUser()
        {
            Console.WriteLine("\n--- Adding New User ---");
            var newUser = new User
            {
                Name = "David Brown",
                EmailAddress = "david@email.com",
                PhoneNumber = "555-4444"
            };

            context.Users.Add(newUser);
            context.SaveChanges();
            Console.WriteLine("User added!");
        }

        // 3. Update a User
        static void UpdateUser()
        {
            Console.WriteLine("\n--- Updating User ---");
            var user = context.Users.FirstOrDefault(u => u.Name == "David Brown");

            if (user != null)
            {
                user.PhoneNumber = "555-9999";
                context.SaveChanges();
                Console.WriteLine("User updated!");
            }
        }

        // 4. Delete a User
        static void DeleteUser()
        {
            Console.WriteLine("\n--- Deleting User ---");
            var user = context.Users.FirstOrDefault(u => u.Name == "David Brown");

            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                Console.WriteLine("User deleted!");
            }
        }
    }
}