using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace LocalImageTagger
{
    //TODO: I got this form a tut video, but I'm not using it. Either use it or remove it. It prevents the need to decalre as a reference.

    /// <summary>
    /// A base value converter than can be directly used in XAML instead of importing as a resource
    /// Call it with Converter={local:ConverterName} directly in the XAML data binding
    /// </summary>
    /// <typeparam name="T">The type of the converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        /// <summary>
        /// A single instance this converter
        /// </summary>
        private static T converter = null;

        /// <summary>
        /// Provides a static instance of the converter
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //Visual studio is recommending a combined assignment, but I am not used to the ?? system well enough to use abbreviations yet
            return converter ?? (converter = new T());
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
