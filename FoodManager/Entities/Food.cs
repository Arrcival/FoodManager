using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace FoodManager.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int UnitId { get; set; }

        [JsonIgnore]
        public Unit Unit;

        public double? PricePerUnit { get; set; }
        public double? WeightPerUnit { get; set; }
        public bool PriceAccurate { get; set; }

        public double? PricePerKg { get; set; }

        [JsonIgnore]
        bool _loaded = false;

        [JsonIgnore]
        public double Price
        {
            get
            {
                if (PricePerUnit != null) return PricePerUnit.Value;
                else if (PricePerKg != null && WeightPerUnit != null)
                {
                    return WeightPerUnit.Value / 1000 * PricePerKg.Value;
                }
                return 0;
            }
        }

        [JsonIgnore]
        public string DisplayUnit => _loaded ? Unit.NameUnit : string.Empty;


        public Food(string name)
        {
            Name = name;
        }

        public void Load()
        {
            if(!_loaded)
            {
                Unit = Database.Units.FirstOrDefault(u => u.UnitId == UnitId);
                _loaded = true;
            }
        }
    }
}
