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
    /// Logique d'interaction pour DisplayRecipeWindow.xaml
    /// </summary>
    public partial class DisplayRecipeWindow : Window
    {
        Recipe recipe;
        public DisplayRecipeWindow(Recipe aRecipe)
        {
            InitializeComponent();
            recipe = aRecipe;
            if(recipe != null)
                DisplayRecipe();
        }


        public void DisplayRecipe()
        {
            if(recipe != null)
            {
                Title += recipe.Name;
                recipeName.Text = recipe.Name;
                recipeImage.Source = new BitmapImage(new Uri(recipe.Image));
                ingredientList.Text = recipe.DisplayIngredients;
                instructions.Text = recipe.Instructions;
            }
        }
    }
}
