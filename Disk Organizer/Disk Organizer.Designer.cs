﻿namespace Disk_Organizer
{
    partial class DiskOrganizer
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
            this.components = new System.ComponentModel.Container();
            this.Browes_Folder = new System.Windows.Forms.Button();
            this.Folder_Path = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.Filter = new System.Windows.Forms.TextBox();
            this.Set_refrash_btn = new System.Windows.Forms.Button();
            this.Folder_label = new System.Windows.Forms.Label();
            this.Filter_label = new System.Windows.Forms.Label();
            this.Filter_toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Folder_Err = new System.Windows.Forms.ErrorProvider(this.components);
            this.Check_All = new System.Windows.Forms.CheckBox();
            this.Instant_Match_checkBox = new System.Windows.Forms.CheckBox();
            this.Filter_button = new System.Windows.Forms.Button();
            this.Count = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Folder_Err)).BeginInit();
            this.SuspendLayout();
            // 
            // Browes_Folder
            // 
            this.Browes_Folder.Location = new System.Drawing.Point(245, 19);
            this.Browes_Folder.Name = "Browes_Folder";
            this.Browes_Folder.Size = new System.Drawing.Size(28, 23);
            this.Browes_Folder.TabIndex = 0;
            this.Browes_Folder.Text = "...";
            this.Browes_Folder.UseVisualStyleBackColor = true;
            this.Browes_Folder.Click += new System.EventHandler(this.Browse_Folder_Click);
            // 
            // Folder_Path
            // 
            this.Folder_Path.Location = new System.Drawing.Point(54, 20);
            this.Folder_Path.Name = "Folder_Path";
            this.Folder_Path.Size = new System.Drawing.Size(189, 20);
            this.Folder_Path.TabIndex = 1;
            this.Folder_Path.Click += new System.EventHandler(this.Folder_Path_Click);
            this.Folder_Path.TextChanged += new System.EventHandler(this.Folder_Path_TextChanged);
            this.Folder_Path.DoubleClick += new System.EventHandler(this.Folder_Path_DoubleClick);
            this.Folder_Path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Folder_Path_KeyDown);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.AutoArrange = false;
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(12, 98);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(774, 313);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            // 
            // Delete_btn
            // 
            this.Delete_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_btn.Location = new System.Drawing.Point(683, 416);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(103, 23);
            this.Delete_btn.TabIndex = 3;
            this.Delete_btn.Text = "Delete Selected";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Filter
            // 
            this.Filter.Enabled = false;
            this.Filter.Location = new System.Drawing.Point(54, 57);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(189, 20);
            this.Filter.TabIndex = 4;
            this.Filter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            this.Filter.DoubleClick += new System.EventHandler(this.Filter_DoubleClick);
            this.Filter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Filter_KeyDown);
            // 
            // Set_refrash_btn
            // 
            this.Set_refrash_btn.Location = new System.Drawing.Point(275, 19);
            this.Set_refrash_btn.Name = "Set_refrash_btn";
            this.Set_refrash_btn.Size = new System.Drawing.Size(117, 23);
            this.Set_refrash_btn.TabIndex = 5;
            this.Set_refrash_btn.Text = "Set\\Refresh Folder";
            this.Set_refrash_btn.UseVisualStyleBackColor = true;
            this.Set_refrash_btn.Click += new System.EventHandler(this.Set_refrash_btn_Click);
            // 
            // Folder_label
            // 
            this.Folder_label.AutoSize = true;
            this.Folder_label.Location = new System.Drawing.Point(12, 28);
            this.Folder_label.Name = "Folder_label";
            this.Folder_label.Size = new System.Drawing.Size(39, 13);
            this.Folder_label.TabIndex = 6;
            this.Folder_label.Text = "Folder:";
            // 
            // Filter_label
            // 
            this.Filter_label.AutoSize = true;
            this.Filter_label.Location = new System.Drawing.Point(12, 63);
            this.Filter_label.Name = "Filter_label";
            this.Filter_label.Size = new System.Drawing.Size(32, 13);
            this.Filter_label.TabIndex = 7;
            this.Filter_label.Text = "Filter:";
            // 
            // Folder_Err
            // 
            this.Folder_Err.ContainerControl = this;
            // 
            // Check_All
            // 
            this.Check_All.AutoSize = true;
            this.Check_All.Location = new System.Drawing.Point(18, 105);
            this.Check_All.Name = "Check_All";
            this.Check_All.Size = new System.Drawing.Size(15, 14);
            this.Check_All.TabIndex = 8;
            this.Check_All.UseVisualStyleBackColor = true;
            this.Check_All.CheckedChanged += new System.EventHandler(this.Check_All_CheckedChanged);
            // 
            // Instant_Match_checkBox
            // 
            this.Instant_Match_checkBox.AutoSize = true;
            this.Instant_Match_checkBox.Enabled = false;
            this.Instant_Match_checkBox.Location = new System.Drawing.Point(325, 60);
            this.Instant_Match_checkBox.Name = "Instant_Match_checkBox";
            this.Instant_Match_checkBox.Size = new System.Drawing.Size(91, 17);
            this.Instant_Match_checkBox.TabIndex = 9;
            this.Instant_Match_checkBox.Text = "Instant Match";
            this.Instant_Match_checkBox.UseVisualStyleBackColor = true;
            this.Instant_Match_checkBox.CheckedChanged += new System.EventHandler(this.Instant_Match_checkBox_CheckedChanged);
            // 
            // Filter_button
            // 
            this.Filter_button.Enabled = false;
            this.Filter_button.Location = new System.Drawing.Point(245, 56);
            this.Filter_button.Name = "Filter_button";
            this.Filter_button.Size = new System.Drawing.Size(75, 23);
            this.Filter_button.TabIndex = 10;
            this.Filter_button.Text = "Filter";
            this.Filter_button.UseVisualStyleBackColor = true;
            this.Filter_button.Click += new System.EventHandler(this.Filter_button_Click);
            // 
            // Count
            // 
            this.Count.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Count.AutoSize = true;
            this.Count.Location = new System.Drawing.Point(10, 440);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(0, 13);
            this.Count.TabIndex = 12;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 416);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(665, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Items.AddRange(new object[] {
            "Filter Only By Name",
            "Filter By Full Path"});
            this.comboBox1.Location = new System.Drawing.Point(423, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.Tag = "";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DiskOrganizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 456);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.Filter_button);
            this.Controls.Add(this.Instant_Match_checkBox);
            this.Controls.Add(this.Check_All);
            this.Controls.Add(this.Filter_label);
            this.Controls.Add(this.Folder_label);
            this.Controls.Add(this.Set_refrash_btn);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Folder_Path);
            this.Controls.Add(this.Browes_Folder);
            this.Name = "DiskOrganizer";
            this.Text = "Disk_Organizer";
            this.Load += new System.EventHandler(this.Disk_Organizer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Folder_Err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Browes_Folder;
        private System.Windows.Forms.TextBox Folder_Path;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.TextBox Filter;
        private System.Windows.Forms.Button Set_refrash_btn;
        private System.Windows.Forms.Label Folder_label;
        private System.Windows.Forms.Label Filter_label;
        private System.Windows.Forms.ToolTip Filter_toolTip;
        private System.Windows.Forms.ErrorProvider Folder_Err;
        private System.Windows.Forms.CheckBox Check_All;
        private System.Windows.Forms.Button Filter_button;
        private System.Windows.Forms.CheckBox Instant_Match_checkBox;
        private System.Windows.Forms.Label Count;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}