using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
namespace dis_task
{
    public partial class index : Form
    {

        private SQLiteHelper sql;

        public index()
        {
            InitializeComponent();
        }

        private void index_Load(object sender, EventArgs e)
        {
            

            string sql = "INSERT INTO dis_team VALUES (31,2,3,4);";
            SQLiteHelper.ExecuteNonQuery(sql);
            string sql2 = "select * from dis_team";
            string[] haha = SQLiteHelper.SqlRow(sql2);
            this.textBox1.Text = haha[3];

            this.dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = SQLiteHelper.SqlTable(sql2);

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

       
    }
}
