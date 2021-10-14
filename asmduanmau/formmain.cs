using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asmduanmau
{
    public partial class formmain : Form
    {
        public static int session = 0;
        public static int profile = 0;
        public static string email;
        Thread th;
        formdangnhap dn = new formdangnhap();
       // formdoimatkhau dmk = new formdoimatkhau();
        //private FormClosedEventHandler formdoimatkhau_FormClose;

        //private formdangnhap dn;

        public formmain()
        {
            InitializeComponent();
        }
       

        private void formquantri_Load(object sender, EventArgs e)
        {
            resetvalue();
            if (profile==1)
            {
                lbchao.Text = null;
                profile = 0;
            }
            this.IsMdiContainer = true;

        }
        
        private void menustripdangnhap_Click(object sender, EventArgs e)
        {

            
            dn = new formdangnhap();
            if (!checkExisForm("formdangnhap"))
            {
                dn.MdiParent = this;
               
                dn.Show();
                dn.FormClosed += new FormClosedEventHandler(form_FormClosed);
            }
            else
            {
                ActiveChildForm("formdangnhap");
            }
        }
        private bool checkExisForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

        private void hướngDẫnSửDụngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Tailieuhuongdansudung.pdf");
                System.Diagnostics.Process.Start(path);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file is not found in the specified location");
            }
        }
        void form_FormClosed(object sender,FormClosedEventArgs e)
        {
            this.Refresh();
            formquantri_Load(sender, e);
        }
        
        private void resetvalue()
        {
           
            if (session == 1)
            {
                lbchao.Text = "chao" + formmain.email;
                menustripnhanvien.Visible = true;
                menustripdanhmuc.Visible = true;
                menustripdangxuat.Enabled = true;
                menustripthongke.Visible = true;
                itemthongke.Visible = true;
                menustripdangnhap.Enabled = false;
                profilenv.Visible = true;
                if (/*int.Parse(dn.vaitro) == 0*/dn.vaitro== "False")
                {
                    vaitronv();
                }
            }
            else
            {
                menustripnhanvien.Visible = false;
                menustripdanhmuc.Visible = false;
                menustripdangxuat.Enabled = false;
                profilenv.Visible = false;
                menustripthongke.Visible = false;
                itemthongke.Visible = false;
                menustripdangnhap.Enabled = true;
            }
        }
        private void vaitronv()
        {
            menustripnhanvien.Visible = false;
            menustripthongke.Visible = false;
        }

        private void profilenv_Click(object sender, EventArgs e)
        {
           
            // dmk = new formdoimatkhau();
            if (!checkExisForm("formdoimatkhau"))
            {
               formdoimatkhau dmk = new formdoimatkhau(formmain.email);
                dmk.MdiParent = this;
               
                dmk.Show();
                dmk.FormClosed += new FormClosedEventHandler(form_FormClosed);
            }
            else
            {
                ActiveChildForm("formdoimatkhau");//form ông ck lên nhau ko, showdl ko dki//đẻ thử lại đã
            }
            
        }

       

        private void itemthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void itemgioithieu_Click(object sender, EventArgs e)
        {

        }

        private void menustripnhanvien_Click(object sender, EventArgs e)
        {
            
            if (!checkExisForm("formnhanvien"))
            {
                formnhanvien fnv = new formnhanvien();
                fnv.MdiParent = this;
                
                fnv.Show();
                 
                fnv.FormClosed += new FormClosedEventHandler(formnhanvien_FormClosed);
            }
            else
            {
                ActiveChildForm("formnhanvien");
            }
        }
        void formnhanvien_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
            formquantri_Load(sender, e);
        }

        private void menustripkhachhang_Click(object sender, EventArgs e)
        {
           
            if (!checkExisForm("FmKhachhang"))
            {
                FmKhachhang fkh = new FmKhachhang();
                fkh.MdiParent = this;
                
                fkh.Show();
                
                fkh.FormClosed += new FormClosedEventHandler(formnhanvien_FormClosed);
                
            }
            else
            {
                ActiveChildForm("FmKhachhang");
            }
        }

        private void menustripsanpham_Click(object sender, EventArgs e)
        {
            
            if (!checkExisForm("formhang"))
            {
                
                formhang fh = new formhang();
                fh.MdiParent = this;
                fh.Show();
                
               
                fh.FormClosed += new FormClosedEventHandler(formnhanvien_FormClosed);
                
            }
            else
            {
                ActiveChildForm("formhang");
            }
        }

        private void itemthongke_Click(object sender, EventArgs e)
        {
            if (!checkExisForm("formthongke"))
            {
                formthongke ftk = new formthongke();
                ftk.MdiParent = this;
                ftk.Show();
                //this.Hide();
                ftk.FormClosed += new FormClosedEventHandler(formnhanvien_FormClosed);

            }
            else
            {
                ActiveChildForm("formhang");
            }
        }

        private void menustriphethong_Click(object sender, EventArgs e)
        {

        }

        private void menustripdangxuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
