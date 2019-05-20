using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerUploadDownload
{
    /// <summary>
    /// 远程服务器上传及下载类
    /// </summary>
    public class ServerUpAndDown
    {
        //    /// <summary>
        //    /// 远程服务器连接的状态
        //    /// </summary>
        //    /// <param name="path"></param>
        //    /// <returns></returns>
        //    public static bool connectState(string path)
        //    {
        //        return connectState(path, "", "");
        //    }

        //    public static bool connectState(string path, string userName, string passWord)
        //    {
        //        bool Flag = false;
        //        Process proc = new Process();
        //        try
        //        {
        //            proc.StartInfo.FileName = "cmd.exe";
        //            proc.StartInfo.UseShellExecute = false;
        //            proc.StartInfo.RedirectStandardError = true;
        //            proc.StartInfo.RedirectStandardInput = true;
        //            proc.StartInfo.RedirectStandardOutput = true;
        //            proc.StartInfo.CreateNoWindow = true;
        //            proc.Start();

        //            string delLine = "net use * /del /y";
        //            proc.StandardInput.WriteLine(delLine);
        //            string dosLine = "net use " + path + " " + passWord + " /user:" + userName;
        //            proc.StandardInput.WriteLine(dosLine);
        //            proc.StandardInput.WriteLine("exit");
        //            while (!proc.HasExited)
        //                proc.WaitForExit(1000);
        //            string errormsg = proc.StandardError.ReadToEnd();
        //            proc.StandardError.Close();
        //            if (string.IsNullOrEmpty(errormsg))
        //                Flag = true;
        //            else
        //                throw new Exception(errormsg);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            proc.Close();
        //            proc.Dispose();
        //        }
        //        return Flag;
        //    }

        //    /// <summary>
        //    /// 从远程服务器下载文件到本地
        //    /// </summary>
        //    /// <param name="src">下载到本地后的文件路径，包含文件的扩展名</param>
        //    /// <param name="dst">远程服务器路径（共享文件夹路径）</param>
        //    /// <param name="fileName">远程服务器（共享文件夹）中的文件名称，包含扩展名</param>
        //    private static void TransportRemoteToLocal(string src, string dst, string fileName)
        //    {
        //        if (!Directory.Exists(dst))
        //        {
        //            Directory.CreateDirectory(dst);
        //        }
        //        dst = dst + fileName;
        //        FileStream inFileStream = new FileStream(dst, FileMode.Open);//远程服务器文件,假定远程服务器共享文件夹确实包含文件，否则报错
        //        FileStream outFileStream = new FileStream(src, FileMode.OpenOrCreate);//从远程服务器下载到本地的文件
        //        byte[] buf = new byte[inFileStream.Length];
        //        int byteCount;

        //        while ((byteCount = inFileStream.Read(buf, 0, buf.Length)) > 0)
        //        {
        //            outFileStream.Write(buf, 0, byteCount);
        //        }
        //        inFileStream.Flush();
        //        inFileStream.Close();
        //        outFileStream.Flush();
        //        outFileStream.Close();
        //    }
        //    /// <summary>
        //    /// 将本地文件上传到远程服务器共享目录
        //    /// </summary>
        //    /// <param name="src">本地文件的绝对路径，包含扩展名</param>
        //    /// <param name="dst">远程服务器共享文件路径，不包含文件扩展名</param>
        //    /// <param name="fileName">上传到远程服务器后的文件扩展名</param>
        //    private static void TransportLocalToRemote(string src, string dst, string fileName)
        //    {
        //        FileStream inFileStream = new FileStream(src, FileMode.Open);//此处假定本地文件存在，否则报错
        //        if (!Directory.Exists(dst))
        //        {
        //            Directory.CreateDirectory(dst);
        //        }
        //        dst = dst + fileName;
        //        FileStream outFileStream = new FileStream(dst, FileMode.OpenOrCreate);
        //        byte[] buf = new byte[inFileStream.Length];
        //        int byteCount;
        //        while ((byteCount = inFileStream.Read(buf, 0, buf.Length)) > 0)
        //        {
        //            outFileStream.Write(buf, 0, byteCount);
        //        }
        //        inFileStream.Flush();
        //        inFileStream.Close();
        //        outFileStream.Flush();
        //        outFileStream.Close();
        //    }



        public void DownLoadFile(string URL, string DIR)
        {
            WebClient client = new WebClient();
            string FileName = URL.Substring(URL.LastIndexOf("\\") + 1);
            string PATH = DIR + FileName;
            try
            {
                WebRequest SC = WebRequest.Create(URL);
            }
            catch
            {
            }
            try
            {
                client.DownloadFile(URL, PATH);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 从远程服务器读取数据到本地
        /// </summary>
        /// <param name="fileNamePath">本地保存地址+读取文件名</param>
        /// <param name="urlPath">远程服务器URL地址</param>
        /// <param name="User">用户名</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        public string DownLoadFile(string fileNamePath, string urlPath, string User, string Pwd)
        {
            string newFileName = fileNamePath.Substring(fileNamePath.LastIndexOf(@"\") + 1);//取文件名称
            if (urlPath.EndsWith(@"\") == false) urlPath = urlPath + @"\";
            urlPath = urlPath + newFileName;//URL带文件名

            WebClient myWebClient = new WebClient();
            NetworkCredential cread = new NetworkCredential(User, Pwd, "Domain");
            myWebClient.Credentials = cread;
            Stream postStream = myWebClient.OpenRead(urlPath);//远程服务器读取文件
            byte[] postArray = new Byte[postStream.Length];//将读取到的文件转化为二进制数组
            if (postStream.CanRead)
            {
                postStream.Read(postArray, 0, postArray.Length);
                postStream.Seek(0, SeekOrigin.Begin);
            }
            else
            {
            }
            try
            {
                using ( FileStream fs = new FileStream(fileNamePath, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(postArray, 0, postArray.Length);
                    fs.Close();
                }
                return "文件下载成功！";
            }
            catch (Exception ex)
            {
                return "文件下载失败！错误内容如下：" + ex.Message;
            }
        }

        /// <summary>
        /// 上传文件：要设置共享文件夹是否有创建的权限，否则无法上传文件
        /// </summary>
        /// <param name="fileNamePath">上传的文件名</param>
        /// <param name="urlPath">远程服务器URL地址</param>
        /// <param name="User">用户名</param>
        /// <param name="Pwd">密码</param>
        public string UpLoadFile(string fileNamePath, string urlPath, string User, string Pwd)
        {
            string newFileName = fileNamePath.Substring(fileNamePath.LastIndexOf(@"\") + 1);//取文件名称
            if (urlPath.EndsWith(@"\") == false) urlPath = urlPath + @"\";
            urlPath = urlPath + newFileName;
            WebClient myWebClient = new WebClient();
            NetworkCredential cread = new NetworkCredential(User, Pwd, "Domain");
            myWebClient.Credentials = cread;
            FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            string value = "";
            try
            {
                byte[] postArray = r.ReadBytes((int)fs.Length);
                Stream postStream = myWebClient.OpenWrite(urlPath);
                // postStream.m 
                if (postStream.CanWrite)
                {
                    postStream.Write(postArray, 0, postArray.Length);
                    value = "文件上传成功！";
                }
                else
                {
                    value = "文件上传错误！";
                }
                postStream.Close();
                return value;
            }
            catch (Exception ex)
            {
                return "错误！错误内容如下：" + ex.Message;
            }
        }
    }
}
