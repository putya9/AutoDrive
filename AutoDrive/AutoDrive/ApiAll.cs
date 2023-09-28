using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace AutoDrive
{
    public static class ApiAll
    {
        private static string BaseAdress = "http://192.168.27.7:5160/api/";
        public static async Task<Client> GetAuth(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(BaseAdress + "Users", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
                return JsonConvert.DeserializeObject<Client>(await response.Content.ReadAsStringAsync());
            }
        }
        public static async Task<List<Car>> GetCars()
        {
            using (HttpClient client = new HttpClient())
            {
                var data = await client.GetStringAsync(BaseAdress + "cars");
                return JsonConvert.DeserializeObject<List<Car>>(data);
            }
        }
        public static async Task<List<Client>> GetClient()
        {
            using (HttpClient client = new HttpClient())
            {
                var data = await client.GetStringAsync(BaseAdress + "Clients");
                return JsonConvert.DeserializeObject<List<Client>>(data);
            }
        }
        public static async Task<List<Order>> GetOrder()
        {
            using (HttpClient client = new HttpClient())
            {
                var data = await client.GetStringAsync(BaseAdress + "Orders");
                return JsonConvert.DeserializeObject<List<Order>>(data);
            }
        }
        public static async Task<List<Category>> GetCategory()
        {
            using (HttpClient client = new HttpClient())
            {
                var data = await client.GetStringAsync(BaseAdress + "Categories");
                return JsonConvert.DeserializeObject<List<Category>>(data);
            }
        }
        public static async Task<bool> PostClient(Client clientUser)
        {
            using( HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, BaseAdress + "Clients");
                string content = JsonConvert.SerializeObject(clientUser);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
        }
        public static async Task<bool> PostOrder(Order order)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, BaseAdress + "Orders");
                string content = JsonConvert.SerializeObject(order);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
        }
    }
}
