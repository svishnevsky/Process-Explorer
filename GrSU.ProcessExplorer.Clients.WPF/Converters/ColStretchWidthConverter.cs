using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace GrSU.ProcessExplorer.Clients.WPF.Converters
{
    public class ColStretchWidthConverter : IValueConverter
    {
        public object Convert(object sender, Type type, object parameter, CultureInfo culture)
        {
            var lw = sender as ListView;
            var gw = lw.View as GridView;
            var total = gw.Columns
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
