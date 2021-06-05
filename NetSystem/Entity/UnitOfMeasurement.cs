using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace NetSystem.Entity
{
    /// <summary>
    /// واحدهای اندازه گیری
    /// </summary>
    public class UnitOfMeasurement
    {

        public UnitOfMeasurement()
        {
            ConsumableParts = new HashSet<ConsumablePart>();
        }


        public int ID { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }


        public virtual ICollection<ConsumablePart> ConsumableParts { get; set; }
    }
}
