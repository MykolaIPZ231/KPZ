using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Services
{
    public class TextQRCodeService : QRCodeGeneratorBase
    {
        private readonly string _content;

        public TextQRCodeService(string content)
        {
            _content = content;
        }

        protected override string GeneratePayload()
        {
            return _content;
        }
    }
}
