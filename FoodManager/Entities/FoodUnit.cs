using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManager.Entities
{
    [Collection("Unit")]
    public class FoodUnit : Entity
    {

        public string NameUnit { get; set; }
        public string DisplayedUnit { get; set; }
        public bool LeftHandle { get; set; }

        public override string ToString()
        {
            return DisplayedUnit;
        }
    }
}
