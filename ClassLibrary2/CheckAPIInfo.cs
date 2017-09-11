using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Layer
{
    public class CheckAPIInfo{

        /// <summary>
        /// Method used to obtain info of the web service defined in References
        /// (implemented as demo)
        /// </summary>
        public static void getGlobalWeatherInfo()
        {
            Console.WriteLine("I can access to WebServiceSoap Project");
        }
        /// <summary>
        /// Method used to obtaint weather info sending a country name as parameter 
        /// (implemented as demo)
        /// </summary>
        /// <param name="country"></param>
        public static void AskGlobalWeatherService(string country)
        {
            Console.WriteLine("***> The country is: '" + country + "'");
            ClassLibrary2.API_Layer.GlobalWeatherSoapClient client =
                new ClassLibrary2.API_Layer.GlobalWeatherSoapClient();
            string getWeatherResult = client.GetCitiesByCountry("Uruguay");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(getWeatherResult.ToString());
            Console.WriteLine("---------------------------------------");

        }
    }
}
