using les_desktop.Model;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace les_desktop.API
{
    public class SystemAPI
    {
        private static string _url = "http://localhost:9999";

        public static DomainEntity Run(DomainEntity aEntity, string path, string method)
        {
            var httpWebRequest = MountRequest(method, path);
            string json = PrepareJsonData(httpWebRequest, aEntity);
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return DeserializeObject(httpResponse, aEntity, path);
        }

        private static DomainEntity DeserializeObject(HttpWebResponse httpResponse, DomainEntity aEntity, string path)
        {
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if(aEntity is User)
                { 
                    User user = JsonConvert.DeserializeObject<User>(result);
                    Authentication authentication = new Authentication
                    {
                        Auth = httpResponse.Headers.Get("Authorization")
                    };
                    user.Authentication = authentication;
                    return user;
                }
                else if(aEntity is Appointment)
                {
                    return JsonConvert.DeserializeObject<Appointment>(result);
                }
                return null;
            }
        }

        private static HttpWebRequest MountRequest(string method, string path)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{_url}/{path}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = method;
            return httpWebRequest;
        }

        private static string PrepareJsonData(HttpWebRequest httpWebRequest, DomainEntity aEntity)
        {
            string json = null;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                if (aEntity is User u)
                {
                    json = $@"{{""email"":""{u.Email}"",""password"":""{u.Password}""}}";
                }
                else if (aEntity is Appointment a)
                { // string para post de apontamento
                    //string json = $@"""email"":""{u.Email}"",""password"":""{u.Password}""";
                }
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            return json;
        }
    }
}
