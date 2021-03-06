﻿using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfYoutubetutorial
{
    [ValueConversion(typeof(string),typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {

        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Get the full path
            var path = (string)value;

            //if the path is null,ignore 
            if (path == null)
                return null;

            //Get the Naem of the File/folder

            var name = MainWindow.GetFileFolderName(path);


            //by default,we pressume image
            var image = "images/file.bmp";

            // if the name is blank,we presume it's a drive as we cannot have a blank file or folder name
            if (string.IsNullOrEmpty(name))
                image = "images/drive.bmp";
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "images/folder.bmp";


            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
