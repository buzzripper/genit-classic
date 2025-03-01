using Dyvenix.Genit.Config;
using Dyvenix.Genit.DocModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Diagram;
using Dyvenix.Genit.Diagram;
using System.Net.Http.Headers;
using Dyvenix.Genit.Generators;

namespace Dyvenix.Genit;

public partial class Form1 : Form
{
	#region Constants


	#endregion

	private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions { WriteIndented = true };

	#region Fields

	private DetailForm _detailForm;
	private bool _suspendUpdates;
	private AppConfig _appConfig;

	#endregion

	#region Ctors / Forms Events

	public Form1()
	{
		InitializeComponent();
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		_appConfig = ConfigManager.GetAppConfig();
		PopulateForm(_appConfig);
		Form1_Resize(null, null);

		//AddRect();
		var doc = Utils.GenerateTestDoc();
		rtbJson.Text = JsonSerializer.Serialize(doc, _serializerOptions);
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

	private void Form1_Resize(object sender, EventArgs e)
	{
		if (this.WindowState == FormWindowState.Minimized) {
			//if (timer1.Enabled)
			//	SetAutoRefresh(false);
		} else {
			//var width = lvLogs.Width - 22;
			//for (var i = 0; i < 4; i++)
			//	width -= lvLogs.Columns[i].Width;
			//lvLogs.Columns[4].Width = width;
		}
	}

	#endregion

	#region Initialization

	private void PopulateForm(AppConfig appConfig)
	{
		_suspendUpdates = true;
		try {
			SetFormSizeAndPosition(appConfig.WindowSize, appConfig.WindowPosition);

		} finally {
			_suspendUpdates = false;
		}
	}

	private Image LoadEmbeddedImage(string resourceName)
	{
		var resourceFullName = $"LogViewer.Resources.{resourceName}";

		Assembly assembly = Assembly.GetExecutingAssembly();

		using (var stream = assembly.GetManifestResourceStream(resourceFullName)) {
			if (stream != null) {
				return Image.FromStream(stream);
			} else {
				throw new Exception("Resource not found: " + resourceName);
			}
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

	private void uiOpen_Click(object sender, EventArgs e)
	{
		if (openFileDlg.ShowDialog(this) == DialogResult.OK) {
			try {
				var contents = File.ReadAllText(openFileDlg.FileName);
				var doc = JsonSerializer.Deserialize<Doc>(contents);
				rtbJson.Text = JsonSerializer.Serialize(doc, _serializerOptions);

			} catch (Exception ex) {
				MessageBox.Show($"Error opening file: {ex.Message}");
			}
		}
	}

	private void uiClose_Click(object sender, EventArgs e)
	{

	}

	private void uiGenerate_Click(object sender, EventArgs e)
	{
		var entityGenerator = new EntityGenerator {
			Enabled = true,
			InclHeader = true,
			OutputRootFolder = @"C:\Work\Genit"
		};

		try {
			var doc = JsonSerializer.Deserialize<Doc>(rtbJson.Text);
			entityGenerator.Run(doc.DbContexts[0]);

		} catch (Exception ex) {
			this.ShowErrorDlg(ex);
		}
	}

	private void uiSave_Click(object sender, EventArgs e)
	{
		if (!ValidateJson(rtbJson.Text))
			return;

		var formattedJson = FormatJson(rtbJson.Text);

		if (saveFileDlg.ShowDialog(this) == DialogResult.OK) {
			try {
				File.WriteAllText(saveFileDlg.FileName, formattedJson);
			} catch (Exception ex) {
				MessageBox.Show($"Error saving file: {ex.Message}");
			}
		}
	}

	private bool ValidateJson(string json)
	{
		try {
			JsonSerializer.Deserialize<Doc>(json);
			return true;

		} catch (Exception ex) {
			MessageBox.Show($"Error saving file: {ex.Message}");
			return false;
		}
	}

	private string FormatJson(string json)
	{
		var parsedJson = JsonSerializer.Deserialize<dynamic>(json);
		return JsonSerializer.Serialize(parsedJson, _serializerOptions);
	}

	private void printToolStripButton_Click(object sender, EventArgs e)
	{
	}

	private void AddRect()
	{
		////var child = new Syncfusion.Windows.Forms.Diagram.RoundRect(new RectangleF(10, 10, 200, 100), 4);
		//var entityView = new EntityRect(new RectangleF(10, 10, 200, 100));
		//entityView.ClassName = "AppUser";

		//diagram1.Model.AppendChild(entityView);
	}

	private void ShowErrorDlg(string message)
	{
		MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}

	private void ShowErrorDlg(Exception ex)
	{
		MessageBox.Show($"{ex.GetType().Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
