using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bokka
{
    public class Settings
    {

        public int BaseWait { get; set; }
        public int ChatWait { get; set; }
        public int FormPosX { get; set; }
        public int FormPosY { get; set; }
        public int TicketUseEach { get; set; }
        public int LimitTicket { get; set; }
        public int LimitCp { get; set; }
        public int MenuIndexWorksCall { get; set; }
        public int MenuIndexArea { get; set; }
        public int MenuIndexBivouac { get; set; }
        //public List<SettingsRunPointPosProperty> RunPoint { get; set; }
        //public List<SettingsNpcProperty> Npc { get; set; }
        //public List<SettingsKeyItemProperty> KeyItem { get; set; }

        //定数
        private const string XML_FILENAME_SETTINGS = "Bokka.xml";
        //private const string XML_FILENAME_DATA = "BokkaData.xml";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="iPlayerName"></param>
        public Settings(string iPlayerName)
        {
            //設定読み込み
            Load(iPlayerName);
        }
        /// <summary>
        /// 設定読み込み
        /// </summary>
        /// <param name="iPlayerName"></param>
        /// <returns></returns>
        public bool Load(string iPlayerName)
        {
            //Bokka.xmlの読み込み
            string xmlFilename = XML_FILENAME_SETTINGS;
            SettingsProperty xmlSettings = new SettingsProperty();
            if (File.Exists(xmlFilename))
            {
                FileStream fs = new FileStream(xmlFilename, System.IO.FileMode.Open);
                //シリアライズ
                XmlSerializer serializer = new XmlSerializer(typeof(SettingsProperty));
                //読み込み
                xmlSettings = (SettingsProperty)serializer.Deserialize(fs);
                fs.Close();
            }
            //メンバに設定
            BaseWait = xmlSettings.BaseWait;
            ChatWait = xmlSettings.ChatWait;
            bool foundFlg = false;
            foreach (SettingsPlayerProperty v in xmlSettings.Player)
            {
                if (v.Name == iPlayerName)
                {
                    foundFlg = true;
                    FormPosX = v.FormPosX;
                    FormPosY = v.FormPosY;
                    TicketUseEach = v.TicketUseEach;
                    LimitTicket = v.LimitTicket;
                    LimitCp = v.LimitCp;
                    MenuIndexWorksCall = v.MenuIndexWorksCall;
                    MenuIndexArea = v.MenuIndexArea;
                    MenuIndexBivouac = v.MenuIndexBivouac;
                }
            }
            if (!foundFlg)
            {
                SettingsPlayerProperty player = new SettingsPlayerProperty();
                FormPosX = player.FormPosX;
                FormPosY = player.FormPosY;
                TicketUseEach = player.TicketUseEach;
                LimitTicket = player.LimitTicket;
                LimitCp = player.LimitCp;
                MenuIndexWorksCall = player.MenuIndexWorksCall;
                MenuIndexArea = player.MenuIndexArea;
                MenuIndexBivouac = player.MenuIndexBivouac;
            }

            //BokkaData.xmlの読み込み
            //xmlFilename = XML_FILENAME_DATA;
            //if (File.Exists(xmlFilename))
            //{
            //    FileStream fs = new FileStream(xmlFilename, System.IO.FileMode.Open);
            //    //シリアライズ
            //    XmlSerializer serializer = new XmlSerializer(typeof(SettingDataProperty));
            //    //読み込み
            //    SettingDataProperty xmlData = (SettingDataProperty)serializer.Deserialize(fs);
            //    fs.Close();

            //    //メンバに設定
            //    RunPoint = new List<SettingsRunPointPosProperty>();
            //    foreach (SettingsRunPointPosProperty v in xmlData.RunPoint) RunPoint.Add(v);
            //    Npc = new List<SettingsNpcProperty>();
            //    foreach (SettingsNpcProperty v in xmlData.Npc) Npc.Add(v);
            //    KeyItem = new List<SettingsKeyItemProperty>();
            //    foreach (SettingsKeyItemProperty v in xmlData.KeyItem) KeyItem.Add(v);
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }
        /// <summary>
        /// 設定保存
        /// </summary>
        /// <param name="iPlayerName"></param>
        /// <returns></returns>
        public bool Save(string iPlayerName)
        {
            //設定の読み込み
            string xmlFilename = XML_FILENAME_SETTINGS;
            XmlSerializer serializer;
            SettingsProperty xmlSettings = new SettingsProperty();
            if (File.Exists(xmlFilename))
            {
                FileStream fs = new FileStream(xmlFilename, System.IO.FileMode.Open);
                //シリアライズ
                serializer = new XmlSerializer(typeof(SettingsProperty));
                //読み込み
                xmlSettings = (SettingsProperty)serializer.Deserialize(fs);
                fs.Close();
            }

            //保存データ設定
            bool foundFlg = false;
            foreach (SettingsPlayerProperty v in xmlSettings.Player)
            {
                if (v.Name == iPlayerName)
                {
                    foundFlg = true;
                    v.FormPosX = FormPosX;
                    v.FormPosY = FormPosY;
                    v.TicketUseEach = TicketUseEach;
                    v.LimitTicket = LimitTicket;
                    v.LimitCp = LimitCp;
                    v.MenuIndexWorksCall = MenuIndexWorksCall;
                    v.MenuIndexArea = MenuIndexArea;
                    v.MenuIndexBivouac = MenuIndexBivouac;
                }
            }
            if (!foundFlg)
            {
                SettingsPlayerProperty player = new SettingsPlayerProperty();
                player.Name = iPlayerName;
                player.FormPosX = FormPosX;
                player.FormPosY = FormPosY;
                player.TicketUseEach = TicketUseEach;
                player.LimitTicket = LimitTicket;
                player.LimitCp = LimitCp;
                player.MenuIndexWorksCall = MenuIndexWorksCall;
                player.MenuIndexArea = MenuIndexArea;
                player.MenuIndexBivouac = MenuIndexBivouac;
                xmlSettings.Player.Add(player);
            }

            //設定の保存
            StreamWriter sw = new StreamWriter(xmlFilename, false, new UTF8Encoding(false));
            //名前空間出力抑制
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(String.Empty, String.Empty);
            //シリアライズ
            serializer = new XmlSerializer(typeof(SettingsProperty));
            serializer.Serialize(sw, xmlSettings, ns);
            //書き込み
            sw.Flush();
            sw.Close();
            sw = null;
            return true;
        }
    }
    [XmlRoot("Bokka")]
    public class SettingsProperty
    {
        public int BaseWait { get; set; }
        public int ChatWait { get; set; }
        public Boolean UseEnternity { get; set; }
        [XmlArray("Players")]
        [XmlArrayItem("Player")]
        public List<SettingsPlayerProperty> Player { get; set; }

        public SettingsProperty()
        {
            BaseWait = 300;
            ChatWait = 1000;
            UseEnternity = true;
            Player = new List<SettingsPlayerProperty>();
        }
    }
    public class SettingsPlayerProperty
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        public int FormPosX { get; set; }
        public int FormPosY { get; set; }
        public int TicketUseEach { get; set; }
        public int LimitTicket { get; set; }
        public int LimitCp { get; set; }
        public int MenuIndexWorksCall { get; set; }
        public int MenuIndexArea { get; set; }
        public int MenuIndexBivouac { get; set; }
        public SettingsPlayerProperty()
        {
            FormPosX = 0;
            FormPosY = 0;
            TicketUseEach = 1;
            LimitTicket = 0;
            LimitCp = 1000;
            MenuIndexWorksCall = -1;
            MenuIndexArea = -1;
            MenuIndexBivouac = -1;
        }
    }

    [XmlRoot("BokkaData")]
    public class SettingDataProperty
    {
        [XmlArray("RunPointData")]
        [XmlArrayItem("RunPoint")]
        public List<SettingsRunPointPosProperty> RunPoint { get; set; }
        [XmlArray("NpcData")]
        [XmlArrayItem("Npc")]
        public List<SettingsNpcProperty> Npc { get; set; }
        [XmlArray("KeyItemData")]
        [XmlArrayItem("KeyItem")]
        public List<SettingsKeyItemProperty> KeyItem { get; set; }

        public SettingDataProperty()
        {
            RunPoint = new List<SettingsRunPointPosProperty>();
            Npc = new List<SettingsNpcProperty>();
            KeyItem = new List<SettingsKeyItemProperty>();
        }
    }
    public class SettingsRunPointPosProperty
    {
        [XmlAttribute("X")]
        public float X { get; set; }
        [XmlAttribute("Y")]
        public float Y { get; set; }
        [XmlAttribute("Z")]
        public float Z { get; set; }
        public SettingsRunPointPosProperty()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
    }
    public class SettingsNpcProperty
    {
        [System.Xml.Serialization.XmlAttribute("ZoneId")]
        public int ZoneId { get; set; }
        [System.Xml.Serialization.XmlAttribute("WayPointId")]
        public short WayPointId { get; set; }
        [System.Xml.Serialization.XmlAttribute("AdministratorId")]
        public short AdministratorId { get; set; }
        public SettingsNpcProperty()
        {
            ZoneId = 0;
            WayPointId = 0;
            AdministratorId = 0;
        }
    }
    public class SettingsKeyItemProperty
    {
        [System.Xml.Serialization.XmlAttribute("Id")]
        public int Id { get; set; }
        [System.Xml.Serialization.XmlAttribute("Enable")]
        public bool Enable { get; set; }
        public SettingsKeyItemProperty()
        {
            Id = 0;
            Enable = false;
        }
    }
}
