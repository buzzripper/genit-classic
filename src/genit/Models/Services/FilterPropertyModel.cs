namespace Dyvenix.Genit.Models.Services;

public class UpdatePropertyModel
{
	public static UpdatePropertyModel CreateNew(PropertyModel property)
	{
		return new UpdatePropertyModel {
			Property = property
		};
	}

	#region Ctors / Init

	public UpdatePropertyModel()
	{
	}

	#endregion

	#region Properties

	public PropertyModel Property { get; set; }

	#endregion
}
