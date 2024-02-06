using IFC_Converter.ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFC_Converter.App
{
	public partial class Form1 : Form
	{
		private IfcFilter _filter;
		public Form1()
		{
			InitializeComponent();
			_filter = new IfcFilter();
			_filter.Checker = new NameChecker();
			filter_type_comboBox.DataSource = Enum.GetValues(typeof(NameFilterType));
			filter_type_comboBox.SelectedIndex = 0;
			save_btn.Enabled = false;
		}

		private void browse_btn_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path_textBox.Text = openFileDialog1.FileName;
            }
		}

		private void path_textBox_TextChanged(object sender, EventArgs e)
		{
			save_btn.Enabled = FileIfc.Exists(path_textBox.Text);
		}

		private void filter_type_comboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			_filter.Checker.FilterType = (NameFilterType)filter_type_comboBox.SelectedIndex;
			CheckAndFixFilterType();
		}

		private void filter_textBox_TextChanged(object sender, EventArgs e)
		{
			_filter.SearchString = filter_textBox.Text;
			CheckAndFixFilterType();
		}

		private void save_btn_Click(object sender, EventArgs e)
		{
			save_btn.Enabled = false;
			int count = _filter.FilterAndSaveFile(path_textBox.Text);
			MessageBox.Show($"Filtered out {count} objects");
			save_btn.Enabled = true;
		}

		private bool InvalidRegex(string pattern)
		{
			try
			{
				var regex = new Regex(pattern);
				return false;
			}
			catch
			{
				MessageBox.Show("Invalid regex!");
				return true;
			}
		}

		private void CheckAndFixFilterType()
		{
			if (_filter.Checker.FilterType == NameFilterType.Regex_expression)
			{
				if (InvalidRegex(filter_textBox.Text))
				{
					_filter.Checker.FilterType = NameFilterType.Contains_Any;
					filter_type_comboBox.SelectedIndex = 0;
				}
			}
		}

	}
}
