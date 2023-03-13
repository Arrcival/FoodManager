using FoodManager.Entities;
using System.Collections.Generic;
using System.Windows;

namespace FoodManager.Windows
{
    /// <summary>
    /// Logique d'interaction pour DisplayStockageWindow.xaml
    /// </summary>
    public partial class DisplayFoodWindow : Window
    {
        private AddFoodWindow addFoodWindow = null;
        private List<Food> Foods;

        public DisplayFoodWindow()
        {
            InitializeComponent();

            Database.Foods.ForEach(food => food.Load());

            Foods = Database.Foods;
            dgFood.ItemsSource = Foods;
        }


        private void addFood_Click(object sender, RoutedEventArgs e)
        {
            addFoodWindow?.Close();
            addFoodWindow = new AddFoodWindow(this);
            addFoodWindow.Show();
        }

        public void Refresh()
        {
            Foods = Database.Foods;
            dgFood.Items.Refresh();
        }
    }
}
