using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FolderSelect;
using System.IO;

namespace Disk_Organizer
{
    public partial class Disk_Organizer : Form
    {
        public Disk_Organizer()
        {
            InitializeComponent();
        }

        private void Browes_Folder_Click(object sender, EventArgs e)
        {

            FolderSelectDialog fs = new FolderSelectDialog();
            Folder_Err.Clear();
            bool result = fs.ShowDialog();
            if (result)
            {
                //listView1.Clear();
                Folder_Path.Text = fs.FileName;
            }
            else
            {
                return;
            }
        }

        private void add(string path, string name)
        {
            string[] row = { path, name };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void Disk_Organizer_Load(object sender, EventArgs e)
        {
            //Filter.Text = "*";
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Name", 250);
            listView1.Columns.Add("Path", 300);
            Filter_toolTip.SetToolTip(Filter, "For Multi Filter seperate the strings with white spase");
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in listView1.Items)
            {
                if (Item.Checked)
                {
                    try
                    {
                        File.Delete(Item.SubItems[1].Text + "\\" + Item.SubItems[0].Text);
                        query();
                    }
                    catch
                    {
                        MessageBox.Show("Failed to delete " + Item.SubItems[1].Text + "\\" + Item.SubItems[0].Text);
                    }
                }
            }
        }

        private void query()
        {
            Folder_Err.Clear();
            listView1.Items.Clear();
            if (Directory.Exists(Folder_Path.Text))
            {
                string[] allfiles = Directory.GetFiles(Folder_Path.Text, "*.*", SearchOption.AllDirectories);
                string[] searchstrings = Filter.Text.Split(' ');
                List<string> videos = new List<string>();
                List<string> Filtered = new List<string>();

                foreach (string name in allfiles)
                {
                    string ext = Path.GetExtension(name).ToLower();
                    string FileName = Path.GetFileName(name);
                    foreach (string arg in searchstrings)
                    {
                        if (ext.Equals(".mp4") || ext.Equals(".avi") || ext.Equals(".mkv"))
                        {
                            if (Path.GetFileName(name.ToLower()).Contains(arg.ToLower()))
                            {
                                if (!Filtered.Contains(name)) Filtered.Add(name);
                            }
                        }
                    }
                }

                foreach (string film in Filtered) add(Path.GetFileName(film), Path.GetDirectoryName(film));
            }
            else MessageBox.Show("No such Folder");

        }
        private void Filter_TextChanged(object sender, EventArgs e)
        {
            Folder_Err.Clear();
            if (Folder_Path.Text == "")
                Folder_Err.SetError(Filter, "You must selcet folder first");
            else query();
        }

        private void Set_refrash_btn_Click(object sender, EventArgs e)
        {
            query();
        }

        private void Folder_Path_TextChanged(object sender, EventArgs e)
        {
            Folder_Err.Clear();
        }

        private void Folder_Path_Click(object sender, EventArgs e)
        {
            Folder_Err.Clear();
        }
    }
}
