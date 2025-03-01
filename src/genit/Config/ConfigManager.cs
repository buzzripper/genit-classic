using System;
using System.IO;
using System.Text.Json;

namespace Dyvenix.Genit.Config;

internal static class ConfigManager
{
	private static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

	private const string cCompanyFoldername = "Dyvenix";
	private const string cConfigFileName = "GenIt.config";

	private static readonly string _configFolderpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), cCompanyFoldername);
	private static readonly string _configFilepath = Path.Combine(_configFolderpath, cConfigFileName);
	private static bool _isInitialized;

	internal static AppConfig GetAppConfig()
	{
		if (!_isInitialized) {
			if (!Directory.Exists(_configFolderpath)) {
				Directory.CreateDirectory(_configFolderpath);
			}
			_isInitialized = true;
		}

		if (!File.Exists(_configFilepath))
			return new AppConfig();

		var json = File.ReadAllText(_configFilepath);
		return JsonSerializer.Deserialize<AppConfig>(json);
	}

	internal static void SaveAppConfig(AppConfig appConfig)
	{

		var json = JsonSerializer.Serialize(appConfig, options: _jsonSerializerOptions);
		File.WriteAllText(_configFilepath, json);
	}
}
