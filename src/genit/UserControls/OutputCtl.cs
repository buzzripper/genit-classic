using Dyvenix.Genit.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls
{
	public partial class OutputCtl : UserControl
	{
		public OutputCtl()
		{
			InitializeComponent();
		}

		public void Clear()
		{
			grdItems.Rows.Clear();
		}

		public void WriteInfo(string message)
		{
			WriteOutput(ErrLevel.Info, message);
		}

		public void WriteWarn(string message)
		{
			WriteOutput(ErrLevel.Warn, message);
		}

		public void WriteError(string message)
		{
			WriteOutput(ErrLevel.Error, message);
		}

		public void WriteOutput(ErrLevel errorLevel, string message)
		{
			WriteOutput(new List<OutputItem> { new OutputItem { ErrorLevel = errorLevel, Message = message } });
		}

		public void WriteOutput(ErrLevel errorLevel, List<string> messages)
		{
			var outputItems = messages.Select(m => new OutputItem { ErrorLevel = errorLevel, Message = m }).ToList();
			WriteOutput(outputItems);
		}

		public void WriteOutput(OutputItem outputItem)
		{
			WriteOutput(new List<OutputItem> { outputItem });
		}

		public void WriteOutput(List<OutputItem> outputItems)
		{
			if (outputItems.Count == 0)
				return;

			grdItems.SuspendLayout();

			foreach (var outputItem in outputItems)
				grdItems.Rows.Add(outputItem.ErrorLevel, outputItem.Message);

			grdItems.FirstDisplayedScrollingRowIndex = grdItems.Rows.Count - 1;
			grdItems.ClearSelection();
			grdItems.ResumeLayout();
		}

		private void grdItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var message = grdItems.Rows[e.ColumnIndex].Cells[1].Value.ToString();
			Clipboard.SetText(message);
		}
	}
}
