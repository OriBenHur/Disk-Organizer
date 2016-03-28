﻿using System;
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
        private int sortColumn = -1;
        public Disk_Organizer()
        {
            InitializeComponent();
        }
        //private ListViewColumnSorter lvwColumnSorter;
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

        private void add(string box, string path, string name ,string size)
        {
           
            string[] row = { box, path, name,size};
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void Disk_Organizer_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("", 24);
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Path");
            listView1.Columns.Add("File Size");
            listView1.CheckBoxes = true;
            Filter_toolTip.SetToolTip(Filter, "For multi filter separate the strings with whitespace");
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in listView1.Items)
            {
                if (Item.Checked)
                {
                    try
                    {
                        File.Delete(Item.SubItems[2].Text + "\\" + Item.SubItems[1].Text); 
                    }
                    catch
                    {
                        MessageBox.Show("Failed to delete " + Item.SubItems[2].Text + "\\" + Item.SubItems[1].Text);
                    }
                }
            }
            query();
            checkBox1.Checked = false;
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
                //CheckBox box = new CheckBox();
                
                foreach (string film in Filtered)
                {
                    FileInfo f = new FileInfo(film);
                    long s1 = f.Length;
                    double s2 = (double)s1 / 1024;
                    string size = " KB";
                    if (s1 > 1024*1024 && s1< 1024 * 1024*1024)
                    {
                        size = " MB";
                        s2 = (double)s1 / (1024*1024);
                    }
                    else if (s1 > 1024 * 1024 * 1024)
                    {
                        size = " GB";
                        s2 = (double)s1 / (1024 * 1024 * 1024);
                    }
                    add("", Path.GetFileName(film), Path.GetDirectoryName(film), s2.ToString("0.00") + size);
                }
                listView1.AutoResizeColumn(0,ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);

            }
            else MessageBox.Show("No such Folder");

        }
        private void Filter_TextChanged(object sender, EventArgs e)
        {
            Folder_Err.Clear();
            if (Folder_Path.Text == "")
            {
                Filter.Text = "";
                checkBox1.Checked = false;
                Folder_Err.SetError(Filter, "You must selcet folder first");

            }
            else
            {
                checkBox1.Checked = false;
                query();
            }
        }

        private void Set_refrash_btn_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].Checked = false;
                }

            }
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }

        private void listView1_ColumnClick(object sender,
                                   System.Windows.Forms.ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                listView1.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listView1.Sorting == SortOrder.Ascending)
                    listView1.Sorting = SortOrder.Descending;
                else
                    listView1.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            listView1.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              listView1.Sorting);
        }
    }
}
