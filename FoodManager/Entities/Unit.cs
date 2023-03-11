namespace FoodManager.Entities
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string NameUnit { get; set; }
        public string DisplayedUnit { get; set; }

        public override string ToString()
        {
            return NameUnit;
        }
    }
}
