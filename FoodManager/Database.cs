using FoodManager.Entities;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FoodManager
{
    public static class Database
    {
        public static List<Food> Foods { get; set; }
        public static List<Recipe> Recipes { get; set; }
        public static List<Unit> Units { get; set; }
        public static List<OwnedFood> OwnedFoods { get; set; }

        public static void SaveFoods() => Save(Consts.FoodFile, Foods);
        public static void SaveRecipes() => Save(Consts.RecipeFile, Recipes);
        public static void SaveUnits() => Save(Consts.UnitFile, Units);
        public static void SaveOwnedFoods() => Save(Consts.OwnedFoodFile, OwnedFoods);

        public static void LoadAll()
        {
            Foods = Load<List<Food>>(Consts.FoodFile) ?? new List<Food>();
            Recipes = Load<List<Recipe>>(Consts.RecipeFile) ?? new List<Recipe>();
            Units = Load<List<Unit>>(Consts.UnitFile) ?? new List<Unit>();
            OwnedFoods = Load<List<OwnedFood>>(Consts.OwnedFoodFile) ?? new List<OwnedFood>();
        }

        static void Save(string fileName, object data)
        {
            string pathFile = Path.Combine(Consts.SaveFolder, fileName);
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(pathFile, json);
        }

        static T Load<T>(string fileName)
        {
            string pathFile = Path.Combine(Consts.SaveFolder, fileName);
            if (!File.Exists(pathFile))
                return default;
            string text = File.ReadAllText(pathFile);
            return JsonSerializer.Deserialize<T>(text);
        }
    }
}
