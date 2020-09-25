using System;
using System.IO;

namespace TelCo.ColorCoder
{
    internal class ManualWriter
    {
        private static string OutputToFile { get; set; }

        internal static void GenerateAndWriteManualToFile()
        {
            GenerateManual();
            WriteManualToFile();

        }
        private static void WriteManualToFile()
        {
            string filePath = GetFilePath();
            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(OutputToFile);
                sw.Close();
            }
            Console.WriteLine("Manual sucessfully added");
        }

        private static string GetFilePath()
        {
            try
            {
                string fileName = @"\Manual.txt";
                string filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
                return filePath;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in fetching file path");
                throw e;
            }
        }

        private static void GenerateManual()
        {
            int numberOfColors = ColorMaps.colorMapMajor.Length * ColorMaps.colorMapMinor.Length;
            OutputToFile = "Welcome to Number - colorPair mapping file...\n";
            for (int i = 1; i <= numberOfColors; i++)
            {
                ColorPair colorPair = DriverMethods.GetColorFromPairNumber(i);
                string colorPairInString = colorPair.ToString();
                OutputToFile += i + ": " + colorPairInString + "\n";
            }
        }
    }
}
