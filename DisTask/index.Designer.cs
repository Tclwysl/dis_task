namespace DisTask
{
    partial class index
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.add_user = new System.Windows.Forms.Button();
            this.dis_work = new System.Windows.Forms.Button();
            this.today_work = new System.Windows.Forms.Button();
            this.old_dis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(879, 336);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(1, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 360);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "今日人员列表";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // add_user
            // 
            this.add_user.Location = new System.Drawing.Point(60, 54);
            this.add_user.Name = "add_user";
            this.add_user.Size = new System.Drawing.Size(142, 58);
            this.add_user.TabIndex = 4;
            this.add_user.Text = "添加人员";
            this.add_user.UseVisualStyleBackColor = true;
            this.add_user.Click += new System.EventHandler(this.add_user_Click);
            // 
            // dis_work
            // 
            this.dis_work.Location = new System.Drawing.Point(262, 54);
            this.dis_work.Name = "dis_work";
            this.dis_work.Size = new System.Drawing.Size(140, 58);
            this.dis_work.TabIndex = 5;
            this.dis_work.Text = "分配业务";
            this.dis_work.UseVisualStyleBackColor = true;
            this.dis_work.Click += new System.EventHandler(this.dis_work_Click);
            // 
            // today_work
            // 
            this.today_work.Location = new System.Drawing.Point(464, 54);
            this.today_work.Name = "today_work";
            this.today_work.Size = new System.Drawing.Size(140, 58);
            this.today_work.TabIndex = 6;
            this.today_work.Text = "查看今日分配";
            this.today_work.UseVisualStyleBackColor = true;
            this.today_work.Click += new System.EventHandler(this.today_work_Click);
            // 
            // old_dis
            // 
            this.old_dis.Location = new System.Drawing.Point(668, 54);
            this.old_dis.Name = "old_dis";
            this.old_dis.Size = new System.Drawing.Size(140, 58);
            this.old_dis.TabIndex = 7;
            this.old_dis.Text = "历史分配";
            this.old_dis.UseVisualStyleBackColor = true;
            this.old_dis.Click += new System.EventHandler(this.old_dis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(56, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(249, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "星期";
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(885, 509);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.old_dis);
            this.Controls.Add(this.today_work);
            this.Controls.Add(this.dis_work);
            this.Controls.Add(this.add_user);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "业务分配";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.index_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.index_FormClosed);
            this.Load += new System.EventHandler(this.index_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button add_user;
        private System.Windows.Forms.Button dis_work;
        private System.Windows.Forms.Button today_work;
        private System.Windows.Forms.Button old_dis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}

