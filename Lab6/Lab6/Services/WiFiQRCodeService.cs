using QRCoder;
using System.Drawing;

namespace Lab6.Services
{
    public class WiFiQRCodeService : QRCodeGeneratorBase
    {
        private readonly string _ssid;
        private readonly string _password;
        private readonly string _encryption;

        public WiFiQRCodeService(string ssid, string password, string encryption)
        {
            _ssid = ssid;
            _password = password;
            _encryption = encryption;
        }

        protected override string GeneratePayload()
        {
            return $"WIFI:T:{_encryption};S:{_ssid};P:{_password};;";
        }
    }
}
