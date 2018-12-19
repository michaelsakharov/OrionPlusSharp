using System.IO;
using System.Text;
using System.Xml;

namespace Engine
{
    internal class XmlClass
    {
        private XmlDocument xmlDoc = new XmlDocument();

        internal string Root { get; set; } = "Settings";
        internal string Filename { get; set; } = Microsoft.VisualBasic.Constants.vbNullString;

        public void NewXmlDocument()
        {
            XmlTextWriter xmlTextWrite = new XmlTextWriter(Filename, Encoding.UTF8);

            // Write blank xml document.
            {
                ref var withBlock = ref xmlTextWrite;
                withBlock.WriteStartDocument(true);
                withBlock.WriteStartElement(Root);
                withBlock.WriteEndElement();
                withBlock.WriteEndDocument();
                withBlock.Flush();
                withBlock.Close();
            }
        }

        internal void WriteString(string Selection, string name, string value)
        {
            // Dim xmlDoc As New XmlDocument()

            // Check if xml filename is here.
            if (!File.Exists(Filename))
                // Create new blank xml file.
                NewXmlDocument();

            // Load xml document.
            // xmlDoc.Load(Me.Filename)

            // Check for settings selection.
            if (xmlDoc.SelectSingleNode(Root + "/" + Selection) == null)
                // Create selection.
                xmlDoc.DocumentElement.AppendChild((XmlNode)xmlDoc.CreateElement(Selection));

            // Check for element node
            XmlNode xmlNode = xmlDoc.SelectSingleNode(Root + "/" + Selection + "/Element[@Name='" + name + "']");

            if (xmlNode == null)
            {
                XmlElement element = xmlDoc.CreateElement("Element");
                // Write new element values.
                element.SetAttribute("Name", name);
                element.SetAttribute("Value", value);
                // Add new node.
                xmlDoc.DocumentElement[Selection].AppendChild((XmlNode)element);
            }
            else
            {
                // Update node values.
                xmlNode.Attributes["Name"].Value = name;
                xmlNode.Attributes["Value"].Value = value;
            }
        }

        internal string ReadString(string Selection, string name, string defaultValue = "")
        {
            // Dim xmlDoc As New XmlDocument()

            if (!File.Exists(Filename))
                return defaultValue;
            else
            {
                // Load xml document.
                // xmlDoc.Load(Filename)
                // Read node value.
                var XmlNode = xmlDoc.SelectSingleNode(Root + "/" + Selection + "/Element[@Name='" + name + "']");

                // Check if node is here.
                if (XmlNode == null)
                    return defaultValue;
                else
                    // Return xml node value
                    return (XmlNode.Attributes["Value"].Value);
            }
        }

        internal void RemoveNode(string Selection, string name)
        {
            // Dim xmlDoc As New XmlDocument()

            // Remove xml node
            if (File.Exists(Filename))
            {
                // Load xml document.
                // xmlDoc.Load(Filename)
                // Read node value.
                var XmlNode = xmlDoc.SelectSingleNode(Root + "/" + Selection + "/Element[@Name='" + name + "']");
                // Check if node is here.
                if (!(XmlNode == null))
                    xmlDoc.SelectSingleNode(Root + "/" + Selection).RemoveChild(XmlNode);
            }
        }

        internal void LoadXml()
        {
            // Load xml document.
            xmlDoc.Load(Filename);
        }

        internal void CloseXml(bool Save)
        {
            if (Save)
                // Update xml document.
                xmlDoc.Save(Filename);
            // Clean up
            xmlDoc = null;
        }
    }
}
