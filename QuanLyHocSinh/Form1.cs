using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class Form1 : Form
    {
        private List<CHocSinh> dsHS;
        public Form1()
        {
            InitializeComponent();
        }
        private void hienThi()
        {
            dgvHocSinh.DataSource = dsHS.ToList();
        }
        private CHocSinh timHS(string ma)
        {
            foreach (CHocSinh item in dsHS)
            {
                if (item.MSHS == ma)
                    return item;
            }
            return null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //dsHS = new List<CHocSinh>();
            if (docFile("hs1.dat") == true)
            {
                hienThi();
            }
            else
                MessageBox.Show("Không đọc được");

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CHocSinh hs = new CHocSinh();
            hs.MSHS = txtMaHS.Text;
            hs.HoTen = txtHoTen.Text;
            hs.DiaChi = txtDiaChi.Text;
            if (rdbNam.Checked == true)
                hs.GioiTinh = "Nam";
            else
                hs.GioiTinh = "Nữ";
                hs.NgaySinh = dtpNgaySinh.Value;
            if (timHS(hs.MSHS) == null)
            {
                dsHS.Add(hs);
                hienThi();
            }
            else
                MessageBox.Show("Mã học sinh đã có trong ds");
        }

        private void dgvHocSinh_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHS.Text = dgvHocSinh.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen.Text = dgvHocSinh.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(dgvHocSinh.Rows[e.RowIndex].Cells[2].Value.ToString());
            if (dgvHocSinh.Rows[e.RowIndex].Cells[3].Value.ToString() == "Nam")
                rdbNam.Checked = true;
            else
                rdbNu.Checked = true;
            txtDiaChi.Text = dgvHocSinh.Rows[e.RowIndex].Cells[4].Value.ToString();
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mahs = txtMaHS.Text;
            if (timHS(mahs) == null)
            {
                MessageBox.Show("Không có hs trong danh sách");
                return;
            }
            foreach (CHocSinh item in dsHS)
            {
                if (item.MSHS == mahs)
                {
                    dsHS.Remove(item);
                    hienThi();
                    MessageBox.Show("Xóa thành công");
                    return;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mahs = txtMaHS.Text;
            if(timHS(mahs)==null)
            {
                MessageBox.Show("Không có học sinh trong danh sách");
                return;
            }
            foreach(CHocSinh item in dsHS)
            {
                if(item.MSHS==mahs)
                {
                    item.HoTen = txtHoTen.Text;
                    item.DiaChi = txtDiaChi.Text;
                    item.NgaySinh = dtpNgaySinh.Value;
                    if (rdbNam.Checked == true)
                        item.GioiTinh = "Nam";
                    else
                        item.GioiTinh = "Nữ";
                    hienThi();
                    return;

                }
            
            }
        }
        public bool GhiFile(string tenfile)
        {
            using (FileStream f = new FileStream(tenfile, FileMode.OpenOrCreate))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(f, dsHS);
                }
                catch (Exception)
                {
                    f.Close();
                    return false;
                }
                finally
                {
                    f.Close();
                }

                return true;
            }
        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            if (GhiFile("hs1.dat") == true)
                MessageBox.Show("Ghi File thành công");
            else
                MessageBox.Show("Ghi File không thành công");
        }
        public bool docFile(string tenFile)
        {
            using (FileStream f = new FileStream(tenFile, FileMode.OpenOrCreate))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    dsHS = bf.Deserialize(f) as List<CHocSinh>;
                }
                catch (Exception)
                {
                    f.Close();
                    return false;
                }
                finally
                {
                    f.Close();
                }

                return true;
            }
        }
    }
}
