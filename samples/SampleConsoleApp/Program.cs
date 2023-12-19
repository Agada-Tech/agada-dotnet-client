using System;
using Agada;
using Agada.Constants;
using Agada.Models;

namespace SampleConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
           Console.WriteLine("Agada Sample Console App");
           Console.ReadLine();

           var client = new AgadaClient(new AgadaOptions(AgadaEnvironment.Sandbox, "YOUR_API_KEY", "en-US", "YOUR_CHANNEL_NAME"));
        }
    }
}