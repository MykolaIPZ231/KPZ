using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Services
{
    public abstract class QRCodeGeneratorBase
    {
        protected abstract string GeneratePayload();

        public void GenerateAndSaveQRCode(string filePath)
        {
            string payload = GeneratePayload();
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                using (Bitmap bitmap = qrCode.GetGraphic(20))
                {
                    bitmap.Save(filePath, ImageFormat.Png);
                }
            }
        }
    }
}
