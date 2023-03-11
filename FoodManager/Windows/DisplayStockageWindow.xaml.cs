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
    public partial class DisplayStockageWindow : Window
    {
        public DisplayStockageWindow()
        {
            InitializeComponent();
            //AlimentDropdown();
            AlimentGrid();
        }

        /*
        private async void AlimentDropdown()
        {
            Task<List<Food>> foodTask = DAL.GetAllFoods();
            List<Food> foodList = await foodTask;

            foodDropdown.ItemsSource = foodList;
            foodDropdown.IsReadOnly = true;
        }*/

        private void AlimentGrid()
        {
            dgFood.ItemsSource = Database.OwnedFoods;


            /*
            var visibleList = new ObservableCollection<StockedFood>();

            for(int i = 0; i < foodList.Count; i++)
            {
                StockedFood sF = foodList[i];
                sF.FoodObject = await DAL.GetFoodFromId(sF.Food);
                sF.FoodObject.Unit = await DAL.GetUnitFromId(sF.FoodObject.FoodUnit);
                visibleList.Add(sF);
            }*/
        }

        /*private void addFoodText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Food food = foodDropdown.SelectedItem as Food;
        }*/
    }
}
