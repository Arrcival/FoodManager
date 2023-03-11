using System;
using System.Text.Json.Serialization;

namespace FoodManager.Entities
{
    public class OwnedFood
    {

        public string FoodID { get; set; }
                
        public DateTime PeremptionDate { get; set; }
        public double Amount { get; set; }

        [JsonIgnore]
        public Food Food { get; set; }

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
