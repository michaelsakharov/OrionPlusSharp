using System.Windows.Forms;
using System.IO;

namespace Engine
{
    internal sealed class Strings
    {
        private Strings()
        {
        }

        internal enum LupusComponent
        {
            Client = 0,
            Editor,
            Server
        }

        private static Language _defaultLanguage;
        private static Language _selectedLanguage;

        internal static void Init(LupusComponent component, string language)
        {
            string path = Application.StartupPath + @"\Data\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path += @"Languages\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            _defaultLanguage = new Language(path + component.ToString() + "_English.xml");
            string fPath = path + component.ToString() + "_" + language + ".xml";
            if (File.Exists(fPath))
                _selectedLanguage = new Language(fPath);
        }

        internal static string Get(string section, string id, params object[] args)
        {
            if (_selectedLanguage != null && _selectedLanguage.Loaded() && _selectedLanguage.HasString(section, id))
                return _selectedLanguage.GetString(section, id, args);
            if (_defaultLanguage != null && _defaultLanguage.Loaded() && _defaultLanguage.HasString(section, id))
                return _defaultLanguage.GetString(section, id, args);
            return "Not Found";
        }
    }
}
