using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Text;

namespace CampusVenueReservation
{
	public class ErrorLog
	{
		public ErrorLog()
		{
		}

		public static void LogTxt(string Source, string ControllerMethodName, string Error)
		{
			try
			{
				DateTime now = DateTime.Now;
				string str = string.Format("{0}__{1}", now.ToString("yyyyMMdd"), "CampusVenue");
				string str1 = Path.Combine(ConfigurationManager.AppSettings["ErrorLogFilePath"].ToString(), str);
				Directory.CreateDirectory(ConfigurationManager.AppSettings["ErrorLogFilePath"].ToString());
				if (File.Exists(str1))
				{
					using (StreamWriter streamWriter = File.AppendText(str1))
					{
						now = DateTime.Now;
						streamWriter.WriteLine(string.Concat("\nError Time:", now.ToString()));
						streamWriter.WriteLine(string.Concat("\nController Method Name :", ControllerMethodName));
						streamWriter.WriteLine(string.Concat("\nError Source:", Source));
						streamWriter.WriteLine(string.Concat("\nError Detail:", Error));
						streamWriter.WriteLine("\n\n");
					}
				}
				else
				{
					using (StreamWriter streamWriter1 = File.CreateText(str1))
					{
						now = DateTime.Now;
						streamWriter1.WriteLine(string.Concat("\nError Time:", now.ToString()));
						streamWriter1.WriteLine(string.Concat("\nController Method Name :", ControllerMethodName));
						streamWriter1.WriteLine(string.Concat("\nError Source:", Source));
						streamWriter1.WriteLine(string.Concat("\nError Detail:", Error));
						streamWriter1.WriteLine("\n\n");
					}
				}
			}
			catch (Exception exception)
			{
				exception.ToString();
			}
		}

		public static void APIError(string exMessage = "", string exStack = "", string subDom = "", string orgURL = "", string url = "")
		{
			StreamWriter lw = null;
			String elogFilePath = ConfigurationManager.AppSettings["ErrorLogFilePath"] + "\\BETAPI.txt";
			try
			{
				//MessageBox.Show(ex.Message);
				if (File.Exists(elogFilePath) == true)
				{
					lw = new StreamWriter(elogFilePath, true, Encoding.Default);
					if (lw.BaseStream.Length >= 3145728)
					{
						lw.Close();
						//Overwrite
						lw = new StreamWriter(elogFilePath, false);
					}
				}
				else
				{
					lw = new StreamWriter(elogFilePath);
				}
				if (lw != null)
				{
					lw.WriteLine("Date Time: " + DateTime.Now.ToString());
					lw.WriteLine("Computer Name: " + Environment.MachineName.ToString());
					lw.WriteLine("Message: " + exMessage);
					lw.WriteLine("Stack Trac: " + exStack);
					lw.WriteLine("SubDom: " + subDom);
					lw.WriteLine("ClientCode: " + orgURL);
					lw.WriteLine("URL: " + url);
					lw.WriteLine("_________________________________________________________________________________________________");
					lw.Close();
				}
			}
			catch
			{
				//ignore it
			}

		}

	}
}