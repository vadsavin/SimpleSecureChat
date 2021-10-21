using SimpleSecureChatAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSecureChatAPI.Client
{
	public class BaseResponce
	{
		public HttpStatusCode StatusCode { get; set; }
		private string _json { get; set; }

		public BaseResponce(HttpStatusCode statusCode)
		{
			StatusCode = statusCode;
		}

		public BaseResponce(HttpStatusCode statusCode, string json)
		{
			StatusCode = statusCode;
			_json = json;
		}

		public T GetObject<T>() where T : JsonSerializable<T> //_json rerialization
		{
			if (string.IsNullOrEmpty(_json)) return null;

			return JsonSerializable<T>.Deserialize(_json);
		}
	}
}
