using Dyvenix.Genit.Misc;
using Dyvenix.Genit.Models.Generators;
using System;
using System.Windows.Forms;

namespace Dyvenix.Genit.UserControls;

public partial class GeneratorsEditCtl : UserControlBase
{
	#region Fields

	private GeneratorsModel _generatorsMdl;

	#endregion

	#region Ctors / Init

	public GeneratorsEditCtl()
	{
		InitializeComponent();
	}

	public GeneratorsEditCtl(GeneratorsModel generatorsMdl) : this()
	{
		_generatorsMdl = generatorsMdl;
		Populate();
	}

	private void DbCtxGenEditCtl_Load(object sender, EventArgs e)
	{
		Populate();
	}

	private void Populate()
	{
		_suspendUpdates = true;

		txtTemplatesFolder.Text = _generatorsMdl.TemplatesFolder;

		_suspendUpdates = false;
	}

	#endregion

	private void btnBrowseTemplatesFolder_Click(object sender, EventArgs e)
	{
		folderDlg.InitialDirectory = txtTemplatesFolder.Text;
		if (folderDlg.ShowDialog() == DialogResult.OK)
			txtTemplatesFolder.Text = Utils.ConvertToRelative(Globals.CurrDocFilepath, folderDlg.SelectedPath);
	}

	private void txtTemplatesFolder_TextChanged(object sender, EventArgs e)
	{
		if (!_suspendUpdates)
			_generatorsMdl.TemplatesFolder = txtTemplatesFolder.Text;
	}
}
