using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CustomerPasswordHashing
{
    public class Customer
    {
        public static Random random = new Random();
        //Everything public for initial build. Access modifiers can be fixed later.
        public string Email {  get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public double CreditCard { get; set; }
        public string PasswordHash { get; set; }

        public Customer(string email, string name, string password, double creditCard)
        {
            Email = email;
            Name = name;
            Password = password;
            CreditCard = creditCard;
        }

        public void GenerateSalt()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            Salt = new byte[Password.Length];

            for (int i = 0; i < Password.Length; i++)
            {
                Salt[i] = (byte)chars[random.Next(chars.Length)];
            }
        }

        public void GeneratePasswordHash()
        {
            const int keySize = 64;
            const int iterations = 350000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(Password),
                Salt,
                iterations,
                hashAlgorithm,
                keySize);
            PasswordHash = Convert.ToHexString(hash);
        }
    }
}