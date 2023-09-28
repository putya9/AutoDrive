using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoDrive
{
    public partial class Order
    {
        [JsonIgnore]
        public decimal FullCost
        {
            get
            {
                TimeSpan delta = endTime - startTime;
                decimal minutes = ((decimal)delta.TotalMinutes);
                return minutes * car.priceForMinute;
            }
        }
    }
}
