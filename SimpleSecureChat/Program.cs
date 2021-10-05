using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SimpleSecureChat.Server;

namespace SimpleSecureChat
{
    public class Program
    {
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			string port = args.Length > 0 ? port = args[0] : "80";
			return Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseUrls($"http://*:{port}").UseStartup<SimpleSecureChatServer>();
				});
		}
	}
}
