using BUS_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asmduanmau
{
    public partial class formthongke : Form
    {
        public formthongke()
        {
            InitializeComponent();
        }
        
        

        private void formthongke_Load(object sender, EventArgs e)
        {
            tabPage2.Text = "Sản phẩm tồn kho";
            tabPage1.Text = "Sản phẩm nhập kho";
            loadGrid_Ton();
            dtgrsanphamnhapkho_Load();
            
        }
        BUS_Hang bushang = new BUS_Hang();
        private void dtgrsanphamnhapkho_Load()
        {
          // dtgrsanphamnhapkho.AutoResizeColumns();
           dtgrsanphamnhapkho.DataSource = bushang.thongkehang();
          // dtgrsanphamnhapkho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgrsanphamnhapkho.Columns[0].HeaderText = "mã Nhân viên";
            dtgrsanphamnhapkho.Columns[1].HeaderText = "tên Nhân viên";
            dtgrsanphamnhapkho.Columns[2].HeaderText = "Số lượng sản phẩm nhập";
            // dtgrsanphamnhapkho.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //  dtgrsanphamnhapkho.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            

        }
        private void loadGrid_Ton()
        {
            dtgrsanphamtonkho.DataSource = bushang.thongketon();
            dtgrsanphamtonkho.Columns[0].HeaderText = "Tên sản phẩm";
            dtgrsanphamtonkho.Columns[1].HeaderText = "Tồn kho";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }  
        private void tabPage2_Click(object sender, EventArgs e)
        {
        }
    }
}
