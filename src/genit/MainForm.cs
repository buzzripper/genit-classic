using Dyvenix.Genit.Config;
using Dyvenix.Genit.Generators;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.Models.Generators;
using Dyvenix.Genit.UserControls;
using Dyvenix.Genit.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace Dyvenix.Genit;

public partial class MainForm : Form
{
	private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions { WriteIndented = true };

	#region Constants

	private const int cOuputMinHeight = 45;

	#endregion

	#region Fields

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
		this.CurrDocFilepath = @"D:\Code\buzzripper\dyvenix\design\Model\Dyv4.gmdl";
		var doc = DocManager.LoadDoc(CurrDocFilepath);

		//var dbCtx = doc.DbContexts[0];
		//var gens = GeneratorsModel.CreateNew();
		//gens.DbContextGen = dbCtx.DbContextGen;
		//gens.EntityGen = dbCtx.EntityGen;
		//gens.EnumGen = dbCtx.EnumGen;
		//gens.ServiceGen = dbCtx.ServiceGen;
		//dbCtx.Generators.IntTestsGen = IntTestsGenModel.CreateNew();
		//dbCtx.Generators = gens;

		this.Doc = doc;
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
		SetFormSizeAndPosition(appConfig.WindowSize, appConfig.WindowPosition);
		this.SetState(GenitAppState.NoDoc);
		_outputHeight = splContent.Height - splContent.SplitterDistance;

		// Clear any tabs
		multiPageCtl.Clear();

