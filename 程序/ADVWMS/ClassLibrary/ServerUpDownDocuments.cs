using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// data upload and dowmload of remote server
    /// </summary>
    public class ServerUpDownDocuments
    {
        protected const string encryptKey = "GDADVWMS";//const key

        /// <summary>
        /// upload general folder files
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="message">message</param>
        /// <returns></returns>
        public static bool UploadingFiles(string filename,string message)
        {
            string filePath = @"\\192.168.0.211\xc-advwms\GeneralFolder";
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);//create documents when the documents is not exists 
            string fullPath = filePath + "\\" + filename + ".txt";//user's document path
            try
            {
                File.WriteAllText(fullPath, Encrypt(message));
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// upload the file
        /// </summary>
        /// <param name="filename">folder name</param>
        /// <param name="username">user name</param>
        /// <param name="message">message</param>
        /// <returns></returns>
        public static bool UploadingFiles(string filename,string username,string message)
        {
            string filePath = @"\\192.168.0.211\xc-advwms\" +filename;
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);//create documents when the documents is not exists 
            string fullPath = filePath + "\\" + username + ".txt";//user's document path
            try
            {
                File.WriteAllText(fullPath, Encrypt(message));
                return true;
            }
            catch
            {
                return false; 
            }
        }

        public static string DownloadingFiles(string filename)
        {
            string filePath = @"\\192.168.0.211\xc-advwms\GeneralFolder";
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);//create documents when the documents is not exists 
            string fullPath = filePath + "\\" + filename + ".txt";//user's document path
            try
            {
                string message = File.ReadAllText(fullPath);
                return Decrypt(message);
            }
            catch
            {
                return string.Empty; 
            }
        }
        /// <summary>
        /// dowmload the file
        /// </summary>
        /// <param name="filename">folder name</param>
        /// <param name="username">user name</param>
        /// <returns></returns>
        public static string DownloadingFiles(string filename,string username)
        {
            string filePath = @"\\192.168.0.211\xc-advwms\" + filename;
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);//create documents when the documents is not exists 
            string fullPath = filePath + "\\" + username + ".txt";//user's document path
            try
            {
                string message = File.ReadAllText(fullPath);
                return Decrypt(message);
            }
            catch 
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// encrypt data
        /// </summary>
        /// <param name="pToEncrypt">data</param>
        /// <returns></returns>
        private static string Encrypt(string pToEncrypt)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {

                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(encryptKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(encryptKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        /// <summary>
        /// decrypt data
        /// </summary>
        /// <param name="pToDecrypt">data</param>
        /// <returns>message</returns>
        private static string Decrypt(string pToDecrypt)
        {
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {

                des.Key = ASCIIEncoding.ASCII.GetBytes(encryptKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(encryptKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }
    }
}
