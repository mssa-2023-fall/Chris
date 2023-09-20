using System;
using System.Diagnostics;

class Program
{
    static double purchasePrice;
    static double appraisedValue;
    static double downPayment;
    static double interestRate;
    static double HOAYearly;
    static double loanTerm;
    static double monthlyIncome;
    static double loanAmount;
    static double propertyTax;
    static double monthlyPropertyTax;
    static double homeownersInsurance;
    static double monthlyHomeownersInsurance;
    static double equityTotal;
    static double monthlyPayment;
    static double HOAMonthly;
    static double monthlyPaymentWithEscrow;
    static bool approveLoan;
    static void Main(string[] args)
    {

        //Step 1: Get Input from the loan officer
        Console.WriteLine("Enter the purchase price of the home:");
        purchasePrice = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the appraised value of the home:");
        appraisedValue = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the down payment:");
        downPayment = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the interest rate (ex. 0.07 for 7%:");
        interestRate = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the annual HOA fee:");
        HOAYearly = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the loan term in years:");
        loanTerm = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter your monthly income:");
        monthlyIncome = double.Parse(Console.ReadLine());



        //Step 2: Calculate the total loan amount

        loanAmount = purchasePrice - downPayment + (purchasePrice * .01) + 2500;

        //Step 2: Determine PMI

        double equityTotal = appraisedValue - loanAmount;
        double equityPercentage = (equityTotal / appraisedValue) * 100;
        double PMIThreshold = 0.10 * appraisedValue;
        bool requiresHomeownersInsurance = equityTotal < PMIThreshold;


        //Step 3: Calculate excrow items

        //Property tax
        propertyTax = appraisedValue * 0.0125;
        monthlyPropertyTax = propertyTax / 12;

        //Homeowners insurance
        homeownersInsurance = appraisedValue * 0.0075;
        monthlyHomeownersInsurance = homeownersInsurance / 12;

        //HOA
        HOAMonthly = HOAYearly / 12;

        //Step 4: Calculate the monthly payment

        double numberOfPayments = (loanTerm * 12);
        double monthlyInterestRate = interestRate / 12;
        double monthlyPayment = (loanAmount * monthlyInterestRate) / (1 - Math.Pow(1 + monthlyInterestRate, -numberOfPayments));
        double monthlyPaymentWithEscrow = monthlyPayment + monthlyPropertyTax + monthlyHomeownersInsurance + HOAMonthly;


        //Step 4: Loan approval/denial
        bool approveLoan = (monthlyPayment / monthlyIncome) < 0.25;



        //output
        Console.WriteLine($"Total Loan Amount: {loanAmount:C}");
        Console.WriteLine($"Equity Percentage: {equityPercentage:F2}%");
        Console.WriteLine($"Monthly Payment: {monthlyPayment:C}");
        Console.WriteLine($"Monthly Payment with excrow: {monthlyPaymentWithEscrow:C}");

        if (requiresHomeownersInsurance)
            Console.WriteLine("Loan Insurance Required");

        if (approveLoan)
            Console.WriteLine("Loan Approved");
        else
            Console.WriteLine("Loan Denied. Idiot.");

        Console.ReadLine();
    }
};
