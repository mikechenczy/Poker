using Poker;
using Poker.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Poker.Utils
{
    internal static class DataUtil
    {
        public static void save()
        {
            JObject json = new JObject();
            if (Const.user != null)
            {
                json["username"] = Const.user.username;
                if (Const.autoLogin)
                {
                    json["password"] = Const.user.password;

                }
            }
            json["autoLogin"] = Const.autoLogin;
            json["autoStart"] = Const.autoStart;
            if(Const.neverShowMessageDialog!=null)
            {
                json["neverShowMessageDialog"] = Const.neverShowMessageDialog;
            }
            saveJsonToFile(Program.WorkingDirectory + "\\data.json", json);
        }

        public static void load()
        {
            JObject json = loadJsonFromFile(Program.WorkingDirectory + "\\data.json");
            if (json == null)
                return;
            if (json["autoLogin"] != null)
            {
                Const.autoLogin = (bool)json["autoLogin"];
            }
            if (json["username"] != null)
            {
                Const.username = (string)json["username"];
            }
            if(json["password"]!=null)
            {
                Const.password = (string)json["password"];
            }
            if (json["autoStart"] != null)
            {
                Const.autoStart = (bool)json["autoStart"];
            }
            if (json["neverShowMessageDialog"] != null)
            {
                Const.neverShowMessageDialog = (string)json["neverShowMessageDialog"];
            }
        }

        public static JObject loadJsonFromFile(string path)
        {
            if (!File.Exists(path))
                return null;
            return (JObject)JsonConvert.DeserializeObject(File.ReadAllText(path));
        }

        public static void saveJsonToFile(string path, JObject json)
        {
            if (!File.Exists(path))
            {
                File.Delete(path);
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(json));
        }
    }
}
