﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3Layer.BIZ;
using _3Layer;

namespace WinForms.LSCongTac
{
    public partial class frmLichSuCongTac : Form
    {
        QuanLyLuongEntities entity = new QuanLyLuongEntities();
        BIZ_LichSuCongTac bizLSCongTac = new BIZ_LichSuCongTac();
        public frmLichSuCongTac()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LichSuCongTac_Load(object sender, EventArgs e)
        {
            try
            {
                //đổ DL vào GridTable
                gridLSCongTac.AutoGenerateColumns = false; // ko cho tự động tạo cột
                List<LichSuCongTac> ds = bizLSCongTac.BIZLayDuLieu();
                int row = 0;
                foreach (LichSuCongTac lsct in ds)
                {
                    gridLSCongTac.Rows.Add(new DataGridViewRow()); //them dong moi trong grid khi trong CSDL co them dong
                    gridLSCongTac.Rows[row].Cells["maCongTac"].Value = lsct.MaCongTac;
                    gridLSCongTac.Rows[row].Cells["tenNV"].Value = lsct.NhanVien.HoTen;
                    gridLSCongTac.Rows[row].Cells["tenDonVi"].Value = lsct.DonVi.TenDonVi;
                    gridLSCongTac.Rows[row].Cells["tenChucVu"].Value = lsct.ChucVu.TenChucVu;
                    gridLSCongTac.Rows[row].Cells["tenNgach"].Value = lsct.NgachLuong.TenNgach;
                    gridLSCongTac.Rows[row].Cells["ngayLam"].Value = lsct.NgayLam;
                    gridLSCongTac.Rows[row].Cells["ngayChuyen"].Value = lsct.NgayChuyen;
                    row++;
                }

                //đổ dữ liệu vào combobox
                List<_3Layer.DonVi> dsDV = bizLSCongTac.BIZLayDLDonVi();
                cbDonVi.Items.Add("----Tất cả----");
                foreach (_3Layer.DonVi item in dsDV)
                {
                    cbDonVi.Items.Add(item);
                }
                //cbDonVi.DataSource = dsDV;
                cbDonVi.DisplayMember = "TenDonVi";
                cbDonVi.ValueMember = "MaDonVi";
                cbDonVi.SelectedIndex = 0;

                List<_3Layer.ChucVu> dsCV = bizLSCongTac.BIZLayDLChucVu();
                cbChucVu.Items.Add("----Tất cả----");
                foreach (_3Layer.ChucVu item in dsCV)
                {
                    cbChucVu.Items.Add(item);
                }
                //cbChucVu.DataSource = dsCV;
                cbChucVu.DisplayMember = "TenChucVu";
                cbChucVu.ValueMember = "MaChucVu";
                cbChucVu.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lấy được dữ liệu!");
            }
            
        }

        //Tìm
        private void btnSearch_MouseClick(object sender, MouseEventArgs e)
        {
            string maNV = txtMaNV.Text.ToString();
            string tenNV = txtTenNV.Text.ToString();

            try
            {
                //lấy giá trị của combobox donvi
                string donVi = "";
                if (cbDonVi.SelectedItem.ToString() == "----Tất cả----")
                {
                    donVi = cbDonVi.SelectedItem.ToString();
                }
                else
                {
                    _3Layer.DonVi DV = (_3Layer.DonVi)cbDonVi.SelectedItem;
                    donVi = DV.MaDonVi;
                }

                //lấy giá trị của combobox cbChucvu    
                string chucVu = "";
                if (cbChucVu.SelectedItem.ToString() == "----Tất cả----")
                {
                    chucVu = cbChucVu.SelectedItem.ToString(); //lấy chuỗi trên
                }
                else
                {
                    _3Layer.ChucVu CV = (_3Layer.ChucVu)cbChucVu.SelectedItem; //lấy đối tượng trong ChucVu
                    chucVu = CV.MaChucVu;
                }

                //khởi tạo danh sách tìm từ biz
                List<LichSuCongTac> dsTim = bizLSCongTac.BIZTimLSCongTac(maNV, tenNV, donVi, chucVu);
                if(dsTim.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy!");
                    gridLSCongTac.Rows.Clear();
                }

                //hiển thị danh sách sau khi tìm
                int row = 0;
                foreach (LichSuCongTac item in dsTim)
                {
                    gridLSCongTac.Rows[row].Cells["MaCongTac"].Value = item.MaChucVu;
                    gridLSCongTac.Rows[row].Cells["tenNV"].Value = item.NhanVien.HoTen;
                    gridLSCongTac.Rows[row].Cells["tenDonVi"].Value = item.DonVi.TenDonVi;
                    gridLSCongTac.Rows[row].Cells["tenChucVu"].Value = item.ChucVu.TenChucVu;
                    gridLSCongTac.Rows[row].Cells["tenNgach"].Value = item.NgachLuong.TenNgach;
                    gridLSCongTac.Rows[row].Cells["ngayLam"].Value = item.NgayLam;
                    gridLSCongTac.Rows[row].Cells["ngayChuyen"].Value = item.NgayChuyen;
                    row++;
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemLSCongTac them = new frmThemLSCongTac();
            them.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}