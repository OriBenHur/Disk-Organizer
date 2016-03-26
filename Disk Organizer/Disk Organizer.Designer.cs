namespace Disk_Organizer
{
    partial class Disk_Organizer
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
            this.Browes_Folder = new System.Windows.Forms.Button();
            this.Folder_Path = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.Filter = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Browes_Folder
            // 
            this.Browes_Folder.Location = new System.Drawing.Point(208, 25);
            this.Browes_Folder.Name = "Browes_Folder";
            this.Browes_Folder.Size = new System.Drawing.Size(28, 23);
            this.Browes_Folder.TabIndex = 0;
            this.Browes_Folder.Text = "...";
            this.Browes_Folder.UseVisualStyleBackColor = true;
            this.Browes_Folder.Click += new System.EventHandler(this.Browes_Folder_Click);
            // 
            // Folder_Path
            // 
            this.Folder_Path.Location = new System.Drawing.Point(13, 27);
            this.Folder_Path.Name = "Folder_Path";
            this.Folder_Path.Size = new System.Drawing.Size(189, 20);
            this.Folder_Path.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(12, 98);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(774, 280);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Delete_btn
            // 
            this.Delete_btn.Location = new System.Drawing.Point(683, 384);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(103, 23);
            this.Delete_btn.TabIndex = 3;
            this.Delete_btn.Text = "Delete Selected";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(13, 63);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(189, 20);
            this.Filter.TabIndex = 4;
            this.Filter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Set Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Disk_Organizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 419);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Folder_Path);
            this.Controls.Add(this.Browes_Folder);
            this.Name = "Disk_Organizer";
            this.Text = "Disk_Organizer";
            this.Load += new System.EventHandler(this.Disk_Organizer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Browes_Folder;
        private System.Windows.Forms.TextBox Folder_Path;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.TextBox Filter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}