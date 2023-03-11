using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace FoodManager.Entities
{
    public class FoodRecipe
    {
        public int Id { get; set; }
        public int Amount { get; set; }


        [JsonIgnore]
        public Food Food { get; set; }

        public void Load()
        {
            Food = Database.Foods.First(food => food.Id == Id);
        }


        public string DisplayIngredient
        {
            get
            {
                Food.Load();
                return $"{Amount}{Food?.Unit?.DisplayedUnit} {Food?.Name}" + Environment.NewLine;
            }
        }
    }
}
