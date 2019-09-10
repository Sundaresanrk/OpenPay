using System;
using System.Collections.Generic;

namespace PlanCalculator
{
    public class PaymentCalculator
    {
        public decimal PurchasePrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public List<PaymentPlan> CalculatePlanDetails()
        {
            List<PaymentPlan> paymentsPlans = new List<PaymentPlan>();

            if (PurchasePrice >= 100 && PurchasePrice < 1000)
            {
                paymentsPlans.Add(GetPaymentPlan(PurchasePrice, PurchaseDate, 20, 5, 15));
                paymentsPlans.Add(GetPaymentPlan(PurchasePrice, PurchaseDate, 30, 4, 15));
            }
            else if (PurchasePrice >= 1000 && PurchasePrice < 10000)
            {
                paymentsPlans.Add(GetPaymentPlan(PurchasePrice, PurchaseDate, 25, 4, 30));
            }

            return paymentsPlans;
        }

        private PaymentPlan GetPaymentPlan(decimal purchasePrice, DateTime purchaseDate, decimal installmentPercentage, int noOfInstallments, int installmentInterval)
        {
            PaymentPlan paymentPlan = new PaymentPlan();
            int toAddDays = installmentInterval;
            paymentPlan.DepositAmount = (installmentPercentage / 100) * purchasePrice;
            paymentPlan.NoOfInstallments = noOfInstallments;
            paymentPlan.InstallmentAmount = (purchasePrice - paymentPlan.DepositAmount) / paymentPlan.NoOfInstallments;
            for (int i = 0; i < paymentPlan.NoOfInstallments; i++)
            {
                paymentPlan.InstallmentDates = paymentPlan.InstallmentDates + "," + purchaseDate.AddDays(toAddDays).ToShortDateString();
                toAddDays = toAddDays + installmentInterval;
            }
            paymentPlan.InstallmentDates = paymentPlan.InstallmentDates.TrimStart(',');
            return paymentPlan;
        }
    }
}