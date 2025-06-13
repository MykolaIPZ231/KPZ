using QRCoder;
using System.Drawing;

namespace Lab6.Services
{
    public class ContactQRCodeService : QRCodeGeneratorBase
    {
        private readonly string _name;
        private readonly string _phone;

        public ContactQRCodeService(string name, string phone)
        {
            _name = name;
            _phone = phone;
        }

        protected override string GeneratePayload()
        {
            return $"MECARD:N:{_name};TEL:{_phone};;";
        }
    }
}
