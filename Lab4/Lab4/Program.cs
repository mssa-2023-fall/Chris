
using System.Text;

internal class Program
{
    private static decimal GetPrice(string item)
    {
        switch (item)
        {
            case "Apple": return 1.99m;
            case "Banana": return 2.49m;
            case "Orange": return 0.99m;
            case "Peach": return 1.29m;
            case "Watermelon": return 3.99m;
            default: return 0m;
        }
    }

    //Capitalize the first letter of each item that the cashier enters. It looks nice on the receipt...
    private static string CapitalizeFirstLetter(string input)
    {
        if(string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input.Substring(1);
    }

    private static int Main(string[] args)
    {
        decimal subTotal = 0m;
        decimal taxRate = 0.075m;
        bool loyaltyCustomer;
        decimal memberDiscount = 0.05m;
        
        StringBuilder receipt = new StringBuilder();

        Console.WriteLine("Please enter the name of the item scanned."+"\n"+"When finished please press 'enter'.");

        while (true)
        {
            string cashierEntry = CapitalizeFirstLetter(Console.ReadLine().ToLower());
            if (string.IsNullOrEmpty(cashierEntry))
                break;


            decimal itemPrice = GetPrice(cashierEntry);

            if (itemPrice == 0m)
            {
                Console.WriteLine("Invalid item. Please enter a valid item.");
            }

            subTotal += itemPrice;
            receipt.AppendLine($"{"Qty: 1   " + cashierEntry,-20} {itemPrice,8:C2}");


        }
        decimal taxValue = Math.Round(decimal.Multiply(subTotal, taxRate),2);
        decimal totalPrice = subTotal + taxValue;
        decimal memberDiscountTotal = Math.Round(subTotal * memberDiscount, 2);

        Console.WriteLine("Is the customer a MOD4 loyalty rewards member? Press 'Y' for yes and 'N' for no.");
        string input2 = Console.ReadLine();
        if (input2 == "y" || input2  == "Y")
        {
            loyaltyCustomer = true;
            totalPrice -= totalPrice * memberDiscountTotal;
        }
        else
        {
            loyaltyCustomer = false;
        }

        //Console Output
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("Thank you for shopping at LAB4.");
        Console.WriteLine(DateTime.Now + "\n");
        Console.WriteLine(receipt.ToString() + "\n");
        Console.WriteLine($"{"Subtotal",-20} {subTotal,8:C2}");
        if (loyaltyCustomer)
        {
            Console.WriteLine($"{"5% Member Discount",-20} {"-$" + memberDiscountTotal,8:C2}");
        }
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"{"Tax @ 7.5%",-20} {taxValue,8:C2}");        
        Console.WriteLine($"{"Total",-20} {totalPrice,8:C2}");   
        Console.WriteLine("===============================");
        return 0;
    }
}