using FoodManager.Entities;
using System.Collections.Generic;
using System.Windows;

namespace FoodManager.Windows
{
    /// <summary>
    /// Logique d'interaction pour AddFoodWindow.xaml
    /// </summary>
    public partial class AddFoodWindow : Window
    {
        Recipe recipe;
        DisplayFoodWindow DisplayFoodWindow;

        #region Bindings
        public List<Unit> Units { get; set; }
        public Unit PickedUnit { get; set; }
        public string FoodName { get; set; }
        public decimal PricePerUnit { get; set; }
        public bool IsPriceAccurate { get; set; }
        public decimal WeightPerUnit { get; set; }
        public decimal PricePerKg { get; set; }
        #endregion

        public AddFoodWindow(DisplayFoodWindow foodWindow)
        {
            Units = Database.Units;
            InitializeComponent();
            DisplayFoodWindow = foodWindow;
        }
        private void addFood_Click(object sender, RoutedEventArgs e)
        {
            if(PickedUnit == null || string.IsNullOrEmpty(FoodName))
            {
                MessageBox.Show("You must have a name and an unit.");
                return;
            }

            var newFood = new Food(FoodName, PickedUnit, PricePerUnit, WeightPerUnit, IsPriceAccurate, PricePerKg);
            Database.Foods.Add(newFood);
            Database.SaveFoods();
            DisplayFoodWindow.Refresh();
            this.Close();
        }
    }
}
