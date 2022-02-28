using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManager.Entities
{
    [Collection("FoodRecipe")]
    public class FoodRecipe : Entity
    {
        [ObjectId]
        public string RecipeID { get; set; }
        public Recipe Recipe;

        [ObjectId]
        public string FoodID { get; set; }
        public Food Food;

        public double Amount { get; set; }

        public string DisplayIngredient
        {
            get
            {
                return $"{Amount}{Food?.Unit?.DisplayedUnit} {Food?.Name}" + Environment.NewLine;
            }
        }
    }
}
