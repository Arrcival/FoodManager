using System.Windows;

namespace FoodManager.Windows
{
    /// <summary>
    /// Logique d'interaction pour DisplayStockageWindow.xaml
    /// </summary>
    public partial class DisplayFoodWindow : Window
    {
        public DisplayFoodWindow()
        {
            InitializeComponent();

            Database.Foods.ForEach(food => food.Load());

            dgFood.ItemsSource = Database.Foods;
        }
    }
}
