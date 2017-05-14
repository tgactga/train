using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainRemoteControl.Model;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using TrainRemoteControl.utilclass;

namespace TrainRemoteControl.dao
{
    class displayCommdao
    {
        
        private const string GetFirstRecordSqlStr=@"SELECT TOP 1 * 
                                                  FROM tab_displayComm
          //添加信息                                        ORDER BY recordtime DESC";//性能偏低
        //public bool AddInfo(displaycomm jg)
        //{

            

        //    bool b = false;
        //    StringBuilder sql = new StringBuilder();
        //    sql = sql.Append("insert into tab_displayComm(lcNumber,djNumber,oil_mass,fire_alarm,up_oil_place,up_water_place,battery_voltage,alarm,alarm_voice,oil_press,water_temp,frequency,motor_speed,voltage,[current],motor_power,power_factor,oil_leak,OKAlarm,NOAlarm,NCAlarm,recordtime)");


        //    sql.Append(" values ('" + jg.LcNumber + "', '" + jg.djNumber + "', '" + jg.Oil_mass + "', '" + jg.Fire_alarm + "', '" + jg.Up_oil_place + "', '" + jg.Up_water_place + "', '" + jg.Battery_voltage + "', '" + jg.Alarm + "', '" + jg.Alarm_voice+ "', '" + jg.Oil_press + "', '" + jg.Water_temp + "', '" + jg.Frequency + "', '" + jg.Motor_speed + "', '" + jg.Voltage + "', '" + jg.Current + "',");
        //    sql.Append("'" + jg.Motor_power + "', '" + jg.Power_factor + "','"+jg.Oil_leak+"', '" + jg.OKAlarm + "', '" + jg.NOAlarm + "', '" + jg.NCAlarm + "', '" + jg.RecordTime + "')");

        //    b = Convert.ToBoolean(db.SqlHelper.ExequteNonQuery(sql.ToString(), System.Data.CommandType.Text));
        //    return b;
        //}

        //查询i号电机状态
        /// <summary>
        /// 电机状态
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public DataTable getdjDatatable(string i)
        {
           // string sql = "select top 1000  oilPress as '油压',waterTemp as '冷却水温',frequency as '电机频率',motorSpeed as '电机转速', voltage as '电压',[current] as 'w相电压',motorPower as '视在功率',powerFactor as '功率因数',oilMass as 'oilMass',alarmValue as 'alarmValue',dateTime as '记录时间'  from CriticalData where generatorId=@i order by dateTime desc";
            //string sql="select top 100 oil_press as '油压',water_temp as '冷却水温',frequency as '电机频率',motor_speed as '电机转速', voltage as '电压',[current] as 'w相电压',motor_power as '视在功率',power_factor as '功率因数',OKAlarm as '报警已经确认',NOAlarm as '报警已经解除',NCAlarm as '报警无法排除'  from tab_displayComm where djNumber=@i"
            string sql = "";
            sql = "select  oilPress as '油压', waterTemp  as  '冷却水温' , frequency  as '电机频率', powerFactor as '功率因数'";
            sql += ",motorSpeed as '电机转速',voltage  as '电压', [current] as 'w相电压', motorPower  as '视在功率', oilMass  as '油量',alarmValue as '报警状态',dateTime as '记录时间'";
            sql += "from CriticalData where generatorId=@i order by dateTime desc ";
            SQLiteParameter[] param = new SQLiteParameter[] { new SQLiteParameter("@i", DbType.AnsiString) };
            SQLiteDBHelper sdb = new SQLiteDBHelper(Program.g_dbPath);
            param[0].Value = i+"";
            return sdb.ExecuteDataTable(sql, param);
        }
        //查询电机室公共信息
        /// <summary>
        /// 公共信息
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public DataTable getdjsCommDataTable(int i)
        {
            string sql = "select top 100 oil_mass as '油箱油量',fire_alarm as '烟火报警',up_oil_place as '上油箱油位',up_water_place as '上水箱水位', battery_voltage as '24V蓄电池电压',alarm as '报警'  from tab_displayComm where djNumber=@i";
            SQLiteParameter[] param = new SQLiteParameter[] { new SQLiteParameter("@i", DbType.Int32) };
            param[0].Value = i;
            SQLiteDBHelper sdb = new SQLiteDBHelper(Program.g_dbPath);
            return sdb.ExecuteDataTable(sql, param);
        }


        public TrainRemoteControl.Model.Display GetFirstRecord()
        {
            SQLiteDataReader dr = null;
            TrainRemoteControl.Model.Display display = new TrainRemoteControl.Model.Display();
            try
            {
                SQLiteDBHelper sdb = new SQLiteDBHelper(Program.g_dbPath);
                dr = sdb.ExecuteReader(GetFirstRecordSqlStr,null);
                string temp = null;
                while (dr.Read())
                {
                    display.Number = dr.GetInt32(2);
                    display.oil_mass = float.Parse(dr.GetString(3));
                    display.fire_alarm = dr.GetBoolean(4);
                    display.up_oil_place = dr.GetBoolean(5);
                    display.up_water_place = dr.GetBoolean(6);
                    display.battery_voltage = dr.GetBoolean(7);
                    display.alarm = dr.GetBoolean(8);
                    display.alarm_voice = dr.GetBoolean(9);
                    temp = dr.GetString(10).Trim();
                    display.oil_press =!string.IsNullOrEmpty(temp)? float.Parse(temp):0;
                    temp = dr.GetString(11).Trim();
                    display.water_temp = !string.IsNullOrEmpty(temp) ? float.Parse(temp) : 0;
                    temp = dr.GetString(12).Trim();
                    display.frequency = !string.IsNullOrEmpty(temp) ? float.Parse(temp) : 0;
                    temp = dr.GetString(13).Trim();
                    display.motor_speed = !string.IsNullOrEmpty(temp) ? float.Parse(temp) : 0;
                    temp = dr.GetString(14).Trim();
                    display.voltage = !string.IsNullOrEmpty(temp) ? float.Parse(temp) : 0;
                    temp = dr.GetString(15).Trim();
                    display.current = !string.IsNullOrEmpty(temp) ? float.Parse(temp) : 0;
                    temp = dr.GetString(16).Trim();
                    display.motor_power = !string.IsNullOrEmpty(temp) ? float.Parse(temp) : 0;
                    temp = dr.GetString(17).Trim();
                    display.power_factor = !string.IsNullOrEmpty(temp) ? float.Parse(temp) : 0;
                    display.oil_leak = dr.GetBoolean(18);
                    display.OKAlarm = dr.GetBoolean(19);
                    display.NOAlarm = dr.GetBoolean(20);
                    display.NCAlarm = dr.GetBoolean(21);
                    display.time = dr.GetDateTime(22);
                }
                return display;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
        }
    }
}
