using RestSharp;
using System;
using Domain;
using Newtonsoft.Json;

namespace Enterprise
{
    public class MarsRoverService
    {
        private const string url = "https://api.nasa.gov";
        public Response GetMarsRorverPhoto(string date)
        {
			try
			{
                string urlEndPoint = "/mars-photos/api/v1/rovers/curiosity/photos";
                string urlParameters = $"?earth_date={date}&api_key=DEMO_KEY";
                string link = urlEndPoint + urlParameters;

                var client = new RestClient(url);
                var request = new RestRequest(urlEndPoint + urlParameters, Method.GET);

                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = client.Execute(request);

                return JsonConvert.DeserializeObject<Response>(response.Content.ToString());
            }
            catch (Exception ex)
			{
                Console.WriteLine("Unsuccessful");
			}

            return new Response();            
        }
    }
}



