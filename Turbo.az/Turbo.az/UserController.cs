using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace structrecord
{
    public class UserController
    {
        private List<User> users = new List<User>();

        public void SignUp()
        {
            Console.Write("Enter a username: ");
            string username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }

            if (users.Exists(u => u.Username == username))
            {
                Console.WriteLine("Username is already taken. Try a different one.");
                return;
            }

            Console.Write("Enter a password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            if (password.Length < 6)
            {
                Console.WriteLine("Password should be at least 6 characters long.");
                return;
            }

            string passwordHash = HashPassword(password);
            users.Add(new User(username, passwordHash));
            Console.WriteLine("Sign Up successful. You can now sign in.");
        }

        public void SignIn()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            var user = users.Find(u => u.Username == username);

            if (user == null)
            {
                Console.WriteLine("Username not found.");
                return;
            }

            if (VerifyPassword(password, user.PasswordHash))
            {
                Console.WriteLine("Sign In successful.");
            }
            else
            {
                Console.WriteLine("Incorrect password.");
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword);
            return inputHash == storedHash;
        }
    }
}
