namespace PlanCalculator
{
    public class PaymentPlan
    {
        public decimal DepositAmount { get; set; }

        public int NoOfInstallments { get; set; }

        public decimal InstallmentAmount { get; set; }

        public string InstallmentDates { get; set; }
    }
}