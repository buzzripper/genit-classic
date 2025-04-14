using System.Collections.ObjectModel;
using System.Linq;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Generators;

namespace Dyvenix.Genit.Generators;

public class IntTestGenerator
{
	#region Constants


	#endregion

	#region Properties

	public GeneratorType Type => GeneratorType.IntegrationTest;

	#endregion

	public void Run(IntTestsGenModel intTestsGenModel, ObservableCollection<EntityModel> entities, string templatesFolderpath)
	{
		if (!intTestsGenModel.Enabled)
			return;

		foreach (var entity in entities.Where(e => e.Service.Enabled && e.Service.InclController)) {
			new ApiClientIntReadTestsGenerator().Run(entity, intTestsGenModel, templatesFolderpath);
			new ApiClientIntUpdateTestsGenerator().Run(entity, intTestsGenModel, templatesFolderpath);
		}
	}
}
