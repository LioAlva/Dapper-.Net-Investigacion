using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using DataStreams.Csv;

namespace DemoCSV
{
	public class MainForm : System.Windows.Forms.Form
	{
		private string fileToLoad = "../../../../sample data/products.csv";

		#region Windows Form Designer generated code

		private System.Windows.Forms.DataGrid dataGrid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox XmlTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox CsvTextBox;
		private System.Windows.Forms.Label label1;
		private MenuStrip menuStrip;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem openToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private OpenFileDialog openFileDialog;

		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.XmlTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CsvTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGrid
			// 
			this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid.DataMember = "";
			this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid.Location = new System.Drawing.Point(8, 276);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.Size = new System.Drawing.Size(776, 292);
			this.dataGrid.TabIndex = 0;
			// 
			// XmlTextBox
			// 
			this.XmlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.XmlTextBox.BackColor = System.Drawing.Color.White;
			this.XmlTextBox.Location = new System.Drawing.Point(400, 50);
			this.XmlTextBox.Multiline = true;
			this.XmlTextBox.Name = "XmlTextBox";
			this.XmlTextBox.ReadOnly = true;
			this.XmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.XmlTextBox.Size = new System.Drawing.Size(384, 200);
			this.XmlTextBox.TabIndex = 1;
			this.XmlTextBox.WordWrap = false;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.Location = new System.Drawing.Point(352, 249);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "CSV to DataGrid";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(552, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "CSV to XML";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CsvTextBox
			// 
			this.CsvTextBox.BackColor = System.Drawing.Color.White;
			this.CsvTextBox.Location = new System.Drawing.Point(8, 50);
			this.CsvTextBox.Multiline = true;
			this.CsvTextBox.Name = "CsvTextBox";
			this.CsvTextBox.ReadOnly = true;
			this.CsvTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.CsvTextBox.Size = new System.Drawing.Size(384, 200);
			this.CsvTextBox.TabIndex = 4;
			this.CsvTextBox.WordWrap = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(184, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 24);
			this.label1.TabIndex = 5;
			this.label1.Text = "CSV";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(792, 24);
			this.menuStrip.TabIndex = 6;
			this.menuStrip.Text = "menuStrip";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "csv";
			this.openFileDialog.Filter = "CSV files|*.csv|All files|*.*";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.CsvTextBox);
			this.Controls.Add(this.XmlTextBox);
			this.Controls.Add(this.dataGrid);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.Text = "CsvReader Demo";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			LoadFromFile();
		}

		private void LoadFromFile()
		{
			using (StreamReader reader = new StreamReader(fileToLoad, Encoding.Default))
			{
				CsvTextBox.Text = reader.ReadToEnd();
			}

			using (CsvReader reader = new CsvReader(fileToLoad))
			{
				dataGrid.DataSource = reader.ReadToEnd();
			}

			using (MemoryStream result = new MemoryStream())
			using (CsvReader reader = new CsvReader(fileToLoad))
			{
				XmlTextWriter writer = new XmlTextWriter(result, Encoding.UTF8);

				writer.Formatting = Formatting.Indented;
				writer.IndentChar = '\t';
				writer.Indentation = 1;

				writer.WriteStartDocument();
				writer.WriteStartElement("products");

				reader.ReadHeaders();

				while (reader.ReadRecord())
				{
					writer.WriteStartElement("product");

					for (int i = 0; i < reader.ColumnCount; i++)
					{
						writer.WriteElementString(reader.GetHeader(i).ToLower()[0] + reader.GetHeader(i).Substring(1), reader[i]);
					}

					writer.WriteEndElement();
				}

				writer.WriteEndElement();
				writer.WriteEndDocument();
				writer.Close();

				using (StreamReader resultReader = new StreamReader(new MemoryStream(result.ToArray())))
				{
					XmlTextBox.Text = resultReader.ReadToEnd();
				}
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog.ShowDialog(this);
			if (result == DialogResult.OK && openFileDialog.FileName.Length > 0)
			{
				fileToLoad = openFileDialog.FileName;
				LoadFromFile();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
