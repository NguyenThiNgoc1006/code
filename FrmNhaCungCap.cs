using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CuaHangGiayDep
{
    public partial class FrmNhaCungCap : Form
    {
        DataTable tblNhaCungCap;

        public FrmNhaCungCap()
        {
            InitializeComponent();
        }

        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = false;

            loadDataToGridview();
        }
        private void loadDataToGridview()
        {
            string sql = "Select * from NhaCungCap";
            tblNhaCungCap = Functions.GetDataToTable(sql);
            dataGridView1.DataSource = tblNhaCungCap;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.Text = dataGridView1.CurrentRow.Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dataGridView1.CurrentRow.Cells["TenNCC"].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtDienThoai.Text = dataGridView1.CurrentRow.Cells["DienThoai"].Value.ToString();
            txtMaNCC.Enabled = false;
        }
        private void ResetValue()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtMaNCC.Enabled = true;
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("không còn dữ liệu!");
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("bạn chưa nhập mã NCC");
                txtMaNCC.Focus();
            }
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("bạn chưa nhập tên NCC");
                txtTenNCC.Focus();
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("bạn chưa nhập địa chỉ");
                txtDiaChi.Focus();
            }
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("bạn chưa nhập số điện thoại");
                txtDienThoai.Focus();
            }

            sql = "update NhaCungCap set TenNCC = '" + txtTenNCC.Text.ToString() + "', "
                + "DiaChi = '" + txtDiaChi.Text.ToString() + "', " + "DienThoai = '" + txtDienThoai.Text.ToString()
                + "'where MaNCC = '" + txtMaNCC.Text + "'";
            Functions.RunSqlDel(sql);

            loadDataToGridview();
            ResetValue();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("không có dữ liệu!");
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập bản ghi nào ");
            }
            if (MessageBox.Show("Bạn có muốn xóa không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "delete from NhaCungCap where MaNCC= '" + txtMaNCC.Text + "'";
                Functions.RunSqlDel(sql);
                loadDataToGridview();
                ResetValue();
            }
        }
            

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("không còn dữ liệu");
                return;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã NCC");
                txtMaNCC.Focus();

            }
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Bạn cần nhập tên NCC");
                txtTenNCC.Focus();

            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn cần nhập địa chỉ");
                txtDiaChi.Focus();

            }
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn cần nhập số điện thoại");
                txtDienThoai.Focus();

            }
            sql = "Select MaNCC from NhaCungCap where MaNCC ='" + txtMaNCC.Text.Trim() + "'";
            if (Functions.Checkey(sql))
            {
                MessageBox.Show("mã NCC này đã có, bạn phai nhập mã khác");
                txtMaNCC.Focus();
                return;
            }
            sql = "insert into NhaCungCap values('" + txtMaNCC.Text + "', '" + txtTenNCC.Text
                + "', '" + txtDiaChi.Text + "', '" + txtDienThoai.Text + "')";
            Functions.RunSqlDel(sql);
            loadDataToGridview();
           ResetValue();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;


        }
        
        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) ||
            (Convert.ToInt32(e.KeyChar) == 8) || (Convert.ToInt32(e.KeyChar) == 13))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}





   
