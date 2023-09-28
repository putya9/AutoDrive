using System;
using System.Collections.Generic;
using System.Text;

namespace AutoDrive
{
    public partial class Car
    {
        public string FullCar
        {
            get
            {
                string fullCar = manufacturer.manufacturerName + " " + model;
                return fullCar;
            }
        }
    }
}
