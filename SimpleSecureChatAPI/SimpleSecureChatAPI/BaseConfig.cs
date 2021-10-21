using Newtonsoft.Json;
using SimpleSecureChatAPI.Utils;
using System.IO;

namespace Deployer.Utils
{
	public abstract class BaseConfig<T> : JsonSerializable<T> where T : BaseConfig<T>
	{
		[JsonIgnore]
		public string ConfigPath { get; private set; }
        public static JsonSerializerSettings CustomSettings { get; }

        static BaseConfig()
		{
			CustomSettings = new JsonSerializerSettings();
			CustomSettings.NullValueHandling = NullValueHandling.Ignore;
			CustomSettings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
			CustomSettings.MissingMemberHandling = MissingMemberHandling.Error;
			CustomSettings.Formatting = Formatting.Indented;
		}

		public static T Load(string path)
		{
			string json = File.ReadAllText(path);

			var config = Deserialize(json);
			config.ConfigPath = path;
			return config;
		}

		public void Save()
		{
			Save(ConfigPath);
		}

		public void Save(string path)
		{
			var json = Serialize();

			File.WriteAllText(path, json);
		}
	}
}
