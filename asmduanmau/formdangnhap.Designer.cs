
namespace asmduanmau
{
    partial class formdangnhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtemaildangnhap = new System.Windows.Forms.TextBox();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.chboxghinhomatkhau = new System.Windows.Forms.CheckBox();
            this.lbquenmatkhau = new System.Windows.Forms.Label();
            this.btndangnhap = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnmat = new System.Windows.Forms.Button();
            this.btnnotmat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email đăng nhập :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mistral", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(235, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 34);
            this.label3.TabIndex = 3;
            this.label3.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // txtemaildangnhap
            // 
            this.txtemaildangnhap.Location = new System.Drawing.Point(282, 191);
            this.txtemaildangnhap.Name = "txtemaildangnhap";
            this.txtemaildangnhap.Size = new System.Drawing.Size(278, 22);
            this.txtemaildangnhap.TabIndex = 4;
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(282, 239);
            this.txtmatkhau.Multiline = true;
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.PasswordChar = '*';
            this.txtmatkhau.Size = new System.Drawing.Size(278, 23);
            this.txtmatkhau.TabIndex = 5;
            // 
            // chboxghinhomatkhau
            // 
            this.chboxghinhomatkhau.AutoSize = true;
            this.chboxghinhomatkhau.Location = new System.Drawing.Point(282, 284);
            this.chboxghinhomatkhau.Name = "chboxghinhomatkhau";
            this.chboxghinhomatkhau.Size = new System.Drawing.Size(139, 21);
            this.chboxghinhomatkhau.TabIndex = 6;
            this.chboxghinhomatkhau.Text = "ghi nhớ mật khẩu";
            this.chboxghinhomatkhau.UseVisualStyleBackColor = true;
            // 
            // lbquenmatkhau
            // 
            this.lbquenmatkhau.AutoSize = true;
            this.lbquenmatkhau.Location = new System.Drawing.Point(446, 288);
            this.lbquenmatkhau.Name = "lbquenmatkhau";
            this.lbquenmatkhau.Size = new System.Drawing.Size(114, 17);
            this.lbquenmatkhau.TabIndex = 7;
            this.lbquenmatkhau.Text = "quên mật khẩu ?";
            this.lbquenmatkhau.Click += new System.EventHandler(this.lbquenmatkhau_Click);
            // 
            // btndangnhap
            // 
            this.btndangnhap.BackColor = System.Drawing.Color.Lime;
            this.btndangnhap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btndangnhap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btndangnhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btndangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangnhap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btndangnhap.Location = new System.Drawing.Point(210, 332);
            this.btndangnhap.Name = "btndangnhap";
            this.btndangnhap.Size = new System.Drawing.Size(172, 51);
            this.btndangnhap.TabIndex = 8;
            this.btndangnhap.Text = "ĐĂNG NHẬP";
            this.btndangnhap.UseVisualStyleBackColor = false;
            this.btndangnhap.Click += new System.EventHandler(this.btndangnhap_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.Color.Lime;
            this.btnthoat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnthoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.btnthoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnthoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthoat.Location = new System.Drawing.Point(432, 332);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(172, 51);
            this.btnthoat.TabIndex = 9;
            this.btnthoat.Text = "THOÁT";
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btnmat
            // 
            this.btnmat.BackgroundImage = global::asmduanmau.Properties.Resources.mat_removebg_preview;
            this.btnmat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnmat.Location = new System.Drawing.Point(508, 238);
            this.btnmat.Name = "btnmat";
            this.btnmat.Size = new System.Drawing.Size(52, 24);
            this.btnmat.TabIndex = 12;
            this.btnmat.UseVisualStyleBackColor = true;
            this.btnmat.Click += new System.EventHandler(this.btnmat_Click);
            // 
            // btnnotmat
            // 
            this.btnnotmat.BackgroundImage = global::asmduanmau.Properties.Resources.mat2_removebg_preview;
            this.btnnotmat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnnotmat.Location = new System.Drawing.Point(508, 239);
            this.btnnotmat.Name = "btnnotmat";
            this.btnnotmat.Size = new System.Drawing.Size(52, 24);
            this.btnnotmat.TabIndex = 11;
            this.btnnotmat.UseVisualStyleBackColor = true;
            this.btnnotmat.Click += new System.EventHandler(this.btnnotmat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::asmduanmau.Properties.Resources.images_removebg_preview;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(294, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 119);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // formdangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnmat);
            this.Controls.Add(this.btnnotmat);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btndangnhap);
            this.Controls.Add(this.lbquenmatkhau);
            this.Controls.Add(this.chboxghinhomatkhau);
            this.Controls.Add(this.txtmatkhau);
            this.Controls.Add(this.txtemaildangnhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "formdangnhap";
            this.Text = "formdangnhap";
            this.Load += new System.EventHandler(this.formdangnhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtemaildangnhap;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.CheckBox chboxghinhomatkhau;
        private System.Windows.Forms.Label lbquenmatkhau;
        private System.Windows.Forms.Button btndangnhap;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnnotmat;
        private System.Windows.Forms.Button btnmat;
    }
}