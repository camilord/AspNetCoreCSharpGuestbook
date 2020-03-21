using Nancy.Json;
using Nancy.Json.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.Utils
{
    public class ReCaptchaV2
    {
        string host_verify_url = "https://www.google.com/recaptcha/api/siteverify";

        public bool Verify(string secret, string response, string remoteip)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    var reqparm = new System.Collections.Specialized.NameValueCollection();
                    reqparm.Add("secret", secret);
                    reqparm.Add("response", response);
                    reqparm.Add("remoteip", remoteip);

                    byte[] responsebytes = client.UploadValues(host_verify_url, "POST", reqparm);
                    string responsebody = Encoding.UTF8.GetString(responsebytes);

                    JavaScriptSerializer decoder = new JavaScriptSerializer();
                    JsonObject objData = (JsonObject)decoder.DeserializeObject(responsebody);

                    return (bool)objData["success"];
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
