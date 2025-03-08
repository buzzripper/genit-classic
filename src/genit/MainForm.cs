using Dyvenix.Genit.Config;
using Dyvenix.Genit.Generators;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.UserControls;
using Dyvenix.Genit.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Dyvenix.Genit;

public partial class MainForm : Form
{
	private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions { WriteIndented = true };

	#region Constants

	private const int cOuputMinHeight = 25;

	#endregion

	#region Fields

	private DetailForm _detailForm;
	private bool _suspendUpdates;
	private AppConfig _appConfig;
	private Doc _doc;
	private int _outputHeight;
	private string _currDocFilepath;

	#endregion

	#region Ctors / Forms Events

	public MainForm()
	{
		InitializeComponent();
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		_appConfig = ConfigManager.GetAppConfig();
		InitializeLayout(_appConfig);

		// DEBUG
		this.Doc = DocManager.LoadDoc(@"C:\Work\Genit\Test1.gmdl");
	}

	private void Form1_Shown(object sender, EventArgs e)
	{
		//this.Cursor = Cursors.WaitCursor;
		//try {

		//} catch (Exception ex) {
		//	MessageBox.Show($"{ex.GetType().Name} doing stuff: {ex.Message}");
		//} finally {
		//	this.Cursor = Cursors.Default;
		//}
	}

	private void Form1_Activated(object sender, EventArgs e)
	{
		//if (this.WindowState == FormWindowState.Minimized)
		//	SetAutoRefresh(false);
	}

	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
	{
		SaveSettings();
	}

	private void MainForm_ResizeEnd(object sender, EventArgs e)
	{

	}

	#endregion

	#region Initialization

	private void InitializeLayout(AppConfig appConfig)
	{
		_suspendUpdates = true;

		try {
			SetFormSizeAndPosition(appConfig.WindowSize, appConfig.WindowPosition);
			this.SetState(GenitAppState.NoDoc);
			_outputHeight = splContent.Height - splContent.SplitterDistance;

			// Clear any tabs
			multiPageCtl.Clear();

		} finally {
			_suspendUpdates = false;
		}
	}

	private void PopulateForm(Doc doc)
	{
		_suspendUpdates = true;
		try {
			if (doc == null) {
				treeNav.Clear();
				multiPageCtl.Clear();
				return;
			}

			treeNav.DataSource = doc.DbContexts[0];
			//treeNav.AssocModelSelected += TreeNav_AssocModelSelected;
			//treeNav.DbContextModelSelected += TreeNav_DbContextModelSelected;
			//treeNav.PropertyModelSelected += TreeNav_PropertyModelSelected;
			//treeNav.EntityModelSelected += TreeNav_EntityModelSelected;
			//treeNav.EnumModelSelected += TreeNav_EnumModelSelected;
			//treeNav.GeneratorModelSelected += TreeNav_GeneratorModelSelected;

		} finally {
			_suspendUpdates = false;
		}
	}

	#endregion

	#region Settings

	private void SaveSettings()
	{
		// Save settings
		var appConfig = new AppConfig();

		// Window
		if (this.WindowState == FormWindowState.Normal) {
			appConfig.WindowPosition = this.Location;
			appConfig.WindowSize = this.Size;
		} else {
			appConfig.WindowPosition = this.RestoreBounds.Location;
			appConfig.WindowSize = this.RestoreBounds.Size;
		}

		ConfigManager.SaveAppConfig(appConfig);
	}

	private void SetFormSizeAndPosition(Size windowSize, Point position)
	{
		this.Width = (windowSize.Width < 934) ? 934 : windowSize.Width;
		this.Height = (windowSize.Height < 633) ? 633 : windowSize.Height;

		// Get the screen that contains the specified coordinates
		Screen screen = Screen.FromPoint(position);

		// Ensure the form is not positioned outside the screen bounds
		System.Drawing.Rectangle workingArea = screen.WorkingArea;

		int x = position.X;
		int y = position.Y;

		if (x < workingArea.Left)
			x = workingArea.Left;
		else if (x + this.Width > workingArea.Right)
			x = workingArea.Right - this.Width;

		if (y < workingArea.Top)
			y = workingArea.Top;
		else if (y + this.Height > workingArea.Bottom)
			y = workingArea.Bottom - this.Height;

		// Set the form's position
		this.StartPosition = FormStartPosition.Manual;
		this.Location = new Point(x, y);
	}

	#endregion

	#region Properties

	private Doc Doc
	{
		get { return _doc; }
		set {
			_doc = value;
			SetState(_doc == null ? GenitAppState.NoDoc : GenitAppState.DocLoaded);
			PopulateForm(_doc);
		}
	}

	#endregion

	#region State management

	private void SetState(GenitAppState state)
	{
		_suspendUpdates = true;
		try {
			switch (state) {
				case GenitAppState.NoDoc:
					SetStateNoDoc();
					break;
				default:
					SetStateDocLoaded();
					break;
			}
		} finally {
			_suspendUpdates = false;
		}
	}

