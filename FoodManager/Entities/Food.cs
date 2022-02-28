using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManager.Entities
{
    [Collection("Food")]
    public class Food : Entity
    {
        public string Name { get; set; }

        [ObjectId]
        public string UnitID { get; set; }

        //[BsonIgnoreIfNull]
        public FoodUnit Unit;

        public double AveragePrice { get; set; }
        public string Image { get; set; }

        public Food(string name)
        {
            Name = name;
        }
    }
}
