using Dyvenix.Genit.Config;
using Dyvenix.Genit.Generators;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.UserControls;
using Dyvenix.Genit.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

	private bool _suspendUpdates;
	private AppConfig _appConfig;
	private int _outputHeight;

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
		//this.CurrDocFilepath = @"C:\Work\Genit\TestA.gmdl";
		//this.Doc = DocManager.LoadDoc(CurrDocFilepath);
	}

	private void Form1_Shown(object sender, EventArgs e)
	{
	}

	private void Form1_Activated(object sender, EventArgs e)
	{
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

			UpdateMruFilesMenu(appConfig.MruFilepaths);

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
			treeNav.EntityDeleted += TreeNav_OnEntityDeleted;
			treeNav.EnumDeleted += TreeNav_OnEnumDeleted;

		} finally {
			_suspendUpdates = false;
		}
	}

	private void TreeNav_OnEntityDeleted(object sender, EntityDeletedEventArgs e)
	{
		foreach (var ctl in multiPageCtl.Controls) {
			if (ctl is EntityContainerCtl entityCtl) {
				if (entityCtl.Entity.Id == e.Entity.Id) {
					multiPageCtl.Remove(entityCtl.Entity.Id);
					entityCtl.Dispose();
					break;
				}
			}
		}
	}

	private void TreeNav_OnEnumDeleted(object sender, EnumDeletedEventArgs e)
	{
		foreach (var ctl in multiPageCtl.Controls) {
			if (ctl is EnumEditCtl enumEditCtl) {
				if (enumEditCtl.EnumModel.Id == e.EnumModel.Id) {
					multiPageCtl.Remove(enumEditCtl.EnumModel.Id);
					enumEditCtl.Dispose();
					break;
				}
			}
		}
	}

	#endregion

	#region Settings

	private void SaveSettings()
	{
		// Window
		if (this.WindowState == FormWindowState.Normal) {
			_appConfig.WindowPosition = this.Location;
			_appConfig.WindowSize = this.Size;
		} else {
			_appConfig.WindowPosition = this.RestoreBounds.Location;
			_appConfig.WindowSize = this.RestoreBounds.Size;
		}
		ConfigManager.SaveAppConfig(_appConfig);
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
		get { return Doc.Instance; }
		set {
			Doc.Instance = value;
			SetState(Doc.Instance == null ? GenitAppState.NoDoc : GenitAppState.DocLoaded);
			PopulateForm(Doc.Instance);
			if (value != null)
				Doc.Instance.DbContexts[0] = value?.DbContexts[0];
			else
				Globals.CurrDocFilepath = null;
		}
	}

	private string CurrDocFilepath
	{
		get { return Globals.CurrDocFilepath; }
		set {
			Globals.CurrDocFilepath = value;
			var filename = Path.GetFileName(value);
			this.Text = string.IsNullOrWhiteSpace(value) ? "Genit" : $"Genit - {filename}";
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
		if (openFileDlg.ShowDialog(this) == DialogResult.OK)
			OpenDoc(openFileDlg.FileName);
	}

	private void OpenDoc(string docFilepath)
	{
		try {
			this.Doc = null;
			this.Doc = DocManager.LoadDoc(docFilepath);
			CurrDocFilepath = docFilepath;
			_appConfig.AddMruFilepath(CurrDocFilepath);
			UpdateMruFilesMenu(_appConfig.MruFilepaths);

		} catch (Exception ex) {
			MessageBox.Show($"Error opening file: {ex.Message}");
		}
	}

	private void UpdateMruFilesMenu(List<string> mruFilepaths)
	{
		mnuRecentFiles.DropDownItems.Clear();

		foreach (var mruFilepath in mruFilepaths) {
			mnuRecentFiles.DropDownItems.Add(new ToolStripMenuItem(mruFilepath, null, MnuMruFile_Click));
		}
	}

	private void MnuMruFile_Click(object sender, EventArgs e)
	{
		var mruFilepath = (sender as ToolStripMenuItem).Text;
		OpenDoc(mruFilepath);
	}

	private void uiSave_Click(object sender, EventArgs e)
	{
		Save();
	}

	private void Save()
	{
		if (string.IsNullOrWhiteSpace(CurrDocFilepath)) {
			if (saveFileDlg.ShowDialog(this) == DialogResult.OK) {
				CurrDocFilepath = saveFileDlg.FileName;
			} else {
				return;
			}
		}

		try {
			DocManager.SaveDoc(this.Doc, CurrDocFilepath);
			outputCtl.WriteInfo($"File saved ({CurrDocFilepath})");

		} catch (ValidationException ex) {
			foreach (var err in ex.Errors)
				outputCtl.WriteError(err);
			MessageBox.Show($"Validation error(s). See output for detail.");

		} catch (Exception ex) {
			MessageBox.Show($"Error saving file: {ex.Message}");
		}
	}

	private void uiClose_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Close the current document?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
			this.Doc = null;
		}
	}

	private void uiSaveAs_Click(object sender, EventArgs e)
	{
		if (saveFileDlg.ShowDialog(this) == DialogResult.OK) {
			try {
				DocManager.SaveDoc(this.Doc, saveFileDlg.FileName);
				CurrDocFilepath = saveFileDlg.FileName;
				outputCtl.WriteInfo($"File saved ({CurrDocFilepath})");

			} catch (ValidationException ex) {
				MessageBox.Show($"Validation error(s). See output for detail.");

			} catch (Exception ex) {
				MessageBox.Show($"Error saving file: {ex.Message}");
			}
		}
	}

	private void uiExit_Click(object sender, EventArgs e)
	{
		if (this.Doc != null) {
			switch (MessageBox.Show("Save changes?", "Close", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
				case DialogResult.Yes:
					if (string.IsNullOrWhiteSpace(CurrDocFilepath)) {
						if (saveFileDlg.ShowDialog(this) == DialogResult.OK) {
							DocManager.SaveDoc(this.Doc, saveFileDlg.FileName);
						}
					} else {
						DocManager.SaveDoc(this.Doc, CurrDocFilepath);
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

	#endregion

	private void uiGenerate_Click(object sender, EventArgs e)
	{
		try {
			if (this.Doc == null) {
				outputCtl.WriteInfo("No document loaded.");
				return;
			}

			var dbContextMdl = this.Doc.DbContexts[0];

			var errors = new List<string>();

			this.Doc.Validate(errors);

			if (errors.Count > 0) {
				errors.Insert(0, "Validation Errors:");
				ShowErrorDlg("Invalid Model", string.Join(Environment.NewLine, errors));
				return;
			}

			if (MessageBox.Show("Generate files?", "Generate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;

			// DbContext
			var dbContextGenMdl = dbContextMdl.DbContextGen;
			if (dbContextGenMdl == null)
				throw new ApplicationException("DbContext generator not found.");
			if (dbContextGenMdl.Enabled) {
				outputCtl.WriteInfo("Running DbContext generator...");
				new DbContextGenerator().Run(dbContextGenMdl, dbContextMdl);
			}

			// Entities
			var entityGenMdl = dbContextMdl.EntityGen;
			if (entityGenMdl == null)
				throw new ApplicationException("Entity generator not found.");
			if (entityGenMdl.Enabled) {
				var entityGenerator = new EntityGenerator(entityGenMdl);
				outputCtl.WriteInfo("Running Entities generator...");
				entityGenerator.Run(dbContextMdl.Entities, dbContextMdl.EntitiesNamespace);
			}

			// Enums
			var enumGenMdl = dbContextMdl.EnumGen;
			if (enumGenMdl == null)
				throw new ApplicationException("Enum generator not found.");
			if (enumGenMdl.Enabled) {
				var enumGenerator = new EnumGenerator(enumGenMdl);
				outputCtl.WriteInfo("Running Entities generator...");
				enumGenerator.Run(dbContextMdl.Enums, dbContextMdl.EnumsNamespace);
			}

			ShowSuccessDlg("Files generated.");

		} catch (Exception ex) {
			this.ShowErrorDlg(ex);
		}

	}

	#region TreeNav

	private void treeNav_DbContextModelSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var dbContextCtl = new DbContextEditCtl(this.Doc.DbContexts[0]);
			multiPageCtl.Add(e.Id, this.Doc.DbContexts[0].Name, dbContextCtl);
			multiPageCtl.Select(e.Id);
		}
	}

	private void treeNav_EntityModelSelected_1(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var entity = this.Doc.DbContexts[0].Entities.First(ent => ent.Id == e.Id);
			var entityCtl = new EntityContainerCtl(entity);
			multiPageCtl.Add(e.Id, entity.Name, entityCtl);
			multiPageCtl.Select(e.Id);
		}
	}

	private void TreeNav_PropertyModelSelected(object sender, UserControls.PropertyModelEventArgs e)
	{
	}

	private void TreeNav_EnumModelSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var enumMdl = this.Doc.DbContexts[0].Enums.First(en => en.Id == e.Id);
			var enumEditCtl = new EnumEditCtl(enumMdl);
			multiPageCtl.Add(enumMdl.Id, enumMdl.Name, enumEditCtl);
			multiPageCtl.Select(enumMdl.Id);
		}
	}

	private void treeNav_DbContextGenSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var dbGenMdl = this.Doc.DbContexts[0].DbContextGen;
			var dbCtxGenEditCtl = new DbCtxGenEditCtl(dbGenMdl);
			multiPageCtl.Add(dbGenMdl.Id, dbGenMdl.Name, dbCtxGenEditCtl);
			multiPageCtl.Select(dbGenMdl.Id);
		}
	}

	private void treeNav_EntityGenSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var entityGenMdl = this.Doc.DbContexts[0].EntityGen;
			var entityGenEditCtl = new EntityGenEditCtl(entityGenMdl);
			multiPageCtl.Add(entityGenMdl.Id, entityGenMdl.Name, entityGenEditCtl);
			multiPageCtl.Select(entityGenMdl.Id);
		}
	}

	private void treeNav_EnumGenSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var enumGenMdl = this.Doc.DbContexts[0].EnumGen;
			var enumGenEditCtl = new EnumGenEditCtl(enumGenMdl);
			multiPageCtl.Add(enumGenMdl.Id, enumGenMdl.Name, enumGenEditCtl);
			multiPageCtl.Select(enumGenMdl.Id);
		}
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
		//var doc = new Doc();
		//doc.DbContexts.Add(new DbContextModel {
		//	Name = "TestDbContext",
		//	ContextNamespace = "TestNamespace",
		//	EntitiesNamespace = "TestNamespace.Entities"
		//});

		////doc.DbContexts[0].Entities.Add(new EntityModel {
		////	Name = "TestEntity",
		////	TableName = "TestTable"
		////});


		//this.Doc = doc;

		//Save();

	}

	private void multiPageCtl_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
	{
		treeNav.Select(e.Id);
	}

	private void treeNav_EntitiesNodeSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{

	}

	private void MainForm_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && e.KeyCode == Keys.S)
			this.Save();
	}
}

