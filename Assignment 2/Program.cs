using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDatabase();

            Console.WriteLine("\nDone. Press any key to exit...");
            Console.ReadKey();
        }

        // ===========================================================
        // 1. List all of the users
        // ===========================================================
        static List<Entities.User> ListAllUsers()
        {
            using (var context = new AppDBContext())
            {
                return context.Users.ToList();
            }
        }

        // ===========================================================
        // 2. Add a new User
        // ===========================================================
        static void AddUser(string firstName, string lastName, string email)
        {
            using (var context = new AppDBContext())
            {
                var newUser = new Entities.User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }

        // ===========================================================
        // 3. Update a User
        // ===========================================================
        static void UpdateUser(int id, string firstName, string lastName, string email)
        {
            using (var context = new AppDBContext())
            {
                var userToUpdate = context.Users.FirstOrDefault(u => u.Id == id);

                if (userToUpdate != null)
                {
                    userToUpdate.FirstName = firstName;
                    userToUpdate.LastName = lastName;
                    userToUpdate.Email = email;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"UpdateUser: no user found with Id {id}.");
                }
            }
        }

        // ===========================================================
        // 4. Delete a User
        // ===========================================================
        static void DeleteUser(int id)
        {
            using (var context = new AppDBContext())
            {
                var userToDelete = context.Users.FirstOrDefault(u => u.Id == id);

                if (userToDelete != null)
                {
                    context.Users.Remove(userToDelete);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"DeleteUser: no user found with Id {id}.");
                }
            }
        }

        // ---------------------------------------------------------
        // Helper used by TestDatabase to print the current list
        // ---------------------------------------------------------
        static void PrintAllUsers(string header)
        {
            Console.WriteLine($"\n--- {header} ---");
            List<Entities.User> users = ListAllUsers();

            if (users.Count == 0)
            {
                Console.WriteLine("(no users found)");
            }
            else
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.Id}, Name: {user.FirstName} {user.LastName}, Email: {user.Email}");
                }
            }
        }

        // ===========================================================
        // TestDatabase: calls each CRUD method, listing all users
        // after each one so the result of every operation is visible
        // ===========================================================
        static void TestDatabase()
        {
            PrintAllUsers("Initial list of users");

            // 1. List all users (already shown above)

            // 2. Add a new user, then list
            AddUser("John", "Smith", "john.smith@example.com");
            PrintAllUsers("Users after AddUser");

            // Grab the user we just added so we can update/delete it
            var addedUser = ListAllUsers().FirstOrDefault(u => u.Email == "john.smith@example.com");

            // 3. Update that user, then list
            if (addedUser != null)
            {
                UpdateUser(addedUser.Id, "Jonathan", "Smith-Updated", "jonathan.smith@example.com");
            }
            PrintAllUsers("Users after UpdateUser");

            // 4. Delete that user, then list
            if (addedUser != null)
            {
                DeleteUser(addedUser.Id);
            }
            PrintAllUsers("Users after DeleteUser");
        }
    }
}