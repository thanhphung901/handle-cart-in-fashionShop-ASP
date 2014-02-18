using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Configuration;
using System.Net.Mail;

public partial class UC_UC_GioHang : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) Xuat_Gio_Hang();
    }

    private void Xuat_Gio_Hang()
    {
        XLGH bangGioHang = (XLGH)Session["XLGH"];
        gvwGioHang.DataKeyNames = new String[] { "IDSP" };
        gvwGioHang.DataSource = bangGioHang;
        gvwGioHang.DataBind();

        lblTong_Tien.Text = bangGioHang.TongThanhTien.ToString("#,##0 VNĐ");
        lblTong_MH.Text = bangGioHang.TongMatHang.ToString();
    }
    private void Xuat_GH_ThongKe()
    {
        XLGH bangGioHang1 = (XLGH)Session["XLGH"];
        gvwGH_TK.DataKeyNames = new String[] { "IDSP" };
        gvwGH_TK.DataSource = bangGioHang1;
        gvwGH_TK.DataBind();

        lblTong_Tien.Text = bangGioHang1.TongThanhTien.ToString("#,##0 VNĐ");
        lblTong_MH.Text = bangGioHang1.TongMatHang.ToString();
    }
    protected void gvwGioHang_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvwGioHang.EditIndex = e.NewEditIndex;
        Xuat_Gio_Hang();
    }
    protected void gvwGioHang_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvwGioHang.EditIndex = -1;
        Xuat_Gio_Hang();
    }
    protected void gvwGioHang_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int i = e.RowIndex;
        string idsp =Convert.ToString(gvwGioHang.DataKeys[i].Value);
        TextBox soLuong = (TextBox)gvwGioHang.Rows[i].Cells[2].Controls[0];

        XLGH bangGioHang = (XLGH)Session["XLGH"];
        bangGioHang.Rows.Find(idsp)["SoLuong"] = Convert.ToInt32(soLuong.Text);
        bangGioHang.AcceptChanges();

        gvwGioHang.EditIndex = -1;
        Xuat_Gio_Hang();
    }
    protected void gvwGioHang_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xoa")
        {
            XLGH bangGioHang = (XLGH)Session["XLGH"];
            for (int i = 0; i < gvwGioHang.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvwGioHang.Rows[i].FindControl("chkChon");
                if (chk.Checked)
                {
                    string idsp = Convert.ToString(gvwGioHang.DataKeys[i].Value);
                    DataRow dongXoa = bangGioHang.Rows.Find(idsp);
                    bangGioHang.Rows.Remove(dongXoa);
                }
            }
            Xuat_Gio_Hang();
        }
    }
    protected void btnTiepTucGH_Click(object sender, EventArgs e)
    {
        if (gvwGioHang.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        else { lblErrorV1.Text = "( Bạn chưa có sản phẩm nào trong giỏ hàng! )"; }
    }
    String SumCols;
    protected void btnThanhToan_Click(object sender, EventArgs e)
    {
        if (gvwGioHang.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 2;
            Xuat_GH_ThongKe();
            lblTenKH.Text = txtTenKH.Text;
            lblDt.Text = txtDt.Text;
            lblEmail.Text = txtEmail.Text;
            lblDiaChi.Text = txtDiaChi.Text;
            lblGhiChu.Text = txtGhiChu.Text;
            lblTongTienTT.Text = "Số tiền thanh toán: <i>" + lblTong_Tien.Text + "</i>";
            String[] detail = { "ID: ", "Tên SP: ", "Số lượng: ", "Đơn giá: " };
            for (int i=0 ; i < gvwGioHang.Rows.Count; i++ )
            {
                for (int n = 0; n < 4; n++)
                {
                    SumCols += detail[n].ToString() + "<i>" + gvwGioHang.Rows[i].Cells[n].Text + "</i>&nbsp; &nbsp;";
                }
                SumCols = SumCols + "<br/>";
                XLDL.detailsSP = SumCols;
            }
        }
        else { lblErrorV2.Text = "( Bạn chưa có sản phẩm nào trong giỏ hàng! )"; }
        
    }
    protected void btnXacNhan_Click(object sender, EventArgs e)
    {
        if (gvwGioHang.Rows.Count > 0)
        {
            string from = "white.stones901@gmail.com"; //Replace this with your own correct Gmail Address
            string to = "white.stones901@gmail.com"; //Replace this with the Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from, "Shop Hàng Hiệu Giá Rẻ" , System.Text.Encoding.UTF8);
            mail.Subject = "ĐƠN ĐẶT HÀNG" ;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "<b>   THÔNG TIN KHÁCH HÀNG</b><br/>"
                + "TÊN: <b>" + lblTenKH.Text + "</b><br/>" 
                + "ĐIỆN THOẠI: <b>" + lblDt.Text + "</b><br/>"
                + "MAIL: <b>" + lblEmail.Text + "</b><br/>"
                + "ĐỊA CHỈ GIAO HÀNG: <b>" + lblDiaChi.Text + "</b><br/><br/>"
                + "<b>   THÔNG TIN SẢN PHẨM</b><br/>"
                + "SẢN PHẨM:<br/> <b>" + XLDL.detailsSP + "</b><br/>"
                + "TỔNG TIỀN THANH TOÁN: <b>" + lblTongTienTT.Text + "</b><br/>"
                + "GHI CHÚ: <b>" + lblGhiChu.Text + "</b><br/>"
                + "ĐÃ GỮI LÚC: " + DateTime.Now.ToShortTimeString() + DateTime.Now.ToShortDateString();
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true ;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();

            client.Credentials = new System.Net.NetworkCredential(from, "Sorry - Password mail can't show");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage );
            }
            MultiView1.ActiveViewIndex = 3;
        }
        else { lblErrorV3.Text = "( Bạn chưa có sản phẩm nào trong giỏ hàng! )"; }
    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        string url = "";
        url = "~/Page/demo.aspx";
        Response.Redirect(url);
    }
    protected void btnHome_Click(object sender, EventArgs e)
    {
        string url = "";
        url = "~/Page/demo.aspx";
        Response.Redirect(url);
    }
}