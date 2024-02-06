namespace IFC_Converter.App
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.path_textBox = new System.Windows.Forms.TextBox();
			this.path_label = new System.Windows.Forms.Label();
			this.browse_btn = new System.Windows.Forms.Button();
			this.filter_textBox = new System.Windows.Forms.TextBox();
			this.save_btn = new System.Windows.Forms.Button();
			this.filter_type_comboBox = new System.Windows.Forms.ComboBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// path_textBox
			// 
			this.path_textBox.Location = new System.Drawing.Point(12, 25);
			this.path_textBox.Name = "path_textBox";
			this.path_textBox.Size = new System.Drawing.Size(470, 20);
			this.path_textBox.TabIndex = 0;
			this.path_textBox.TextChanged += new System.EventHandler(this.path_textBox_TextChanged);
			// 
			// path_label
			// 
			this.path_label.AutoSize = true;
			this.path_label.Location = new System.Drawing.Point(12, 9);
			this.path_label.Name = "path_label";
			this.path_label.Size = new System.Drawing.Size(82, 13);
			this.path_label.TabIndex = 1;
			this.path_label.Text = "Path for IFC file:";
			// 
			// browse_btn
			// 
			this.browse_btn.Location = new System.Drawing.Point(497, 25);
			this.browse_btn.Name = "browse_btn";
			this.browse_btn.Size = new System.Drawing.Size(75, 23);
			this.browse_btn.TabIndex = 2;
			this.browse_btn.Text = "Browse";
			this.browse_btn.UseVisualStyleBackColor = true;
			this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
			// 
			// filter_textBox
			// 
			this.filter_textBox.Location = new System.Drawing.Point(232, 66);
			this.filter_textBox.Name = "filter_textBox";
			this.filter_textBox.Size = new System.Drawing.Size(250, 20);
			this.filter_textBox.TabIndex = 3;
			this.filter_textBox.TextChanged += new System.EventHandler(this.filter_textBox_TextChanged);
			// 
			// save_btn
			// 
			this.save_btn.Location = new System.Drawing.Point(497, 64);
			this.save_btn.Name = "save_btn";
			this.save_btn.Size = new System.Drawing.Size(75, 23);
			this.save_btn.TabIndex = 4;
			this.save_btn.Text = "Save IFC";
			this.save_btn.UseVisualStyleBackColor = true;
			this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
			// 
			// filter_type_comboBox
			// 
			this.filter_type_comboBox.FormattingEnabled = true;
			this.filter_type_comboBox.Location = new System.Drawing.Point(15, 66);
			this.filter_type_comboBox.Name = "filter_type_comboBox";
			this.filter_type_comboBox.Size = new System.Drawing.Size(200, 21);
			this.filter_type_comboBox.TabIndex = 5;
			this.filter_type_comboBox.SelectedIndexChanged += new System.EventHandler(this.filter_type_comboBox_SelectedIndexChanged);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 101);
			this.Controls.Add(this.filter_type_comboBox);
			this.Controls.Add(this.save_btn);
			this.Controls.Add(this.filter_textBox);
			this.Controls.Add(this.browse_btn);
			this.Controls.Add(this.path_label);
			this.Controls.Add(this.path_textBox);
			this.Name = "Form1";
			this.Text = "Filter IFC by name";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox path_textBox;
		private System.Windows.Forms.Label path_label;
		private System.Windows.Forms.Button browse_btn;
		private System.Windows.Forms.TextBox filter_textBox;
		private System.Windows.Forms.Button save_btn;
		private System.Windows.Forms.ComboBox filter_type_comboBox;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}

