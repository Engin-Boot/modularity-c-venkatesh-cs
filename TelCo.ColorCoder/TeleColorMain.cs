using System;
using System.Drawing;

namespace TelCo.ColorCoder
{
    
    internal class TeleColorCoderMain
    {
       
        /// <summary>
        /// Main
        /// </summary>
        /// </summary>
        public static void Main()
        {
            Tester.TestColor();
            ManualWriter.GenerateAndWriteManualToFile();
        }
    }
}
