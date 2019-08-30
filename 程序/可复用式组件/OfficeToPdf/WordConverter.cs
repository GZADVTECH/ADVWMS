using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace OfficeToPdf
{
    public class WordConverter
    {
        //构造函数
        public WordConverter()
        { }
        /// <summary>
        /// 转换word 成PDF文档
        /// </summary>
        /// <param name="_lstrInputFile">原文件路径</param>
        /// <param name="_lstrOutFile">pdf文件输出路径</param>
        /// <returns>true 成功</returns>
        public bool ConverterToPdf(string _lstrInputFile, string _lstrOutFile)
        {
            Microsoft.Office.Interop.Word.Application lobjWordApp = null;
            Document objDoc = null;
            object lobjMissing = System.Reflection.Missing.Value;
            object lobjSaveChanges = null;
            try
            {
                Object lobjFileName = (Object)_lstrInputFile;
                objDoc = lobjWordApp.Documents.Open(ref lobjFileName, ref lobjMissing, ref lobjMissing,
                  ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing,
                  ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing);
                objDoc.Activate();
                Object lobjOutPutFileName = (Object)_lstrOutFile;
                object lobjFileFormat = WdSaveFormat.wdFormatPDF; //保存格式为PDF
                objDoc.SaveAs(ref lobjOutPutFileName, ref lobjFileFormat, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing,
                  ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing, ref lobjMissing,
                  ref lobjMissing, ref lobjMissing, ref lobjMissing);
                lobjSaveChanges = WdSaveOptions.wdDoNotSaveChanges;
                ((_Document)objDoc).Close(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
                objDoc = null;
                ((_Application)lobjWordApp).Quit(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
                lobjWordApp = null;
            }
            catch (Exception ex)
            {
                //其他日志操作；
                return false;
            }
            finally
            {
                if (objDoc != null)
                {
                    ((_Document)objDoc).Close(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
                    Marshal.ReleaseComObject(objDoc);
                    objDoc = null;
                }
                if (lobjWordApp != null)
                {
                    ((_Application)lobjWordApp).Quit(ref lobjSaveChanges, ref lobjMissing, ref lobjMissing);
                    Marshal.ReleaseComObject(lobjWordApp);
                    lobjWordApp = null;
                }
                //主动激活垃圾回收器，主要是避免超大批量转文档时，内存占用过多，而垃圾回收器并不是时刻都在运行！
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return true;
        }
    }
}
