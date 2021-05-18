namespace DisTask
{
    partial class MainForm
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
            this.ts_Main = new System.Windows.Forms.ToolStrip();
            this.ms_Main = new System.Windows.Forms.MenuStrip();
            this.tsmi_PersonList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_TaskList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_TaskDispatch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_TaskHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_PersonList = new System.Windows.Forms.ToolStripButton();
            this.tsb_TaskList = new System.Windows.Forms.ToolStripButton();
            this.tsb_TaskDispatch = new System.Windows.Forms.ToolStripButton();
            this.tsb_TaskHistory = new System.Windows.Forms.ToolStripButton();
            this.tsb_Exit = new System.Windows.Forms.ToolStripButton();
            this.ts_Main.SuspendLayout();
            this.ms_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts_Main
            // 
            this.ts_Main.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.ts_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_PersonList,
            this.tsb_TaskList,
            this.tsb_TaskDispatch,
            this.tsb_TaskHistory,
            this.tsb_Exit});
            this.ts_Main.Location = new System.Drawing.Point(0, 57);
            this.ts_Main.Name = "ts_Main";
            this.ts_Main.Size = new System.Drawing.Size(975, 51);
            this.ts_Main.TabIndex = 1;
            this.ts_Main.Text = "toolStrip1";
            // 
            // ms_Main
            // 
            this.ms_Main.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.ms_Main.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.ms_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_PersonList,
            this.tsmi_TaskList,
            this.tsmi_TaskDispatch,
            this.tsmi_TaskHistory,
            this.tsmi_Exit});
            this.ms_Main.Location = new System.Drawing.Point(0, 0);
            this.ms_Main.Name = "ms_Main";
            this.ms_Main.Size = new System.Drawing.Size(975, 49);
            this.ms_Main.TabIndex = 2;
            this.ms_Main.Text = "标题栏";
            // 
            // tsmi_PersonList
            // 
            this.tsmi_PersonList.Name = "tsmi_PersonList";
            this.tsmi_PersonList.Size = new System.Drawing.Size(133, 41);
            this.tsmi_PersonList.Text = "人员维护 &P";
            this.tsmi_PersonList.Click += new System.EventHandler(this.tsmi_PersonList_Click);
            // 
            // tsmi_TaskList
            // 
            this.tsmi_TaskList.Name = "tsmi_TaskList";
            this.tsmi_TaskList.Size = new System.Drawing.Size(132, 41);
            this.tsmi_TaskList.Text = "任务维护 &T";
            this.tsmi_TaskList.Click += new System.EventHandler(this.tsmi_TaskList_Click);
            // 
            // tsmi_TaskDispatch
            // 
            this.tsmi_TaskDispatch.Name = "tsmi_TaskDispatch";
            this.tsmi_TaskDispatch.Size = new System.Drawing.Size(136, 41);
            this.tsmi_TaskDispatch.Text = "任务分配 &D";
            this.tsmi_TaskDispatch.Click += new System.EventHandler(this.tsmi_TaskDispatch_Click);
            // 
            // tsmi_TaskHistory
            // 
            this.tsmi_TaskHistory.Name = "tsmi_TaskHistory";
            this.tsmi_TaskHistory.Size = new System.Drawing.Size(136, 41);
            this.tsmi_TaskHistory.Text = "任务历史 &H";
            this.tsmi_TaskHistory.Click += new System.EventHandler(this.tsmi_TaskHistory_Click);
            // 
            // tsmi_Exit
            // 
            this.tsmi_Exit.Name = "tsmi_Exit";
            this.tsmi_Exit.Size = new System.Drawing.Size(90, 41);
            this.tsmi_Exit.Text = "退出 &E";
            this.tsmi_Exit.Click += new System.EventHandler(this.tsmi_Exit_Click);
            // 
            // tsb_PersonList
            // 
            this.tsb_PersonList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_PersonList.Image = global::DisTask.Properties.Resources.Person;
            this.tsb_PersonList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_PersonList.Name = "tsb_PersonList";
            this.tsb_PersonList.Size = new System.Drawing.Size(40, 45);
            this.tsb_PersonList.Text = "人员维护";
            this.tsb_PersonList.Click += new System.EventHandler(this.tsb_PersonList_Click);
            // 
            // tsb_TaskList
            // 
            this.tsb_TaskList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_TaskList.Image = global::DisTask.Properties.Resources.Task;
            this.tsb_TaskList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_TaskList.Name = "tsb_TaskList";
            this.tsb_TaskList.Size = new System.Drawing.Size(40, 45);
            this.tsb_TaskList.Text = "任务维护";
            this.tsb_TaskList.Click += new System.EventHandler(this.tsb_TaskList_Click);
            // 
            // tsb_TaskDispatch
            // 
            this.tsb_TaskDispatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_TaskDispatch.Image = global::DisTask.Properties.Resources.Dispatch;
            this.tsb_TaskDispatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_TaskDispatch.Name = "tsb_TaskDispatch";
            this.tsb_TaskDispatch.Size = new System.Drawing.Size(40, 45);
            this.tsb_TaskDispatch.Text = "任务分配";
            this.tsb_TaskDispatch.Click += new System.EventHandler(this.tsb_TaskDispatch_Click);
            // 
            // tsb_TaskHistory
            // 
            this.tsb_TaskHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_TaskHistory.Image = global::DisTask.Properties.Resources.TaskHis;
            this.tsb_TaskHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_TaskHistory.Name = "tsb_TaskHistory";
            this.tsb_TaskHistory.Size = new System.Drawing.Size(40, 45);
            this.tsb_TaskHistory.Text = "任务历史";
            this.tsb_TaskHistory.Click += new System.EventHandler(this.tsb_TaskHistory_Click);
            // 
            // tsb_Exit
            // 
            this.tsb_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Exit.Image = global::DisTask.Properties.Resources.Exit;
            this.tsb_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Exit.Name = "tsb_Exit";
            this.tsb_Exit.Size = new System.Drawing.Size(40, 45);
            this.tsb_Exit.Text = "退出";
            this.tsb_Exit.Click += new System.EventHandler(this.tsb_Exit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 476);
            this.Controls.Add(this.ts_Main);
            this.Controls.Add(this.ms_Main);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ms_Main;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "任务分配程序";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ts_Main.ResumeLayout(false);
            this.ts_Main.PerformLayout();
            this.ms_Main.ResumeLayout(false);
            this.ms_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts_Main;
        private System.Windows.Forms.ToolStripButton tsb_PersonList;
        private System.Windows.Forms.ToolStripButton tsb_TaskList;
        private System.Windows.Forms.ToolStripButton tsb_TaskDispatch;
        private System.Windows.Forms.ToolStripButton tsb_TaskHistory;
        private System.Windows.Forms.MenuStrip ms_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PersonList;
        private System.Windows.Forms.ToolStripMenuItem tsmi_TaskList;
        private System.Windows.Forms.ToolStripMenuItem tsmi_TaskDispatch;
        private System.Windows.Forms.ToolStripMenuItem tsmi_TaskHistory;
        private System.Windows.Forms.ToolStripButton tsb_Exit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Exit;
    }
}

