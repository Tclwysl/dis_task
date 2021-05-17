using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dis_task
{
    public partial class dis_disres : Form
    {
        

        //数据库加载函数
        //private void DisplayData()
        //{
            

        //    this.da = null;
        //    this.command = null;
        //    ds = new DataSet();
        //    command = new SQLiteCommand(selectsql, (SQLiteHelper.dbConnection()));
        //    da = new SQLiteDataAdapter(command);
        //    da.Fill(ds, "dis_disres");
        //    this.dataGridView1.DataSource = ds.Tables[0];
        //    SQLiteHelper.closeConn();

        //}

        private SQLiteDataAdapter da = null;
        SQLiteCommand command = null;
        DataSet ds = new DataSet();

        public dis_disres()
        {
            InitializeComponent();
        }

        private void dis_disres_Load(object sender, EventArgs e)
        {
            this.groupBox1.Text = DateTime.Now.ToLongDateString().ToString();//日期
            string data = groupBox1.Text;
            string selectsql = "select * from dis_disres where disres_disestablishtime = '" + data + "'";


            command = new SQLiteCommand(selectsql, (SQLiteHelper.dbConnection()));
            da = new SQLiteDataAdapter(command);
            da.Fill(ds, "dis_disres");
            this.dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.Columns[0].HeaderCell.Value = "业务id";
            dataGridView1.Columns[1].HeaderCell.Value = "业务类型";
            dataGridView1.Columns[2].HeaderCell.Value = "分配时间";
            dataGridView1.Columns[3].HeaderCell.Value = "业务地点";
            dataGridView1.Columns[4].HeaderCell.Value = "分配人员id";
            dataGridView1.Columns[5].HeaderCell.Value = "分配人员姓名";
            dataGridView1.Columns[6].HeaderCell.Value = "所属小组";
            dataGridView1.Columns[7].HeaderCell.Value = "业务难度";
            dataGridView1.Columns[8].HeaderCell.Value = "工作量";
            //dataGridView1.Columns[9].HeaderCell.Value = "工作总量";
            


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

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未更新....");
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            index indexForm = new index();
            //userForm.Show();
            indexForm.ShowDialog();
            this.Dispose();//释放所有资源
        }

        private void dis_disres_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            index indexForm = new index();
            //userForm.Show();
            indexForm.ShowDialog();
            this.Dispose();//释放所有资源
        }
    }
}
