using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Restaurant.UI.Helpers
{
    public static class Serializer<T> where T : class
    {
        public static string JsonSerializer(T obj)
        {
            string output = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });
            return output;
        }

        public static string XmlSterializer(T obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            var subReq = obj;
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString();
                    return xml;
                }
            }
        }
    }
}
