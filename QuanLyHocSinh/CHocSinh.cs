using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh
{
    [Serializable] public class CHocSinh
    {
        private string m_mahs;
        private string m_hoten;
        private DateTime m_ngaysinh;
        private string m_phai;
        private string m_diachi;
        public string MSHS
        {
            get { return m_mahs; }
            set { m_mahs = value; }
        }
        public string HoTen
        {
            get { return m_hoten; }
            set { m_hoten = value; }
        }
        public DateTime NgaySinh
        {
            get { return m_ngaysinh; }
            set { m_ngaysinh = value; }
        }
        public string GioiTinh
        {
            get { return m_phai; }
            set { m_phai = value; }
        }
        public string DiaChi
        {
            get { return m_diachi; }
            set { m_diachi = value; }
        }
        public CHocSinh(string ma, string ht, DateTime ns, string gt, string dc)
        {
            m_mahs = ma;
            m_hoten = ht;
            m_ngaysinh = ns;
            m_phai = gt;
            m_diachi = dc;

        }
        public CHocSinh()
        {
            m_mahs = " ";
            m_hoten = " ";
            m_ngaysinh = DateTime.Now;
            m_phai = " ";
            m_diachi = " ";
        }
    }
}

