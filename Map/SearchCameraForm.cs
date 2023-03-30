using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map
{
	public partial class SearchCameraForm : Form
	{
		private string _camera;
		private List<string> _maps;

		public SearchCameraForm()
		{
			InitializeComponent();
		}

		public string SelectedMap { get; set; }

		private async void BtnSearchCamera_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			ResetCamera();
			ResetMaps();

			_maps = await Task.Run(() => SearchCamera(tbCamera.Text));

			if (_maps.Count > 0)
			{
				_camera = tbCamera.Text;
				var path = $"cameras\\{_maps.First()}\\{_camera}.jpg";

				try
				{
					imgPreview.Image = Image.FromFile(path);
				}
				catch
				{
					imgPreview.Image = null;
				}

				foreach (string map in _maps)
				{
					var node = new TreeNode
					{
						Text = map,
						ImageIndex = 0,
						SelectedImageIndex = 0
					};
					tvMaps.Nodes.Add(node);
				}
				tvMaps.SelectedNode = tvMaps.Nodes[0];
			}
			else
			{
				MessageBox.Show("Камера не найдена.");
			}

			Cursor = Cursors.Default;
		}

		private void ResetCamera()
		{
			_camera = null;
			imgPreview.Image = null;
		}

		private void ResetMaps()
		{
			SelectedMap = null;
			_maps = new List<string>();
			tvMaps.Nodes.Clear();
		}

		private List<string> SearchCamera(string camera)
		{
			var maps = new List<string>();

			if (!Directory.Exists("cameras"))
			{
				return maps;
			}

			var dirCameras = new DirectoryInfo("cameras");
			foreach (DirectoryInfo directory in dirCameras.GetDirectories())
			{
				foreach (FileInfo file in directory.GetFiles())
				{
					int index = file.Name.LastIndexOf('.');
					string cameraNumber = file.Name.Remove(index);					

					if (cameraNumber == camera)
					{
						maps.Add(directory.Name);
						break;
					}
				}
			}

			return maps;
		}

		private void ImgPreview_DoubleClick(object sender, EventArgs e)
		{
			if (_camera == null)
			{
				return;
			}

			var path = $"cameras\\{_maps.First()}\\{_camera}.jpg";

			if (File.Exists(path))
			{
				Process.Start(path);
			}
		}

		private void TvMaps_AfterSelect(object sender, TreeViewEventArgs e)
		{
			SelectedMap = e.Node.Text;
		}

		private void BtnOpenMap_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				DialogResult = DialogResult.OK;
			}
		}

		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
