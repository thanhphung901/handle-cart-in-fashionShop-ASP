using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public class XLDL
{
    public static string StrCnn = ConfigurationManager.ConnectionStrings["QLQAConnectionString"].ConnectionString;
    static SqlConnection Cnn;
    public static string detailsSP;
    public static DataTable DocBang(string comm)
    {
        DataTable dt = new DataTable();
        try
        {
            if (Cnn == null) Cnn = new SqlConnection(StrCnn);
            SqlDataAdapter da = new SqlDataAdapter(comm, Cnn);
            da.FillSchema(dt, SchemaType.Mapped);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return dt;
    }

    public static int ThucHienLenh(string comm)
    {
        try
        {
            if (Cnn == null) Cnn = new SqlConnection(StrCnn);
            if (Cnn.State == ConnectionState.Closed) Cnn.Open();
            SqlCommand cmd = new SqlCommand(comm,Cnn);
            int kq = cmd.ExecuteNonQuery();
            Cnn.Close();
            return kq;
        }
        catch (SqlException ex)
        {
            return -1;
        }
    }
}