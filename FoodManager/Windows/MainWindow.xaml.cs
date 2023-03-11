using System.ComponentModel;
using System.Windows;

namespace FoodManager.Windows
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DisplayStockageWindow stockageWindow = null;
        //private AddStockageWindow addStockageWindow = null;
        private DisplayRecipeWindow displayRecipeWindow = null;
        private DisplayFoodWindow displayFoodWindow = null;

        public MainWindow()
        {
            InitializeComponent();
            Database.LoadAll();
        }

        private void stockageButton_Click(object sender, RoutedEventArgs e)
        {
            stockageWindow?.Close();
            stockageWindow = new DisplayStockageWindow();
            stockageWindow.Show();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            stockageWindow?.Close();
            //addStockageWindow?.Close();
        }

        private void coursesButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            addStockageWindow?.Close();
            addStockageWindow = new AddStockageWindow();
            addStockageWindow.Show();
            */
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            displayRecipeWindow?.Close();
            displayRecipeWindow = new DisplayRecipeWindow();
            displayRecipeWindow.Show();
            */
        }

        private void displayFood_Click(object sender, RoutedEventArgs e)
        {
            displayFoodWindow?.Close();
            displayFoodWindow = new DisplayFoodWindow();
            displayFoodWindow.Show();
        }
    }
}
