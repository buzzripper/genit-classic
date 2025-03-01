using System.Drawing;

namespace Dyvenix.Genit;

public class ErrorLevelDisplay
{
	public ErrorLevelDisplay(int imageIndex, string text, Color textColor)
	{
		ImageIndex = imageIndex;
		Text = text;
		TextColor = textColor;
	}

	public int ImageIndex { get; set; }
	public string Text { get; set; }
	public Color TextColor { get; set; }
}
