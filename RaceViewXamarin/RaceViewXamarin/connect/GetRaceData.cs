using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace RaceViewXamarin.connect
{
    public class GetRaceData
    {
        public static String DownloadRaceData()
        {
            try
            {
                WebRequest request = HttpWebRequest.Create(Constants.Url);
                request.ContentType = "application/json";
                request.Method = "GET";

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        Debug.WriteLine("GetRaceData - Error fetching data. Server returned status code: {0}", response.StatusCode);
                    }
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (WebException we)
            {
                Debug.WriteLine("DownloadRaceData - WebException: " + we.ToString(), we);
                return null;
            }
        }
    }
}
