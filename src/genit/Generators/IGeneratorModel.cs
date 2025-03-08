using Dyvenix.Genit.Models;

namespace Dyvenix.Genit.Generators;

public interface IGeneratorModel
{
	string Name { get; }
	void Run(DbContextModel dbContextMdl);
}
