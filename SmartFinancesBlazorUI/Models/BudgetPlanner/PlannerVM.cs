using SmartFinancesBlazorUI.Models.Enum;

namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class PlannerVM
    {
        public List<ExpenseDto> Expenses { get; set; }
        public decimal Budget { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal HousingAmount { get => GetTotalAmountByExpenseType(ExpenseType.Housing); }
        public decimal UtilitiesAmount { get => GetTotalAmountByExpenseType(ExpenseType.Utilities); }
        public decimal FoodAmount { get => GetTotalAmountByExpenseType(ExpenseType.Food); }
        public decimal ClothesAmount { get => GetTotalAmountByExpenseType(ExpenseType.Clothes); }
        public decimal HealthAmount { get => GetTotalAmountByExpenseType(ExpenseType.Health); }
        public decimal EntertainmentAmount { get => GetTotalAmountByExpenseType(ExpenseType.Entertainment); }
        public decimal ElectronicsAmount { get => GetTotalAmountByExpenseType(ExpenseType.Electronics); }
        public decimal HouseholdAmount { get => GetTotalAmountByExpenseType(ExpenseType.Household); }
        public decimal TransportationAmount { get => GetTotalAmountByExpenseType(ExpenseType.Transportation); }
        public decimal PersonalAmount { get => GetTotalAmountByExpenseType(ExpenseType.Personal); }

        private void GetTotalAmount()
        {
            foreach (var item in Expenses)
            {
                TotalAmount += item.Amount;
            }
        }

        private decimal GetTotalAmountByExpenseType(ExpenseType expenseType)
        {
            var expenses = Expenses.FindAll(q => q.Type == expenseType);
            decimal amount = 0;

            foreach (var item in expenses)
            {
                amount += item.Amount;
            }

            return amount;
        }
    }
}
