﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common.Str
{
    public class DESEncrypt
    {
        #region 秘钥
        private string key = "90ioklnm";
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }
        #endregion

        #region 构造函数
        public DESEncrypt(string k)
        {
            if (!k.IsNullOrEmpty())
            {
                k = k.Trim().FillChar(8, 'a'); //补满8位，超出不补
                key = k;
            }
        }

        public DESEncrypt()
        {
        }
        #endregion

        /**/
        /// <summary> 
        /// DES加密 
        /// </summary> 
        /// <param name="encryptString"></param> 
        /// <returns></returns> 
        public string DesEncrypt(string encryptString)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, provider.CreateEncryptor(keyBytes, keyIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }

        /**/
        /// <summary> 
        /// DES解密 
        /// </summary> 
        /// <param name="decryptString"></param> 
        /// <returns></returns> 
        public string DesDecrypt(string decryptString)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, provider.CreateDecryptor(keyBytes, keyIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());
        }
    }
}
