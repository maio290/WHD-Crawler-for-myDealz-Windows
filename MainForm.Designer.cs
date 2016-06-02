// File created on 31.05.2016 at 15:36
namespace WHD_Crawler
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.URL_TextBox = new System.Windows.Forms.TextBox();
			this.Label_URL = new System.Windows.Forms.Label();
			this.Submit = new System.Windows.Forms.Button();
			this.Idealo_Checkbox = new System.Windows.Forms.CheckBox();
			this.Heise_Checkbox = new System.Windows.Forms.CheckBox();
			this.PVL_GroupBox = new System.Windows.Forms.GroupBox();
			this.Output_GroupBox = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Idealo = new System.Windows.Forms.TextBox();
			this.Output = new System.Windows.Forms.TextBox();
			this.Optionen_GroupBox = new System.Windows.Forms.GroupBox();
			this.NewLine_PVL = new System.Windows.Forms.CheckBox();
			this.AppendText = new System.Windows.Forms.CheckBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.Copyright = new System.Windows.Forms.ToolStripStatusLabel();
			this.DL_Progress = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.Euro_Checkbox = new System.Windows.Forms.CheckBox();
			this.PVL_GroupBox.SuspendLayout();
			this.Output_GroupBox.SuspendLayout();
			this.Optionen_GroupBox.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// URL_TextBox
			// 
			this.URL_TextBox.Location = new System.Drawing.Point(79, 26);
			this.URL_TextBox.Name = "URL_TextBox";
			this.URL_TextBox.Size = new System.Drawing.Size(572, 20);
			this.URL_TextBox.TabIndex = 0;
			// 
			// Label_URL
			// 
			this.Label_URL.Location = new System.Drawing.Point(21, 24);
			this.Label_URL.Name = "Label_URL";
			this.Label_URL.Size = new System.Drawing.Size(52, 23);
			this.Label_URL.TabIndex = 1;
			this.Label_URL.Text = "URL:";
			this.Label_URL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Submit
			// 
			this.Submit.Location = new System.Drawing.Point(28, 137);
			this.Submit.Name = "Submit";
			this.Submit.Size = new System.Drawing.Size(630, 23);
			this.Submit.TabIndex = 2;
			this.Submit.Text = "Beginne Crawling";
			this.Submit.UseVisualStyleBackColor = true;
			this.Submit.Click += new System.EventHandler(this.crawl);
			// 
			// Idealo_Checkbox
			// 
			this.Idealo_Checkbox.Checked = true;
			this.Idealo_Checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.Idealo_Checkbox.Location = new System.Drawing.Point(6, 19);
			this.Idealo_Checkbox.Name = "Idealo_Checkbox";
			this.Idealo_Checkbox.Size = new System.Drawing.Size(69, 24);
			this.Idealo_Checkbox.TabIndex = 4;
			this.Idealo_Checkbox.Text = "Idealo";
			this.Idealo_Checkbox.UseVisualStyleBackColor = true;
			this.Idealo_Checkbox.Click += new System.EventHandler(this.Idealo_Clickl);
			// 
			// Heise_Checkbox
			// 
			this.Heise_Checkbox.Location = new System.Drawing.Point(81, 19);
			this.Heise_Checkbox.Name = "Heise_Checkbox";
			this.Heise_Checkbox.Size = new System.Drawing.Size(69, 24);
			this.Heise_Checkbox.TabIndex = 5;
			this.Heise_Checkbox.Text = "Heise";
			this.Heise_Checkbox.UseVisualStyleBackColor = true;
			this.Heise_Checkbox.Click += new System.EventHandler(this.Heise_Click);
			// 
			// PVL_GroupBox
			// 
			this.PVL_GroupBox.Controls.Add(this.Idealo_Checkbox);
			this.PVL_GroupBox.Controls.Add(this.Heise_Checkbox);
			this.PVL_GroupBox.Location = new System.Drawing.Point(461, 19);
			this.PVL_GroupBox.Name = "PVL_GroupBox";
			this.PVL_GroupBox.Size = new System.Drawing.Size(156, 54);
			this.PVL_GroupBox.TabIndex = 6;
			this.PVL_GroupBox.TabStop = false;
			this.PVL_GroupBox.Text = "PVL";
			// 
			// Output_GroupBox
			// 
			this.Output_GroupBox.Controls.Add(this.label2);
			this.Output_GroupBox.Controls.Add(this.Idealo);
			this.Output_GroupBox.Controls.Add(this.Output);
			this.Output_GroupBox.Location = new System.Drawing.Point(678, 12);
			this.Output_GroupBox.Name = "Output_GroupBox";
			this.Output_GroupBox.Size = new System.Drawing.Size(544, 539);
			this.Output_GroupBox.TabIndex = 7;
			this.Output_GroupBox.TabStop = false;
			this.Output_GroupBox.Text = "Output";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 256);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(532, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "PVL - bei mehreren Einträgen:";
			// 
			// Idealo
			// 
			this.Idealo.Location = new System.Drawing.Point(6, 282);
			this.Idealo.Multiline = true;
			this.Idealo.Name = "Idealo";
			this.Idealo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.Idealo.Size = new System.Drawing.Size(532, 251);
			this.Idealo.TabIndex = 1;
			// 
			// Output
			// 
			this.Output.HideSelection = false;
			this.Output.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Output.Location = new System.Drawing.Point(6, 19);
			this.Output.Multiline = true;
			this.Output.Name = "Output";
			this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.Output.Size = new System.Drawing.Size(532, 226);
			this.Output.TabIndex = 0;
			this.Output.WordWrap = false;
			// 
			// Optionen_GroupBox
			// 
			this.Optionen_GroupBox.Controls.Add(this.Euro_Checkbox);
			this.Optionen_GroupBox.Controls.Add(this.NewLine_PVL);
			this.Optionen_GroupBox.Controls.Add(this.AppendText);
			this.Optionen_GroupBox.Controls.Add(this.PVL_GroupBox);
			this.Optionen_GroupBox.Location = new System.Drawing.Point(28, 355);
			this.Optionen_GroupBox.Name = "Optionen_GroupBox";
			this.Optionen_GroupBox.Size = new System.Drawing.Size(623, 190);
			this.Optionen_GroupBox.TabIndex = 8;
			this.Optionen_GroupBox.TabStop = false;
			this.Optionen_GroupBox.Text = "Optionen";
			// 
			// NewLine_PVL
			// 
			this.NewLine_PVL.Location = new System.Drawing.Point(6, 49);
			this.NewLine_PVL.Name = "NewLine_PVL";
			this.NewLine_PVL.Size = new System.Drawing.Size(139, 24);
			this.NewLine_PVL.TabIndex = 10;
			this.NewLine_PVL.Text = "Leerzeile nach PVL";
			this.NewLine_PVL.UseVisualStyleBackColor = true;
			// 
			// AppendText
			// 
			this.AppendText.Location = new System.Drawing.Point(6, 19);
			this.AppendText.Name = "AppendText";
			this.AppendText.Size = new System.Drawing.Size(182, 24);
			this.AppendText.TabIndex = 9;
			this.AppendText.Text = "Text aneinander anhängen";
			this.AppendText.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.Copyright});
			this.statusStrip1.Location = new System.Drawing.Point(0, 559);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1245, 22);
			this.statusStrip1.TabIndex = 9;
			// 
			// Copyright
			// 
			this.Copyright.Name = "Copyright";
			this.Copyright.Size = new System.Drawing.Size(479, 17);
			this.Copyright.Text = "Copyright 2016 - Mario-Luca Hoffmann <github@maio290.de> - Alle Rechte vorbehalte" +
			"n";
			this.Copyright.Click += new System.EventHandler(this.CopyrightClick);
			// 
			// DL_Progress
			// 
			this.DL_Progress.ForeColor = System.Drawing.Color.Green;
			this.DL_Progress.Location = new System.Drawing.Point(118, 70);
			this.DL_Progress.Name = "DL_Progress";
			this.DL_Progress.Size = new System.Drawing.Size(533, 23);
			this.DL_Progress.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "Fortschritt:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Euro_Checkbox
			// 
			this.Euro_Checkbox.Location = new System.Drawing.Point(6, 79);
			this.Euro_Checkbox.Name = "Euro_Checkbox";
			this.Euro_Checkbox.Size = new System.Drawing.Size(139, 24);
			this.Euro_Checkbox.TabIndex = 11;
			this.Euro_Checkbox.Text = "Verwende € statt EUR";
			this.Euro_Checkbox.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1245, 581);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DL_Progress);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.Optionen_GroupBox);
			this.Controls.Add(this.Output_GroupBox);
			this.Controls.Add(this.Submit);
			this.Controls.Add(this.Label_URL);
			this.Controls.Add(this.URL_TextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "WHD-Crawler for myDealz.de";
			this.PVL_GroupBox.ResumeLayout(false);
			this.Output_GroupBox.ResumeLayout(false);
			this.Output_GroupBox.PerformLayout();
			this.Optionen_GroupBox.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox Euro_Checkbox;
		private System.Windows.Forms.CheckBox NewLine_PVL;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar DL_Progress;
		private System.Windows.Forms.ToolStripStatusLabel Copyright;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.CheckBox AppendText;
		private System.Windows.Forms.GroupBox Optionen_GroupBox;
		private System.Windows.Forms.TextBox Idealo;
		private System.Windows.Forms.TextBox Output;
		private System.Windows.Forms.GroupBox Output_GroupBox;
		private System.Windows.Forms.GroupBox PVL_GroupBox;
		private System.Windows.Forms.CheckBox Heise_Checkbox;
		private System.Windows.Forms.CheckBox Idealo_Checkbox;
		private System.Windows.Forms.Button Submit;
		private System.Windows.Forms.Label Label_URL;
		private System.Windows.Forms.TextBox URL_TextBox;
	}
}
