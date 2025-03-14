using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dyvenix.Genit.Models;
using System.Xml.XPath;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Dyvenix.Genit.UserControls
{
	public partial class NavPropGridCtl : UserControl
	{
		#region Fields

		private ObservableCollection<AssocModel> _assocModels;
		private List<NavPropGridRowCtl> _assocGridRows = new List<NavPropGridRowCtl>();
		private bool _suspendUpdates;

		#endregion

		#region Ctors / Init

		public NavPropGridCtl()
		{
			InitializeComponent();
		}

		private void NavPropGridCtl_Load(object sender, EventArgs e)
		{
			splMain.Height = lblPrimaryPropertyName.Height + 4;
		}

		#endregion

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ObservableCollection<AssocModel> DataSource
		{
			get { return _assocModels; }
			set {
				_assocModels = value;
				_assocModels.CollectionChanged += AssocModels_CollectionChanged;
				PopulateRows();
			}
		}

		private void PopulateRows()
		{
			if (this.DesignMode)
				return;

			_suspendUpdates = true;
			SuspendLayout();

			try {
				foreach (var row in _assocGridRows) {
					this.Controls.Remove(row);
					row.Dispose();
				}
				_assocGridRows.Clear();

				var count = 0;
				foreach (var assocMdl in _assocModels) {
					NavPropGridRowCtl navPropGridRowCtl = new NavPropGridRowCtl(assocMdl);
					navPropGridRowCtl.Top = splMain.Height + (count++ * 35);
					navPropGridRowCtl.Left = 0;
					navPropGridRowCtl.Width = this.Width;
					navPropGridRowCtl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
					navPropGridRowCtl.NavigationPropertyChanged += NavPropGridRowCtl_NavigationPropertyChanged;

					_assocGridRows.Add(navPropGridRowCtl);
					this.Controls.Add(navPropGridRowCtl);
				}

				splMain_SplitterMoved(null, null);
				splCardinality_SplitterMoved(null, null);
				splRelPropName_SplitterMoved(null, null);

			} catch (Exception ex) {
				MessageBox.Show(ex.Message);

			} finally {
				_suspendUpdates = false;
				ResumeLayout();
			}
		}

		#region UI Events

		private void NavPropGridRowCtl_NavigationPropertyChanged(object sender, NavPropChangedEventArgs e)
		{
			if (e.Action == NavPropChangedAction.Deleted)
				_assocModels.Remove(e.Assoc);
		}

		private void AssocModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove)
				PopulateRows();
		}

		private void splMain_SplitterMoved(object sender, SplitterEventArgs e)
		{
			foreach (var ctl in _assocGridRows)
				if (ctl is NavPropGridRowCtl)
					((NavPropGridRowCtl)ctl).Col1Width = splMain.SplitterDistance;
		}

		private void splCardinality_SplitterMoved(object sender, SplitterEventArgs e)
		{
			foreach (var ctl in _assocGridRows)
				if (ctl is NavPropGridRowCtl)
					((NavPropGridRowCtl)ctl).Col2Width = splMain.SplitterDistance;
		}

		private void splRelPropName_SplitterMoved(object sender, SplitterEventArgs e)
		{
			foreach (var ctl in _assocGridRows)
				if (ctl is NavPropGridRowCtl)
					((NavPropGridRowCtl)ctl).Col3Width = splMain.SplitterDistance;
		}

		#endregion
	}
}
