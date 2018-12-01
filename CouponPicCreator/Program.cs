using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Drawing.Text;
//using System.Drawing.Drawing2D;
//using System.Drawing.Text;

namespace CuponPicCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            StreamReader reader = new StreamReader(folder + "//cupons.txt");
            string allCupons = reader.ReadToEnd();
            string[] AllCupons = allCupons.Split('\n');
            int cuponCount = AllCupons.Length;
            for (int i = 0; i < cuponCount; i++)
            {

                string cuponText = AllCupons[i].Split(' ')[0];
                // string content = AllCupons[i].Split(' ')[1];
               // string desctiption = "Открывает премииум контент для участников UCTF 2017 Summer";
                // string firstText = "Hello";
                // string secondText = "World";

                string sourceImagePath = folder + "//template.png";
                PointF firstLocation = new PointF(110f, 135f);
               // PointF secondLocation = new PointF(10, 260f);

                string imageFilePath = folder + "//rendered" + $"//picture{i + 1}.png";
                Bitmap bitmap = (Bitmap)Image.FromFile(sourceImagePath);//load the image file
                InstalledFontCollection fontCol = new InstalledFontCollection();
                // for (int x = 0; x <= fontCol.Families.Length - 1; x++)
                //{
                //  Console.WriteLine(fontCol.Families[x].Name);
                //}
                // Console.ReadKey();
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Futura PT Heavy", 50, FontStyle.Bold))
                    {
                        graphics.DrawString(cuponText, arialFont, Brushes.WhiteSmoke, firstLocation);

                    }
                    using (Font arialFont = new Font("Futura PT Heavy", 17, FontStyle.Bold))
                    {
                     //   graphics.DrawString(desctiption, arialFont, Brushes.GhostWhite, secondLocation);
                    }
                    bitmap.Save(imageFilePath);//save the image file
                }
            }

            
        }
    }
}
