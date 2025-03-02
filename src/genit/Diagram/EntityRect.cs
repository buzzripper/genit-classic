using Syncfusion.Windows.Forms.Diagram;
using System;
using System.Runtime.Serialization;

namespace Dyvenix.Genit.Diagram;


/// <summary>
/// Summary description for EntityRect
/// </summary>

[Serializable]
public class EntityRect : RoundRect
{
	#region Class Members
	private System.Drawing.Image titleImage = null;

	private string className = string.Empty;
	private string classType = string.Empty;
	private string objectType = string.Empty;

	Label lblClassName = new Label();
	Label lblClassType = new Label();
	Label lblObjectType = new Label();

	#endregion

	#region Class Properties

	public string ClassName
	{
		get { return lblClassName.Text; }
		set { lblClassName.Text = value; }
	}
	public string ClassType
	{
		get { return lblClassType.Text; }
		set { lblClassType.Text = value; }
	}
	public string ObjectType
	{
		get { return lblObjectType.Text; }
		set { lblObjectType.Text = value; }
	}

	public System.Drawing.Image TitleImage
	{
		get { return titleImage; }
		set { titleImage = value; }
	}

	#endregion

	#region Class Initialize/Finalize methods
	/// <summary>
	/// Initializes a new instance of the <see cref="Rectangle"/> class.
	/// </summary>
	/// <param name="x">X-coordinate of rectangle.</param>
	/// <param name="y">Y-coordinate of rectangle.</param>
	/// <param name="width">Width of rectangle.</param>
	/// <param name="height">Height of rectangle.</param>
	public EntityRect(float x, float y, float width, float height)
		: this(new System.Drawing.RectangleF(x, y, width, height))
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Rectangle"/> class.
	/// </summary>
	/// <param name="rcBounds">Rectangle containing position and size.</param>
	public EntityRect(System.Drawing.RectangleF rcBounds) : base(new System.Drawing.RectangleF(rcBounds.X, rcBounds.Y, rcBounds.Width, rcBounds.Height))
	{
		InitializeRectangle(rcBounds, MeasureUnits.Pixel);
	}

	public EntityRect(EntityRect src)
		: base(src)
	{
	}

	/// <summary>
	/// Serialization constructor for the ImageLabel class.
	/// </summary>
	/// <param name="info">Serialization state information</param>
	/// <param name="context">Streaming context information</param>
	protected EntityRect(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	private void InitializeRectangle(System.Drawing.RectangleF rectBounds, MeasureUnits measureUnits)
	{
		this.Labels.Add(lblClassName);
		lblClassName.FontStyle.Family = "Tahoma";
		lblClassName.FontStyle.Size = 9;
		lblClassName.FontStyle.Bold = true;
		lblClassName.OffsetX = 10;
		lblClassName.OffsetY = 5;
		lblClassName.ReadOnly = false;

		var label = new Label {
			Text = "PropertyOne"
		};
		this.Labels.Add(lblClassName);
	}

	#endregion

	#region Class Override Methods
	protected override void Render(System.Drawing.Graphics gfx)
	{
		base.Render(gfx);
		System.Drawing.Drawing2D.GraphicsState graph = gfx.Save();
		if (TitleImage != null) {
			gfx.DrawImage(TitleImage, (this.PinPoint.X - 25) + (this.Size.Width - this.PinPoint.X), 5, 17.5f, 17.5f);
		}
		gfx.Restore(graph);
	}
	#endregion
}