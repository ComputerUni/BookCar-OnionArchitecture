using Microsoft.AspNetCore.SignalR;
using System.Text.Json.Serialization;

namespace CarBook.WebApi.Hubs
{
    public class CarHub(IHttpClientFactory _httpClientFactory) : Hub
    {
        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseCar = await client.GetAsync("https://localhost:7200/api/Statistics/GetCarCount");

            var value = await responseCar.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCarCount", value);


        }
    }
}
