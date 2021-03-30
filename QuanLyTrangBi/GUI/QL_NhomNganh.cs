using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTrangBi.Model;

namespace QuanLyTrangBi.GUI
{
    public partial class QL_NhomNganh : UserControl
    {
        int index = 0, index1 = 0;
        public Database db = Provider.db;
        int flag;
        public QL_NhomNganh()
        {
            InitializeComponent();
        }

        #region Hàm hỗ trợ
        private void Dis_En(bool e)
        {
            dgv_LoaiTrangBiMain.Enabled = e;
            btnThem.Enabled = e;
            btnSua.Enabled = e;
            btnXoa.Enabled = e;
            txtTimKiem.Enabled = e;

            btnLuu.Enabled = !e;
            btnHuy.Enabled = !e;
            txtTen_LoaiTrangBi.Enabled = !e;
        }

        private void ClearData()
        {
            txtTen_LoaiTrangBi.Text = "";
        }

        private EquipmentType DanhSach_LoaiTrangBiByID()
        {
            try
            {
                int id = (int)dgv_LoaiTrangBi.GetFocusedRowCellValue("ID");
                EquipmentType ltb = db.EquipmentTypes.Where(p => p.ID == id).FirstOrDefault();
                if (ltb == null) return new EquipmentType();
                return ltb;
            }
            catch
            {
                return new EquipmentType();
            }
        }
        private EquipmentType DanhSach_LoaiTrangBiByForm()
        {
            EquipmentType ltb = new EquipmentType();
            try
            {
                ltb.Name = txtTen_LoaiTrangBi.Text;
            }
            catch { }

            return ltb;
        }

        private void Binding()
        {
            try
            {
                EquipmentType ltb = DanhSach_LoaiTrangBiByID();
                if (ltb.ID == 0) return;
                txtTen_LoaiTrangBi.Text = ltb.Name;
            }
            catch { }
        }

        private bool Check()
        {
            if (txtTen_LoaiTrangBi.Text == "")
            {
                MessageBox.Show("Tên loại trang bị không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckLuaChon()
        {
            EquipmentType ltb = DanhSach_LoaiTrangBiByID();
            if (ltb.ID == 0)
            {
                MessageBox.Show("Chưa có loại trang bị nào được chọn",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Update(ref EquipmentType cu, EquipmentType moi)
        {
            cu.Name = moi.Name;
        }

        #endregion

        #region LoadForm
        private void LoadDS_LoaiTrangBi()
        {
            int i = 0;
            string key = txtTimKiem.Text.Trim().ToUpper();
            var listltb = db.EquipmentTypes.ToList()
                            .Select(p => new
                            {
                                ID = p.ID,
                                Name = p.Name,
                            }).ToList();
            dgv_LoaiTrangBiMain.DataSource = listltb.ToList()
                                     .Where(p => p.Name.ToUpper().Contains(key))
                                     .Select(p => new
                                     {
                                         ID = p.ID,
                                         STT = ++i,
                                         Name = p.Name    
                                     }).ToList();
            Binding();
            // load dong da chon
            try
            {
                index = index1;
                dgv_LoaiTrangBi.FocusedRowHandle = index;
                dgv_LoaiTrangBiMain.Select();
            }
            catch { }
        }
        private void QL_LoaiTrangBi_Load(object sender, EventArgs e)
        {
            ClearData();
            LoadDS_LoaiTrangBi();
            Dis_En(true);
        }
        #endregion

        #region Sự kiện

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            Dis_En(false);
            ClearData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            Dis_En(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckLuaChon() == false) return;
            EquipmentType ltb = DanhSach_LoaiTrangBiByID();
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa loại trang bị " + ltb.Name + "?",
                                              "Thông báo",
                                              MessageBoxButtons.OKCancel,
                                              MessageBoxIcon.Warning);

            if (rs == DialogResult.Cancel) return;

            try
            {
                db.EquipmentTypes.Remove(ltb);
                db.SaveChanges();
                MessageBox.Show("Xóa thông tin loại trang bị thành công",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thông tin loại trang bị thất bại\n" + ex.Message,
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            LoadDS_LoaiTrangBi();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            EquipmentType moi = DanhSach_LoaiTrangBiByForm();
            if (!Check()) return;
            if (flag == 0)
            {
                db.EquipmentTypes.Add(moi);
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Thêm thông tin loại trang bị thành công",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm thông tin loại trang bị thất bại\n" + ex.Message,
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                if (CheckLuaChon() == false) return;
                EquipmentType cu = DanhSach_LoaiTrangBiByID();
                Update(ref cu, moi);
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Sưa thông tin loại trang bị thành công",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa thông tin loại trang bị thất bại\n" + ex.Message,
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            LoadDS_LoaiTrangBi();
            Dis_En(true);
            return;
        }     

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Dis_En(true);
            Binding();
        }

        private void dgv_LoaiTrangBi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Binding();
            try
            {
                index1 = index;
                index = dgv_LoaiTrangBi.FocusedRowHandle;
            }
            catch { }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDS_LoaiTrangBi();
            txtTimKiem.Focus();
        }
        #endregion
    }
}
