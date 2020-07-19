﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace LocalImageTagger
{
    /// <summary>
    /// A base value converter than can be directly used in XAML instead of importing as a resource
    /// </summary>
    /// <typeparam name="T">The type of the converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        /// <summary>
        /// A single instance this converter
        /// </summary>
        private static T converter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //Visual studio is recommending a combined assignment, but I am not used to the ?? system well enough to use abbreviations yet
            return converter ?? (converter = new T());
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
