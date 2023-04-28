using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DotNetAnnuaireClient.CustomControls
{
    public class SalarieRechercheConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2 || !(values[0] is object) || !(values[1] is string))
            {
                return Visibility.Collapsed;
            }

            var obj = values[0];
            var searchString = ((string)values[1]).ToLower();

            if (string.IsNullOrEmpty(searchString))
            {
                return Visibility.Visible;
            }

            var properties = obj.GetType().GetProperties();
            foreach (var prop in properties)
            {

                if (prop.Name.Equals("MotDePasse"))
                {
                    continue;
                }

                var value = prop.GetValue(obj, null);
                if (value != null && value.ToString().ToLower().Contains(searchString))
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
