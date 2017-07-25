using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using TrainRemoteControl.utilclass;
using TrainRemoteControl.TCP;

namespace TrainRemoteControl
{
    public partial class TestFrom : Form
    {
        string connectionString = "D:\\train\\Demo11.db3";
        public TestFrom()
        {
            InitializeComponent();
        }
        TCPServiceUtil tcputil = new TCPServiceUtil();
        private void TestFrom_Load(object sender, EventArgs e)
        {
            

            tcputil.InitalSevice();
     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dbPath = connectionString;
            //如果不存在改数据库文件，则创建该数据库文件 
            if (!System.IO.File.Exists(dbPath))
            {
                SQLiteDBHelper.CreateDB(connectionString);
            }
            string sqlcreatetab = "CREATE TABLE CriticalData" +
                           "(id integer IDENTITY(1,1) NOT NULL," +
                           "lcNum varchar(1,20) NOT NULL," +
                           "generatorId int NOT NULL," +
                           "oilPress real NOT NULL," +
                           "waterTemp real NOT NULL," +
                           "frequency real NOT NULL," +
                           "motorSpeed real NOT NULL," +
                           "voltage real NOT NULL," +
                           "current real NOT NULL," +
                           "motorPower real NOT NULL," +
                           "powerFactor real ," +
                           "oilMass real NOT NULL," +
                           "alarmValue int NOT NULL," +
                           "dateTime datetime NOT NULL)";


            string Inspe = "CREATE TABLE InspectionRecords(" +
                    "id int IDENTITY(1,1) NOT NULL," +
                    "lcNum nchar(20) NOT NULL," +
                    "status nchar(10) NOT NULL," +
                    "planTime datetime NOT NULL," +
                    "recordTime datetime NULL," +
                    "worker nchar(20) NOT NULL," +
                    "remarks nchar(30) NULL)";

            StringBuilder temperaturesql = new StringBuilder();

            temperaturesql.Append(" CREATE TABLE tab_temperature (lcnum nvarchar(10) NULL,");
            for (int i = 1; i <= 57; i++)
            {
                temperaturesql.Append("s" + i + " int NULL,t" + i + " real NULL,");
            }
            temperaturesql.Append("sendtime datetime NULL)");
            SQLiteDBHelper db = new SQLiteDBHelper("");
            bool result1 = db.ExecuteNonQuery(sqlcreatetab, null) > 0;
            bool result2 = db.ExecuteNonQuery(Inspe, null) > 0;   
            bool result3 = db.ExecuteNonQuery(temperaturesql.ToString(), null) > 0;

            if (result1 && result2 && result3)
            {
                MessageBox.Show("ok");
            }
           



        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                //SetDisplayMessage("我说:" + this.textBox1.Text);
               tcputil.SendMsg2Server(1, "test111111111111111111");

            }
            catch (Exception ex)
            {
                MessageBox.Show("system:" + ex.Message);

               // tcputil.ReConnectEvent.Set();
                // throw;
            }
             
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
