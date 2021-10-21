using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleSecureChatAPI.Client
{
	public class CallbackClient : IDisposable
	{
		public HttpClient Client { get; private set; }
		public Uri ServerUri { get; set; }

		public CallbackClient(Uri serverUri)
		{
			Client = new HttpClient();
			Client.Timeout = TimeSpan.FromMilliseconds(2000);

			ServerUri = serverUri;
		}

		/// <summary>
		/// Sends POST request to server.
		/// </summary>
		/// <param name="route">Route to send request on server.</param>
		/// <param name="data">Data to send.</param>
		/// <returns></returns>
		public async Task<HttpResponseMessage> CallPostAsync(string route, string data)
		{
			var content = new StringContent(data);
			return await Client.PostAsync(GetFullUri(route), content);
		}

		public async Task<HttpResponseMessage> CallPostAsync<T>(string route, T data)
		{
			JsonSerializerOptions options = new JsonSerializerOptions();
			options.Converters.Add(new JsonStringEnumConverter(null, false));

			var content = JsonContent.Create(data, null, options);

			await content.ReadAsStringAsync();

			return await Client.PostAsync(GetFullUri(route), content);
		}

		public async Task<HttpResponseMessage> CallGetAsync(string route)
		{
			return await Client.GetAsync(GetFullUri(route));
		}

		public async Task<BaseResponce> SendPostAsync(string route, string data)
		{
			var response = await CallPostAsync(route, data);

			return new BaseResponce(response.StatusCode);
		}

		public async Task<BaseResponce> SendPostAsync<T>(string route, T data)
		{
			var response = await CallPostAsync(route, data);

			return new BaseResponce(response.StatusCode);
		}

		public async Task<BaseResponce> SendGetAsync(string route, Dictionary<string, string> query = null)
		{
			var response = await Client.GetAsync(GetFullUri(route, query));
			string result = await response.Content.ReadAsStringAsync();

			return new BaseResponce(response.StatusCode, result);
		}

		private Uri GetFullUri(string route)
		{
			return new Uri(ServerUri, route);
		}

		private Uri GetFullUri(string route, Dictionary<string, string> query)
		{
			if (query == null) return GetFullUri(route);

			string queryString = QueryToString(query);
			string combinedRoute = CombineQueryInRoute(route, queryString);

			return new Uri(ServerUri, combinedRoute);
		}

		private string CombineQueryInRoute(string route, string query)
		{
			return $"{route}?{query}";
		}

		private string QueryToString(Dictionary<string, string> query) 
		{
			return string.Join("&", query.Select(value => $"{value.Key}={WebUtility.UrlEncode(value.Value)}"));
		}

		public void Dispose()
		{
			Client?.CancelPendingRequests();
			Client?.Dispose();
			Client = null;
		}
	}
}
