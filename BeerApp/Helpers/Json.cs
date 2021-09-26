using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Helpers
{
    public class Json
    {
        public static void JsonSerialization(List<string> text)
        {

            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("History.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, text);
                }
            }
        }


        public static void JsonDeserialize(List<string> t)
        {
            List<string> texts = null;
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader("History.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    texts = serializer.Deserialize<List<string>>(jr);
                }
               
            }
            foreach (var item in texts)
            {
                t.Add(item);
            }
        }
    }
}
