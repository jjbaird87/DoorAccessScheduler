using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DoorOpenAccessScheduler.Helpers
{
    internal static class Utils
    {
        public static string SerializeObject<T>(T pObject)
        {
            var memoryStream = new MemoryStream();

            var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            try
            {
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(xmlTextWriter, pObject);


                var doc = new XmlDocument();
                memoryStream.Position = 0;
                doc.Load(memoryStream);
                memoryStream.Close();
                // strip out default namespaces "xmlns:xsi" and "xmlns:xsd"
                doc.DocumentElement?.Attributes.RemoveAll();

                var sw = new StringWriter();
                var xw = new XmlTextWriter(sw);
                doc.WriteTo(xw);

                return sw.ToString();
            }
            finally
            {
                memoryStream.Close();
                xmlTextWriter.Close();
            }
        }

        public static T DeserializeObject<T>(string xmlString)
        {
            if (string.IsNullOrWhiteSpace(xmlString))
                return default(T);

            using (var memStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(memStream);
            }
        }        
    }
}
