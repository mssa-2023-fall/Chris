using Microsoft.AspNetCore.Identity;
using System;
using CustomerPasswordHashing;
using System.Security.Cryptography;

public class Program
{
    private static void Main(string[] args)
    {
        //Create the dictionary
        Dictionary<string, Customer> customerDictionary = new();
      
        //Create customers
        Customer customerOne = new("johndoe@gmail.com", "John", "password0", 1111222233334444);
        Customer customerTwo = new("janesmith@hotmail.com", "Jane", "password1", 1117222233335444);
        Customer customerThree = new("fred@gmail.com", "Fred", "password2", 2222333344445555);
        Customer customerFour = new("mikejohnson@yahoo.com", "Mike", "password3", 1781422233835432);
        
        //Generate password salt
        customerOne.GenerateSalt();
        customerTwo.GenerateSalt();
        customerThree.GenerateSalt();
        customerFour.GenerateSalt();

        //Generate hashed passwords
        customerOne.GeneratePasswordHash();
        customerTwo.GeneratePasswordHash();
        customerThree.GeneratePasswordHash();
        customerFour.GeneratePasswordHash();

        //Add customers to dictionary
        customerDictionary.Add(customerOne.Email, customerOne);
        customerDictionary.Add(customerTwo.Email, customerTwo);
        customerDictionary.Add(customerThree.Email, customerThree);
        customerDictionary.Add(customerFour.Email, customerFour);

        //Console prompts to collect email and password
        Console.WriteLine("Please enter your email:");
        var userEmail = Console.ReadLine();
        if (userEmail == null) Console.WriteLine("Please ender a valid email:");
        
        Console.WriteLine("\nPlease enter your password:");
        var userPassword = Console.ReadLine();
        if (userPassword == null) Console.WriteLine("Please ender a valid password:");

        Console.Clear();


        //Logic that takes the console provided email, assembles a temp customer with userEmail and userPassword
        //Then searches the customer dictionary for a matching email.
        //Then generates a hashed password using the original salt with the console provided user password
        //If the password hashes match, access is granted. If they don't match, "incorrect password"
        //If the email is not found, "Access denied"
        if (customerDictionary.TryGetValue(userEmail, out Customer customerIsInDictionary))
        {
            byte[] storedSalt = customerIsInDictionary.Salt;
            Customer tempCustomer = new Customer(userEmail, "", userPassword, 0)
            {
                Salt = storedSalt
            };

            tempCustomer.GeneratePasswordHash();

            if (customerIsInDictionary.PasswordHash == tempCustomer.PasswordHash)
            {
                Console.WriteLine("Access granted.");
            }
            else
            {
                Console.WriteLine("Incorrect password.");
            }
        }
        else
        {
            Console.WriteLine("Access denied.");
        }
    }
}