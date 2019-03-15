using System;
using System.Net;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch st = new Stopwatch();

            st.Start();

            string url = "https://uinames.com/api/?ext&amount=50";

            string json = new WebClient().DownloadString(url);



            List<CustomObject> data = new JavaScriptSerializer().Deserialize<List<CustomObject>>(json);

            st.Stop();

            foreach (CustomObject x in data)
            {
                Console.WriteLine("Name: {0} {1}\nGender: {2}\nRegion: {3}\n", x.name, x.surname, x.gender, x.region);
            }
  
            Console.WriteLine("time to populate = {0}", st.ElapsedMilliseconds);

            Console.ReadLine();
        }

        public class CustomObject
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string gender { get; set; }
            public string region { get; set; }

        }
    }
}
