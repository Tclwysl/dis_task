using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisTask
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsmi_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请您确认是否退出(Y/N)", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tsmi_PersonList_Click(object sender, EventArgs e)
        {
            user userFrm = new user();
            userFrm.MdiParent = this;
            userFrm.StartPosition = FormStartPosition.CenterScreen;
            userFrm.Show();
        }

        private void tsmi_TaskList_Click(object sender, EventArgs e)
        {
            dis_work taskFrm = new dis_work();
            taskFrm.MdiParent = this;
            taskFrm.StartPosition = FormStartPosition.CenterScreen;
            taskFrm.Show();

        }

        private void tsmi_TaskDispatch_Click(object sender, EventArgs e)
        {
            dis_disres disFrm = new dis_disres();
            disFrm.MdiParent = this;
            disFrm.StartPosition = FormStartPosition.CenterScreen;
            disFrm.Show();
        }

        private void tsmi_TaskHistory_Click(object sender, EventArgs e)
        {
            dis_dishis hisFrm = new dis_dishis();
            hisFrm.MdiParent = this;
            hisFrm.StartPosition = FormStartPosition.CenterScreen;
            hisFrm.Show();
        }

        private void tsb_PersonList_Click(object sender, EventArgs e)
        {
            this.tsmi_PersonList_Click(sender, e);
        }

        private void tsb_TaskList_Click(object sender, EventArgs e)
        {
            this.tsmi_TaskList_Click(sender, e);
        }

        private void tsb_TaskDispatch_Click(object sender, EventArgs e)
        {
            this.tsmi_TaskDispatch_Click(sender, e);
        }

        private void tsb_TaskHistory_Click(object sender, EventArgs e)
        {
            this.tsmi_TaskHistory_Click(sender, e);
        }

        private void tsb_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请您确认是否退出(Y/N)", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
