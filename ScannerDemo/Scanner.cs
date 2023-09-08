using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WIA;
using System.Windows.Forms;

namespace ScannerDemo
{
    class Scanner
    {
        private readonly DeviceInfo _deviceInfo;
        private int resolution = 150;
        private int width_pixel = 1250;
        private int height_pixel = 1700;
        private int color_mode = 1;
        const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
        public Scanner(DeviceInfo deviceInfo)
        {
            this._deviceInfo = deviceInfo;
        }
 
        /// <summary>
        /// Scan a image with PNG Format
        /// </summary>
        /// <returns></returns>
        public ImageFile ScanPNG()
        {
            // Connect to the device and instruct it to scan
            // Connect to the device
            var device = this._deviceInfo.Connect();

            // Select the scanner
            CommonDialogClass dlg = new CommonDialogClass(); 

            var item = device.Items[1];

            try
            {
                SetWIAProperty(item.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, 200);

                object scanResult = dlg.ShowTransfer(item, WIA.FormatID.wiaFormatPNG, true);

                if(scanResult != null)
                {
                    var imageFile = (ImageFile)scanResult;

                    // Return the imageFile
                    return imageFile;
                }
            }
            catch (COMException e)
            {
                // Display the exception in the console.
                Console.WriteLine(e.ToString());

                uint errorCode = (uint)e.ErrorCode;

                // Catch 2 of the most common exceptions
                if (errorCode ==  0x80210006)
                {
                    MessageBox.Show("The scanner is busy or isn't ready");
                }else if(errorCode == 0x80210064)
                {
                    MessageBox.Show("The scanning process has been cancelled.");
                }else
                {
                    MessageBox.Show("A non catched error occurred, check the console","Error",MessageBoxButtons.OK);
                }
            }

            return new ImageFile();
        }

        /// <summary>
        /// Scan a image with JPEG Format
        /// </summary>
        /// <returns></returns>
        public ImageFile ScanJPEG()
        {
            // Connect to the device and instruct it to scan
            // Connect to the device
            var device = this._deviceInfo.Connect();

            // Select the scanner
            CommonDialogClass dlg = new CommonDialogClass();

            var item = device.Items[1];
            
            try
            {

                SetWIAProperty(item.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, 200);

                object scanResult = dlg.ShowTransfer(item, WIA.FormatID.wiaFormatJPEG, true);

                if (scanResult != null)
                {
                    var imageFile = (ImageFile)scanResult;

                    // Return the imageFile
                    return imageFile;
                }
            }
            catch (COMException e)
            {
                // Display the exception in the console.
                Console.WriteLine(e.ToString());

                uint errorCode = (uint)e.ErrorCode;

                // Catch 2 of the most common exceptions
                if (errorCode == 0x80210006)
                {
                    MessageBox.Show("The scanner is busy or isn't ready");
                }
                else if (errorCode == 0x80210064)
                {
                    MessageBox.Show("The scanning process has been cancelled.");
                }
                else
                {
                    MessageBox.Show("A non catched error occurred, check the console", "Error", MessageBoxButtons.OK);
                }
            }

            return new ImageFile();
        }

        /// <summary>
        /// Scan a image with TIFF Format
        /// </summary>
        /// <returns></returns>
        public ImageFile ScanTIFF()
        {
            // Connect to the device and instruct it to scan
            // Connect to the device
            var device = this._deviceInfo.Connect();

            // Select the scanner
            CommonDialogClass dlg = new CommonDialogClass();

            var item = device.Items[1];

            try
            {
                SetWIAProperty(item.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, 200);

                object scanResult = dlg.ShowTransfer(item, WIA.FormatID.wiaFormatTIFF, true);

                if (scanResult != null)
                {
                    var imageFile = (ImageFile)scanResult;

                    // Return the imageFile
                    return imageFile;
                }
            }
            catch (COMException e)
            {
                // Display the exception in the console.
                Console.WriteLine(e.ToString());

                uint errorCode = (uint)e.ErrorCode;

                // Catch 2 of the most common exceptions
                if (errorCode == 0x80210006)
                {
                    MessageBox.Show("The scanner is busy or isn't ready");
                }
                else if (errorCode == 0x80210064)
                {
                    MessageBox.Show("The scanning process has been cancelled.");
                }
                else
                {
                    MessageBox.Show("A non catched error occurred, check the console", "Error", MessageBoxButtons.OK);
                }
            }

            return new ImageFile();
        }

        
       

        
        private static void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }

        /// <summary>
        /// Declare the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (string) this._deviceInfo.Properties["Name"].get_Value();
        }
         
    }
}
