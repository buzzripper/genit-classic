using System.Collections.Generic;

namespace Dyvenix.Genit.Models;

public class Doc
{
	#region Static

	public static Doc Instance { get; set; }

	public static Doc CreateNew()
	{
		var doc = new Doc();
		doc.DbContexts.Add(DbContextModel.CreateNew());

		return doc;
	}

	#endregion

	public string Name { get; set; }
	public string Description { get; set; }
	public string Version { get; set; } = "1.0.0";

	public string ModelFilepath { get; set; }
	public List<DbContextModel> DbContexts { get; set; } = new List<DbContextModel>();

	public Doc()
	{
	}

	public void Validate(List<string> errorList)
	{
		foreach (var dbContext in DbContexts)
			dbContext.Validate(errorList);
	}
}
