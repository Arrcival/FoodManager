using FoodManager.Entities;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

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
            DisplayRecipe();
        }


        public void DisplayRecipe()
        {
            if(recipe != null)
            {
                recipe.Load();

                Title += recipe.Name;
                recipeName.Text = recipe.Name;
                ingredientList.Text = recipe.DisplayIngredients;
                instructions.Text = string.Join(Environment.NewLine, recipe.Instructions);
            }
        }
    }
}
