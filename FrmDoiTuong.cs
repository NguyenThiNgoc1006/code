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
    public partial class FrmDoiTuong : Form
    {
        DataTable tblDoiTuong;

        public FrmDoiTuong()
        {
            InitializeComponent();
        }

        private void FrmDoiTuong_Load(object sender, EventArgs e)
        {
            
            txtMaDT.Enabled = false;

            loadDataToGridview();
        }
        private void loadDataToGridview()
        {
            string sql = "Select * from DoiTuong";
            tblDoiTuong = Functions.GetDataToTable(sql);
            dataGridView_DoiTuong.DataSource = tblDoiTuong;
        }
       
        private void ResetValue()
        {
            txtMaDT.Text = "";
            txtTenDT.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtMaDT.Enabled = true;
            txtMaDT.Focus();
        }
       
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDoiTuong.Rows.Count == 0)
            {
                MessageBox.Show("không còn dữ liệu!");
            }
            if (txtMaDT.Text == "")
            {
                MessageBox.Show("bạn chưa nhập mã DT");
                txtMaDT.Focus();
            }
            if (txtTenDT.Text == "")
            {
                MessageBox.Show("bạn chưa nhập tên DT");
                txtTenDT.Focus();
            }
            sql = "update DoiTuong set tenDT = '" + txtTenDT.Text + "'where MaDT ='" + txtMaDT.Text + "'";
             
            Functions.RunSqlDel(sql);

            loadDataToGridview();
            ResetValue();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDoiTuong.Rows.Count == 0)
            {
                MessageBox.Show("không có dữ liệu!");
            }
            if (txtMaDT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào ");
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "Delete from DoiTuong where MaDT= '" + txtMaDT.Text + "'";
                Functions.RunSqlDel(sql);
                loadDataToGridview();
                ResetValue();

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDoiTuong.Rows.Count == 0)
            {
                MessageBox.Show("không còn dữ liệu");
                return;
            }
            if (txtMaDT.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã DT");
                txtMaDT.Focus();

            }
            if (txtTenDT.Text == "")
            {
                MessageBox.Show("Bạn cần nhập tên DT");
                txtTenDT.Focus();

            }
            sql = "select MaDT from DoiTuong where MaDT ='" + txtMaDT.Text.Trim() + "'";
            if (Functions.Checkey(sql))
            {
                MessageBox.Show("Mã này đã có, bạn phải nhập mã khác");
                txtMaDT.Focus();
                return;
            }
            sql = "insert into DoiTuong values('" + txtMaDT.Text + "' ,'" + txtTenDT.Text + "')";
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

        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_DoiTuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDT.Text = dataGridView_DoiTuong.CurrentRow.Cells["MaDT"].Value.ToString();
            txtTenDT.Text = dataGridView_DoiTuong.CurrentRow.Cells["TenDT"].Value.ToString();
            txtMaDT.Enabled = false;
           
        }
    }

    

       
    }

