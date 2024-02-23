using BUS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GUI.Controllers
{
    public class RoomController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public RoomController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> IndexAsync()
        {
            string link = "https://localhost:7280/api/Customers";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link))
                {
                        string jsonResult = await res.Content.ReadAsStringAsync();
                        var resoult = JsonConvert.DeserializeObject<List<Customer>>(jsonResult);
                        List<Customer> listCus = resoult;
                        return View(listCus);
                }
            }
        }
    }
}
