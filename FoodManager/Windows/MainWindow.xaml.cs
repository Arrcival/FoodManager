using FoodManager.Entities;
using FoodManager.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodManager.Windows
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DisplayStockageWindow stockageWindow = null;
        private AddStockageWindow addStockageWindow = null;
        private DisplayRecipeWindow displayRecipeWindow = null;
        private DisplayFoodWindow displayFoodWindow = null;

        public MainWindow()
        {
            InitializeComponent();
            DAL.Connect().GetAwaiter();
        }

        private void stockageButton_Click(object sender, RoutedEventArgs e)
        {
            stockageWindow?.Close();
            stockageWindow = new DisplayStockageWindow();
            stockageWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            stockageWindow?.Close();
            addStockageWindow?.Close();
        }

        private void coursesButton_Click(object sender, RoutedEventArgs e)
        {
            addStockageWindow?.Close();
            addStockageWindow = new AddStockageWindow(DAL.GetAllStockedFood().GetAwaiter().GetResult());
            addStockageWindow.Show();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            displayRecipeWindow?.Close();
            displayRecipeWindow = new DisplayRecipeWindow(DAL.GetAllRecipes().GetAwaiter().GetResult().First());
            displayRecipeWindow.Show();
        }

        private void displayFood_Click(object sender, RoutedEventArgs e)
        {
            displayFoodWindow?.Close();
            displayFoodWindow = new DisplayFoodWindow(DAL.GetAllFoods().GetAwaiter().GetResult());
            displayFoodWindow.Show();
        }
    }
}
