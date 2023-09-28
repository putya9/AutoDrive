using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace AutoDrive
{


    public class Rootobject
    {
        public Order[] Property1 { get; set; }
    }

    public partial class Order
    {
        public int orderId { get; set; }
        public int clientId { get; set; }
        public int carId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Car car { get; set; }
        public Client client { get; set; }
    }

    public partial class Car
    {
        public int carId { get; set; }
        public int manufacturerId { get; set; }
        public int categoryId { get; set; }
        public string model { get; set; }
        public int colorId { get; set; }
        public decimal priceForMinute { get; set; }
        public byte[] photo { get; set; }
        public string carNumber { get; set; }
        [JsonProperty("category")]
        public Category Idcategory { get; set; }
        public Color color { get; set; }
        public Manufacturer manufacturer { get; set; }
        [JsonIgnore]
        public ImageSource image { get => ImageSource.FromStream(() => new MemoryStream(photo)); }
    }

    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }

    public class Color
    {
        public int colorId { get; set; }
        public string colorName { get; set; }
    }

    public class Manufacturer
    {
        public int manufacturerId { get; set; }
        public string manufacturerName { get; set; }
    }

    public class Client
    {
        public int clientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string patronymic { get; set; }
        public string passport { get; set; }
        public string drivingLicense { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
    }


}
