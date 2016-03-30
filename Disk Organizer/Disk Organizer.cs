using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Disk_Organizer
{
    public partial class DiskOrganizer : Form
    {
        //private int _sortColumn = -1;
        public DiskOrganizer()
        {
            InitializeComponent();
        }

        // browse method
        private void Browse_Folder_Click(object sender, EventArgs e)
        {
            var fs = new FolderSelectDialog();
            Folder_Err.Clear();
            var result = fs.ShowDialog();
            if (!result) return;
            Filter.Text = "";
            Folder_Path.Text = fs.FileName;
        }

        // add method used to add new item to the listView
        private void Add(string box, string path, string name, string size)
        {
            string[] row = { box, path, name, size };
            var item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        // initial form load configuration 
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

        // try to delete the checked filse 
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            
            foreach (ListViewItem item in listView1.Items)
            {
                if (!item.Checked) continue;
                try
                {
                    
                    //item.SubItems[2].Text = Folder Path
                    //item.SubItems[1].Text = File Name
                    File.Delete(item.SubItems[2].Text + @"\" + item.SubItems[1].Text);

                }
                catch
                {
                    MessageBox.Show(@"Failed to delete " + item.SubItems[2].Text + @"\" + item.SubItems[1].Text);
                }
            }
            checkBox1.Checked = false;
            Filter.Text = "";
            Query();
            if(List.Count >1 || List.Count == 0)
            Count.Text = List.Count + @" Items in List";
            else Count.Text = List.Count + @" Item in List";
            //GetCout();
        }

        public List<string> List 
        {
            get { return _filtered; }
            set { _filtered = value; }
        }

        private List<string> _filtered = new List<string>();

        // Main method, search for all matching objects in a respective path 
        // if the path is not empty or not invalid run a query matching the filters configured
        private void Query()
        {
            Folder_Err.Clear();
            listView1.Items.Clear();
            var filtered = new List<string>();
            List = filtered;
            // helper List that will be used in leter stage
            
            if (Directory.Exists(Folder_Path.Text))
            {
                // allfiles holds all the files in the given path
                var allfiles = GetFileList("*.*", Folder_Path.Text);

                // searchstrings splite the string given in the Filter Text Field
                var searchstrings = Filter.Text.Split(' ');

                // loop over the allfiles array
                //and filtering only the needed files into Filtered List
                foreach (var name in allfiles)
                {
                    var extension = Path.GetExtension(name);
                    if (extension == null) continue;
                    var ext = extension.ToLower();
                    var fileName = Path.GetFileName(name);
                    if (fileName == null) throw new ArgumentNullException(nameof(fileName));
                    foreach (var arg in searchstrings)
                    {
                        if (!ext.Equals(".mp4") && !ext.Equals(".avi") && !ext.Equals(".mkv")) continue;
                        if (!Path.GetFileName(name.ToLower()).Contains(arg.ToLower())) continue;
                        if (filtered.Contains(name)) continue;
                        filtered.Add(name);
                    }
                }

                // after we finished filtering the files we will add them to the ListView
                foreach (var film in List)
                {
                    var f = new FileInfo(film);
                    var s1 = f.Length;
                    var s2 = (double)s1 / 1024;
                    var size = " KB";
                    if (s1 > 1024 * 1024 && s1 < 1024 * 1024 * 1024)
                    {
                        size = " MB";
                        s2 = (double)s1 / (1024 * 1024);
                    }
                    else if (s1 > 1024 * 1024 * 1024)
                    {
                        size = " GB";
                        s2 = (double)s1 / (1024 * 1024 * 1024);
                    }
                    Add("", Path.GetFileName(film), Path.GetDirectoryName(film), s2.ToString("0.00") + size);
                    
                }
                
                listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                if (List.Count > 1 || List.Count == 0)
                    Count.Text = List.Count + @" Items in List";
                else Count.Text = List.Count + @" Item in List";
            }
            else MessageBox.Show(@"No such Folder");

        }

        // Clear the error provider when Filter text is change
        // if the path is not empty run new query to refrash the results
        private void Filter_TextChanged(object sender, EventArgs e)
        {
            if (!Instant_Match_checkBox.Checked) return;
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
                Query();
                if (List.Count > 1 || List.Count == 0)
                    Count.Text = List.Count + @" Items in List";
                else Count.Text = List.Count + @" Item in List";
            }
        }

        // Clear the error provider when refrash is clicked 
        // also run new query to refrash the results
        private void Set_refrash_btn_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            Query();
            if (List.Count > 1 || List.Count == 0)
                Count.Text = List.Count + @" Items in List";
            else Count.Text = List.Count + @" Item in List";
        }


        // Clear the error provider when folder path change
        private void Folder_Path_TextChanged(object sender, EventArgs e)
        {
            Folder_Err.Clear();
        }
        // Clear the error provider when folder path btn is clicked
        private void Folder_Path_Click(object sender, EventArgs e)
        {
            Folder_Err.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (var i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].Checked = true;
                }
            }
            else
            {
                for (var i = 0; i < listView1.Items.Count; i++)
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

        //private void listView1_ColumnClick(object sender,
        //                           ColumnClickEventArgs e)
        //{
        //    // Determine whether the column is the same as the last column clicked.
        //    if (e.Column != _sortColumn)
        //    {
        //        // Set the sort column to the new column.
        //        _sortColumn = e.Column;
        //        // Set the sort order to ascending by default.
        //        listView1.Sorting = SortOrder.Ascending;
        //    }
        //    else
        //    {
        //        // Determine what the last sort order was and change it.
        //        listView1.Sorting = listView1.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
        //    }

        //    // Call the sort method to manually sort.
        //    //listView1.Sort();

        //    // Set the ListViewItemSorter property to a new ListViewItemComparer object.
        //    listView1.ListViewItemSorter = new ListViewItemComparer(e.Column,
        //                                                      listView1.Sorting);
        //}
        //}

        public static IEnumerable<string> GetFileList(string fileSearchPattern, string rootFolderPath)
        {
            Queue<string> pending = new Queue<string>();
            pending.Enqueue(rootFolderPath);
            string[] tmp;
            while (pending.Count > 0)
            {
                rootFolderPath = pending.Dequeue();
                tmp = Directory.GetFiles(rootFolderPath, fileSearchPattern);
                for (var i = 0; i < tmp.Length; i++)
                {
                    yield return tmp[i];
                }
                tmp = Directory.GetDirectories(rootFolderPath);
                for (var i = 0; i < tmp.Length; i++)
                {
                    pending.Enqueue(tmp[i]);
                }
            }
        }

        private void Instant_Match_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Instant_Match_checkBox.Checked)
            {
                Instant_Match_checkBox.Location = new Point(325, 60);
                Filter_button.Visible = true;
            }
            else
            {
                Filter_button.Visible = false;
                Instant_Match_checkBox.Location = new Point(247, 60);
            }

        }

        private void Filter_button_Click(object sender, EventArgs e)
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
                Query();
                if (List.Count > 1 || List.Count == 0)
                    Count.Text = List.Count + @" Items in List";
                else Count.Text = List.Count + @" Item in List";
            }
        }
    }
}
