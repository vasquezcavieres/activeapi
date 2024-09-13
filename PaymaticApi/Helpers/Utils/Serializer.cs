using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Cl.Intertrade.ActivPay.Helpers.Utils
{
    public class XmlHelper
    {
        #region Methods

        /// <summary>
        /// Deserializes an XML file to the specified type of object.
        /// </summary>
        /// <typeparam name="T">The Type of object to deserialize</typeparam>
        /// <param name="xmlFilePath">The path to the XML file to deserialize</param>
        /// <returns>An object instance</returns>
        public static T DeserializeFromFile<T>(string xmlFilePath) where T : class
        {
            using (var reader = XmlReader.Create(xmlFilePath))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Deserializes an XML string to a specified object.
        /// </summary>
        /// <typeparam name="T">The Type to deserialize</typeparam>
        /// <param name="xmlString">The XML string to deserialize</param>
        /// <returns>An object instance</returns>
        public static T DeserializeFromString<T>(string xmlString, string nodeName) where T : class
        {
            using (var reader = new StringReader(xmlString))
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = nodeName;
                xRoot.Namespace = "";
                xRoot.IsNullable = true;

                var serializer = new XmlSerializer(typeof(T), xRoot);

                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Serializes an object of the specified Type to a file.
        /// </summary>
        /// <typeparam name="T">The Type of the object to serialize</typeparam>
        /// <param name="xmlFilePath">The path to save the XML file to</param>
        /// <param name="objectToSerialize">The object instance to serialize</param>
        public static void SerializeToFile<T>(string xmlFilePath, T objectToSerialize) where T : class
        {
            using (var writer = new StreamWriter(xmlFilePath))
            {
                // Do this to avoid the serializer inserting default XML namespaces.
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                var serializer = new XmlSerializer(objectToSerialize.GetType());
                serializer.Serialize(writer, objectToSerialize, namespaces);
            }
        }

        /// <summary>
        /// Serializes an object of a specified Type to a string.
        /// </summary>
        /// <typeparam name="T">The Type of the object to serialize</typeparam>
        /// <param name="objectToSerialize">The object instance to serialize</param>
        /// <returns>The XML string representation of the object</returns>
        public static string SerializeToString<T>(T objectToSerialize) where T : class
        {
            using (var writer = new StringWriter())
            {
                // Do this to avoid the serializer inserting default XML namespaces.
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                var serializer = new XmlSerializer(objectToSerialize.GetType());
                serializer.Serialize(writer, objectToSerialize, namespaces);

                return writer.ToString();
            }
        }

        #endregion
    }

    public class SerializerUtil
    {
        public static T Deserialize<T>(XmlDocument xmlData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlTextReader reader = new XmlTextReader(new StringReader(xmlData.InnerXml.Replace(" xmlns=\"\"", "")));
            T item = (T)serializer.Deserialize(reader);
            reader.Close();
            return item;
        }

        public static XmlDocument Serialize<T>(T objectSerialize)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            xmlSer.Serialize((TextWriter)writer, objectSerialize);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());
            return doc;
        }

        public static List<T> XmlDeserializeTO<T>(XmlDocument document)
        {
            XmlSerializer xs = new XmlSerializer(typeof(IList<T>));
            XmlTextReader reader = new XmlTextReader(new StringReader(document.ToString()));
            List<T> lst = (List<T>)xs.Deserialize(reader);
            reader.Close();
            return lst;
        }

        public static XmlDocument XmlSerializeTO<T>(IList<T> lst)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<T>));
            Stream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, Encoding.GetEncoding("iso-8859-1"));
            writer.WriteStartDocument(true);
            xs.Serialize((XmlWriter)writer, lst);
            writer.Flush();
            stream.Position = 0L;
            XmlDocument document = new XmlDocument();
            document.Load(stream);
            stream.Close();
            return document;
        }
    }
}