	private void SetStateNoDoc()
	{
		EnableNew(true);
		EnableOpen(true);
		EnableSave(false);
		EnableSaveAs(false);
		EnableGenerate(false);
		multiPageCtl.Visible = false;
	}

	private void SetStateDocLoaded()
	{
		EnableNew(true);
		EnableOpen(true);
		EnableSave(true);
		EnableSaveAs(true);
		EnableGenerate(true);
		multiPageCtl.Visible = true;
	}

	private void EnableNew(bool value)
	{
		mnuNew.Enabled = value;
		btnNew.Enabled = value;
	}

	private void EnableOpen(bool value)
	{
		mnuOpen.Enabled = value;
		btnOpen.Enabled = value;
	}

	private void EnableSave(bool value)
	{
		mnuSave.Enabled = value;
		btnSave.Enabled = value;
	}

	private void EnableSaveAs(bool value)
	{
		mnuSaveAs.Enabled = value;
	}

	private void EnableGenerate(bool value)
	{
		btnGenerate.Enabled = value;
	}

	#endregion

	#region Doc Load/Save

	private void uiOpen_Click(object sender, EventArgs e)
	{
		if (openFileDlg.ShowDialog(this) == DialogResult.OK) {
			try {
				this.Doc = DocManager.LoadDoc(openFileDlg.FileName);
				_currDocFilepath = openFileDlg.FileName;

			} catch (Exception ex) {
				MessageBox.Show($"Error opening file: {ex.Message}");
			}
		}
	}

	private void uiSave_Click(object sender, EventArgs e)
	{
		if (saveFileDlg.ShowDialog(this) == DialogResult.OK) {
			try {
				DocManager.SaveDoc(this.Doc, saveFileDlg.FileName);

			} catch (ValidationException ex) {
				MessageBox.Show($"Validation error(s). See output for detail.");

			} catch (Exception ex) {
				MessageBox.Show($"Error saving file: {ex.Message}");
			}
		}
	}

