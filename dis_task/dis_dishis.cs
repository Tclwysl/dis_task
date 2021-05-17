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
    public partial class dis_dishis : Form
    {
        string selectsql = "select * from dis_dishis";
        //数据库加载函数
        private void DisplayData()
        {
            //string sql = "select * from dis_team";
            //this.dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.DataSource = SQLiteHelper.SqlTable(sql);

            this.da = null;
            this.command = null;
            ds = new DataSet();
            command = new SQLiteCommand(selectsql, (SQLiteHelper.dbConnection()));
            da = new SQLiteDataAdapter(command);
            da.Fill(ds, "dis_dishis");
            this.dataGridView1.DataSource = ds.Tables[0];
            SQLiteHelper.closeConn();

        }

        private SQLiteDataAdapter da = null;
        SQLiteCommand command = null;
        DataSet ds = new DataSet();

        public dis_dishis()
        {
            InitializeComponent();
        }

        private void dis_dishis_Load(object sender, EventArgs e)
        {
            command = new SQLiteCommand(selectsql, (SQLiteHelper.dbConnection()));
            da = new SQLiteDataAdapter(command);
            da.Fill(ds, "dis_dishis");
            this.dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.Columns[0].HeaderCell.Value = "编号";
            dataGridView1.Columns[1].HeaderCell.Value = "业务id";
            dataGridView1.Columns[2].HeaderCell.Value = "客户姓名";
            dataGridView1.Columns[3].HeaderCell.Value = "拟贷款金额";
            dataGridView1.Columns[4].HeaderCell.Value = "业务类型";
            dataGridView1.Columns[5].HeaderCell.Value = "项目名称";
            dataGridView1.Columns[6].HeaderCell.Value = "机构名称";
            dataGridView1.Columns[7].HeaderCell.Value = "客户经理";
            dataGridView1.Columns[8].HeaderCell.Value = "地点";
            dataGridView1.Columns[9].HeaderCell.Value = "任务发布时间";
            dataGridView1.Columns[10].HeaderCell.Value = "业务难度";
            dataGridView1.Columns[11].HeaderCell.Value = "工作量";
            dataGridView1.Columns[12].HeaderCell.Value = "分配人员id";
            dataGridView1.Columns[13].HeaderCell.Value = "分配人员";
            dataGridView1.Columns[14].HeaderCell.Value = "分配日期";
           

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

        private void dis_dishis_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            index indexForm = new index();
            //userForm.Show();
            indexForm.ShowDialog();
            this.Dispose();//释放所有资源
        }
    }
}
