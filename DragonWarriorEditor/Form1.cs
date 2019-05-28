using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DragonWarriorEditor {
	public partial class FormMain : Form {
		string filepath;

		public FormMain() {
			InitializeComponent();
			populateComboBoxSelectMap();
			setFormControlsStatus(false);
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			buttonOpen_Click(sender, e);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			AboutBox1 aboutbox = new AboutBox1();
			aboutbox.ShowDialog();
		}

		private void buttonOpen_Click(object sender, EventArgs e) {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Open file...";
			openFileDialog.Filter = "nes files (*.nes)|*.nes|All files (*.*)|*.*";
			openFileDialog.Multiselect = false;

			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				setFormControlsStatus(true);

				string path = openFileDialog.FileName;
				filepath = path;
				textBoxFileName.Text = path;
			}
		}

		private void populateComboBoxSelectMap() {
			comboBoxSelectMap.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxSelectMap.DataSource = new BindingSource(Definition.MapNames, null);
			comboBoxSelectMap.DisplayMember = "Value";
			comboBoxSelectMap.ValueMember = "Key";

			comboBoxSelectMap.SelectedIndex = 0;
		}

		private void setFormControlsStatus(bool isEnabled) {
			buttonEditMap.Enabled = isEnabled;
			comboBoxSelectMap.Enabled = isEnabled;
		}

		private void buttonEditMap_Click(object sender, EventArgs e) {
			Definition.Map map = (Definition.Map)comboBoxSelectMap.SelectedValue;
			MapForm form = new MapForm(filepath, map);
			form.ShowDialog();
		}
	}
}
