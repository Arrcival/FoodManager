using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManager.Entities
{
    [Collection("Recipe")]
    public class Recipe : Entity
    {
        public string Name { get; set; }
        public string Instructions { get; set; }

        public List<FoodRecipe> FoodList = new List<FoodRecipe>();
        public double Note { get; set; }
        public int Personnes { get; set; }
        public int CuissonTime { get; set; }
        public int PreparationTime { get; set; }
        public string Image { get; set; }
        public int TotalTime { get { return CuissonTime + PreparationTime; } }

        public string DisplayIngredients
        {
            get
            {
                string txt = "";
                if (FoodList != null)
                    foreach (FoodRecipe fr in FoodList)
                        txt += fr.DisplayIngredient;
                return txt;
            }        
        }

        public Recipe(string aName, string someInstructions, double aNote, int aPersonnes, int aCuisson, int aPreparation, string anURL)
        {
            Name = aName;
            Instructions = someInstructions;
            Note = aNote;
            Personnes = aPersonnes;
            CuissonTime = aCuisson;
            PreparationTime = aPreparation;
            Image = anURL;
        }
    }
}
