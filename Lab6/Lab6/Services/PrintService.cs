using System;
using System.Drawing;
using System.Drawing.Printing;

namespace Lab6.Services
{
    public class PrintService
    {
        public void PrintQRCode(string filePath)
        {
            using (PrintDocument printDoc = new PrintDocument())
            {
                printDoc.PrintPage += (sender, e) =>
                {
                    try
                    {
                        using (var image = Image.FromFile(filePath))
                        {
                            e.Graphics.DrawImage(image, 10, 10, 300, 300);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error printing: {ex.Message}");
                    }
                };
                printDoc.Print();
            }
        }
    }
}