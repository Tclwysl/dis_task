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
    public partial class add_work : Form
    {
        public add_work()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string detwork_custname = uiTextBox1.Text;
            string detwork_loan = uiTextBox2.Text;
            string detwork_type = uiComboBox1.Text;
            string detwork_project = uiTextBox3.Text;
            string detwork_mechanism = uiTextBox4.Text;
            string detwork_manager = uiTextBox5.Text;
            string detwork_place = uiTextBox6.Text;
            string detwork_establishtime = uiTimePicker1.Text;
            string detwork_difficulty = uiComboBox2.Text;
            string detwork_workload = uiComboBox3.Text;

            if (MessageBox.Show("确定新增?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string add_work_sql = "INSERT INTO dis_detwork (detwork_custname, detwork_loan, detwork_type, detwork_project, detwork_mechanism, detwork_manager, detwork_place, detwork_establishtime, detwork_difficulty, detwork_workload) VALUES ('"+ detwork_custname + "', '"+ detwork_loan + "', '"+ detwork_type + "', '"+ detwork_project + "', '"+ detwork_mechanism + "', '"+ detwork_manager + "', '"+ detwork_place + "', '"+ detwork_establishtime + "', '"+ detwork_difficulty + "', '"+ detwork_workload + "')";
                int overdis_add_work = SQLiteHelper.ExecuteNonQuery(add_work_sql);//add_user_sql（用户新增）
                if (overdis_add_work == 1)
                {
                    MessageBox.Show("业务信息添加成功!");
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("业务信息添加失败!");
                }

            }

        }

        private void add_work_Load(object sender, EventArgs e)
        {

            //业务类型
            string detwork_type_sql = "select value from dis_dic where dic_id = 2";
            List<string> detwork_type = SQLiteHelper.sqlcolumn(detwork_type_sql);
            foreach (string work_type in detwork_type)
            {
                uiComboBox1.Items.Add("" + work_type + "");
            }
            this.uiComboBox1.SelectedIndex = 0;

            //业务难度detwork_difficulty_sql
            string detwork_dif_type_sql = "select value from dis_dic where dic_id = 3";
            List<string> detwork_dif_type = SQLiteHelper.sqlcolumn(detwork_dif_type_sql);
            foreach (string work_dif_type in detwork_dif_type)
            {
                uiComboBox2.Items.Add("" + work_dif_type + "");
            }
            this.uiComboBox2.SelectedIndex = 0;

            //工作量detwork_workload_sql
            string detwork_workload_sql = "select value from dis_dic where dic_id = 4";
            List<string> detwork_workload = SQLiteHelper.sqlcolumn(detwork_workload_sql);
            foreach (string detwork_load in detwork_workload)
            {
                uiComboBox3.Items.Add("" + detwork_load + "");
            }
            this.uiComboBox3.SelectedIndex = 0;
        }
    }
}
