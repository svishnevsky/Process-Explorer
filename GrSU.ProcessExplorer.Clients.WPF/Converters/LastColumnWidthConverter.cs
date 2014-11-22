using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace GrSU.ProcessExplorer.Clients.WPF.Converters
{
    public class LastColumnWidthConverter : IValueConverter
    {
        public object Convert(object sender, Type type, object parameter, CultureInfo culture)
        {
            ListView lw = sender as ListView;
            GridView gw = lw.View as GridView;
            double total = gw.Columns
                .Take(gw.Columns.Count - 1)
                .Sum(col => col.ActualWidth);
            return (lw.ActualWidth - total - 50);
        }

        public object ConvertBack(object o, Type type, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
