using FoodManager.Entities;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour AddStockageWindow.xaml
    /// </summary>
    public partial class AddStockageWindow : Window
    {
        List<Food> foods = new List<Food>();
        int row = 0;
        public AddStockageWindow()
        {
            InitializeComponent();
            InitFoods();
        }

        public AddStockageWindow(List<StockedFood> listOfFood)
        {
            InitializeComponent();
            InitFromList(listOfFood);
            
        }

        public async void InitFromList(List<StockedFood> listOfFood)
        {
            foods = await DAL.GetAllFoods();
            for (int i = 0; i < listOfFood.Count; i++)
            {
                Grid grid = AddNewLine();
                ComboBox dropdown = grid.Children[0] as ComboBox;
                dropdown.ItemsSource = foods;
                dropdown.SelectedIndex = foods.FindIndex(p => p.ID == listOfFood[i].FoodID);
                DatePicker date = grid.Children[1] as DatePicker;
                date.Text = listOfFood[i].PeremptionDateDisplay;
                TextBox amountBox = grid.Children[2] as TextBox;
                amountBox.Text = listOfFood[i].Amount.ToString();
                TextBlock unit = grid.Children[3] as TextBlock;
                unit.Text = listOfFood[i].DisplayUnit;
            }
        }

        public async void InitFoods()
        {
            foods = await DAL.GetAllFoods();
            AddNewLine();
        }

        public Grid AddNewLine()
        {
            ControlTemplate ct = FindResource("hiddenField") as ControlTemplate;
            Border border = ct.LoadContent() as Border; row++;
            border.Name = "field" + row;
            Grid grid = border.Child as Grid;
            ComboBox dropdown = grid.Children[0] as ComboBox;
            dropdown.ItemsSource = foods;
            mainPanel.Children.Add(border);
            return grid;
        }
    }
}
