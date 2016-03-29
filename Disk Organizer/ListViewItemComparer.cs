using System;
using System.Collections;
using System.Windows.Forms;

namespace Disk_Organizer
{
    class ListViewItemComparer : IComparer
    {
        private readonly int _col;
        private readonly SortOrder _order;
        public ListViewItemComparer()
        {
            _col = 0;
            _order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            _col = column;
            _order = order;
        }

        public int Compare(object x, object y)
        {
            int returnVal;
            // Determine whether the type being compared is a date type.
            try
            {
                // Parse the two objects passed as a parameter as a DateTime.
                var firstDate =
                        DateTime.Parse(((ListViewItem)x).SubItems[_col].Text);
                var secondDate =
                        DateTime.Parse(((ListViewItem)y).SubItems[_col].Text);
                // Compare the two dates.
                returnVal = DateTime.Compare(firstDate, secondDate);
            }
            // If neither compared object has a valid date format, compare
            // as a string.
            catch
            {
                // Compare the two items as a string.
                returnVal = string.CompareOrdinal(((ListViewItem)x).SubItems[_col].Text,
                            ((ListViewItem)y).SubItems[_col].Text);
            }
            // Determine whether the sort order is descending.
            if (_order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }
}
