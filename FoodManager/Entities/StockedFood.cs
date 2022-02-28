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
    [Collection("StockedFood")]
    public class StockedFood : Entity
    {

        [ObjectId]
        public string FoodID { get; set; }

        
        public Food Food = null;
        public DateTime PeremptionDate { get; set; }
        public double Amount { get; set; }

        public string PeremptionDateDisplay { get { return PeremptionDate.ToString("dd/MM/yyyy"); } }
        public string DisplayQuantity
        {
            get
            {
                return Amount.ToString() + Food?.Unit?.DisplayedUnit; 
            }
        }

        public string Name
        {
            get
            {
                return Food?.Name;
            }
        }

        public string DisplayUnit { get { return Food?.Unit?.DisplayedUnit; } }


    }
}
