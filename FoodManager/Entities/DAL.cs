using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodManager.Entities
{
    public static class DAL
    {
        public async static Task Connect()
        {
            /*var settings = MongoClientSettings.FromConnectionString("");
            MongoClient client = new MongoClient(settings);
            Database = client.GetDatabase("FoodDatabase");*/

            //await DB.InitAsync("FoodDatabase", MongoClientSettings.FromConnectionString());

            await DB.InitAsync("FoodDatabase", MongoClientSettings.FromConnectionString(ConfigurationManager.AppSettings["databaseString"]));
        }

        public async static Task<List<Food>> GetAllFoods()
        {
            return await DB
                .Queryable<Food>()
                .Join(
                    DB.Collection<FoodUnit>(),
                    f => f.UnitID,
                    unit => unit.ID,
                    (f, unit) => new Food(f.Name)
                    {
                        ID = f.ID,
                        UnitID = f.UnitID,
                        Unit = unit
                    })
                .ToListAsync();
        }
        public async static Task<List<StockedFood>> GetAllStockedFood()
        {
            return await DB
                .Queryable<StockedFood>()
                .Join(
                    DB.Collection<Food>(),
                    sf => sf.FoodID,
                    f => f.ID,
                    (sf, f) => new StockedFood
                    {
                        ID = sf.ID,
                        Amount = sf.Amount,
                        FoodID = f.ID,
                        Food = f,
                        PeremptionDate = sf.PeremptionDate
                    })
                .Join(
                    DB.Collection<FoodUnit>(),
                    sf => sf.Food.UnitID,
                    u => u.ID,
                    (sf, u) => new StockedFood
                    {
                        ID = sf.ID,
                        Amount = sf.Amount,
                        FoodID = sf.FoodID,
                        PeremptionDate = sf.PeremptionDate,
                        Food = new Food(sf.Food.Name)
                        {
                            ID = sf.Food.ID,
                            UnitID = sf.Food.UnitID,
                            Unit = u
                        }
                    })
                .ToListAsync();
        }

        public async static Task<List<Recipe>> GetAllRecipes()
        {
            return await DB
                .Queryable<Recipe>()
                .GroupJoin(
                    DB.Collection<FoodRecipe>(),
                    r => r.ID,
                    fr => fr.RecipeID,
                    (r, collection) => new Recipe(r.Name, r.Instructions, r.Note, r.Personnes, r.CuissonTime, r.PreparationTime, r.Image)
                    {
                        ID = r.ID,
                        FoodList = collection.ToList()
                    })
                .ToListAsync();
        }
    }
}
