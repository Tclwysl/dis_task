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
    public partial class dis_work : Form
    {
        string selectsql = "select detwork_id,detwork_custname,detwork_loan,detwork_type,detwork_project,detwork_mechanism,detwork_manager,detwork_place,detwork_establishtime,detwork_difficulty,detwork_workload,detwork_state from dis_detwork where detwork_bz = '1'";
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
            da.Fill(ds, "dis_detwork");
            this.dataGridView1.DataSource = ds.Tables[0];
            SQLiteHelper.closeConn();

        }

        private SQLiteDataAdapter da = null;
        SQLiteCommand command = null;
        DataSet ds = new DataSet();

        public dis_work()
        {
            InitializeComponent();
        }

        private void dis_work_Load(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToLongDateString().ToString();//日期
            this.label2.Text = SQLiteHelper.Week();//星期

            command = new SQLiteCommand(selectsql, (SQLiteHelper.dbConnection()));
            da = new SQLiteDataAdapter(command);
            da.Fill(ds, "dis_detwork");
            this.dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.Columns[0].HeaderCell.Value = "业务id";
            dataGridView1.Columns[1].HeaderCell.Value = "客户姓名";
            dataGridView1.Columns[2].HeaderCell.Value = "拟贷款金额";
            dataGridView1.Columns[3].HeaderCell.Value = "业务类型";
            dataGridView1.Columns[4].HeaderCell.Value = "项目名称";
            dataGridView1.Columns[5].HeaderCell.Value = "机构名称";
            dataGridView1.Columns[6].HeaderCell.Value = "客户经理";
            dataGridView1.Columns[7].HeaderCell.Value = "地点";
            dataGridView1.Columns[8].HeaderCell.Value = "任务发布时间";
            dataGridView1.Columns[9].HeaderCell.Value = "业务难度";
            dataGridView1.Columns[10].HeaderCell.Value = "工作量";
            dataGridView1.Columns[11].HeaderCell.Value = "业务状态";

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

        private void button1_Click(object sender, EventArgs e)//增加
        {
            if (MessageBox.Show("确定新增?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(da);
                da.InsertCommand = scb.GetInsertCommand();
                da.Update(ds, "dis_detwork");
                DisplayData();
            }
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            if (MessageBox.Show("确认删除?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ds.AcceptChanges();
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(da);
                ds.Tables[0].Rows[this.dataGridView1.CurrentRow.Index].Delete();
                da.DeleteCommand = scb.GetDeleteCommand();
                da.Update(ds, "dis_detwork");
                DisplayData();

            }
        }

        private void button3_Click(object sender, EventArgs e)//修改
        {
            if (MessageBox.Show("确定修改?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(da);
                da.UpdateCommand = scb.GetUpdateCommand();
                da.Update(ds, "dis_detwork");
                DisplayData();
            }
        }

        private void button4_Click(object sender, EventArgs e)//刷新
        {
            DisplayData();
            MessageBox.Show("刷新成功！");
        }

        private void button5_Click(object sender, EventArgs e)//分配
        {
          
            //string work_user_sql = "";
            
            dis dis = new dis();

            //dis.MdiParent = this;

            dis.ShowDialog();
            //   MessageBox.Show("da！");
        }

        private void button6_Click(object sender, EventArgs e)//返回
        {
            this.Hide();
            index indexForm = new index();
            //userForm.Show();
            indexForm.ShowDialog();
            this.Dispose();//释放所有资源
        }

        private void dis_work_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            index indexForm = new index();
            //userForm.Show();
            indexForm.ShowDialog();
            this.Dispose();//释放所有资源
        }
    }
}
