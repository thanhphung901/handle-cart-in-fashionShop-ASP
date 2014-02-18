using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class XLGH:DataTable
{
	public XLGH()
	{
        DataColumn colIDSP = this.Columns.Add("IDSP", typeof(System.String));
        this.Columns.Add("TEN_SP", typeof(System.String));
        this.Columns.Add("SoLuong", typeof(System.Int32));
        this.Columns.Add("GIA", typeof(System.Double));
        this.Columns.Add("ThanhTien", typeof(System.Double),"SoLuong*GIA");
        this.PrimaryKey = new DataColumn[] { colIDSP };
	}

    public int TongMatHang
    {
        get { return this.Rows.Count; }
    }

    public double TongThanhTien
    {
        get
        {
            double kq = 0;
            object tong = this.Compute("Sum(ThanhTien)", "");
            if (tong != DBNull.Value) kq = (double)tong;
            return kq;
        }
    }

    public void Them(string idSP, string tenSP, double gia)
    {
        DataRow dong = this.Rows.Find(idSP);
        if (dong != null)
        {
            int sl = (int)dong["SoLuong"];
            dong["SoLuong"] = sl + 1;
        }
        else
        {
            DataRow dong_moi = this.NewRow();
            dong_moi["IDSP"] = idSP;
            dong_moi["TEN_SP"] = tenSP;
            dong_moi["SoLuong"] = 1;
            dong_moi["GIA"] = gia;
            this.Rows.Add(dong_moi);
        }
        this.AcceptChanges();//Cap nhat
    }
}