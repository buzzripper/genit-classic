using System.Collections.Generic;

namespace Dyvenix.Genit.Models;

public class Doc
{
	public static Doc Instance { get; set; }

	public string Name { get; set; }
	public string Description { get; set; }
	public string Version { get; set; } = "1.0.0";

	public string ModelFilepath { get; set; }
	public List<DbContextModel> DbContexts { get; set; } = new List<DbContextModel>();

	public void Validate(List<string> errorList)
	{
		foreach (var dbContext in DbContexts)
			dbContext.Validate(errorList);
	}

	public void InitializeOnLoad()
	{
		foreach (var dbContext in DbContexts)
			dbContext.InitializeOnLoad();
	}
}