		UpdateMruFilesMenu(appConfig.MruFilepaths);
	}

	private void PopulateForm(Doc doc)
	{
		if (doc == null) {
			treeNav.Clear();
			multiPageCtl.Clear();
			return;
		}

		treeNav.DataSource = doc.DbContexts[0];
		treeNav.EntityDeleted += TreeNav_OnEntityDeleted;
		treeNav.EnumDeleted += TreeNav_OnEnumDeleted;
	}

	private void TreeNav_OnEntityDeleted(object sender, EntityDeletedEventArgs e)
	{
		foreach (var ctl in multiPageCtl.Controls) {
			if (ctl is EntityContainerCtl entityCtl) {
				if (entityCtl.Entity.Id == e.Entity.Id) {
					multiPageCtl.Remove(entityCtl.Entity.Id);
					//entityCtl.Dispose();
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
		switch (state) {
			case GenitAppState.NoDoc:
				SetStateNoDoc();
				break;
			default:
				SetStateDocLoaded();
				break;
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

	#region Generate

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

			var templatesFolderpath = Utils.ResolveRelativePath(Globals.CurrDocFilepath, dbContextMdl.Generators.TemplatesFolder);

			// DbContext
			var dbContextGenMdl = dbContextMdl.Generators.DbContextGen;
			if (dbContextGenMdl == null)
				throw new ApplicationException("DbContext generator not found.");
			if (dbContextGenMdl.Enabled) {
				outputCtl.WriteInfo("Running DbContext generator...");
				new DbContextGenerator().Run(dbContextGenMdl, dbContextMdl, dbContextMdl.Generators.EntityGen.EntitiesNamespace, templatesFolderpath);
			}

			// Entities
			var entityGenMdl = dbContextMdl.Generators.EntityGen;
			if (entityGenMdl == null)
				throw new ApplicationException("Entity generator not found.");
			if (entityGenMdl.Enabled) {
				var entityGenerator = new EntityGenerator();
				outputCtl.WriteInfo("Running Entities generator...");
				entityGenerator.Run(entityGenMdl, dbContextMdl.Entities, entityGenMdl.EntitiesNamespace, templatesFolderpath);
			}

			// Enums
			var enumGenMdl = dbContextMdl.Generators.EnumGen;
			if (enumGenMdl == null)
				throw new ApplicationException("Enum generator not found.");
			if (enumGenMdl.Enabled) {
				var enumGenerator = new EnumGenerator();
				outputCtl.WriteInfo("Running Entities generator...");
				enumGenerator.Run(enumGenMdl, dbContextMdl.Enums, enumGenMdl.EnumsNamespace, templatesFolderpath);
			}

			// Services
			var svcGenMdl = dbContextMdl.Generators.ServiceGen;
			if (svcGenMdl == null)
				throw new ApplicationException("Service generator not found.");
			if (svcGenMdl.Enabled) {
				var svcGenerator = new ServiceGenerator();
				outputCtl.WriteInfo("Running Services generator...");
				svcGenerator.Run(svcGenMdl, dbContextMdl.Entities, entityGenMdl.EntitiesNamespace, templatesFolderpath);
			}

			// DTOs
			if (svcGenMdl.Enabled) {
				var dtoGenerator = new DtoGenerator();
				outputCtl.WriteInfo("Running DTO generator...");
				dtoGenerator.Run(svcGenMdl, dbContextMdl.Entities, entityGenMdl.EntitiesNamespace, templatesFolderpath);
			}

			// Integration Tests
			var intTestsGenMdl = dbContextMdl.Generators.IntTestsGen;
			if (intTestsGenMdl == null)
				throw new ApplicationException("Integration test generator not found.");
			if (intTestsGenMdl.Enabled) {
				var intTestsGenerator = new IntTestGenerator();
				outputCtl.WriteInfo("Running Integration Tests generator...");
				intTestsGenerator.Run(intTestsGenMdl, dbContextMdl.Entities, templatesFolderpath);
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

	private void treeNav_ServiceModelSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{
	}

	private void treeNav_GeneratorsModelSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var gensMdl = this.Doc.DbContexts[0].Generators;
			var generatorsEditCtl = new GeneratorsEditCtl(gensMdl);
			multiPageCtl.Add(gensMdl.Id, gensMdl.Name, generatorsEditCtl);
			multiPageCtl.Select(gensMdl.Id);
		}
	}

	private void treeNav_DbContextGenSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var dbGenMdl = this.Doc.DbContexts[0].Generators.DbContextGen;
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
			var entityGenMdl = this.Doc.DbContexts[0].Generators.EntityGen;
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
			var enumGenMdl = this.Doc.DbContexts[0].Generators.EnumGen;
			var enumGenEditCtl = new EnumGenEditCtl(enumGenMdl);
			multiPageCtl.Add(enumGenMdl.Id, enumGenMdl.Name, enumGenEditCtl);
			multiPageCtl.Select(enumGenMdl.Id);
		}
	}

	private void treeNav_ServiceGenSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var svcGenMdl = this.Doc.DbContexts[0].Generators.ServiceGen;
			var svcGenEditCtl = new ServiceGenEditCtl(svcGenMdl);
			multiPageCtl.Add(svcGenMdl.Id, svcGenMdl.Name, svcGenEditCtl);
			multiPageCtl.Select(svcGenMdl.Id);
		}
	}

	private void treeNav_IntTestsGenSelected(object sender, NavTreeNodeSelectedEventArgs e)
	{
		if (SelectTabPageById(e.Id))
			return;

		if (!multiPageCtl.Select(e.Id)) {
			var intTestsGenMdl = this.Doc.DbContexts[0].Generators.IntTestsGen;
			var svcGenEditCtl = new IntTestsGenEditCtl(intTestsGenMdl);
			multiPageCtl.Add(intTestsGenMdl.Id, intTestsGenMdl.Name, svcGenEditCtl);
			multiPageCtl.Select(intTestsGenMdl.Id);
		}
	}

	#endregion

	#region Tabs

	private bool SelectTabPageById(Guid id)
	{
		return multiPageCtl.Select(id);
	}

	private void AddNewTabPage(string name, Control ctl, TabType tabType, Guid id)
	{
		multiPageCtl.Add(id, name, ctl);
	}

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
		ToggleOutputVisibility();
	}

	private void tbOutput_DoubleClick(object sender, EventArgs e)
	{
		ToggleOutputVisibility();
	}

	private void ToggleOutputVisibility()
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

	private void uiNew_Click(object sender, EventArgs e)
	{
		this.Doc = Doc.CreateNew();
	}
}

