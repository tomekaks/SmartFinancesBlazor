namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class PlannerVM
    {
        public YearlySummaryVM? YearlySummary { get; set; }
        public MonthlySummaryVM? CurrentMonthlySummary { get; set; }
        public List<ExpenseTypeVM> ExpenseTypes { get; set; } = new();
        public decimal Budget { get; set; }
        public decimal TotalAmount { get => GetTotalAmount(); }
        public decimal Saved { get => Budget - TotalAmount; }
        public decimal HousingAmount { get => GetTotalAmountByExpenseType(Constants.HOUSING); }
        public decimal UtilitiesAmount { get => GetTotalAmountByExpenseType(Constants.UTILITIES); }
        public decimal FoodAmount { get => GetTotalAmountByExpenseType(Constants.FOOD); }
        public decimal ClothesAmount { get => GetTotalAmountByExpenseType(Constants.CLOTHES); }
        public decimal HealthAmount { get => GetTotalAmountByExpenseType(Constants.HEALTH); }
        public decimal EntertainmentAmount { get => GetTotalAmountByExpenseType(Constants.ENTERTAINMENT); }
        public decimal ElectronicsAmount { get => GetTotalAmountByExpenseType(Constants.ELECTRONICS); }
        public decimal HouseholdAmount { get => GetTotalAmountByExpenseType(Constants.HOUSEHOLD); }
        public decimal TransportationAmount { get => GetTotalAmountByExpenseType(Constants.TRANSPORTATION); }
        public decimal PersonalAmount { get => GetTotalAmountByExpenseType(Constants.PERSONAL); }

        private decimal GetTotalAmount()
        {
            decimal totalAmount = 0;

            if (CurrentMonthlySummary.Expenses != null && CurrentMonthlySummary.Expenses.Count > 0)
            {    
                foreach (var item in CurrentMonthlySummary.Expenses)
                {
                    totalAmount += item.Amount;
                }
            }
            return totalAmount;
        }

        private decimal GetTotalAmountByExpenseType(string expenseType)
        {
            decimal amount = 0;
            var expenses = CurrentMonthlySummary.Expenses.FindAll(q => q.ExpenseTypeVM.Name == expenseType);

            if(expenses != null && expenses.Any())
            {
                foreach (var item in expenses)
                {
                    amount += item.Amount;
                }
            }

            return amount;
        }
    }
}
