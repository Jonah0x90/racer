using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace _51Racer
{
    static class API
    {
        static string appDir;
        static string host;
        static string api;
        static string uploads;

        static API()
        {
            appDir = Config.GetShareInstance().GetValue("AppDirPath");
            if (!Directory.Exists(appDir)) Directory.CreateDirectory(appDir);
            host = Config.GetShareInstance().GetValue("HOST");
            uploads = host + "public/uploads/";
            api = Config.GetShareInstance().GetValue("API");
        }

        public static void Install(string uid,string username, string aid,string deviceid)
        {
            EnvInfo.HttpGet(api + "install/?uid=" + uid + "&aid=" + aid + "&username=" + username + "&deviceid=" + deviceid);
        }

        public static List<ImageApp> GetAppList(int type = 1, string ids = "")
        {
            string ext = type == 1 ? ".apk" : ".ipa";
            XmlDocument xmlDom = new XmlDocument();
            string xmlString = EnvInfo.HttpGet(api + "app/platform/" + type + "/ids/" + ids.Replace(',','-'));
            xmlDom.LoadXml(xmlString);
            XmlNode node = xmlDom.ChildNodes[1].ChildNodes[2];
            List<ImageApp> tempList = new List<ImageApp>();
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                string appId = node.ChildNodes[i].SelectSingleNode("cid").InnerText;
                string appName = node.ChildNodes[i].SelectSingleNode("title").InnerText;
                string appPath = appDir + appId + ext;
                string appUrlPath = uploads + node.ChildNodes[i].SelectSingleNode("down_link").InnerText;
                string appImgPath = appDir + appId + ".jpg";
                string appImgUrlPath = uploads + node.ChildNodes[i].SelectSingleNode("thumb").InnerText;
                ImageApp app = new ImageApp(appId, appName, appPath, appUrlPath, appImgPath, appImgUrlPath);
                app.Location = new Point(10 + i * 80, 10);
                tempList.Add(app);
            }
            return tempList;
        }

        public static List<AppPackage> GetPackList(Panel panel)
        {
            XmlDocument xmlDom = new XmlDocument();
            string xmlString = EnvInfo.HttpGet(api + "package");
            xmlDom.LoadXml(xmlString);
            XmlNode node = xmlDom.ChildNodes[1].ChildNodes[2];
            List<AppPackage> tempList = new List<AppPackage>();
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                string packName = node.ChildNodes[i].SelectSingleNode("title").InnerText;
                string ids = node.ChildNodes[i].SelectSingleNode("description").InnerText;
                List<ImageApp> apps = API.GetAppList(1, ids);
                AppPackage pack = new AppPackage(packName, apps, panel);
                pack.Location = new Point(10 + i * 180, 9);
                tempList.Add(pack);
            }
            return tempList;
        }
    }
}
