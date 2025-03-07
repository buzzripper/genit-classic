using Dyvenix.Genit.Config;
using Dyvenix.Genit.Generators;
using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models;
using Dyvenix.Genit.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
	}

	private void Form1_Shown(object sender, EventArgs e)
	{
		this.Cursor = Cursors.WaitCursor;
		try {

		} catch (Exception ex) {
			MessageBox.Show($"{ex.GetType().Name} doing stuff: {ex.Message}");
		} finally {
			this.Cursor = Cursors.Default;
		}
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
	}

	private void SetStateDocLoaded()
	{
		EnableNew(true);
		EnableOpen(true);
		EnableSave(true);
		EnableSaveAs(true);
		EnableGenerate(true);
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
			var errors = new List<string>();

			_doc.Validate(errors);

			if (errors.Count > 0) {
				errors.Insert(0, "Validation Errors:");
				ShowErrorDlg("Invalid Model", string.Join(Environment.NewLine, errors));
				return;
			}

			if (MessageBox.Show("Generate files?", "Generate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;

			var entityGenerator = new EntityGenerator {
				Enabled = true,
				InclHeader = true,
				OutputRootFolder = @"D:\Code\buzzripper\dyvenix\src\app1.data\Entities"
				//OutputRootFolder = @"c:\work\genit\Entities"
			};
			entityGenerator.Run(_doc.DbContexts[0]);

			var dbContextGenerator = new DbContextGenerator {
				Enabled = true,
				InclHeader = true,
				OutputFolder = @"D:\Code\buzzripper\dyvenix\src\app1.data\Contexts"
				//OutputFolder = @"c:\work\genit\Entities"
			};
			dbContextGenerator.Run(_doc.DbContexts[0]);

			ShowSuccessDlg("Files generated.");

		} catch (Exception ex) {
			this.ShowErrorDlg(ex);
		}

	}

	#endregion

	private void PopulateForm(Doc doc)
	{
		_suspendUpdates = true;
		try {
			treeNav.DataSource = doc.DbContexts[0];
			treeNav.AssocModelSelected += TreeNav_AssocModelSelected;
			treeNav.DbContextModelSelected += TreeNav_DbContextModelSelected;
			treeNav.PropertyModelSelected += TreeNav_PropertyModelSelected;
			treeNav.EntityModelSelected += TreeNav_EntityModelSelected;
			treeNav.EnumModelSelected += TreeNav_EnumModelSelected;
			treeNav.GeneratorModelSelected += TreeNav_GeneratorModelSelected;
		} finally {
			_suspendUpdates = false;
		}
	}

	#region TreeNav

	private void TreeNav_DbContextModelSelected(object sender, UserControls.DbContextModelEventArgs e)
	{
		outputCtl.WriteInfo($"DbContext selected: {e.DbContext.Name}");
	}

	private void TreeNav_EntityModelSelected(object sender, UserControls.EntityModelEventArgs e)
	{
		outputCtl.WriteInfo($"DbContext selected: {e.Entity.Name}");
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

	private void treeNav_AfterSelect(object sender, TreeViewEventArgs e)
	{
		if (_suspendUpdates || this.Doc == null)
			return;

		if (e.Node.Text == "DbContext") {
			dbContextEditCtl.SetDbContext(this.Doc.DbContexts[0]);
		}
	}

	private void btnClearOuput_Click(object sender, EventArgs e)
	{
		outputCtl.Clear();
	}
}

