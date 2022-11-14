using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Random_RGB_Image
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random rng = new Random();
            byte[,,] colors = new byte[3, 1080, 1920];

            for (int color = 0; color < colors.GetLength(0); color++)
            {
                for (int rows = 0; rows < colors.GetLength(1); rows++)
                {
                    for (int col = 0; col < colors.GetLength(2); col++)
                    {
                        colors[color, rows, col] = (byte)rng.Next(0, 255);
                    }
                }
            }

            Bitmap bitmapImage = new Bitmap(colors.GetLength(2), colors.GetLength(1), PixelFormat.Format24bppRgb);

            for(int row = 0; row < bitmapImage.Height; row++)
            {
                for(int col = 0; col < bitmapImage.Width; col++)
                {
                    bitmapImage.SetPixel(col, row, Color.FromArgb(colors[0, row, col] , colors[1, row, col], colors[2, row, col]));
                }
            }

            bitmapImage.Save("Test.png");
    }
    }
}
