using System;
using System.Collections.Generic;

namespace PlanCalculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PaymentCalculator paymentCalculator = new PaymentCalculator();
            while (true)
            {
                Console.WriteLine("Please input the following details:");
                Console.WriteLine("Plese enter the Purchase Price:");

                var purchasePrice = Console.ReadLine();

                decimal price;

                if (decimal.TryParse(purchasePrice, out price))
                {
                    Console.WriteLine();
                    Console.WriteLine("Plese enter the Purchase Date in valid format eg.,'DD/MM/YYYY' format:");

                    var purchaseDate = Console.ReadLine();

                    DateTime date;
                    if (DateTime.TryParse(purchaseDate, out date))
                    {
                        paymentCalculator.PurchasePrice = price;
                        paymentCalculator.PurchaseDate = date;
                        var paymentDetails = paymentCalculator.CalculatePlanDetails();
                        DisplayPlanDetails(paymentDetails);
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid date.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid Purchase Price.");
                    Console.WriteLine();
                }
            }
        }

        private static void DisplayPlanDetails(List<PaymentPlan> paymentPlans)
        {
            Console.WriteLine();
            Console.WriteLine("*****************Payment Plans******************");

            if (paymentPlans != null && paymentPlans.Count > 0)
            {
                foreach (var item in paymentPlans)
                {
                    Console.WriteLine("Deposit Amount: {0}", item.DepositAmount);
                    Console.WriteLine("No. Of Installments: {0}", item.NoOfInstallments);
                    Console.WriteLine("Installment Amount: {0}", item.InstallmentAmount);
                    Console.WriteLine("Installment Dates: {0}", item.InstallmentDates);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Deposit Amount: {0}", "Plans not offered");
                Console.WriteLine("No. Of Installments: {0}", "Plans not offered");
                Console.WriteLine("Installment Amount: {0}", "Plans not offered");
                Console.WriteLine("Installment Dates: {0}", "Plans not offered");
                Console.WriteLine();
            }
            Console.WriteLine("********************End*********************");
            Console.WriteLine();
        }
    }
}