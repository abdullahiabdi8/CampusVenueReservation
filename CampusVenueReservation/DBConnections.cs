using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CampusVenueReservation
{
	public class DBConnections
	{
		public DBConnections()
		{
		}

		public static void Dispose(SqlConnection con)
		{
			if (con.State == ConnectionState.Open)
			{
				con.Close();
			}
			con.Dispose();
		}

		public static SqlConnection GetConnection()
		{
			SqlConnection sqlConnection;
			SqlConnection sqlConnection1 = null;
			try
			{
				string str = ConfigurationManager.ConnectionStrings["stringConnections"].ToString();
				sqlConnection1 = new SqlConnection(str);
				sqlConnection1.Open();
				sqlConnection = sqlConnection1;
			}
			catch (Exception ex)
			{
				ErrorLog.LogTxt("GetConnection", "DBConnections/GetConnection", ex.ToString());
				sqlConnection = sqlConnection1;
			}
			return sqlConnection;
		}
	}
}