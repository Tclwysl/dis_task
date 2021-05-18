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
    public partial class add_user : Form
    {
        public add_user()
        {
            InitializeComponent();
            

        }

        private void add_user_Load(object sender, EventArgs e)
        {
            uiCheckBoxGroup1.ColumnCount = 2;

            string team_dic_sql = "select value from dis_dic where dic_id = 2";
            List<string> team_dic = SQLiteHelper.sqlcolumn(team_dic_sql);
            foreach (string team_dic_type in team_dic)
            {
                uiComboBox1.Items.Add(""+ team_dic_type + "" );
            }
            this.uiComboBox1.SelectedIndex = 1;
        }

        

        private void uiCheckBoxGroup1_ValueChanged(object sender, int index, string text, bool isChecked)
        {
            if (index==5)
            {
                if (isChecked)
                {
                    uiCheckBoxGroup1.SelectAll();
                    
                }
                else
                {
                    uiCheckBoxGroup1.UnSelectAll();
                }
            }

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            var stringlist = new List<string>();//string List
            stringlist = uiCheckBoxGroup1.SelectedItems.ConvertAll(c => { return c.ToString(); }).ToList();//obj转str
            string[] strArra2 = stringlist.ToArray();//str转[]
            string user_work = string.Join("", strArra2);//[]转字符串
            if (uiTextBox1.Text == "")
            {
                MessageBox.Show("员工姓名不能为空哦！");
            }
            else if (uiComboBox1.Text == "")
            {
                MessageBox.Show("员工所属小组还未选择哦！");
            }
            
            else if (user_work == "")
            {
                MessageBox.Show("员工工作日还未选择哦！");
            }
            else
            {
                if (MessageBox.Show("确定新增?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string user_name = uiTextBox1.Text;
                    string user_team = uiComboBox1.Text;
                    if (user_work.Contains("每天"))
                    {
                        user_work = "每天";
                    }
                    
                    string add_user_sql = "INSERT INTO dis_team (user_name,user_team,user_work) VALUES ('"+ user_name + "','"+ user_team + "','"+ user_work + "')";
                    int overdis_add_user = SQLiteHelper.ExecuteNonQuery(add_user_sql);//add_user_sql（用户新增）
                    if (overdis_add_user == 1)
                    {
                        MessageBox.Show("员工信息添加成功!");
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("员工信息添加失败!");
                    }
                    
                }
            }
            

        }
    }
}
