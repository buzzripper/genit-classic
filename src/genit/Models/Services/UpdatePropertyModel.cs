namespace Dyvenix.Genit.Models.Services;

public class FilterPropertyModel
{
	public static FilterPropertyModel CreateNew(PropertyModel property, bool isOptional = false, bool isInternal = false)
	{
		return new FilterPropertyModel {
			Property = property,
			IsOptional = isOptional,
			IsInternal = isInternal
		};
	}

	#region Ctors / Init

	public FilterPropertyModel()
	{
	}

	#endregion

	#region Properties

	public PropertyModel Property { get; set; }
	public bool IsOptional { get; set; }
	public bool IsInternal { get; set; }
	public string InternalValue { get; set; }

	#endregion
}
