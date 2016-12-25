using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


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

        private void Counter()
        {
            if (List.Count > 1 || List.Count == 0) Count.Text = List.Count + @" Items in the List";
            else Count.Text = List.Count + @" Item in the List";
            progressBar1.Value = 0;
        }

        // add method used to add new item to the listView
        private void Add(string box, string index, string path, string name, string size)
        {
            string[] row = { box, index, path, name, size };
            var item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        // initial form load configuration 
        private void Disk_Organizer_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("", 24);
            listView1.Columns.Add("#");
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Path");
            listView1.Columns.Add("File Size");
            listView1.CheckBoxes = true;
            Filter_toolTip.SetToolTip(Filter, "For multi filter separate the search string with commas\nSupport Wildcard");
        }

        // try to delete the checked filse 
        private void Delete_btn_Click(object sender, EventArgs e)
        {

            foreach (ListViewItem item in listView1.Items)
            {
                if (!item.Checked) continue;
                try
                {

                    //item.SubItems[3].Text = Folder Path
                    //item.SubItems[2].Text = File Name
                    File.Delete(item.SubItems[3].Text + @"\" + item.SubItems[2].Text);
                    _allfiles.Remove(item.SubItems[3].Text + @"\" + item.SubItems[2].Text);

                }
                catch
                {
                    MessageBox.Show(@"Failed to delete " + item.SubItems[3].Text + @"\" + item.SubItems[2].Text);
                }
            }
            Check_All.Checked = false;
            //Filter.Text = "";
            Query();
            Counter();
        }

        public IList<string> List
        {
            get { return _filtered; }
            set { _filtered = value; }
        }


        private IList<string> _filtered = new List<string>();
        private IList<string> _allfiles = new List<string>();

        // Main method, search for all matching objects in a respective path 
        // if the path is not empty or not invalid run a query matching the filters configured
        private void Query()
        {
            Folder_Err.Clear();
            listView1.Items.Clear();
            if (Instant_Match_checkBox.Checked)
            {
                Instant_Match_checkBox.Location = new Point(247, 60);
            }
            var filtered = new List<string>();
            List = filtered;
            // helper List that will be used in leter stage
            var filterStr = Filter.Text;
            var searchstrings = Regex.Split(filterStr, @",");

            // loop over the allfiles array
            //and filtering only the needed files into Filtered List
            var i = 1;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = _allfiles.Count;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            if (Filter.Text != "")
            {
                foreach (var name in _allfiles)
                {
                    try
                    {
                        //var extension = Path.GetExtension(name);
                        //if (extension == null) continue;
                        //var ext = extension.ToLower();
                        foreach (var arg in searchstrings)
                        {
                            var filter = arg.Trim();
                            //if (ext.Equals(".mp4") || ext.Equals(".avi") || ext.Equals(".mkv"))
                            //{
                            var isValid = Regex.IsMatch(Path.GetFileName(name), filter, RegexOptions.IgnoreCase);
                            if (isValid)
                            {
                                if (!List.Contains(name) && !List.Contains(name.ToLower()))
                                {
                                    filtered.Add(name);
                                }
                            }
                            //}
                            //else _allfiles.Remove(name);
                            progressBar1.PerformStep();
                        }
                    }

                    catch (Exception e)
                    {
                        var pattern = "[?*]";
                        Match match = Regex.Match(e.Message, pattern);
                        var msg = match.Value;
                        if (e.Message.Contains("Quantifier {x,y} following nothing"))
                        {
                            Folder_Err.SetError(Filter,
                                "'" + msg + "'" +
                                " Cna't be followed by nothing Try putting '.' (dot) in front of it\n aka: ." + msg);
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (var name in _allfiles)
                {
                    filtered.Add(name);
                }
            }
            progressBar1.Minimum = 0;
            progressBar1.Maximum = filtered.Count;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            // after we finished filtering the files we will add them to the ListView
            foreach (var film in filtered)
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
                var co = i++;
                progressBar1.PerformStep();
                Add("", co.ToString(), Path.GetFileName(film), Path.GetDirectoryName(film),
                    s2.ToString("0.00") + size);
            }
            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
            Counter();
            //var file = new FileStream("C:\\TMP\\schedule.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //var sw = new StreamWriter(file);
            //foreach (ListViewItem listItem in listView1.Items)
            //{
            //    sw.WriteLine(listItem.SubItems[1].Text + ";" + listItem.SubItems[2].Text + ";" + listItem.SubItems[3].Text + ";" + listItem.SubItems[4].Text);
            //}
            //sw.Close();
            //file.Close();




        }

        // Clear the error provider when Filter text is change
        // if the path is not empty run new query to refrash the results
        private void Filter_TextChanged(object sender, EventArgs e)
        {
            if (Instant_Match_checkBox.Checked)
            {
                Folder_Err.Clear();
                if (Folder_Path.Text == "")
                {
                    Filter.Text = "";
                    Check_All.Checked = false;
                    Instant_Match_checkBox.Location = new Point(260, 60);
                    Folder_Err.SetError(Filter, "You must selcet folder first");
                    //Thread.Sleep(2000);
                    //Folder_Err.Clear();

                }
                else
                {
                    Check_All.Checked = false;
                    Query();
                    Counter();
                }
            }
        }

        private IList<string> Filteredlist(IList<string> list)
        {
            List<string> tmp = new List<string>();
            foreach (var name in list)
            {
                var extension = Path.GetExtension(name);
                if (extension == null) continue;
                var ext = extension.ToLower();
                if (ext.Equals(".mp4") || ext.Equals(".avi") || ext.Equals(".mkv"))
                {
                    tmp.Add(name);
                }
            }
            return tmp;
        }

        // Clear the error provider when refrash is clicked 
        // also run new query to refrash the results
        private void Set_refrash_btn_Click(object sender, EventArgs e)
        {
            Count.Text = @"0 Items in the List";
            Check_All.Checked = false;
            if (Directory.Exists(Folder_Path.Text))
            {
                _allfiles.Clear();
                _allfiles = Filteredlist(GetFiles(Folder_Path.Text, "*.*"));
                if (_allfiles.Count > 500)
                {
                    DialogResult dr =
                        MessageBox.Show(
                            @"Do you really wanna process " + _allfiles.Count + @" Files?" + Environment.NewLine +
                            @"Take in consider that it will take me some time to process all these files",
                            @"Wow this will take me some time..", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            Query();
                            Filter.Enabled = true;
                            Filter_button.Enabled = true;
                            Instant_Match_checkBox.Enabled = true;
                            break;

                        case DialogResult.No:
                            break;
                    }
                }

                else
                {
                    Query();
                    if (Folder_Path.Text == "") return;
                    Filter.Enabled = true;
                    Filter_button.Enabled = true;
                    Instant_Match_checkBox.Enabled = true;
                }
                //Counter();
            }
            else
            {
                Filter.Enabled = false;
                Filter_button.Enabled = false;
                Instant_Match_checkBox.Enabled = false;
                MessageBox.Show(@"No such Folder");
            }
        }


        // Clear the error provider when folder path change
        private void Folder_Path_TextChanged(object sender, EventArgs e)
        {
            Folder_Err.Clear();
            _allfiles.Clear();
            Filter.Enabled = false;
            Filter_button.Enabled = false;
            Instant_Match_checkBox.Enabled = false;
            if (Instant_Match_checkBox.Checked)
            {
                Instant_Match_checkBox.Location = new Point(247, 60);
            }
        }
        // Clear the error provider when folder path btn is clicked
        private void Folder_Path_Click(object sender, EventArgs e)
        {
            Folder_Err.Clear();
            if (Instant_Match_checkBox.Checked)
            {
                Instant_Match_checkBox.Location = new Point(247, 60);
            }
        }

        private void Check_All_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_All.Checked)
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


        private static IList<string> GetFiles(string path, string pattern)
        {
            var files = new List<string>();

            try
            {
                files.AddRange(Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly));
                foreach (var directory in Directory.GetDirectories(path)) files.AddRange(GetFiles(directory, pattern));
            }
            catch
            {
                Console.WriteLine(@"Opps!");
            }

            return files;
        }


        //public static IEnumerable<string> GetFileList(string fileSearchPattern, string rootFolderPath)
        //{
        //    var list = new List<string>();
        //    try
        //    {
        //        Queue<string> pending = new Queue<string>();
        //        pending.Enqueue(rootFolderPath);

        //        while (pending.Count > 0)
        //        {

        //            rootFolderPath = pending.Dequeue();
        //            var tmp = Directory.GetFiles(rootFolderPath, fileSearchPattern);


        //            for (var i = 0; i < tmp.Length; i++)
        //            {
        //                list.Add(tmp[i]);
        //            }
        //            tmp = Directory.GetDirectories(rootFolderPath);
        //            for (var i = 0; i < tmp.Length; i++)
        //            {
        //                pending.Enqueue(tmp[i]);
        //            }
        //        }

        //        return list;
        //    }
        //    catch
        //    {

        //        Console.WriteLine(@"");
        //    }
        //    return list;
        //}


        private void Instant_Match_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Instant_Match_checkBox.Checked)
            {
                Folder_Err.Clear();
                Instant_Match_checkBox.Location = new Point(325, 60);
                Filter_button.Visible = true;
            }
            else
            {
                Folder_Err.Clear();
                Filter_button.Visible = false;
                Instant_Match_checkBox.Location = new Point(247, 60);
            }

        }

        private void Filter_button_Click(object sender, EventArgs e)
        {
            Count.Text = @"0 Items in the List";
            Folder_Err.Clear();
            if (Instant_Match_checkBox.Checked)
            {
                Instant_Match_checkBox.Location = new Point(247, 60);
            }
            if (Folder_Path.Text == "")
            {
                Filter.Text = "";
                Check_All.Checked = false;
                Folder_Err.SetError(Filter, "You must selcet folder first");

            }
            if (_allfiles.Count == 0)
            {
                Check_All.Checked = false;
                Folder_Err.SetError(Filter, "Please Click on Set\\Refresh Folder Button First");
            }
            else
            {
                Check_All.Checked = false;
                Query();
                //Counter();
            }
        }

        private void Filter_DoubleClick(object sender, EventArgs e)
        {
            Folder_Err.Clear();
            if (Instant_Match_checkBox.Checked)
            {
                Instant_Match_checkBox.Location = new Point(247, 60);
            }
        }

        private void Folder_Path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Set_refrash_btn_Click(sender, e);
        }

        private void Filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Filter_button_Click(sender, e);
        }

        private void Folder_Path_DoubleClick(object sender, EventArgs e)
        {
            if (Folder_Path.Text == "")
            {
                Browse_Folder_Click(sender, e);
            }

            else Folder_Path.SelectAll();

        }


    }
}
