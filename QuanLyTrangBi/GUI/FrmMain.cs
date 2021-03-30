using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using QuanLyTrangBi.GUI;

namespace QuanLyTrangBi
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnQL_TrangBi_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            QL_TrangBi uc = new QL_TrangBi();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btn_XuatBaoCao_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btnQL_LoaiTrangBi_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            QL_NhomNganh uc = new QL_NhomNganh();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnQL_ThuongHieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            QL_LoaiTrangBi uc = new QL_LoaiTrangBi();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnQL_ChuyenNhom_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            QL_ChuyenNhom uc = new QL_ChuyenNhom();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnQL_BaoDuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            QL_BaoDuong uc = new QL_BaoDuong();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnQL_Thamso_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            QL_ThamSo uc = new QL_ThamSo();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnQL_SuaChua_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            QL_SuaChua uc = new QL_SuaChua();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnTK_SuaChua_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            TK_SuaChua uc = new TK_SuaChua();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnTK_ChuyenNhom_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            TK_ChuyenNhom uc = new TK_ChuyenNhom();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            TK_BaoDuong uc = new TK_BaoDuong();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            QL_TrangBi uc = new QL_TrangBi();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }
       
    }
}