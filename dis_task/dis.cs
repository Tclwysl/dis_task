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
    public partial class dis : Form
    {
        public dis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            string rqdata = dateTimePicker1.Text;
            string week = GetWeekDes((int)date.DayOfWeek);//判断是星期几

            string work_sql = "select * from dis_detwork where detwork_bz = '1' order by random()";//sql工作随机


            if (week != "星期六" && week != "星期日")
            {
                //新增 避免一直随机到幸运儿
                string adduser_work_sql = "select * from dis_team where (user_work like'%" + week + "%') or (user_work = '每天')";
                List<string> adduser_work = SQLiteHelper.sqlcolumn(adduser_work_sql);//获取当日可工作员工编号
                foreach (string adduser in adduser_work)
                {
                    string select_user_sql = "select * from dis_team where user_id= " + adduser + "";
                    string[] select_user = SQLiteHelper.SqlRow(select_user_sql);//获取员工数据


                    string add_workuser_sql = "insert into dis_workload(dis_userid,dis_username,dis_level,dis_data) VALUES (" + select_user[0] + ",'" + select_user[1] + "','" + select_user[2] + "','" + rqdata + "')";
                    int i = SQLiteHelper.ExecuteNonQuery(add_workuser_sql);
                }

                if (MessageBox.Show("确定分配?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<string> akk_work = SQLiteHelper.sqlcolumn(work_sql);//获取随机工作编号
                    foreach (System.String work in akk_work)
                    {
                        //分配标志dis_bz
                        int dis_bz = 0;

                        //获取工作等级
                        string work_lev = "select detwork_difficulty from dis_detwork where  " + work + " ";
                        string work_leve = SQLiteHelper.sqlone(work_lev);
                        string work_level;
                        if (work_leve == "A" || work_leve == "B")
                        {
                            work_level = "F";
                        }
                        else
                        {
                            work_level = "E";
                        }

                        //查询当日可工作员工
                        string user_sql = "select * from dis_team where (user_work like'%" + week + "%') or (user_work = '每天') order by random()";

                        List<string> user_id = SQLiteHelper.sqlcolumn(user_sql);//获取可工作人员编号（随机）
                        foreach (System.String user in user_id)
                        {
                            //获取当日工作分配

                            string todaywork_sql = "select COUNT(*) from dis_workload where dis_userid = " + user + " and  dis_data = '" + rqdata + "'";
                            string pd = SQLiteHelper.sqlone(todaywork_sql);
                            //查询当前人员等级
                            string user_lev_sql = "select user_team from dis_team where user_id = " + user + " ";
                            string user_level_sql = SQLiteHelper.sqlone(user_lev_sql);

                            if ((user_level_sql != work_level) && (user_level_sql != "E"))//如果当前人员等级不等于任务等级，或者当前人员等级不是E级
                            {
                                continue;//人员等级与任务等级不匹配
                            }

                            if (pd == "1")//当日已经分配过这个人
                            {
                                //判断工作量
                                //MessageBox.Show("人员id：" + user + "");
                                //如果任务是E级，就找E级工作量最少的那个
                                string leswork_sql;
                                if (work_level == "E")
                                {
                                    leswork_sql = "SELECT dis_work FROM dis_workload where dis_level = 'E' and dis_data = '" + rqdata + "' ORDER BY dis_work ";//获取最少的工作量是多少
                                }
                                else
                                {
                                    leswork_sql = "SELECT dis_work FROM dis_workload where dis_data = '" + rqdata + "' ORDER BY dis_work ";//获取最少的工作量是多少
                                }
                                string thisleswork_sql = "SELECT dis_work FROM dis_workload where  dis_userid = " + user + " and  dis_data = '" + rqdata + "'";//获取当前人员的工作量是不是最少工作量

                                string getleswork = SQLiteHelper.sqlone(leswork_sql);//最少工作量
                                string getthisleswork = SQLiteHelper.sqlone(thisleswork_sql);//当前人员工作量

                                if (getleswork == getthisleswork)
                                {

                                    //执行分配
                                    //获取分配人员姓名、小组
                                    string usernameteam_sql = "select user_name,user_team from dis_team where user_id = " + user + "";
                                    string[] usernameteam = SQLiteHelper.SqlRow(usernameteam_sql);//分配人员姓名、小组（list）
                                    //获取任务数据
                                    string worklist_sql = "select * from dis_detwork where detwork_id = " + work + "";
                                    string[] work_row = SQLiteHelper.SqlRow(worklist_sql);//获取任务数据

                                    /*********************      dis_disres（当日分配新增） -----overdisres     **********************************/                                  
                                    string in_dis_disresSql = "insert into dis_disres(disres_id,disres_type,disres_disestablishtime,disres_palce,disres_userid,disres_username,disres_userteam,disres_difficulty,disres_workload) values (" + work_row[0] + ",'" + work_row[3] + "','" + rqdata + "','" + work_row[7] + "'," + user + ",'" + usernameteam[0] + "','" + usernameteam[1] + "','" + work_row[9] + "','" + work_row[10] + "')";                                   
                                    /*********************************************************/

                                    /***********************      dis_dishis（历史分配新增） -----overdishis     ************************************/
                                    string in_dis_dishisSql = "insert into dis_dishis(dishis_id, dishis_cusname, dishis_loan, dishis_type, dishis_project, dishis_mechanism, dishis_manager, dishis_place, dishis_establishtime, dishis_difficulty, dishis_workload, dishis_userid, dishis_username, dishis_disestablishtime) VALUES (" + work_row[0] + ", '" + work_row[1] + "', '" + work_row[2] + "', '" + work_row[3] + "', '" + work_row[4] + "', '" + work_row[5] + "', '" + work_row[6] + "', '" + work_row[7] + "', '" + work_row[8] + "', '" + work_row[9] + "', '" + work_row[10] + "', " + user + ", '" + usernameteam[0] + "', '" + rqdata + "')";
                                    /*********************************************************/

                                    /***********************      del_detwork（任务列表软删除） -----overdeldetwork     ************************************/
                                    string del_dis_detworkSql = "update dis_detwork set detwork_bz = 0 where detwork_id = " + work + "";
                                    /*********************************************************/

                                    /***********************      add_workload（当日工作量增加） -----overaddworkload    ************************************/
                                    string add_dis_workloadSql = "update dis_workload set dis_work = dis_work + " + work_row[10] + " where dis_userid="+user+"";
                                    /*********************************************************/

                                    int overdis_disres = SQLiteHelper.ExecuteNonQuery(in_dis_disresSql);//dis_disres（当日分配） -----overdisres
                                    int overdis_dishis = SQLiteHelper.ExecuteNonQuery(in_dis_dishisSql);//dis_dishis（历史分配） -----overdishis 
                                    int overdeldetwork = SQLiteHelper.ExecuteNonQuery(del_dis_detworkSql);//del_detwork（任务列表软删除） -----overdeldetwork
                                    int overaddworkload = SQLiteHelper.ExecuteNonQuery(add_dis_workloadSql);//add_workload（当日工作量增加） -----overaddworkload

                                    if (overdis_disres == 1 && overdis_dishis == 1 && overdeldetwork == 1 && overaddworkload == 1)
                                    {
                                        //分配成功
                                        dis_bz = 1;//分配完毕标志位置1
                                                   //dis_bz分配标志置1
                                        break;//进行下一个任务的分配
                                    }
                                }
                                else
                                {
                                    continue;//判断不是工作量最少的人，跳出本次分配继续下一个
                                }
                            }
                            else//没有分配过任务
                            {
                                //执行分配
                                //获取分配人员姓名、小组
                                string usernameteam_sql = "select user_name,user_team from dis_team where user_id = " + user + "";
                                string[] usernameteam = SQLiteHelper.SqlRow(usernameteam_sql);//分配人员姓名、小组（list）
                                                                                              //获取任务数据
                                string worklist_sql = "select * from dis_detwork where detwork_id = " + work + "";
                                string[] work_row = SQLiteHelper.SqlRow(worklist_sql);//获取任务数据


                                /*********************      dis_disres（当日分配新增） -----overdis_disres     **********************************/
                                string in_dis_disresSql = "insert into dis_disres(disres_id,disres_type,disres_disestablishtime,disres_palce,disres_userid,disres_username,disres_userteam,disres_difficulty,disres_workload) values (" + work_row[0] + ",'" + work_row[3] + "','" + rqdata + "','" + work_row[7] + "'," + user + ",'" + usernameteam[0] + "','" + usernameteam[1] + "','" + work_row[9] + "','" + work_row[10] + "')";
                                /*********************************************************/

                                /***********************      dis_dishis（历史分配新增） -----overdis_dishis     ************************************/
                                string in_dis_dishisSql = "insert into dis_dishis(dishis_id, dishis_cusname, dishis_loan, dishis_type, dishis_project, dishis_mechanism, dishis_manager, dishis_place, dishis_establishtime, dishis_difficulty, dishis_workload, dishis_userid, dishis_username, dishis_disestablishtime) VALUES (" + work_row[0] + ", '" + work_row[1] + "', '" + work_row[2] + "', '" + work_row[3] + "', '" + work_row[4] + "', '" + work_row[5] + "', '" + work_row[6] + "', '" + work_row[7] + "', '" + work_row[8] + "', '" + work_row[9] + "', '" + work_row[10] + "', " + user + ", '" + usernameteam[0] + "', '" + rqdata + "')";
                                /*********************************************************/

                                /***********************      del_detwork（任务列表软删除） -----overdel_detwork     ************************************/
                                string del_dis_detworkSql = "update dis_detwork set detwork_bz = 0 where detwork_id = " + work + "";
                                /*********************************************************/

                                /***********************      add_workload（添加一条当日工作量） -----overadd_workload    ************************************/
                                string add_dis_workloadSql = "insert into dis_workload(dis_userid,dis_username,dis_level,dis_data,dis_work) VALUES (" + user + ",'" + usernameteam[0] + "','" + user_level_sql + "','" + rqdata + "','" + work_row[10] + "')";
                                /*********************************************************/

                                int overdis_disres = SQLiteHelper.ExecuteNonQuery(in_dis_disresSql);// dis_disres（当日分配新增） -----overdis_disres   
                                int overdis_dishis = SQLiteHelper.ExecuteNonQuery(in_dis_dishisSql);// dis_dishis（历史分配新增） -----overdis_dishis
                                int overdel_detwork = SQLiteHelper.ExecuteNonQuery(del_dis_detworkSql);//del_detwork（任务列表软删除） -----overdel_detwork 
                                int overadd_workload = SQLiteHelper.ExecuteNonQuery(add_dis_workloadSql);//add_workload（添加一条当日工作量） -----overadd_workload 


                                if (overdis_disres == 1 && overdis_dishis == 1 && overdel_detwork == 1 && overadd_workload == 1)
                                {
                                    //分配成功
                                    dis_bz = 1;//分配完毕标志位置1
                                               //dis_bz分配标志置1
                                               // MessageBox.Show("true");
                                    break;//进行下一个任务的分配
                                }
                            }

                            //如果这个任务分配了标志位是1，修改为0进入下一个任务分配
                            if (dis_bz != 0)
                            {
                                //dis_bz = 0;
                                break;
                            }
                        }

                    }
                    //全部任务分配完毕,清空任务列表
                    MessageBox.Show("任务分配完毕!");
                    dis dis = new dis();
                    dis.Close();
                }
            }
            else
            {
                MessageBox.Show("今天是休息日哦");
            }

        }
        //获取星期几
        private string GetWeekDes(int index)
        {
            switch (index)
            {
                case 0: return "星期日";
                case 1: return "星期一";
                case 2: return "星期二";
                case 3: return "星期三";
                case 4: return "星期四";
                case 5: return "星期五";
                case 6: return "星期六";
            }
            return "";
        }

        private void dis_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
        }
    }
}
