using System.Linq;
using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.Generators;

public class IntTestGenerator
{
	#region Constants


	#endregion

	#region Properties

	public GeneratorType Type => GeneratorType.IntegrationTest;

	#endregion

	public void Run(DbContextModel dbContextMdl, string templatesFolderpath)
	{
		if (!dbContextMdl.Generators.IntTestsGen.Enabled)
			return;

		foreach (var entity in dbContextMdl.Entities.Where(e => e.Service.Enabled && e.Service.InclController)) {
			new ApiClientIntReadTestsGenerator().Run(entity, dbContextMdl, templatesFolderpath);
			new ApiClientIntUpdateTestsGenerator().Run(entity, dbContextMdl, templatesFolderpath);
		}
	}
}
