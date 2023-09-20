﻿using System;

class Program
{
    static double purchasePrice;
    static double downPayment;
    static double marketValue;
    static double interestRate;
    static double monthlyInterestRate;
    static double yearlyHOAFees;
    static double monthlyIncome;
    static int loanTerm;
    static double loanInsurance;
    static double propertyTax;
    static double escrow;
    static double monthlyEscrow;
    static double homeOwnersInsurance;

    static void Main(string[] args)
    {
        AskForInput();
        double calcLoanAmount = CalculateLoanAmount();
        Console.WriteLine(calcLoanAmount);
        double monthlyPayment = CalculateMontlyPayment(calcLoanAmount, interestRate, loanTerm);
        Console.WriteLine(monthlyPayment);
        LoanStatus(monthlyPayment);
    }





    static void AskForInput()
    {
        //Step 1: Get Input from the loan officer
        Console.WriteLine("Enter the purchase price of the home:");
        purchasePrice = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the down payment from the buyer:");
        downPayment = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the market value:");
        marketValue = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the interest rate:");
        interestRate = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the yearly HOA fees:");
        yearlyHOAFees = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the buyer's monthly income:");
        monthlyIncome = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the loan term (15 or 30):");
        loanTerm = int.Parse(Console.ReadLine());
    }





    //Step 2: Calculate the total loan amount
    static double CalculateLoanAmount()
    {
        double originationFee = 0.01 * (purchasePrice - downPayment) + 2500;
        double totalLoanAmount = purchasePrice - downPayment + originationFee;

        //how much money "you have in the house" how much quap you have into the house
        double equity = marketValue - totalLoanAmount;



        if (equity < (marketValue * .1))
        {
            loanInsurance = 0.01 * totalLoanAmount;
        }
        else
        {
            //you do not pay loan insurance
            loanInsurance = 0;
        }

        return totalLoanAmount;
    }





    //Step 3: Calculate the monthly payment
    static double CalculateMontlyPayment(double localLoanAmount, double interest, int loanLength)
    {

        //include property tax
        double monthlyPayment = CalculateMortgage(localLoanAmount, interest, loanLength);
        propertyTax = marketValue * 0.0125 / 12;
        homeOwnersInsurance = marketValue * 0.0075 / 12;
        double monthlyHOA = yearlyHOAFees / 12;
        escrow = propertyTax + homeOwnersInsurance + monthlyHOA + loanInsurance;
        monthlyEscrow = escrow / 12;


        double totalMonthlyPayment = monthlyPayment + escrow;

        return totalMonthlyPayment;

    }





    static double CalculateMortgage(double principal, double rate, int term)
    {
        double r = (rate / 100) / 12;
        int n = 12 * term;
        return principal * (r) * Math.Pow(1 + r, n) / (Math.Pow(1 + r, n) - 1);
    }






    //Step 4: Loan approval/denial
    static bool LoanStatus(double monthlyPayment)
    {
        //loan is approved if the buyers monthly payment is greater than their monthly income * .25
        if (monthlyPayment <= monthlyIncome * .25)
        {
            Console.WriteLine("Loan Approved!");
            return true;
        }
        else
        {
            Console.WriteLine("Loan Denied, ur poor!");
            return false;
        }
    }
};
