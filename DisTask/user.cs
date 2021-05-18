using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisTask
{
    public partial class user : Form
    {
        string selectsql = "select * from dis_team";
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
            da.Fill(ds, "dis_team");
            this.dataGridView1.DataSource = ds.Tables[0];
            SQLiteHelper.closeConn();

        }

        private SQLiteDataAdapter da = null;
        SQLiteCommand command = null;
        DataSet ds = new DataSet();

        public user()
        {
            InitializeComponent();
            
        }

        private void user_Load(object sender, EventArgs e)
        {
            //this.dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.DataSource = SQLiteHelper.SqlTable(selectsql);
            //(SQLiteHelper.dbConnection())   //等于conn


            command = new SQLiteCommand(selectsql, (SQLiteHelper.dbConnection()));
            da = new SQLiteDataAdapter(command);
            da.Fill(ds, "dis_team");
            this.dataGridView1.DataSource = ds.Tables[0];


            dataGridView1.Columns[0].HeaderCell.Value = "人员编号";
            dataGridView1.Columns[1].HeaderCell.Value = "人员姓名";
            dataGridView1.Columns[2].HeaderCell.Value = "所属小组";
            dataGridView1.Columns[3].HeaderCell.Value = "工作时间";



            dataGridView1.Columns[0].ReadOnly = true;//人员编号列 只读
            //dataGridView1.Columns[4].HeaderCell.Value = "总工作量";

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
            add_user adduser = new add_user();
            adduser.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            //MessageBox.Show(this.dataGridView1.CurrentRow.Cells[1].Value + "");
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                MessageBox.Show("即将删除的员工姓名： " + this.dataGridView1.CurrentRow.Cells[1].Value);
                if (MessageBox.Show("确认删除?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show(this.dataGridView1.CurrentRow.Cells[1].Value + "");
                    ds.AcceptChanges();
                    SQLiteCommandBuilder scb = new SQLiteCommandBuilder(da);
                    ds.Tables[0].Rows[this.dataGridView1.CurrentRow.Index].Delete();
                    da.DeleteCommand = scb.GetDeleteCommand();
                    da.Update(ds, "dis_team");
                    DisplayData();

                }
            }
            else if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("只能选中一行哦", "提示");
            }
            else
            {
                MessageBox.Show("需要点击想删除用户的id列前面的空白部分哦", "提示");
            }
        }

        private void button3_Click(object sender, EventArgs e)//修改
        {
            if (MessageBox.Show("确定修改?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(da);
                da.UpdateCommand = scb.GetUpdateCommand();
                da.Update(ds, "dis_team");
                DisplayData();
            }

            
        }

        private void button4_Click(object sender, EventArgs e)//更新
        {
            DisplayData();
            MessageBox.Show("刷新成功！");


        }

        private void add_Click(object sender, EventArgs e)
        {
            this.button1_Click(this, null);
        }

        private void del_Click(object sender, EventArgs e)
        {
            this.button2_Click(this, null);
        }

        private void upd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定修改?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(da);
                da.UpdateCommand = scb.GetUpdateCommand();
                da.Update(ds, "dis_team");
                DisplayData();
            }
        }

        private void res_Click(object sender, EventArgs e)
        {
            DisplayData();
            MessageBox.Show("刷新成功！");
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            index indexForm = new index();
            //userForm.Show();
            indexForm.ShowDialog();
            this.Dispose();//释放所有资源
        }

        private void user_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            index indexForm = new index();
            //userForm.Show();
            
            indexForm.ShowDialog();
            this.Dispose();//释放所有资源
            //this.Close();
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            index indexForm = new index();
            //userForm.Show();
           
            indexForm.ShowDialog();
            this.Dispose();//释放所有资源
            //this.Close();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
