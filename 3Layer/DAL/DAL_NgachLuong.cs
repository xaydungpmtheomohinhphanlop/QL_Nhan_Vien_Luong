﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Layer.DAL
{
    class DAL_NgachLuong
    {
        QuanLyLuongEntities entity = new QuanLyLuongEntities();

        //đổ DL vào gridview
        public List<NgachLuong> LayDuLieuNgach()
        {
            try
            {
                entity = new QuanLyLuongEntities();
                List<NgachLuong> list = new List<NgachLuong>();
                var ds = from ngach in entity.NgachLuongs
                         select ngach;
                list = ds.ToList();
                return list;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Tìm
        public List<NgachLuong> TimNgachLuong(string maTim, string tenTim)
        {
            try
            {
                List<NgachLuong> list = new List<NgachLuong>();
                var dsTim = from ngach in entity.NgachLuongs
                            select ngach;
                if(maTim != "")
                {
                    dsTim = dsTim.Where(s => s.MaNgach.Equals(maTim));
                }
                if(tenTim != "")
                {
                    dsTim = dsTim.Where(s => s.TenNgach.Contains(tenTim));
                }
                list = dsTim.ToList();
                return list;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Thêm ngạch lương
        public bool ThemNgachLuong(NgachLuong ngach)
        {
            try
            {
                entity.NgachLuongs.Add(ngach);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Xoá ngạch lương
        public bool XoaNgachLuong(string maXoa)
        {
            try
            {
                NgachLuong ngach = (NgachLuong)entity.NgachLuongs.Where(s => s.MaNgach == maXoa).First();
                entity.NgachLuongs.Remove(ngach);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Tạo mã tự động
        public string TaoMaNgachLuong()
        {
            try
            {
                string kq = "";
                var ma = from ngach in entity.NgachLuongs
                         orderby ngach.MaNgach descending
                         select ngach.MaNgach;
                if(ma.Count() == 0)
                {
                    kq = "N0001";
                }
                else
                {
                    string maNgach = ma.First().ToString();
                    int so = int.Parse(maNgach.Substring(1));
                    int soTang = so + 1;

                    if(soTang < 10)
                    {
                        kq = "N000" + soTang.ToString();
                    }
                    else if(soTang < 100)
                    {
                        kq = "N00" + soTang.ToString();
                    }
                    else if(soTang < 1000)
                    {
                        kq = "N0" + soTang.ToString();
                    }
                    else
                    {
                        kq = "N" + soTang.ToString();
                    }
                }
                return kq;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Sửa ngạch lương
        public bool SuaNgachLuong(NgachLuong ngachSua)
        {
            try
            {
                entity.NgachLuongs.Attach(ngachSua);
                var ngach = entity.Entry(ngachSua);
                ngach.Property(s => s.TenNgach).IsModified = true;
                ngach.Property(s => s.NienHan).IsModified = true;
                ngach.Property(s => s.MoTa).IsModified = true;
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Tìm ngạch lương theo mã để lấy DL đổ vào form sửa
        public NgachLuong TimNgachLuongTheoMa(string maTim)
        {
            try
            {
                var dsTim = (from ngachLuong in entity.NgachLuongs
                             where ngachLuong.MaNgach == maTim
                             select ngachLuong).ToList();
                if(dsTim.Count > 0)
                {
                    NgachLuong ngach = dsTim[0];
                    return ngach;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
