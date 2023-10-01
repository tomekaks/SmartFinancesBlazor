namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class PlannerVM
    {
        public PlannerVM()
        {
            GetTotalAmount();
        }

        public List<ExpenseVM> Expenses { get; set; } = new List<ExpenseVM>();
        public decimal Budget { get; set; }
        public decimal TotalAmount { get; set; }
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

        private void GetTotalAmount()
        {
            if (Expenses != null && Expenses.Count > 0)
            {
                foreach (var item in Expenses)
                {
                    TotalAmount += item.Amount;
                }
            }    
        }

        private decimal GetTotalAmountByExpenseType(string expenseType)
        {
            var expenses = Expenses.FindAll(q => q.ExpenseTypeVM.Name == expenseType);
            decimal amount = 0;

            foreach (var item in expenses)
            {
                amount += item.Amount;
            }

            return amount;
        }
    }
}
