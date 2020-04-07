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
    public partial class FrmNuocSX : Form
    {
        DataTable tblNuocSX;
        public FrmNuocSX()
        {
            InitializeComponent();
        }

        private void NuocSX_Load(object sender, EventArgs e)
        {
            txtMaNSX.Enabled = false;

            loadDataToGridview();
        }
        private void loadDataToGridview()
        {
            string sql = "Select * From NuocSX";
            tblNuocSX = Functions.GetDataToTable(sql);
            dataGridView_NuocSX.DataSource = tblNuocSX;
        }
       
        private void Resetvalue()
        {
            txtMaNSX.Text = "";
            txtTenNSX.Text = "";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            Resetvalue();
            txtMaNSX.Enabled = true;
            txtMaNSX.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNuocSX.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu! ");
            }
            if (txtMaNSX.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã NSX");
                txtMaNSX.Focus();
            }
            if(txtTenNSX.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên NSX");
                txtTenNSX.Focus();
            }
            sql = "update NuocSX set TenNSX='" + txtTenNSX.Text + "' where MaNSX ='" + txtMaNSX.Text + "'";
            Functions.RunSqlDel(sql);
            loadDataToGridview();
            Resetvalue();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNuocSX.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!");
            }
            if(txtMaNSX.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào");
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                sql = "delete from NuocSX where MaNSX= '" + txtMaNSX.Text + "'";
                Functions.RunSqlDel(sql);
                loadDataToGridview();
                Resetvalue();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNuocSX.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!");
                return;
            }
            if(txtMaNSX.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã NSX");
                txtMaNSX.Focus();
            }
            if(txtTenNSX.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên NSX");
                txtTenNSX.Focus();
            }
            sql = "Select MaNSX from NuocSX where MaNSX ='" + txtMaNSX.Text.Trim() + "'";
            if (Functions.Checkey(sql))
            {
                MessageBox.Show("Mã NSX này đã có bạn phải nhập mã khác");
                txtMaNSX.Focus();
                return;
            }
            sql = "insert into NuocSX values( '" + txtMaNSX.Text + "' ,'" + txtTenNSX.Text + "')";
            Functions.RunSqlDel(sql);
            loadDataToGridview();
            Resetvalue();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Resetvalue();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void dataGridView_NuocSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNSX.Text = dataGridView_NuocSX.CurrentRow.Cells["MaNSX"].Value.ToString();
            txtTenNSX.Text = dataGridView_NuocSX.CurrentRow.Cells["TenNSX"].Value.ToString();
            txtMaNSX.Enabled = false;
        }
    }
}
