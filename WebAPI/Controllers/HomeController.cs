using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #region GET ALL
        public async Task<IActionResult> Index()
        {
            List<Client> clientsList = new List<Client>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62621/api/Client"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    clientsList = JsonConvert.DeserializeObject<List<Client>>(apiResponse);
                }
            }
            return View(clientsList);
        }
        #endregion

        #region GET BY ID
        public ViewResult GetClient() => View();

        [HttpPost]
        public async Task<IActionResult> GetClient(int id)
        {
            Client client = new Client();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62621/api/Client/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    client = JsonConvert.DeserializeObject<Client>(apiResponse);
                }
            }
            return View(client);
        }
        #endregion

        #region POST ADD
        public ViewResult AddClient() => View();

        [HttpPost]
        public async Task<IActionResult> AddClient(Client client)
        {
            if (!this.ModelState.IsValid)
            {
                Response.StatusCode = 400;
                ViewBag.SalvoComSucesso = false;
                return View(client);
            }
            else
            {
                Client receivedClient = new Client();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("http://localhost:62621/api/Client", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        receivedClient = JsonConvert.DeserializeObject<Client>(apiResponse);
                    }
                }
                ViewBag.SalvoComSucesso = true;
                return View(receivedClient);
            }
        }
        #endregion

        #region PUT UPDATE
        public async Task<IActionResult> UpdateClient(int id)
        {
            Client client = new Client();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:62621/api/Client/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    client = JsonConvert.DeserializeObject<Client>(apiResponse);
                }
            }
            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            if (!this.ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return View(client);
            }
            else
            {
                Client receivedClient = new Client();
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(client.Id.ToString()), "Id");
                    content.Add(new StringContent(client.Name), "Name");
                    content.Add(new StringContent(client.Email), "Email");
                    content.Add(new StringContent(client.Phone), "Phone");
                    //StringContent content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync("http://localhost:62621/api/Client", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        receivedClient = JsonConvert.DeserializeObject<Client>(apiResponse);
                    }
                }
                return View(receivedClient);
            }
        }
        #endregion

        #region DELETE
        [HttpPost]
        public async Task<IActionResult> DeleteClient(int ClientId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:62621/api/Client/" + ClientId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
        #endregion


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
