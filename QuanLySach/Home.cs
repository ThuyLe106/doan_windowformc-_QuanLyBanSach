using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySach
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon dang xuat khong?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                frmDangNhap dangNhap = new frmDangNhap();
                dangNhap.ShowDialog();
            }
        }
        private void XoaGiaTri()
        {
            txtLoaiSach.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNhaSX.Text = "";
            txtSoLuong.Text = "";
            txtGiaTien.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtLoaiSach.Text != "" && txtTenSach.Text != "" && txtTacGia.Text != "" && txtNhaSX.Text != "" && txtSoLuong.Text != "" && txtGiaTien.Text != "")
            {
                try
                {
                    int soLuong = Convert.ToInt32(txtSoLuong.Text);
                    try
                    {
                        int giaTien = Convert.ToInt32(txtGiaTien.Text);
                        dgvKhoSach.Rows.Add(txtLoaiSach.Text, txtTenSach.Text, txtTacGia.Text, txtNhaSX.Text, txtSoLuong.Text, txtGiaTien.Text);
                        XoaGiaTri();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Nhap sai su lieu gia tien");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Nhap sai su lieu so luong");
                }
            }
            else
            {

                    MessageBox.Show("Ban can nhap du thong tin");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int viTri = dgvKhoSach.CurrentCell.RowIndex;
            if(MessageBox.Show("Ban co muon xoa thong tin nay khong!", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                dgvKhoSach.Rows.RemoveAt(viTri);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int vitri = dgvKhoSach.CurrentCell.RowIndex;
            dgvKhoSach[0, vitri].Value = txtLoaiSach.Text;
            dgvKhoSach[1, vitri].Value = txtTenSach.Text;
            dgvKhoSach[2, vitri].Value = txtTacGia.Text;
            dgvKhoSach[3, vitri].Value = txtNhaSX.Text;
            dgvKhoSach[4, vitri].Value = txtSoLuong.Text;
            dgvKhoSach[5, vitri].Value = txtGiaTien.Text;
            XoaGiaTri();
        }

        private void dgvKhoSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvKhoSach.Rows.Count != 0)
            {
            DataGridViewRow row = dgvKhoSach.Rows[dgvKhoSach.CurrentCell.RowIndex];
            txtLoaiSach.Text = row.Cells[0].Value.ToString();
            txtTenSach.Text = row.Cells[1].Value.ToString();
            txtTacGia.Text = row.Cells[2].Value.ToString();
            txtNhaSX.Text = row.Cells[3].Value.ToString();
            txtSoLuong.Text = row.Cells[4].Value.ToString();
            txtGiaTien.Text = row.Cells[5].Value.ToString();
            }
         

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (checkBoxLoaiSach.Checked)
            {
                dgvTimKiem.Rows.Clear();
                for (int i = 0; i < dgvKhoSach.Rows.Count -1; i++)
                {
                    if (dgvKhoSach[0,i].Value.ToString() == txtcbLoaiSach.Text)
                    {
                        dgvTimKiem.Rows.Add(dgvKhoSach[1,i].Value, dgvKhoSach[2, i].Value, dgvKhoSach[4,i].Value, dgvKhoSach[5, i].Value);
                    }
                }
            }
          else  if (checkBoxTacGia.Checked)
            {
                dgvTimKiem.Rows.Clear();
                for (int i = 0; i < dgvKhoSach.Rows.Count - 1; i++)
                {
                    if (dgvKhoSach[2, i].Value.ToString() == txtcbTacGia.Text)
                    {
                        dgvTimKiem.Rows.Add(dgvKhoSach[1, i].Value, dgvKhoSach[2, i].Value, dgvKhoSach[4, i].Value, dgvKhoSach[5, i].Value);
                    }
                }
            }
            else if (checkBoxLoaiSach.Checked && checkBoxTacGia.Checked)
            {
                dgvTimKiem.Rows.Clear();
                for (int i = 0; i < dgvKhoSach.Rows.Count - 1; i++)
                {
                    if (dgvKhoSach[0, i].Value.ToString() == txtcbLoaiSach.Text && dgvKhoSach[2, i].Value.ToString() == txtcbTacGia.Text)
                    {
                        dgvTimKiem.Rows.Add(dgvKhoSach[1, i].Value, dgvKhoSach[2, i].Value, dgvKhoSach[4, i].Value, dgvKhoSach[5, i].Value);
                    }
                }
            }
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            if (txtTenSach1.Text != "" && txtSoLuong2.Text != "" && txtGiaTien2.Text != "")
            {
                try
                {
                    int soLuong = Convert.ToInt32(txtSoLuong2.Text);
                    try
                    {
                        int giaTien = Convert.ToInt32(txtGiaTien2.Text);
                        for (int i = 0; i < dgvKhoSach.Rows.Count - 1; i++)
                        {
                            if (dgvKhoSach[1,i].Value.ToString() == txtTenSach1.Text)
                            {
                                //Neu sach con trong kho
                                if (Convert.ToInt32(dgvKhoSach[4,i].Value) - Convert.ToInt32(txtSoLuong2.Text) >= 0)
                                {
                                    //Dieu kien so sach
                                    int gia1 = Convert.ToInt32(dgvKhoSach[5, i].Value) / Convert.ToInt32(dgvKhoSach[4, i].Value);
                                    int gia2 = Convert.ToInt32(txtGiaTien2.Text) / Convert.ToInt32(txtSoLuong2.Text);
                                    int tienLai = (gia2 - gia1) * Convert.ToInt32(txtSoLuong2.Text);
                                    dgvMuaSach.Rows.Add(dgvKhoSach[0,i].Value, txtTenSach1.Text, txtSoLuong2.Text, tienLai.ToString(),
                                        dateTimeNgayMua.Text);
                                    dgvKhoSach[4, i].Value = Convert.ToInt32(dgvKhoSach[4, i].Value) - Convert.ToInt32(txtSoLuong2.Text);
                                    dgvKhoSach[5, i].Value = Convert.ToInt32(dgvKhoSach[4, i].Value) * gia1;

                                }
                                else
                                {
                                    MessageBox.Show("Sach khong du , Chi con " + dgvKhoSach[4, i].Value);
                                }
                              
                            }
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Ban nhap sai du lieu gia tien");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Ban nhap sai du lieu");
                }
            }
            else
            {
                MessageBox.Show("Nhap day du thong tin!");
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cbLoaiSach3.Checked)
            {
                dgvThongKe.Rows.Clear();
                for (int i = 0; i < dgvMuaSach.Rows.Count - 1; i++)
                {
                    if (dgvMuaSach[0,i].Value.ToString() == txtcbLoaiSach.Text)
                    {
                        dgvThongKe.Rows.Add(dgvMuaSach[0, i].Value,
                    dgvMuaSach[1, i].Value, dgvMuaSach[2, i].Value, dgvMuaSach[3, i].Value,
                    dgvMuaSach[4, i].Value);
                    }
                    
                }
            }
          else  if (cbNgayThang3.Checked)
            {
                dgvThongKe.Rows.Clear();
                for (int i = 0; i < dgvMuaSach.Rows.Count - 1; i++)
                {
                    if (dgvMuaSach[4,i].Value.ToString() == dateTimeNgayMua.Text)
                    {
                        dgvThongKe.Rows.Add(dgvMuaSach[0, i].Value,
                    dgvMuaSach[1, i].Value, dgvMuaSach[2, i].Value, dgvMuaSach[3, i].Value,
                    dgvMuaSach[4, i].Value);
                    }
                    
                }
            }
          else  if (cbLoaiSach3.Checked && cbNgayThang3.Checked)
            {
                dgvThongKe.Rows.Clear();
                for (int i = 0; i < dgvMuaSach.Rows.Count - 1; i++)
                {
                    if (dgvMuaSach[0, i].Value.ToString() == txtcbLoaiSach.Text && dgvMuaSach[4, i].Value.ToString() == dateTimeNgayMua3.Text)
                    {
                        dgvThongKe.Rows.Add(dgvMuaSach[0, i].Value,
                    dgvMuaSach[1, i].Value, dgvMuaSach[2, i].Value, dgvMuaSach[3, i].Value,
                    dgvMuaSach[4, i].Value);
                    }

                }
            }

        }

        private void btnDung_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
