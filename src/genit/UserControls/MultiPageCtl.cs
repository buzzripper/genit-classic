using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class MultiPageCtl : UserControl
{
	public event EventHandler<SelectedItemChangedEventArgs> SelectedItemChangedEventArgs;
	public event EventHandler<SelectedItemChangedEventArgs> SelectedItemChanged;

	#region Fields

	private readonly List<MultiPageItem> _items = new List<MultiPageItem>();

	#endregion

	#region Ctors / Init

	public MultiPageCtl()
	{
		InitializeComponent();
	}

	private void MultiPageCtl_Load(object sender, EventArgs e)
	{
	}

	#endregion

	#region Properties

	private MultiPageItem _selectedItem;
	private MultiPageItem SelectedItem
	{
		get { return _selectedItem; }
		set {
			_selectedItem = value;
			btnCloseItem.Enabled = value != null;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string Title
	{
		get {
			return tbTitle.Text;
		}
		set {
			tbTitle.Text = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int TitlePadding
	{
		get { return tbTitle.Padding.Left; }
		set { tbTitle.Padding = new Padding(0, 0, value, 0); }
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ButtonsHeight
	{
		get { return toolStrip.Height; }
		set { toolStrip.Height = value; }
	}

	//[Browsable(false)]
	public Guid? SelectedId { get { return SelectedItem?.Id; } }

	#endregion

	#region UI Events

	private void Btn_Click(object sender, EventArgs e)
	{
		var btn = sender as ToolStripButton;
		if (btn != null) {
			var mpItem = btn.Tag as MultiPageItem;
			if (mpItem != null)
				Select((MultiPageItem)btn.Tag);
		}
	}

	private void MultiButton_SizeChanged(object sender, EventArgs e)
	{
	}

	#endregion

	public int Add(Guid id, string text, Control control)
	{
		var btn = new ToolStripButton();
		btn.Text = text;
		btn.Padding = new Padding(5, 0, 5, 0);
		btn.Click += Btn_Click;

		var mpItem = new MultiPageItem(id, btn, control);
		_items.Add(mpItem);

		btn.Tag = mpItem;

		AddControl(control);

		var newIdx = toolStrip.Items.Add(btn);
		return newIdx;
	}

	private void AddControl(Control control)
	{
		control.Top = toolStrip.Height;
		control.Left = 0;
		control.Width = this.Width;
		control.Height = this.Height - toolStrip.Height;
		control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
		this.Controls.Add(control);
	}

	public bool Select(Guid id)
	{
		var item = _items.FirstOrDefault(x => x.Id == id);
		if (item != null) {
			Select(item);
			return true;
		} else {
			return false;
		}
	}

	private void Select(MultiPageItem multiPageItem)
	{
		if (multiPageItem == SelectedItem)
			return;

		this.SuspendLayout();

		foreach (var item in _items) {
			if (item == multiPageItem) {
				item.Ctl.Visible = true;
				item.Button.BackColor = SystemColors.ActiveCaption;
				SelectedItem = multiPageItem;

			} else {
				item.Ctl.Visible = false;
				item.Button.BackColor = Color.Transparent;
			}
		}

		this.ResumeLayout();
		SelectedItemChangedEventArgs?.Invoke(this, new SelectedItemChangedEventArgs(multiPageItem.Id));
	}

	public void Clear()
	{
		if (_items.Count == 0)
			return;

		foreach (var item in _items) {
			this.Controls.Remove(item.Ctl);
			item.Ctl.Dispose();
		}

		toolStrip.Items.Clear();
		_items.Clear();
		SelectedItem = null;
	}

	public bool Remove(Guid id)
	{
		var item = _items.FirstOrDefault(x => x.Id == id);
		if (item != null) {
			RemoveItem(item);
			return true;

		} else {
			return false;
		}
	}

	private void RemoveItem(MultiPageItem item)
	{
		this.Controls.Remove(item.Ctl);
		item.Ctl.Dispose();

		toolStrip.Items.Remove(item.Button);
		item.Button.Dispose();

		_items.Remove(item);
	}

	public class MultiPageItem
	{
		public MultiPageItem(Guid id, ToolStripButton button, Control ctl)
		{
			Id = id;
			Button = button;
			Ctl = ctl;
		}

		public Guid Id { get; set; }
		public ToolStripButton Button { get; set; }
		public Control Ctl { get; set; }
	}

	private void btnCloseItem_Click(object sender, EventArgs e)
	{
		if (this.SelectedId.HasValue)
			this.Remove(this.SelectedId.Value);

		if (_items.Count > 0)
			Select(_items[0]);
		else
			SelectedItem = null;
	}
}

#region EventArg Classes

public class SelectedItemChangedEventArgs : EventArgs
{
	public Guid Id { get; }

	public SelectedItemChangedEventArgs(Guid id)
	{
		Id = id;
	}
}

#endregion