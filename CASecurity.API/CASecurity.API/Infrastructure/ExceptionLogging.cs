using System;
using System.IO;
using context = System.Web.HttpContext;

namespace CASecurity.API.Infrastructure
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
            
            ErrorlineNo = ex.StackTrace;
            Errormsg = ex.GetType().Name.ToString();
            extype = ex.GetType().ToString();
            exurl = context.Current.Request.Url.ToString();
            ErrorLocation = ex.Message.ToString() + Environment.NewLine;

            try
            {
                var filepath = System.Configuration.ConfigurationManager.AppSettings["ErrorLoggerBath"].ToString();

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                }
                filepath = filepath +"/Api/Error -"+ DateTime.Today.ToString("dd-MM-yy")+"-"+ DateTime.Now.Ticks.ToString() + ".txt";   //Text File Name
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    sw.WriteLine(Errormsg + "-"+ exurl);
                    sw.WriteLine(ErrorLocation);
                    sw.WriteLine(ErrorlineNo);                    
                    sw.WriteLine(line);
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
        public static void SendProcessLog(Exception ex)
        {
            var line = Environment.NewLine + Environment.NewLine;


            ErrorlineNo = ex.StackTrace;
            Errormsg = ex.GetType().Name.ToString();
            extype = ex.GetType().ToString();
            exurl = context.Current.Request.Url.ToString();
            ErrorLocation = ex.Message.ToString() + Environment.NewLine;

            try
            {
                var filepath = System.Configuration.ConfigurationManager.AppSettings["ErrorLoggerBath"].ToString();

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                }
                filepath = filepath + "/Api/Error -" + DateTime.Today.ToString("dd-MM-yy") + "-" + DateTime.Now.Ticks.ToString() + ".txt";   //Text File Name
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(Errormsg);
                    sw.WriteLine(ErrorLocation);
                    sw.WriteLine(ErrorlineNo);
                    sw.WriteLine(line);
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
