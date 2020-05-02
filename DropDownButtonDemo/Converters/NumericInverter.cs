using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace DropDownButtonDemo.Converters
{
    /// <summary>
    /// Converts numeric values to their arithmetic negative.
    /// </summary>
    public class NumericInverter : MarkupExtension, IValueConverter
    {
        #region MarkupExtension Members

        /// <summary>
        /// Returns an object that is provided as the value of the target property for the markup extension.
        /// </summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension. Not used.</param>
        /// <returns>The converter instance.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider) { return this; }

        #endregion MarkupExtension Members

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (Type.GetTypeCode(value.GetType()))
            {
                // Signed byte (8-bit)
                case TypeCode.SByte: return -(System.SByte)value;

                // Signed integer (16-bit)
                case TypeCode.Int16: return -(System.Int16)value;

                // Signed integer (32-bit)
                case TypeCode.Int32: return -(System.Int32)value;

                // Signed integer (64-bit)
                case TypeCode.Int64: return -(System.Int64)value;

                // Simple decimal floating-point number
                case TypeCode.Decimal: return -(System.Decimal)value;

                // Single-precision floating-point number
                case TypeCode.Single: return -(System.Single)value;

                // Double-precision floating-point number
                case TypeCode.Double: return -(System.Double)value;

                /// Unsigned numeric objects and non-numeric objects
                /// These data types do not support inversion!
                default: throw new ArithmeticException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Numeric inversion works the same way in both directions
            return Convert(value, targetType, parameter, culture);
        }

        #endregion IValueConverter Members
    }
}
