using asprise_imaging_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanOperation
{
    /// <summary>
    /// 扫描类
    /// </summary>
    public class Scan
    {/// <summary>
     /// 扫描到JPEG
     /// </summary>
        public static void scanToJpeg()
        {
            Result result = new AspriseImaging().Scan(new Request().SetTwainCap(TwainConstants.ICAP_PIXELTYPE, TwainConstants.TWPT_RGB).SetTwainCap(TwainConstants.ICAP_SUPPORTEDSIZES, TwainConstants.TWSS_USLETTER).SetPromptScanMore(true).AddOutputItem(new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_JPG).SetSavePath(".\\${TMS}${EXT}")), "select", true, true);

            List<string> files = result == null ? null : result.GetImageFiles();
            Console.WriteLine("Scanned:" + string.Join(", ", files == null ? new string[0] : files.ToArray()));
        }
        /// <summary>
        /// JASON版扫描到JPEG
        /// </summary>
        public static void scanToJpegJson()
        {
            Result result = new AspriseImaging().Scan("{" +
                "  \"twain_cap_setting\" : {" +
                "    \"ICAP_PIXEXELTYPE\" : \"TWPT_RGB\"," +
                "    \"ICAP_SUPPORPORTEDSIZES\" : \"TWSS_USLESLETTER\"" +
                "  }," +
                "  \"prompt_scan_more\" : true," +
                "  \"output_settings\" : [ {" +
                "    \"type\" : \"save\"," +
                "    \"format\" : \"jpg\"," +
                "    \"save_path\" : \".\\\\${TMS}${EXT}\"" +
                "  } ]" +
                "}", "select", true, true);

            List<string> files = result == null ? null : result.GetImageFiles();
            Console.WriteLine("scanned:" + string.Join(", ", files == null ? new string[0] : files.ToArray()));
        }
        /// <summary>
        /// 扫描并上传
        /// </summary>
        public static void scanAndUpload()
        {
            Result result = new AspriseImaging().Scan(new Request().AddOutputItem(new RequestOutputItem(AspriseImaging.OUTPUT_UPLOAD, AspriseImaging.FORMAT_JPG).SetUploadSetting(new UploadSetting("http://asprise.com/scan/applet/upload.php?action=dump").AddPostField("title", "Test scan"))), "select", true, true);

            String response = result == null ? null : result.GetUploadResponse();
            Console.WriteLine("From server: \n" + response);
        }
        /// <summary>
        /// JASON版扫描并上传
        /// </summary>
        public static void scanAndUploadJson()
        {
            Result result = new AspriseImaging().Scan("{" +
              "  \"output_settings\" : [ {" +
              "    \"type\" : \"upload\"," +
              "    \"format\" : \"jpg\"," +
              "    \"upload_target\" : {" +
              "      \"url\" : \"http://asprise.com/scan/applet/upload.php?action=dump\"," +
              "      \"post_fields\" : {" +
              "        \"title\" : \"Test scan\"" +
              "      }" +
              "    }" +
              "  } ]" +
              "}", "select", true, true);
            String response = result == null ? null : result.GetUploadResponse();
            Console.WriteLine("From server: \n" + response);
        }
        /// <summary>
        /// 扫描到PDF
        /// </summary>
        public static void scanToPdf()
        {
            Result result = new AspriseImaging().Scan(new Request().AddOutputItem(
                new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_PDF)
                    .SetPdfTextLine("Scanned on ${DATETIME} by user X") // 第一页底部的可选文本行
                    .AddExifTag("DocumentName", "Scan to PDF by Asprise") // 可选PDF文档属性（元数据）
                    .SetSavePath(".\\${TMS}${EXT}")
                ).SetPromptScanMore(true) // 是否提示用户扫描更多页面
             , "select", true, true);

            string pdfFile = result == null ? null : result.GetPdfFile();
            Console.WriteLine("Documents scanned as PDF: " + pdfFile);
        }
        /// <summary>
        /// 扫描到PDF以CcittG4上传
        /// </summary>
        public static void scanToPdfCcittG4AndUpload()
        {
            Result result = new AspriseImaging().Scan(new Request().AddOutputItem(
                new RequestOutputItem(AspriseImaging.OUTPUT_UPLOAD, AspriseImaging.FORMAT_PDF)
                    .SetPdfForceBlackWhite(true)
                    .SetUploadSetting(new UploadSetting("http://asprise.com/scan/applet/upload.php?action=dump")
                        .SetCookies("name=value; poweredBy=Asprise"))
                ), "select", true, true);

            String response = result == null ? null : result.GetUploadResponse();
            Console.WriteLine("From server: \n" + response);
        }
        /// <summary>
        /// 扫描到PDFA
        /// </summary>
        public static void scanToPdfA()
        {
            Result result = new AspriseImaging().Scan(new Request().AddOutputItem(
                new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_PDF)
                    .SetPdfaCompliant(true)
                    .AddExifTag(AspriseImaging.EXIF_NAME_DocumentName, "PDF/A to meet compliance requirements")
                    .SetSavePath(".\\${TMS}${EXT}")
                ), "select", true, true);
            string pdfFile = result == null ? null : result.GetPdfFile();
            Console.WriteLine("Documents scanned as PDF: " + pdfFile);
        }
        /// <summary>
        /// 扫描到TIFF
        /// </summary>
        public static void scanToTiff()
        {
            Result result = new AspriseImaging().Scan(new Request().AddOutputItem(
                new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_TIF)
                    .SetTiffCompression(AspriseImaging.TIFF_COMPRESSION_CCITT_G4)
                    .SetSavePath(".\\${TMS}${EXT}")
            ), "select", true, true);

            string tiffFile = result == null ? null : result.GetTiffFile();
            Console.WriteLine("Documents scanned as TIFF: " + tiffFile);
        }
        /// <summary>
        /// 扫描并记忆
        /// </summary>
        public static void scanToMemory()
        {
            Result result = new AspriseImaging().Scan(new Request().AddOutputItem(
                new RequestOutputItem(AspriseImaging.OUTPUT_RETURN_BASE64, AspriseImaging.FORMAT_JPG)
            ), "select", true, true);

            Console.WriteLine("Scan to memory: " + result);
        }
        /// <summary>
        /// 识别条形码
        /// </summary>
        public static void recognizeBarcodes()
        {
            Result result = new AspriseImaging().Scan(new Request()
                .SetRecognizeBarcodes(true)
                .AddOutputItem(new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_JPG).SetSavePath(".\\${TMS}${EXT}")),
            "select", true, true);

            List<string> barcodes = result == null ? null : result.GetBarcodes();
            Console.WriteLine("Barcodes: " + string.Join(";\n", barcodes == null ? new string[0] : barcodes.ToArray()));
        }
        /// <summary>
        /// JSON版识别条形码
        /// </summary>
        public static void recognizeBarcodesJson()
        {
            Result result = new AspriseImaging().Scan("{" +
                "  \"recognize_barcodes\" : true," +
                "  \"output_settings\" : [ {" +
                "    \"type\" : \"save\"," +
                "    \"format\" : \"jpg\"," +
                "    \"save_path\" : \".\\\\${TMS}${EXT}\"" +
                "  } ]" +
                "}", "select", true, true);

            List<string> barcodes = result == null ? null : result.GetBarcodes();
            Console.WriteLine("Barcodes: " + string.Join(";\n", barcodes == null ? new string[0] : barcodes.ToArray()));
        }
        /// <summary>
        /// adf扫描
        /// </summary>
        public static void adf()
        {
            Result result = new AspriseImaging().Scan(new Request()
                .SetTwainCap(TwainConstants.CAP_FEEDERENABLED, true)
                .SetTwainCap(TwainConstants.CAP_AUTOFEED, true)
                .SetTwainCap(TwainConstants.CAP_DUPLEXENABLED, true)
                .SetDiscardBlankPages(true)
                .SetBlankPageThreshold(0.03m)
                .AddOutputItem(new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_PDF).SetSavePath(".\\${TMS}${EXT}")),
                "select", true, true);
            string pdfFile = result == null ? null : result.GetPdfFile();
            Console.WriteLine("Documents scanned as PDF: " + pdfFile);
        }
        /// <summary>
        /// 列表源
        /// </summary>
        public static void listSources()
        {
            AspriseImaging imaging = new AspriseImaging();
            List<Source> sourcesNameOnly = imaging.ScanListSources(); // Names without capabilities

            List<Source> sourcesFullDetails = imaging.ScanListSourcesWithFullDetails(); // with caps
            foreach (Source src in sourcesFullDetails)
            {
                Console.WriteLine(src.ProductName + ": pixel type = " +
                    src.GetCap(TwainConstants.ICAP_PIXELTYPE).GetCurrentValue());
            }

            Source defaultSource = Source.GetDefaultSource(sourcesFullDetails);
            Console.WriteLine("Default source is: " + defaultSource);

            Source source = defaultSource;
            List<Capability> caps = source.GetCaps();
            foreach (Capability cap in caps)
            {
                Console.WriteLine(cap.GetName() + ": " + cap.GetCurrentValue());
            }
        }
        /// <summary>
        /// 更新Caps
        /// </summary>
        public static void setGetCaps()
        {
            Source source = new AspriseImaging().GetSource("select", false, "all", false, false, "CAP_FEEDERENABLED: 1; CAP_DUPLEXENABLED: 1");
            List<Capability> caps = source.GetCaps();

            foreach (Capability cap in caps)
            {
                Console.WriteLine(cap.GetName() + ": " + cap.GetCurrentValue());
            }
        }
    }
}
