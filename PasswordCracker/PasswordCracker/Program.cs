using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;

namespace Brute_Force
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter password:");
            string Password = Console.ReadLine();
            string Hash = MD5Hash(Password);

            Console.WriteLine("Password Hash: " + Hash);

            // string Password = "7e7f2d0ac2c4baf24ed0b7f71760e78e";
            string line = "";
            bool keepSearching = true;
            int counter = 0;
            int kounter = 0;
            Console.Title = "Current Password Count: 0k";

            StreamReader file = new StreamReader("rockyou.txt");
            while((line = file.ReadLine()) != null && keepSearching)
            {
                if (MD5Hash(line) == Hash)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(line);
                    Console.ResetColor();
                    MessageBox.Show("Done! " + line + "\n" + MD5Hash(line));
                    keepSearching = false;
                }
                else
                {
                    //Console.WriteLine(line);

                }
                counter++;
                if (counter >= 1000)
                {
                    kounter++;
                    counter = 0;
                    Console.Title = "Current Password Count: " + kounter + "k";
                }
            }
            file.Close();
            if (line == null)
                Console.WriteLine("Could not find password.");
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider MD5Provider = new MD5CryptoServiceProvider();
            byte[] bytes = MD5Provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i ++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}