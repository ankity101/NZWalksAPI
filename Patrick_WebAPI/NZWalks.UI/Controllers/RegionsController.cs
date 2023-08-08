using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.DTO;
using NZWalks.UI.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Reflection;


namespace NZWalks.UI.Controllers
{
	public class RegionsController : Controller
	{
		private readonly IHttpClientFactory httpClientFactory;

		public RegionsController(IHttpClientFactory httpClientFactory)
		{
			this.httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{

			List<RegionDto> response = new List<RegionDto>();
			try
			{
				HttpClientHandler clientHandler = new HttpClientHandler();
				clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
				HttpClient client = new HttpClient(clientHandler);
				//var client = httpClientFactory.CreateClient();

				var httpResponseMessage = await client.GetAsync("https://localhost:7185/api/Regions");

				httpResponseMessage.EnsureSuccessStatusCode(); // If not success it throws a exception.

				 response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());

				 

			}
			catch (Exception ex)
			{
				// 
				throw;
			}

			return View(response);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]

		public async Task<IActionResult> Add(AddRegionViewModel addRegionViewModel)
		{
            //var client = httpClientFactory.CreateClient();		

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var httpRequestMessage = new HttpRequestMessage()
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri("https://localhost:7185/api/Regions"),
				Content = new StringContent(JsonSerializer.Serialize(addRegionViewModel),Encoding.UTF8,	"application/Json")
			};
			var httpResponseMessage = await client.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

			var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();

			if (response is not null)
				return RedirectToAction("Index", "Regions");

			return View();
        }

		[HttpGet]

		public async Task<IActionResult> Edit(Guid id)
		{
            //var client = httpClientFactory.CreateClient();

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var response = await client.GetFromJsonAsync<RegionDto>($"https://localhost:7185/api/Regions/{id.ToString()}");

			if(response is not null)
			{
				return View(response);
			}
			return View(null);

		}

		[HttpPost]
		public async Task<IActionResult> Edit(RegionDto regionDto)
		{
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var httprequestMessage = new HttpRequestMessage()
			{
				Method = HttpMethod.Put,
				RequestUri = new Uri($"https://localhost:7185/api/Regions/{regionDto.Id}"),
				Content = new StringContent(JsonSerializer.Serialize(regionDto), Encoding.UTF8, "application/json")
			};

            var httpResponseMessage = await client.SendAsync(httprequestMessage);
			httpResponseMessage.EnsureSuccessStatusCode();

			var response = httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();
            
			if(response is not null)
			{
				return RedirectToAction("Edit", "Regions");
			}
			return View();

        }


		[HttpPost]
		public async Task<IActionResult> Delete(RegionDto request)
		{
            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var httpResponseMessage = await client.DeleteAsync($"https://localhost:7185/api/regions/{request.Id}");
		
				httpResponseMessage.EnsureSuccessStatusCode();

				return RedirectToAction("Index", "Regions");
        }
			 

        }
    }

	

