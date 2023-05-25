using System.Xml.Serialization;
using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace Slaveworld
{
    namespace Utils
    {
        public class Xml
        {
            public static void SerializeXml(object data, string filename)
            {
                using (TextWriter sw = new StreamWriter(filename))
                {
                    XmlSerializer xz = new XmlSerializer(data.GetType());
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    xz.Serialize(sw, data, ns);
                }
            }

            public static T DeserializeXml<T>(string filename)
            {
                T obj;
                XmlSerializer xz = new XmlSerializer(typeof(T));
                using (Stream reader = new FileStream(filename, FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                    obj = (T)xz.Deserialize(reader);
                }
                return obj;
            }
        }
    }
}
