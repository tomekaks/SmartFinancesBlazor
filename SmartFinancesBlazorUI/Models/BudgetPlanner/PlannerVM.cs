using SmartFinancesBlazorUI.Models.Enum;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class PlannerVM
    {
        public List<ExpenseDto> Expenses { get; set; } = new List<ExpenseDto>();
        public double Budget { get; set; }
        public double TotalAmount { get; set; }
        public double HousingAmount { get => GetTotalAmountByExpenseType(Constants.HOUSING); }
        public double UtilitiesAmount { get => GetTotalAmountByExpenseType(Constants.UTILITIES); }
        public double FoodAmount { get => GetTotalAmountByExpenseType(Constants.FOOD); }
        public double ClothesAmount { get => GetTotalAmountByExpenseType(Constants.CLOTHES); }
        public double HealthAmount { get => GetTotalAmountByExpenseType(Constants.HEALTH); }
        public double EntertainmentAmount { get => GetTotalAmountByExpenseType(Constants.ENTERTAINMENT); }
        public double ElectronicsAmount { get => GetTotalAmountByExpenseType(Constants.ELECTRONICS); }
        public double HouseholdAmount { get => GetTotalAmountByExpenseType(Constants.HOUSEHOLD); }
        public double TransportationAmount { get => GetTotalAmountByExpenseType(Constants.TRANSPORTATION); }
        public double PersonalAmount { get => GetTotalAmountByExpenseType(Constants.PERSONAL); }

        private void GetTotalAmount()
        {
            foreach (var item in Expenses)
            {
                TotalAmount += item.Amount;
            }
        }

        private double GetTotalAmountByExpenseType(string expenseType)
        {
            var expenses = Expenses.FindAll(q => q.Type == expenseType);
            double amount = 0;

            foreach (var item in expenses)
            {
                amount += item.Amount;
            }

            return amount;
        }
    }
}
