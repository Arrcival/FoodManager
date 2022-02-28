using FoodManager.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace FoodManager.Windows
{
    /// <summary>
    /// Logique d'interaction pour DisplayStockageWindow.xaml
    /// </summary>
    public partial class DisplayFoodWindow : Window
    {
        public DisplayFoodWindow(List<Food> foodList)
        {
            InitializeComponent();

            dgFood.ItemsSource = foodList;
        }
    }
}
