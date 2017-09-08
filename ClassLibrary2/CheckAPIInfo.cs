using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Layer
{
    public class CheckAPIInfo{

        public static void getGlobalWeatherInfo()
        {
            Console.WriteLine("I can access to WebServiceSoap Project");
            //API_Layer.
        }
        public static void AskGlobalWeatherService(string country)
        {
            Console.WriteLine("***> The country is: '" + country + "'");
            ClassLibrary2.API_Layer.GlobalWeatherSoapClient client =
                new ClassLibrary2.API_Layer.GlobalWeatherSoapClient();
            string getWeatherResult = client.GetCitiesByCountry("Uruguay");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(getWeatherResult.ToString());
            Console.WriteLine("---------------------------------------");

            /*API_Layer myClient =
                new API_Layer.soapClient("GetCitiesByCountry");
            myClient.Open();
            Console.WriteLine(myClient.GetCitiesByCountry("Uruguay").ToString());*/

        }
    }
}
