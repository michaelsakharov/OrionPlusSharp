
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.IO;
using System.Xml;
using Engine;

namespace Engine
{
	
	public class Language
	{
		private readonly bool _loaded = false;
		private readonly Dictionary<string, Dictionary<string, string>> _loadedStrings = new Dictionary<string, Dictionary<string, string>>();
		internal Language(string filename)
		{
			if (File.Exists(filename))
			{
				XmlDocument xmlDoc = new XmlDocument();
				// Create an XML document object
				xmlDoc.Load(filename);
				// Load the XML document from the specified file
				XmlNodeList nodes = xmlDoc.SelectNodes("//Strings").Item(0).ChildNodes;
				foreach (XmlNode node in nodes)
				{
					if (!(node.NodeType == XmlNodeType.Comment))
					{
						if (!_loadedStrings.ContainsKey(node.Name.ToLower()))
						{
							_loadedStrings.Add(node.Name.ToLower(), new Dictionary<string, string>());
						}
						foreach (XmlNode childNode in node.ChildNodes)
						{
							if (!(childNode.NodeType == XmlNodeType.Comment))
							{
								if (!_loadedStrings[node.Name.ToLower()].ContainsKey(childNode.Attributes["id"].Value.ToLower()))
								{
									_loadedStrings[node.Name.ToLower()].Add(childNode.Attributes["id"].Value.ToLower(), childNode.FirstChild.Value);
								}
							}
						}
					}
				}
				//Try to load it into dictionaries.
				_loaded = true;
			}
		}
		
		internal bool Loaded()
		{
			return _loaded;
		}
		
		internal bool HasString(string section, string id)
		{
			if (_loadedStrings.ContainsKey(section.ToLower()))
			{
				if (_loadedStrings[section.ToLower()].ContainsKey(id.ToLower()))
				{
					return true;
				}
			}
			return false;
		}
		
		internal string GetString(string section, string id, params object[] args)
		{
			try
			{
				return string.Format(System.Convert.ToString(_loadedStrings[section.ToLower()][id.ToLower()]), args);
			}
			catch (FormatException)
			{
				return "Format Exception!";
			}
		}
	}
}
