using System;
using TechTalk.SpecFlow;
using API_Layer;

namespace Test.Steps.API_Steps
{
    [Binding]
    public class ValidateAPISteps
    {
        [Given(@"I have entered (.*) into web service request")]
        public void WebServiceRequestInfo(string city)
        {
            Console.WriteLine("This is the Given......!!!!!: '" + city + "'");
            CheckAPIInfo.getGlobalWeatherInfo();
        }

        [Then(@"the result should contain (.*) inside")]
        public void ShowWebServiceInfo(string stringValidate)
        {
            Console.WriteLine("This is the Then......!!!!!");
            CheckAPIInfo.AskGlobalWeatherService("Uruguay");
            //API_Layer.CheckAPIInfo.AskGlobalWeatherService("Uruguay");
        }
    }
}
