using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using TrainRemoteControl.utilclass;
using System.Data;

namespace TrainRemoteControl.DAl
{
    class AlarmRecordDAL
    {
        #region SQL语句
        private const string UPDATE_ALARM = "UPDATE AlarmRecords SET isupload=@isupload  where lcNum=@lcNum ";
        private const string INSERT_ALARM = "INSERT INTO AlarmRecords(isupload,lcNum,[status],recordTime,alarmCriticalData,remarks)VALUES(@isupload,@lcNum,@status,@recordTime,@alarmCriticalData,@remarks)";

        private const string PARAM_ISUPLOAD = "@isupload";
        private const string PARAM_LCNUM = "@lcNum";
        private const string PARAM_STATUS = "@status";
        private const string PARAM_RECORDTIME = "@recordTime";
        private const string PARAM_ALARMCRITICALDATA = "@alarmCriticalData";
        private const string PARAM_REMARKS = "@remarks";

        private const string PARAM_TOPROWCOUNT = "@topRowCount";
        private const string PARAM_PAGESIZE = "@pageSize";
        private const string PARAM_PAGENUMBER = "@pageNumber";
        #endregion
        private const int PAGESIZE = 30;


        //保存确认报警记录
        public bool SaveAlarmRecord(Model.AlarmInfo alarmInfo)
        {
            SQLiteParameter[] sqlParams = new SQLiteParameter[6];
            sqlParams[0] = new SQLiteParameter(PARAM_ISUPLOAD, DbType.String, 20);
            sqlParams[1] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 10);
            sqlParams[2] = new SQLiteParameter(PARAM_STATUS, DbType.String, 10);
            sqlParams[3] = new SQLiteParameter(PARAM_RECORDTIME, DbType.DateTime, 8);
            sqlParams[4] = new SQLiteParameter(PARAM_ALARMCRITICALDATA, DbType.String, 40);
            sqlParams[5] = new SQLiteParameter(PARAM_REMARKS, DbType.String, 30);
            sqlParams[0].Value = "ture";
            sqlParams[1].Value =  "T401";
            sqlParams[2].Value =  "报警";
             
            
                sqlParams[3].Value = DateTime.Now;
         
            sqlParams[4].Value =  "关键数据报警|温度超过警戒值";
            sqlParams[5].Value =  "备注";
            SQLiteDBHelper sdb = new SQLiteDBHelper(Program.g_dbPath);
            return sdb.ExecuteNonQuery(INSERT_ALARM, sqlParams) > 0;
        }


        //更新报警记录
        public bool updateAlarmRecord(Model.AlarmInfo alarmInfo)
        {
            SQLiteParameter[] sqlParams = new SQLiteParameter[2];
            sqlParams[0] = new SQLiteParameter(PARAM_ISUPLOAD, DbType.String, 20);
            sqlParams[1] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 10);
            sqlParams[0].Value = "ture";
            sqlParams[1].Value = "T401";
            SQLiteDBHelper sdb = new SQLiteDBHelper(Program.g_dbPath);
            return sdb.ExecuteNonQuery(UPDATE_ALARM, sqlParams) > 0;
        }

    }
}
