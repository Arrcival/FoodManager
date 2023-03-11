using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FoodManager.Entities
{
    public class Recipe
    {
        public string Name { get; set; }
        public int Portions { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }


        public int PreparationTime { get; set; }
        public int CuissonTime { get; set; }

        public double Note { get; set; }

        public List<string> Instructions { get; set; }
        public List<FoodRecipe> Ingredients { get; set; }


        [JsonIgnore]
        public bool Loaded = false;

        [JsonIgnore]
        public int TotalTime { get { return CuissonTime + PreparationTime; } }

        public Recipe(string aName, List<string> someInstructions, double aNote, int portions, int aCuisson, int aPreparation, string anURL)
        {
            Name = aName;
            Instructions = someInstructions;
            Note = aNote;
            Portions = portions;
            CuissonTime = aCuisson;
            PreparationTime = aPreparation;
            Image = anURL;
        }

        public string DisplayIngredients
        {
            get
            {
                string txt = "";
                if (Ingredients != null && Loaded)
                    foreach (FoodRecipe fr in Ingredients)
                        txt += fr.DisplayIngredient;
                return txt;
            }
        }

        public void Load()
        {
            if(!Loaded)
            {
                foreach(var ingredient in Ingredients)
                {
                    ingredient.Load();
                }
                Loaded = true;
            }
        }
    }
}
