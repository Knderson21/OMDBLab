using Newtonsoft.Json;
using System.Net;

namespace OMDBAPI.Models
{
    public class MovieDAL
    {
        public MovieModel GetMovie(string title)
        {
            string key = "350805ef"; //this API Key should be hidden
            string url = $"http://www.omdbapi.com/?apikey={key}&t={title}";

            //setup request
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //capture response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //save response data
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();


            //***
            //convert string of JSON into a C# object <--ADJUST--
            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);
            return result;
        }
    }
}
