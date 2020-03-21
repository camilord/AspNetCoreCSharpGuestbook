using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guestbook.Utils
{
    public class ReCaptchaV2Response
    {
        public bool success { get; set; }

        public Int64 challenge_ts { get; set; }

        public String hostname { get; set; }

        void setsuccess(bool success) { this.success = success; }

        void setchallenge_ts(Int64 challenge_ts) { this.challenge_ts = challenge_ts; }

        void sethostname(String hostname) { this.hostname = hostname; }

        public bool getResult()
        {
            return success;
        }

        public Int64 getChallengeTS()
        {
            return challenge_ts;
        }

        public String getHostname()
        {
            return hostname;
        }
    }
}
