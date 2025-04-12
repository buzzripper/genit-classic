
namespace Dyvenix.Genit.Models.Services;

public class UpdatePropertyModel
{
	public static UpdatePropertyModel CreateNew(PropertyModel property, bool isOptional)
	{
		return new UpdatePropertyModel {
			Property = property,
			IsOptional = isOptional
		};
	}

	#region Ctors / Init

	public UpdatePropertyModel()
	{
	}

	#endregion

	#region Properties

	public PropertyModel Property { get; set; }
	public bool IsOptional { get; set; }

	#endregion
}