	private void uiClose_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Close the current document?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
			this.Doc = null;
		}
	}

	private void uiExit_Click(object sender, EventArgs e)
	{
		if (this.Doc != null) {
			switch (MessageBox.Show("Save changes?", "Close", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
				case DialogResult.Yes:
					if (string.IsNullOrWhiteSpace(_currDocFilepath)) {
						if (saveFileDlg.ShowDialog(this) == DialogResult.OK) {
							DocManager.SaveDoc(this.Doc, saveFileDlg.FileName);
						}
					} else {
						DocManager.SaveDoc(this.Doc, _currDocFilepath);
					}
					Application.Exit();
					break;

				case DialogResult.No:
					Application.Exit();
					break;

				case DialogResult.Cancel:
					return;
			}
		}

		Application.Exit();
	}

	private void uiGenerate_Click(object sender, EventArgs e)
	{
		try {
			if (_doc == null) {
				outputCtl.WriteInfo("No document loaded.");
				return;
			}

			var dbContextMdl = _doc.DbContexts[0];

			var errors = new List<string>();

			_doc.Validate(errors);

			if (errors.Count > 0) {
				errors.Insert(0, "Validation Errors:");
				ShowErrorDlg("Invalid Model", string.Join(Environment.NewLine, errors));
				return;
			}

			if (MessageBox.Show("Generate files?", "Generate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;

			// DbContext
			var dbContextGenMdl = dbContextMdl.Generators.First(g => g.GeneratorType == GeneratorType.DbContext) as DbContextGenModel;
			if (dbContextGenMdl == null)
				throw new ApplicationException("DbContext generator not found.");
			if (dbContextGenMdl.Enabled) {
				var dbContextGenerator = new DbContextGenerator(dbContextGenMdl);
				outputCtl.WriteInfo("Running DbContext generator...");
				dbContextGenerator.Run(dbContextMdl);
			}

			// Entities
			var entityGenMdl = dbContextMdl.Generators.FirstOrDefault(g => g.GeneratorType == GeneratorType.Entity) as EntityGenModel;
			if (entityGenMdl == null)
				throw new ApplicationException("Entity generator not found.");
			if (entityGenMdl.Enabled) {
				var entityGenerator = new EntityGenerator(entityGenMdl);
				outputCtl.WriteInfo("Running Entities generator...");
				entityGenerator.Run(dbContextMdl);
			}

			ShowSuccessDlg("Files generated.");

		} catch (Exception ex) {
			this.ShowErrorDlg(ex);
		}

	}

	#endregion

	#region TreeNav

	private void treeNav_DbContextModelSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var dbContextCtl = new DbContextEditCtl(_doc.DbContexts[0]);
			multiPageCtl.Add(e.Id, _doc.DbContexts[0].Name, dbContextCtl);
		}
	}

	private void treeNav_EntityModelSelected_1(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var entity = _doc.DbContexts[0].Entities.First(e => e.Id == e.Id);
			var entityCtl = new EntityContainerCtl(entity);
			multiPageCtl.Add(e.Id, entity.Name, entityCtl);
		}
	}

	private void TreeNav_PropertyModelSelected(object sender, UserControls.PropertyModelEventArgs e)
	{
	}

	private void TreeNav_EnumModelSelected(object sender, UserControls.EnumModelEventArgs e)
	{
	}

	private void TreeNav_AssocModelSelected(object sender, UserControls.AssocModelEventArgs e)
	{
	}

	private void TreeNav_GeneratorModelSelected(object sender, UserControls.GeneratorModelEventArgs e)
	{
	}

	#endregion

	#region Tabs

	//private void AddNewTabPage(string name, Control ctl, TabType tabType, Guid id)
	//{
	//	var tabPage = new TabPage(name) {
	//		Tag = new TabData { TabType = tabType, Id = id }
	//	};
	//	tabPage.Controls.Add(ctl);
	//	ctl.Dock = DockStyle.Fill;
	//	tabsMain.TabPages.Add(tabPage);
	//	tabsMain.SelectedTab = tabPage;
	//	tabsMain.Visible = true;
	//	tabsMain.Focus();
	//}

	//private bool SelectTabPageById(Guid id)
	//{
	//	var tabPage = GetTabPageById(id);
	//	if (tabPage != null) {
	//		tabsMain.SelectedTab = tabPage;
	//		return true;
	//	}
	//	return false;
	//}

	//private TabPage GetTabPageById(Guid id)
	//{
	//	foreach (TabPage tabPage in tabsMain.TabPages) {
	//		var tabData = tabPage.Tag as TabData;
	//		if (tabData == null)
	//			continue;
	//		if (tabData.Id == id)
	//			return tabPage;
	//	}
	//	return null;
	//}

	private bool SelectTabPageById(Guid id)
	{
		return multiPageCtl.Select(id);
	}

	private void AddNewTabPage(string name, Control ctl, TabType tabType, Guid id)
	{
		multiPageCtl.Add(id, name, ctl);
	}

	//private TabPage GetTabPageById(Guid id)
	//{
	//	foreach (TabPage tabPage in tabsMain.TabPages) {
	//		var tabData = tabPage.Tag as TabData;
	//		if (tabData == null)
	//			continue;
	//		if (tabData.Id == id)
	//			return tabPage;
	//	}
	//	return null;
	//}

	#endregion

	#region Utils

	private void ShowErrorDlg(string message)
	{
		ShowErrorDlg("Error", message);
	}

	private void ShowErrorDlg(string caption, string message)
	{
		MessageBox.Show(this, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
	}

	private void ShowErrorDlg(Exception ex)
	{
		MessageBox.Show(this, $"{ex.GetType().Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}

	private void ShowSuccessDlg(string message)
	{
		MessageBox.Show(this, message, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}

	private void btnShowOutput_Click(object sender, EventArgs e)
	{
		if (splOutput.Height > cOuputMinHeight) {
			_outputHeight = splOutput.Height; // Cache the previous distance
			splContent.SplitterDistance = splContent.Height - cOuputMinHeight;  // Hide
		} else {
			splContent.SplitterDistance = splContent.Height - _outputHeight;
		}
	}

	private void btnClearOuput_Click(object sender, EventArgs e)
	{
		outputCtl.Clear();
	}

	#endregion

	private void btnTest1_Click(object sender, EventArgs e)
	{
		try {
			this.Doc = DocManager.LoadDoc("TEST");
			outputCtl.WriteInfo("Doc opened.");

		} catch (Exception ex) {
			this.ShowErrorDlg(ex);
		}
	}

	private void btnTest2_Click(object sender, EventArgs e)
	{
		//var items = new List<string> { "Item 1", "Item 2", "Item 3" };
		//stringListEditor1.Items = items;

		//listBox1.Items.Clear();
		//listBox1.Items.AddRange(items.ToArray());

		//stringListEditor1.ItemAdded += (s, e) => {
		//	listBox1.Items.Add(e.Value);
		//};	
		//stringListEditor1.ItemChanged += (s, e) => {
		//	listBox1.Items[e.Index] = e.Value;
		//};
		//stringListEditor1.ItemDeleted += (s, e) => {
		//	listBox1.Items.RemoveAt(e.Index);
		//};
	}

	private void btnDeleteTab_Click(object sender, EventArgs e)
	{
		if (multiPageCtl.SelectedId.HasValue)
			multiPageCtl.Remove(multiPageCtl.SelectedId.Value);
	}

	private void multiPageCtl_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
	{
		treeNav.Select(e.Id);
	}

	private void treeNav_EntitiesNodeSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{

	}
}

