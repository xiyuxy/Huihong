﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Huihong
{
    class config
    {
        [DllImport("kernel32")] // 写入配置文件的接口
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")] // 读取配置文件的接口
        private static extern int GetPrivateProfileString(
        string section, string key, string def,
        StringBuilder retVal, int size, string filePath);
        // 向配置文件写入值
        public static void Conwr(
        string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }
        // 读取配置文件的值
        public static string ProfileReadValue(
        string section, string key, string path)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", sb, 255, path);
            return sb.ToString().Trim();
        }
    }
}
