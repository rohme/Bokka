using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Bokka
{
    public class MiscTools
    {
        /// <summary>
        /// 正規表現で文字列を検索する
        /// </summary>
        /// <param name="iString">検索対象文字列</param>
        /// <param name="iMatchString">正規表現文字列</param>
        /// <param name="oGroupString">正規表現で取得された文字列のList</param>
        /// <returns>マッチした場合Trueを返す</returns>
        public static bool GetRegexString(string iString, string iMatchString, out List<string> oGroupString)
        {
            oGroupString = new List<string>();
            Regex reg = new Regex(iMatchString, RegexOptions.None);
            Match ma = reg.Match(iString);
            if (ma.Success)
            {
                if (ma.Groups.Count > 1)
                {
                    for (int i = 1; i < ma.Groups.Count; i++)
                    {
                        oGroupString.Add(ma.Groups[i].Value);
                    }
                }
            }
            return ma.Success;
        }
        /// <summary>
        /// アプリケーションタイトルの取得
        /// </summary>
        /// <returns></returns>
        public static string GetAppTitle()
        {
            AssemblyTitleAttribute asmttl = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute));
            return asmttl.Title;
        }
        /// <summary>
        /// アプリケーションのアセンブリ名の取得
        /// </summary>
        /// <returns></returns>
        public static string GetAppAssemblyName()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyName asmn = asm.GetName();
            return asmn.Name;
        }
        /// <summary>
        /// アプリケーションバージョンの取得
        /// </summary>
        /// <returns></returns>
        public static string GetAppVersion()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Version ver = asm.GetName().Version;
            string ret = string.Format("{0}.{1}.{2}", ver.Major, ver.Minor, ver.Build);
            return ret;
        }

        /// <summary>
        /// 整数の乱数を取得する
        /// </summary>
        /// <param name="iFrom">範囲From</param>
        /// <param name="iTo">範囲To</param>
        /// <returns>指定した範囲の整数</returns>
        public static int GetRandomNumber(int iFrom, int iTo)
        {
            int from = 0;
            int to = 0;
            if (iFrom > iTo)
            {
                from = iTo;
                to = iFrom;
            }
            else
            {
                from = iFrom;
                to = iTo;
            }
            Random rnd = new Random();
            return rnd.Next(from, to);
        }
    }
}
