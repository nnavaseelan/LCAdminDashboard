using System;
using System.IO;
using context = System.Web.HttpContext;

namespace SDKApp
{
    

    /// <summary>  
    /// Summary description for ExceptionLogging  
    /// </summary>  
    public static class ExceptionLogging
    {
        private static String ErrorlineNo, Errormsg, extype, exurl, hostIp, ErrorLocation, HostAdd;

        public static void SendErrorToText(Exception ex)
        {
            var line = Environment.NewLine + Environment.NewLine;

            //ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            ErrorlineNo = ex.StackTrace;
            Errormsg = ex.GetType().Name.ToString();
            extype = ex.GetType().ToString();
            //exurl = context.Current.Request.Url.ToString();
            ErrorLocation = ex.Message.ToString() + Environment.NewLine;

            try
            {
                var filepath = System.Configuration.ConfigurationManager.AppSettings["ErrorLoggerBath"].ToString();
                filepath = filepath + "/SDK/";
                
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                }
                filepath = filepath +"log-"+ DateTime.Today.ToString("dd-MM-yy")+"-"+ DateTime.Now.Ticks.ToString() + ".txt";   //Text File Name
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    sw.WriteLine(Errormsg);
                    sw.WriteLine(ErrorLocation);
                    sw.WriteLine(ErrorlineNo);                    
                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.Flush();
                    sw.Close();

                }

            }
            catch (Exception e)
            {
                e.ToString();

            }
        }

    }
}
