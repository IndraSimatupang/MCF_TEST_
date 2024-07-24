//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using WebApp.Models;

//namespace WebApp.Controllers
//{
//    public class BpkbController : Controller
//    {
//        private readonly IHttpClientFactory _clientFactory;

//        public BpkbController(IHttpClientFactory clientFactory)
//        {
//            _clientFactory = clientFactory;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var client = _clientFactory.CreateClient("WebApi");

//            var response = await client.GetAsync("api/bpkb");

//            if (response.IsSuccessStatusCode)
//            {
//                var responseStream = await response.Content.ReadAsStreamAsync();
//                var bpkbs = await JsonSerializer.DeserializeAsync<List<MvcServiceConfig>>(responseStream);

//                return View(bpkbs);
//            }
//            else
//            {
//                // Handle failure to fetch data
//                return View(new List<MvcServiceConfig>());
//            }
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(MvcServiceConfig model)
//        {
//            var client = _clientFactory.CreateClient("WebApi");

//            var json = JsonSerializer.Serialize(model);
//            var content = new StringContent(json, Encoding.UTF8, "application/json");

//            var response = await client.PostAsync("api/bpkb", content);

//            if (response.IsSuccessStatusCode)
//            {
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                // Handle failure to create Bpkb
//                ModelState.AddModelError(string.Empty, "Failed to create Bpkb");
//                return View(model);
//            }
//        }

//        public async Task<IActionResult> Edit(string id)
//        {
//            var client = _clientFactory.CreateClient("WebApi");

//            var response = await client.GetAsync($"api/bpkb/{id}");

//            if (response.IsSuccessStatusCode)
//            {
//                var responseStream = await response.Content.ReadAsStreamAsync();
//                var bpkb = await JsonSerializer.DeserializeAsync<MvcServiceConfig>(responseStream);

//                return View(bpkb);
//            }
//            else
//            {
//                // Handle failure to fetch Bpkb for editing
//                return RedirectToAction("Index");
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(string id, MvcServiceConfig model)
//        {
//            var client = _clientFactory.CreateClient("WebApi");

//            var json = JsonSerializer.Serialize(model);
//            var content = new StringContent(json, Encoding.UTF8, "application/json");

//            var response = await client.PutAsync($"api/bpkb/{id}", content);

//            if (response.IsSuccessStatusCode)
//            {
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                // Handle failure to update Bpkb
//                ModelState.AddModelError(string.Empty, "Failed to update Bpkb");
//                return View(model);
//            }
//        }

//        public async Task<IActionResult> Delete(string id)
//        {
//            var client = _clientFactory.CreateClient("WebApi");

//            var response = await client.DeleteAsync($"api/bpkb/{id}");

//            if (response.IsSuccessStatusCode)
//            {
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                // Handle failure to delete Bpkb
//                return RedirectToAction("Index");
//            }
//        }
//    }
//}
