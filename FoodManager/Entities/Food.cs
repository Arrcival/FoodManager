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

        public decimal? PricePerUnit { get; set; }
        public decimal? WeightPerUnit { get; set; }
        public bool PriceAccurate { get; set; }

        public decimal? PricePerKg { get; set; }

        [JsonIgnore]
        bool _loaded = false;

        [JsonIgnore]
        public decimal Price
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

        public Food() { }

        public Food(string name, Unit unit, decimal? price, decimal? weight, bool accurate, decimal? priceKg)
        {
            Id = Database.GetNextFoodId();
            Name = name;
            Unit = unit;
            UnitId = Unit.UnitId;
            PricePerUnit = price != 0 ? price : null;
            WeightPerUnit = weight != 0 ? weight : null;
            PriceAccurate = accurate;
            PricePerKg = priceKg != 0 ? priceKg : null;
            _loaded = true;
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
