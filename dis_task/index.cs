using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace dis_task
{
    public partial class index : Form
    {

        private SQLiteHelper sql;

        public index()
        {
            InitializeComponent();
            skinEngine1.SkinFile = System.Environment.CurrentDirectory + "\\Skins\\MP10.ssk";　　//选择皮肤文件
        }

        private void index_Load(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToLongDateString().ToString();
            this.label2.Text = SQLiteHelper.Week();

            String week = SQLiteHelper.Week();


            //string sql = "INSERT INTO dis_team VALUES (31,2,3,4);";
            //SQLiteHelper.ExecuteNonQuery(sql);
            //查询当日可工作员工
            string sql = "select * from dis_team where (user_work like'%" + week + "%') or (user_work = '每天')";
            //string[] haha = SQLiteHelper.SqlRow(sql);
            //this.textBox1.Text = haha[3];

            this.dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = SQLiteHelper.SqlTable(sql);

            dataGridView1.Columns[0].HeaderCell.Value = "人员编号";
            dataGridView1.Columns[1].HeaderCell.Value = "人员姓名";
            dataGridView1.Columns[2].HeaderCell.Value = "所属小组";
            dataGridView1.Columns[3].HeaderCell.Value = "工作时间";

            int width = 0;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                this.dataGridView1.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += this.dataGridView1.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > this.dataGridView1.Size.Width)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void add_user_Click(object sender, EventArgs e)
        {
            this.Hide();
            user userForm = new user();
            //userForm.Show();
            userForm.ShowDialog();
            this.Dispose();//释放所有资源
        }

        private void dis_work_Click(object sender, EventArgs e)
        {
            this.Hide();
            dis_work dis_workForm = new dis_work();
            //userForm.Show();
            dis_workForm.ShowDialog();
            this.Dispose();//释放所有资源
        }

        private void today_work_Click(object sender, EventArgs e)
        {
            this.Hide();
            dis_disres dis_disresForm = new dis_disres();
            //userForm.Show();
            dis_disresForm.ShowDialog();
            this.Dispose();//释放所有资源dis_disres
        }

        private void old_dis_Click(object sender, EventArgs e)
        {
            this.Hide();
            dis_dishis dis_dishisForm = new dis_dishis();
            //userForm.Show();
            dis_dishisForm.ShowDialog();
            this.Dispose();//释放所有资源
        }

        private void index_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("请您确认是否退出(Y/N)", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                e.Cancel = false;//允许退出系统
                this.Dispose();//释放所有资源
                //Application.Exit();
            }
            else
            {
                e.Cancel = true;//阻止退出系统
            }

        }

        private void index_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();              //关闭窗体
        }
    }
}
