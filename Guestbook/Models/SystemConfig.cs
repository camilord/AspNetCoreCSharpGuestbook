using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guestbook.Models
{
    public class SystemConfig
    {
        public string RecaptchaSecretKey { get; set; }
        public string RecaptchaSiteKey { get; set; }
    }
}
