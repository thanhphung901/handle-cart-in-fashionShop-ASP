<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_GioHang.ascx.cs" Inherits="UC_UC_GioHang" %>

<link type="text/css" rel="Stylesheet" href="../Styles/GioHang.css" />
<link type="text/css" rel="Stylesheet" href="../Styles/Site.css" />

<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
    <div class="r1">GIỎ HÀNG CỦA BẠN
        <asp:Label ID="lblErrorV1" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <hr width="930px" color="#ccc" size="1px" class="clear"/>
    
    <div class="r2">
    <asp:GridView ID="gvwGioHang" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="IDSP" Width="99%" 
        onrowcancelingedit="gvwGioHang_RowCancelingEdit" 
        onrowcommand="gvwGioHang_RowCommand" onrowediting="gvwGioHang_RowEditing" 
        onrowupdating="gvwGioHang_RowUpdating" ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:BoundField DataField="IDSP" HeaderText="ID" ReadOnly="True">
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="TEN_SP" HeaderText="Tên sản phẩm" ReadOnly="True" />
            <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
            <asp:BoundField DataField="GIA" HeaderText="Đơn giá" ReadOnly="True" />
            <asp:BoundField DataField="ThanhTien" DataFormatString="{0:#,##0}" 
                HeaderText="Thành tiền" ReadOnly="True" />
            <asp:CommandField EditText="Sửa" HeaderText="Hiệu chỉnh" 
                ShowEditButton="True" />
            <asp:TemplateField HeaderImageUrl="~/Img/delete.png"><HeaderTemplate><asp:ImageButton ID="ImageButton1" runat="server" CommandName="xoa" 
                        ImageUrl="~/Img/delete.png" Width="24px" /></HeaderTemplate><ItemTemplate><asp:CheckBox ID="chkChon" runat="server" /></ItemTemplate><ItemStyle Height="18px" Width="18px" /></asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#EEEEEE" />
        <RowStyle Height="40px" HorizontalAlign="Center" />
    </asp:GridView>
</div>
<div style="font-size:1.1em;float:right;margin-right:20px;">
    <table>
        <tr>
            <td style="text-align:right;">Tổng số mặt hàng: </td>
            <td><b><asp:Label ID="lblTong_MH" runat="server"></asp:Label></b></td>
        </tr>
        <tr>
            <td style="text-align:right;">Khuyến mãi: </td>
            <td><b>0</b></td>
        </tr>
        <tr>
            <td style="text-align:right;"><b>Tổng số tiền:</b></td>
            <td><b><asp:Label ID="lblTong_Tien" runat="server"></asp:Label></b></td>
        </tr>
    </table>
</div>

<div style="clear:both;width:950px;margin-left:10px;"><br />
    &nbsp;
    <b>Ghi chú về đơn hàng</b>
    <br />
    <asp:TextBox ID="txtGhiChu" runat="server" Rows="5" TextMode="MultiLine" 
        Width="95%"></asp:TextBox>
    <asp:Button runat="server" class="button" Text="Tiếp tục mua hàng" 
        ID="btnTiepTucGH" onclick="btnTiepTucGH_Click"></asp:Button>
    </div>
    </asp:View>

    <asp:View ID="View2" runat="server">
        <div class="r1">THÔNG TIN KHÁCH HÀNG
            <asp:Label ID="lblErrorV2" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <hr width="930px" color="#ccc" size="1px" class="clear"/>

        <div class="r2">
            <table cellpadding="8" cellspacing="0" >
            <tr>
                <td class="detail">TÊN KHÁCH HÀNG</td>
                <td>
                    <asp:TextBox runat="server" class="textbox" ID="txtTenKH" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="detail">ĐIỆN THOẠI LIÊN HỆ</td>
                <td>
                    <asp:TextBox runat="server" class="textbox" ID="txtDt" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="detail">Email</td>
                <td>
                    <asp:TextBox runat="server" class="textbox" ID="txtEmail" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="detail">ĐỊA ĐIỂM GIAO HÀNG</td>
                <td>
                    <asp:TextBox runat="server" class="textbox" ID="txtDiaChi" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button runat="server" Text="THANH TOÁN" ID="btnThanhToan" class="button" 
                        onclick="btnThanhToan_Click"></asp:Button></td>
            </tr>
        </table>
        </div>
    </asp:View>
    <asp:View ID="View3" runat="server">
        <div class="r1">XÁC NHẬN ĐƠN HÀNG
            <asp:Label ID="lblErrorV3" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <hr width="930px" color="#ccc" size="1px" class="clear"/>

        <div class="r2">
        <asp:GridView ID="gvwGH_TK" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="IDSP" Width="99%" 
            onrowcommand="gvwGioHang_RowCommand" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="IDSP" HeaderText="Mã sản phẩm" ReadOnly="True" />
                <asp:BoundField DataField="TEN_SP" HeaderText="Tên sản phẩm" ReadOnly="True" />
                <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
                <asp:BoundField DataField="GIA" HeaderText="Đơn giá" ReadOnly="True" />
                <asp:BoundField DataField="ThanhTien" DataFormatString="{0:#,##0}" 
                    HeaderText="Thành tiền" ReadOnly="True" />
            </Columns>
            <HeaderStyle BackColor="#EEEEEE" />
            <RowStyle Height="40px" HorizontalAlign="Center" />
        </asp:GridView>
    </div>
    <div class="XNDHfleft">
        <table cellpadding="5" cellspacing="0" >
            <tr>
                <td class="detail">TÊN KHÁCH HÀNG</td>
                <td>
                    <asp:Label runat="server" ID="lblTenKH" class="lbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="detail">ĐIỆN THOẠI LIÊN HỆ</td>
                <td>
                    <asp:Label runat="server" ID="lblDt" class="lbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="detail">Email</td>
                <td>
                    <asp:Label runat="server" ID="lblEmail" class="lbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="detail">ĐỊA ĐIỂM GIAO HÀNG</td>
                <td>
                    <asp:Label runat="server" ID="lblDiaChi" class="lbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="detail">GHI CHÚ</td>
                <td>
                    <asp:Label runat="server" ID="lblGhiChu" class="lbl"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="XNDHright">
        <br /><br /><br />
        <asp:Label runat="server" ID="lblTongTienTT" class="lblTT"></asp:Label>
    </div>
        <br />
        <br />
        <hr width="930px" color="#ccc" size="1px" class="clear"/>
        <br />
    <div class="XNDHfooter">
        <asp:Button runat="server" ID="btnXacNhan" Text="Xác nhận đơn hàng" 
            class="button" onclick="btnXacNhan_Click"></asp:Button>
        &nbsp;
        <asp:Button runat="server" ID="btnHuy" Text="Hủy đơn hàng" class="button" 
            onclick="btnHuy_Click"></asp:Button>
    </div>
    <br />
    </asp:View>
    <asp:View ID="View4" runat="server">
        <div style="text-align:center;font-family:Arial;margin-top:10px;">
            <span style="font-size:1.2em;color:BlueViolet;">ĐÃ GỬI ĐƠN ĐẶT HÀNG THÀNH CÔNG</span><br />
            <span style="font-size:1em;">Chúng tôi sẽ liên hệ với bạn để xác nhận thông tin trong thời gian sớm nhất.<br />
               <i>Cảm ơn bạn đã tin tưởng và chọn sản phẩm của chúng tôi.</i>
            </span><br />
            <asp:Button runat="server" ID="btnHome" Text="Trở về Trang Chủ" 
            class="button" onclick="btnHome_Click"></asp:Button>
        </div>
    </asp:View>
</asp:MultiView>
