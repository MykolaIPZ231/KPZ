using QRCoder;
using System.Drawing;

namespace Lab6.Services
{
        public class EmailQRCodeService : QRCodeGeneratorBase
        {
            private readonly string _email;
            private readonly string _subject;

            public EmailQRCodeService(string email, string subject)
            {
                _email = email;
                _subject = subject;
            }

            protected override string GeneratePayload()
            {
                return $"mailto:{_email}?subject={_subject}";
            }
        }
}
