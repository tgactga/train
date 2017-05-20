using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using TrainRemoteControl.utilclass;
using System.Data;
using TrainRemoteControl.Model;

namespace TrainRemoteControl
{
    public class CriticalDataDAL
    {
        #region SQL语句
        private const string UPDATE_CRITICAL = "UPDATE CriticalData SET isuploadstate=@isuploadstate  where lcNum=@lcNum  and saveTime=@saveTime ";
        private const string INSERT_DISPLAY = @"INSERT INTO CriticalData(lcNum,generatorId,oilPress,waterTemp,frequency,motorSpeed,voltage,[current],motorPower,powerFactor,oilMass,alarmValue,[dateTime],[saveTime],isuploadstate)
                                                VALUES(@lcNum,@generatorId,@oilPress,@waterTemp,@frequency,@motorSpeed,@voltage,@current,@motorPower,@powerFactor,@oilMass,@alarmValue,@dateTime,@saveTime,@isuploadstate)";
        private const string SELECT_CDATA_TOP = @"SELECT TOP @rowCount lcNum,generatorId,oilPress,waterTemp,frequency,motorSpeed,voltage,[current],motorPower,powerFactor,oilMass,alarmValue,[dateTime,[saveTime],isuploadstate]
                                                  FROM CriticalData";
        private const string SELECT_CDATA_DATE = @"SELECT lcNum,generatorId,oilPress,waterTemp,frequency,motorSpeed,voltage,[current],motorPower,powerFactor,oilMass,alarmValue,[dateTime],[saveTime],isuploadstate
                                                   FROM CriticalData
                                                   WHERE dateTime>@preDate AND dateTime<@nextDate";
        private const string SELECT_CDATA_DATE_ISNOTUPLOAD = @"SELECT lcNum,generatorId,oilPress,waterTemp,frequency,motorSpeed,voltage,[current],motorPower,powerFactor,oilMass,alarmValue,[dateTime],[saveTime],isuploadstate
                                                   FROM CriticalData
                                                   WHERE lcNum=@lcNum AND isuploadstate=@isuploadstate";
        private const string SELECT_CDATA_GENERATORID = @"SELECT TOP @rowCount lcNum,generatorId,oilPress,waterTemp,frequency,motorSpeed,voltage,[current],motorPower,powerFactor,oilMass,alarmValue,[dateTime]
                                                        FROM CriticalData
                                                        WHERE generatorId=@generatorId";
        private const string SCALAR_ROWCOUNT = "SELECT COUNT(*) FROM CriticalData";

        private const string SCALAR_ROWCOUNT_LCNUM = "SELECT COUNT(*) FROM CriticalData WHERE lcNum=@lcNum";

        private const string SCALAR_ROWCOUNT_DATE = "SELECT COUNT(*) FROM CriticalData WHERE [dateTime]<@startDateTime AND [dateTime]<@endDateTime";

        private const string SCALAR_RC_ALARMED = "SELECT COUNT(*) FROM CriticalData WHERE alarmValue>0";

        private const string SCALAR_RC_NONALARM = "SELECT COUNT(*) FROM CriticalData WHERE alarmValue=0";

        private const string SCALAR_RC_LD = "SELECT COUNT(*) FROM CriticalData WHERE lcNum=@lcNum AND [dateTime]<@startDateTime AND [dateTime]<@endDateTime";

        private const string SCALAR_RC_DA = "SELECT COUNT(*) FROM CriticalData WHERE alarmValue>0 AND [dateTime]<@startDateTime AND [dateTime]<@endDateTime";

        private const string SCALAR_RC_DNA = "SELECT COUNT(*) FROM CriticalData WHERE alarmValue=0 AND [dateTime]<@startDateTime AND [dateTime]<@endDateTime";

        private const string SCALAR_RC_LA = "SELECT COUNT(*) FROM CriticalData WHERE lcNum=@lcNum AND alarmValue>0";

        private const string SCALAR_RC_LNA = "SELECT COUNT(*) FROM CriticalData WHERE lcNum=@lcNum AND alarmValue=0";

        private const string SCALAR_RC_LDA = "SELECT COUNT(*) FROM CriticalData WHERE  lcNum=@lcNum AND alarmValue>0 AND [dateTime]<@startDateTime AND [dateTime]<@endDateTime";

        private const string SCALAR_RC_LDNA = "SELECT COUNT(*) FROM CriticalData WHERE  lcNum=@lcNum AND alarmValue=0 AND [dateTime]<@startDateTime AND [dateTime]<@endDateTime";

        private const string SCALAR_RC_LG = "SELECT COUNT(*) FROM CriticalData WHERE lcNum=@lcNum AND generatorId=@generatorId";

        private const string SP_GCD = "GetPartialCriticalData";//code=0
        private const string SP_GCD_A = "GetPartialCriticalDataByAlarm";//code=16
        private const string SP_GCD_D = "GetPartialCriticalDataByDate";//code=12
        private const string SP_GCD_L = "GetPartialCriticalDataByLCNum";//code=2
        private const string SP_GCD_DA = "GetPartialCriticalDataByDateAndAlarm";//code=28
        private const string SP_GCD_DL = "GetPartialCriticalDataByDateAndLCNum";//code=14
        private const string SP_GCD_LA = "GetPartialCriticalDataByLCNumAndAlarm";//code=18
        private const string SP_GCD_LG = "GetPartialCriticalDataByLCNumAndGId";//code=3
        private const string SP_GCD_LDA = "GetPartialCriticalDataByLDA";//code=30


        private const string PARAM_LCNUM = "@lcNum";
        private const string PARAM_GID = "@generatorId";
        private const string PARAM_OILPRESS = "@oilPress";
        private const string PARAM_WATERTEMP = "@waterTemp";
        private const string PARAM_FRE = "@frequency";
        private const string PARAM_MSPEED = "@motorSpeed";
        private const string PARAM_V = "@voltage";
        private const string PARAM_CURRENT = "@current";
        private const string PARAM_MPOWER = "@motorPower";
        private const string PARAM_POWERFACTOR = "@powerFactor";
        private const string PARAM_OILMASS = "@oilMass";
        private const string PARAM_ALARMVALUE = "@alarmValue";
        private const string PARAM_DATETIME = "@dateTime";
        private const string PARAM_SAVETIME = "@saveTime";
        private const string PARAM_ROWCOUNT = "@rowCount";
        private const string PARAM_PREDATE = "@preDate";
        private const string PARAM_NEXTDATE = "@nextDate";

        private const string PARAM_PAGESIZE = "@pageSize";
        private const string PARAM_PAGENUMBER = "@pageNumber";
        private const string PARAM_ALARMSTATUS = "@alarmStatus";
        private const string PARAM_STARTTIME = "@startDateTime";
        private const string PARAM_ENDTIME = "@endDateTime";

        private const string PARAM_ISUPLOADSTATE = "@isuploadstate"; 
        #endregion

        private const int PAGESIZE = 30;
        /// <summary>
        /// 根据分页页码获取部分数据
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <returns>关键数据</returns>
        //public List<CriticalData> GetPartialCriticalData(int pageNumber)
        //{
        //    List<CriticalData> criticalDataList = new List<CriticalData>(PAGESIZE);
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[2];
        //    sqlParams[0] = new SQLiteParameter(PARAM_PAGESIZE, DbType.Int32, 4);
        //    sqlParams[1] = new SQLiteParameter(PARAM_PAGENUMBER, DbType.Int32, 4);
        //    sqlParams[0].Value = PAGESIZE;
        //    sqlParams[1].Value = pageNumber;
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GCD, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            criticalDataList.Add(new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12)));
        //        }
        //        return criticalDataList;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }
        //}

        ///// <summary>
        ///// 通过时间以及页码获取部分关键数据
        ///// </summary>
        ///// <param name="startDateTime">开始时间点</param>
        ///// <param name="endDateTime">结束时间点</param>
        ///// <param name="pageNumber">页码</param>
        ///// <returns>关键数据列表</returns>
        //public List<CriticalData> GetPartialCriticalDataByDate(DateTime startDateTime, DateTime endDateTime, int pageNumber)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[4];
        //    sqlParams[0] = new SQLiteParameter(PARAM_STARTTIME, DbType.DateTime, 8);
        //    sqlParams[1] = new SQLiteParameter(PARAM_ENDTIME, DbType.DateTime, 8);
        //    sqlParams[2] = new SQLiteParameter(PARAM_PAGENUMBER, DbType.Int32, 4);
        //    sqlParams[3] = new SQLiteParameter(PARAM_PAGESIZE, DbType.Int32, 4);
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    sqlParams[2].Value = pageNumber;
        //    sqlParams[3].Value = PAGESIZE;
        //    List<CriticalData> tempList = new List<CriticalData>(PAGESIZE);
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GCD_D, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            tempList.Add(new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12)));
        //        }
        //        return tempList;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }
        //}


        //public List<CriticalData> GetPartialCriticalDataByLCNum(string lcNum, int pageNumber)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[3];
        //    sqlParams[0] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 20);
        //    sqlParams[1] = new SQLiteParameter(PARAM_PAGENUMBER, DbType.Int32, 4);
        //    sqlParams[2] = new SQLiteParameter(PARAM_PAGESIZE, DbType.Int32, 4);
        //    sqlParams[0].Value = lcNum;
        //    sqlParams[1].Value = pageNumber;
        //    sqlParams[2].Value = PAGESIZE;
        //    SqlDataReader dr = null;
        //    List<CriticalData> tempList = new List<CriticalData>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GCD_L, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            tempList.Add(new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12)));
        //        }
        //        return tempList;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }

        //}


        //public List<CriticalData> GetPartialCriticalDataByAlarmStatus(bool alarmStatus, int pageNumber)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[]
        //    {
        //        new SQLiteParameter(PARAM_ALARMSTATUS,SqlDbType.Bit,1),
        //        new SQLiteParameter(PARAM_PAGENUMBER,DbType.Int32,4),
        //        new SQLiteParameter(PARAM_PAGESIZE,DbType.Int32,4)
        //    };
        //    sqlParams[0].Value = alarmStatus;
        //    sqlParams[1].Value = pageNumber;
        //    sqlParams[2].Value = PAGESIZE;
        //    SqlDataReader dr = null;
        //    List<CriticalData> tempList = new List<CriticalData>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GCD_A, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            tempList.Add(new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12)));
        //        }
        //        return tempList;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }
        //}


        //public List<CriticalData> GetPartialCriticalDataByDateAndAlarm(DateTime startDateTime, DateTime endDateTime, bool alarmStatus, int pageNumber)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[5];
        //    sqlParams[0] = new SQLiteParameter(PARAM_STARTTIME, DbType.DateTime, 8);
        //    sqlParams[1] = new SQLiteParameter(PARAM_ENDTIME, DbType.DateTime, 8);
        //    sqlParams[2] = new SQLiteParameter(PARAM_ALARMSTATUS, SqlDbType.Bit, 1);
        //    sqlParams[3] = new SQLiteParameter(PARAM_PAGENUMBER, DbType.Int32, 4);
        //    sqlParams[4] = new SQLiteParameter(PARAM_PAGESIZE, DbType.Int32, 4);
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    sqlParams[2].Value = alarmStatus;
        //    sqlParams[3].Value = pageNumber;
        //    sqlParams[4].Value = PAGESIZE;
        //    SqlDataReader dr = null;
        //    List<CriticalData> tempList = new List<CriticalData>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GCD_DA, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            tempList.Add(new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12)));
        //        }
        //        return tempList;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }

        //}


        //public List<CriticalData> GetPartialCriticalDataByDateAndLcNum(DateTime startTime, DateTime endTime, string lcNum, int pageNumber)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[5];
        //    sqlParams[0] = new SQLiteParameter(PARAM_STARTTIME, DbType.DateTime, 8);
        //    sqlParams[1] = new SQLiteParameter(PARAM_ENDTIME, DbType.DateTime, 8);
        //    sqlParams[2] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 20);
        //    sqlParams[3] = new SQLiteParameter(PARAM_PAGENUMBER, DbType.Int32, 4);
        //    sqlParams[4] = new SQLiteParameter(PARAM_PAGESIZE, DbType.Int32, 4);
        //    sqlParams[0].Value = startTime;
        //    sqlParams[1].Value = endTime;
        //    sqlParams[2].Value = lcNum;
        //    sqlParams[3].Value = pageNumber;
        //    sqlParams[4].Value = PAGESIZE;
        //    SqlDataReader dr = null;
        //    List<CriticalData> tempList = new List<CriticalData>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GCD_DL, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            tempList.Add(new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12)));
        //        }
        //        return tempList;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }
        //}

        //public List<CriticalData> GetPartialCriticalDataByLCNumAndAlarm(string lcNum, bool alarmStatus, int pageNumber)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[4];
        //    sqlParams[0] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 20);
        //    sqlParams[1] = new SQLiteParameter(PARAM_ALARMSTATUS, SqlDbType.Bit, 1);
        //    sqlParams[2] = new SQLiteParameter(PARAM_PAGENUMBER, DbType.Int32, 4);
        //    sqlParams[3] = new SQLiteParameter(PARAM_PAGESIZE, DbType.Int32, 4);
        //    sqlParams[0].Value = lcNum;
        //    sqlParams[1].Value = alarmStatus;
        //    sqlParams[2].Value = pageNumber;
        //    sqlParams[3].Value = PAGESIZE;
        //    SqlDataReader dr = null;
        //    List<CriticalData> tempList = new List<CriticalData>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GCD_LA, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            tempList.Add(new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12)));
        //        }
        //        return tempList;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }
        //}

        //public List<CriticalData> GetPartialCriticalDataByLcNumAndGId(string lcNum, int generatorId, int pageNumber)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[4];
        //    sqlParams[0] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 20);
        //    sqlParams[1] = new SQLiteParameter(PARAM_GID, DbType.Int32, 4);
        //    sqlParams[2] = new SQLiteParameter(PARAM_PAGENUMBER, DbType.Int32, 4);
        //    sqlParams[3] = new SQLiteParameter(PARAM_PAGESIZE, DbType.Int32, 4);
        //    sqlParams[0].Value = lcNum;
        //    sqlParams[1].Value = generatorId;
        //    sqlParams[2].Value = pageNumber;
        //    sqlParams[3].Value = PAGESIZE;
        //    SqlDataReader dr = null;
        //    List<CriticalData> tempList = new List<CriticalData>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GCD_LG, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            tempList.Add(new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12)));
        //        }
        //        return tempList;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }

        //}

        //public List<CriticalData> GetPartialCriticalDataByLDA(string lcNum, DateTime start, DateTime end, bool alarmStatus, int pageNumber)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[6];
        //    sqlParams[0] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 20);
        //    sqlParams[1] = new SQLiteParameter(PARAM_STARTTIME, DbType.DateTime, 8);
        //    sqlParams[2] = new SQLiteParameter(PARAM_ENDTIME, DbType.DateTime, 8);
        //    sqlParams[3] = new SQLiteParameter(PARAM_ALARMSTATUS, SqlDbType.Bit, 1);
        //    sqlParams[4] = new SQLiteParameter(PARAM_PAGENUMBER, DbType.Int32, 4);
        //    sqlParams[5] = new SQLiteParameter(PARAM_PAGESIZE, DbType.Int32, 4);
        //    sqlParams[0].Value = lcNum;
        //    sqlParams[1].Value = start;
        //    sqlParams[2].Value = end;
        //    sqlParams[3].Value = alarmStatus;
        //    sqlParams[4].Value = pageNumber;
        //    sqlParams[5].Value = PAGESIZE;
        //    SqlDataReader dr = null;
        //    List<CriticalData> tempList = new List<CriticalData>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GCD_LDA, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            tempList.Add(new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12)));
        //        }
        //        return tempList;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }

        //}

        //public int GetPageTotal()
        //{
        //    object obj = SQLHelper.ExecuteScalar(SCALAR_ROWCOUNT);
        //    int total = (int)obj;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByDate(DateTime startDateTime, DateTime endDateTime)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[2];
        //    sqlParams[0] = new SQLiteParameter(PARAM_STARTTIME, DbType.DateTime, 8);
        //    sqlParams[1] = new SQLiteParameter(PARAM_ENDTIME, DbType.DateTime, 8);
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_ROWCOUNT_DATE, sqlParams);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByLCNum(string lcNum)
        //{
        //    SQLiteParameter serialNum = new SQLiteParameter(PARAM_LCNUM, DbType.String, 20);
        //    serialNum.Value = lcNum;
        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_ROWCOUNT_LCNUM, serialNum);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByAlarmStatus(bool alarmStatus)
        //{
        //    string sqlStr = alarmStatus ? SCALAR_RC_ALARMED : SCALAR_RC_NONALARM;
        //    object objTotal = SQLHelper.ExecuteScalar(sqlStr);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByDateAndAlarm(DateTime startDateTime, DateTime endDateTime, bool alarmStatus)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[]
        //    {
        //        new SQLiteParameter(PARAM_STARTTIME,DbType.DateTime,8),
        //        new SQLiteParameter(PARAM_ENDTIME,DbType.DateTime,8)
        //    };
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    string sqlStr = alarmStatus ? SCALAR_RC_DA : SCALAR_RC_DNA;
        //    object objTotal = SQLHelper.ExecuteScalar(sqlStr, sqlParams);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByDateAndLCNum(DateTime startDateTime, DateTime endDateTime, string lcNum)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[3];
        //    sqlParams[0] = new SQLiteParameter(PARAM_STARTTIME, DbType.DateTime, 8);
        //    sqlParams[1] = new SQLiteParameter(PARAM_ENDTIME, DbType.DateTime, 8);
        //    sqlParams[2] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 20);
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    sqlParams[2].Value = lcNum;
        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_RC_LD, sqlParams);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByLCNumAndAlarm(string lcNum, bool alarmStatus)
        //{
        //    SQLiteParameter serialNum = new SQLiteParameter(PARAM_LCNUM, DbType.String, 20);
        //    serialNum.Value = lcNum;
        //    string sqlStr = alarmStatus ? SCALAR_RC_LA : SCALAR_RC_LNA;
        //    object objTotal = SQLHelper.ExecuteScalar(sqlStr, serialNum);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByLDA(string lcNum, DateTime start, DateTime end, bool alarmStatus)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[] 
        //    {
        //        new SQLiteParameter(PARAM_LCNUM,DbType.String,20),
        //        new SQLiteParameter(PARAM_STARTTIME,DbType.DateTime,8),
        //        new SQLiteParameter(PARAM_ENDTIME,DbType.DateTime,8)
        //    };
        //    sqlParams[0].Value = lcNum;
        //    sqlParams[1].Value = start;
        //    sqlParams[2].Value = end;
        //    string sqlStr = alarmStatus ? SCALAR_RC_LDA : SCALAR_RC_LDNA;
        //    object objTotal = SQLHelper.ExecuteScalar(sqlStr, sqlParams);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByLcNumAndGId(string lcNum, int generatorId)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[] 
        //    {
        //        new SQLiteParameter(PARAM_LCNUM,DbType.String,20),
        //        new SQLiteParameter(PARAM_GID,DbType.Int32,4)
        //    };
        //    sqlParams[0].Value = lcNum;
        //    sqlParams[1].Value = generatorId;
        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_RC_LG, sqlParams);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public List<CriticalData> GetCriticalDataByDate(DateTime date)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[2];
        //    sqlParams[0] = new SQLiteParameter(PARAM_PREDATE, DbType.DateTime, 8);
        //    sqlParams[1] = new SQLiteParameter(PARAM_NEXTDATE, DbType.DateTime, 8);
        //    sqlParams[0].Value = date.Date.AddDays(-1);
        //    sqlParams[1].Value = date.Date.AddDays(1);
        //    List<CriticalData> cDList = new List<CriticalData>(100);
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SELECT_CDATA_DATE, CommandType.Text, sqlParams);
        //        while (dr.Read())
        //        {
        //            CriticalData criticalData = new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12));
        //            cDList.Add(criticalData);
        //        }
        //        return cDList;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }
        //}


        //public List<CriticalData> GetCriticalDataBygeneratorId(int rowCount, int generatorId)
        //{
        //    SQLiteParameter[] sqlParams = new SQLiteParameter[2];
        //    sqlParams[0] = new SQLiteParameter(PARAM_ROWCOUNT, DbType.Int32, 4);
        //    sqlParams[1] = new SQLiteParameter(PARAM_GID, DbType.Int32, 4);
        //    sqlParams[0].Value = rowCount;
        //    sqlParams[1].Value = generatorId;
        //    List<CriticalData> criticalDataList = new List<CriticalData>(rowCount);
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SELECT_CDATA_TOP, CommandType.Text, sqlParams);
        //        while (dr.Read())
        //        {
        //            CriticalData criticalData = new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12));
        //            criticalDataList.Add(criticalData);
        //        }
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }
        //    return criticalDataList;
        //}

        //public List<CriticalData> GetCriticalData(int rowCount)
        //{
        //    SQLiteParameter SQLiteParameter = new SQLiteParameter(PARAM_ROWCOUNT, DbType.Int32, 4);
        //    SQLiteParameter.Value = rowCount;
        //    List<CriticalData> criticalDataList = new List<CriticalData>(rowCount);
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SELECT_CDATA_TOP, CommandType.Text, SQLiteParameter);
        //        while (dr.Read())
        //        {
        //            CriticalData criticalData = new CriticalData(dr.GetString(0).Trim(), dr.GetInt32(1), (float)dr.GetDouble(2), (float)dr.GetDouble(3), (float)dr.GetDouble(4), (float)dr.GetDouble(5), (float)dr.GetDouble(6), (float)dr.GetDouble(7), (float)dr.GetDouble(8), (float)dr.GetDouble(9), (float)dr.GetDouble(10), dr.GetInt32(11), dr.GetDateTime(12));
        //            criticalDataList.Add(criticalData);
        //        }
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }
        //    return criticalDataList;
        //}

        public bool SaveCriticalData(Display display, string lcNum)
        {
            SQLiteParameter[] sqlParams = new SQLiteParameter[13];
            sqlParams[0] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 20);
            sqlParams[1] = new SQLiteParameter(PARAM_GID, DbType.Int32, 4);
            sqlParams[2] = new SQLiteParameter(PARAM_OILPRESS, DbType.Double, 4);
            sqlParams[3] = new SQLiteParameter(PARAM_WATERTEMP, DbType.Double, 4);
            sqlParams[4] = new SQLiteParameter(PARAM_FRE, DbType.Double, 4);
            sqlParams[5] = new SQLiteParameter(PARAM_MSPEED, DbType.Double, 4);
            sqlParams[6] = new SQLiteParameter(PARAM_V, DbType.Double, 4);
            sqlParams[7] = new SQLiteParameter(PARAM_CURRENT, DbType.Double, 4);
            sqlParams[8] = new SQLiteParameter(PARAM_MPOWER, DbType.Double, 4);
            sqlParams[9] = new SQLiteParameter(PARAM_POWERFACTOR, DbType.Double, 4);
            sqlParams[10] = new SQLiteParameter(PARAM_OILMASS, DbType.Double, 4);
            sqlParams[11] = new SQLiteParameter(PARAM_ALARMVALUE, DbType.Int32, 4);
            sqlParams[12] = new SQLiteParameter(PARAM_DATETIME, DbType.DateTime, 8);
            sqlParams[0].Value = lcNum;
            sqlParams[1].Value = display.Number;
            sqlParams[2].Value = display.oil_press;
            sqlParams[3].Value = display.water_temp;
            sqlParams[4].Value = display.frequency;
            sqlParams[5].Value = display.motor_speed;
            sqlParams[6].Value = display.voltage;
            sqlParams[7].Value = display.current;
            sqlParams[8].Value = display.motor_power;
            sqlParams[9].Value = display.power_factor;
            sqlParams[10].Value = display.oil_mass;
            // sqlParams[11].Value = display.AlarmValue;
            sqlParams[12].Value = display.time;
            SQLiteDBHelper sdb = new SQLiteDBHelper(Program.g_dbPath);
            return sdb.ExecuteNonQuery(INSERT_DISPLAY, sqlParams) == 1;
        }

        public bool SaveCriticalData(CriticalData cd)
        {
            SQLiteParameter[] sqlParams = new SQLiteParameter[15];
            sqlParams[0] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 20);
            sqlParams[1] = new SQLiteParameter(PARAM_GID, DbType.Int32, 4);
            sqlParams[2] = new SQLiteParameter(PARAM_OILPRESS, DbType.Double);
            sqlParams[3] = new SQLiteParameter(PARAM_WATERTEMP, DbType.Double, 4);
            sqlParams[4] = new SQLiteParameter(PARAM_FRE, DbType.Double, 4);
            sqlParams[5] = new SQLiteParameter(PARAM_MSPEED, DbType.Double, 4);
            sqlParams[6] = new SQLiteParameter(PARAM_V, DbType.Double, 4);
            sqlParams[7] = new SQLiteParameter(PARAM_CURRENT, DbType.Double, 4);
            sqlParams[8] = new SQLiteParameter(PARAM_MPOWER, DbType.Double, 4);
            sqlParams[9] = new SQLiteParameter(PARAM_POWERFACTOR, DbType.Double, 4);
            sqlParams[10] = new SQLiteParameter(PARAM_OILMASS, DbType.Double, 4);
            sqlParams[11] = new SQLiteParameter(PARAM_ALARMVALUE, DbType.Int32, 4);
            sqlParams[12] = new SQLiteParameter(PARAM_DATETIME, DbType.DateTime, 8);
            sqlParams[13] = new SQLiteParameter(PARAM_SAVETIME, DbType.DateTime, 8);
            sqlParams[14] = new SQLiteParameter(PARAM_ISUPLOADSTATE, DbType.String, 20);
            sqlParams[0].Value = cd.LcNum;
            sqlParams[1].Value = cd.GeneratorId;
            sqlParams[2].Value = cd.OilPress;
            sqlParams[3].Value = cd.WaterTemp;
            sqlParams[4].Value = cd.Frequency;
            sqlParams[5].Value = cd.MotorSpeed;
            sqlParams[6].Value = cd.Voltage;
            sqlParams[7].Value = cd._Current;
            sqlParams[8].Value = cd.MotorPower;
            sqlParams[9].Value = cd.PowerFactor;
            sqlParams[10].Value = cd.OilMass;
            sqlParams[11].Value = cd.AlarmValue;
            sqlParams[12].Value = cd.Date;
            sqlParams[13].Value = cd.SaveNowTime;
            sqlParams[14].Value = cd.Isuploadstate;
            SQLiteDBHelper sdb = new SQLiteDBHelper(Program.g_dbPath);
            return sdb.ExecuteNonQuery(INSERT_DISPLAY, sqlParams) == 1;
        }


        public bool SaveTempData(List<CellTerminal> ct, string time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Temperature(");
            strSql.Append("Status1,Temperature5,Temperature50,Status51,Temperature51,Status52,Temperature52,Status53,Temperature53,Status54,Temperature54,Status55,Status6,Temperature55,Status56,Temperature56,Status57,Temperature57,Status58,Temperature58,Status59,Temperature59,recordTime,Temperature6,Status7,Temperature7,Status8,Temperature8,Status9,Temperature9,Status10,Temperature1,Temperature10,Status11,Temperature11,Status12,Temperature12,Status13,Temperature13,Status14,Temperature14,Status15,Status2,Temperature15,Status16,Temperature16,Status17,Temperature17,Status18,Temperature18,Status19,Temperature19,Status20,Temperature2,Temperature20,Status21,Temperature21,Status22,Temperature22,Status23,Temperature23,Status24,Temperature24,Status25,Status3,Temperature25,Status26,Temperature26,Status27,Temperature27,Status28,Temperature28,Status29,Temperature29,Status30,Temperature3,Temperature30,Status31,Temperature31,Status32,Temperature32,Status33,Temperature33,Status34,Temperature34,Status35,Status4,Temperature35,Status36,Temperature36,Status37,Temperature37,Status38,Temperature38,Status39,Temperature39,Status40,Temperature4,Temperature40,Status41,Temperature41,Status42,Temperature42,Status43,Temperature43,Status44,Temperature44,Status45,Status5,Temperature45,Status46,Temperature46,Status47,Temperature47,Status48,Temperature48,Status49,Temperature49,Status50");
            strSql.Append(") values (");
            strSql.Append("@Status1,@Temperature5,@Temperature50,@Status51,@Temperature51,@Status52,@Temperature52,@Status53,@Temperature53,@Status54,@Temperature54,@Status55,@Status6,@Temperature55,@Status56,@Temperature56,@Status57,@Temperature57,@Status58,@Temperature58,@Status59,@Temperature59,@recordTime,@Temperature6,@Status7,@Temperature7,@Status8,@Temperature8,@Status9,@Temperature9,@Status10,@Temperature1,@Temperature10,@Status11,@Temperature11,@Status12,@Temperature12,@Status13,@Temperature13,@Status14,@Temperature14,@Status15,@Status2,@Temperature15,@Status16,@Temperature16,@Status17,@Temperature17,@Status18,@Temperature18,@Status19,@Temperature19,@Status20,@Temperature2,@Temperature20,@Status21,@Temperature21,@Status22,@Temperature22,@Status23,@Temperature23,@Status24,@Temperature24,@Status25,@Status3,@Temperature25,@Status26,@Temperature26,@Status27,@Temperature27,@Status28,@Temperature28,@Status29,@Temperature29,@Status30,@Temperature3,@Temperature30,@Status31,@Temperature31,@Status32,@Temperature32,@Status33,@Temperature33,@Status34,@Temperature34,@Status35,@Status4,@Temperature35,@Status36,@Temperature36,@Status37,@Temperature37,@Status38,@Temperature38,@Status39,@Temperature39,@Status40,@Temperature4,@Temperature40,@Status41,@Temperature41,@Status42,@Temperature42,@Status43,@Temperature43,@Status44,@Temperature44,@Status45,@Status5,@Temperature45,@Status46,@Temperature46,@Status47,@Temperature47,@Status48,@Temperature48,@Status49,@Temperature49,@Status50");
            strSql.Append(") ");

            SQLiteParameter[] parameters = {
                        new SQLiteParameter("@Status1", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature1", DbType.String,10) ,         
                        new SQLiteParameter("@Status2", DbType.String,10) ,       
                        new SQLiteParameter("@Temperature2", DbType.String,10) ,                  
                        new SQLiteParameter("@Status3", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature3", DbType.String,10) ,       
                        new SQLiteParameter("@Status4", DbType.String,10) ,         
                        new SQLiteParameter("@Temperature4", DbType.String,10) ,             
                        new SQLiteParameter("@Status5", DbType.String,10) ,                   
                        new SQLiteParameter("@Temperature5", DbType.String,10) ,          
                        new SQLiteParameter("@Status6", DbType.String,10) ,      
                        new SQLiteParameter("@Temperature6", DbType.String,10) ,            
                        new SQLiteParameter("@Status7", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature7", DbType.String,10) ,            
                        new SQLiteParameter("@Status8", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature8", DbType.String,10) ,            
                        new SQLiteParameter("@Status9", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature9", DbType.String,10) ,            
                        new SQLiteParameter("@Status10", DbType.String,10) ,                
                        new SQLiteParameter("@Temperature10", DbType.String,10) ,            
                        new SQLiteParameter("@Status11", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature11", DbType.String,10) ,            
                        new SQLiteParameter("@Status12", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature12", DbType.String,10) ,            
                        new SQLiteParameter("@Status13", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature13", DbType.String,10) ,            
                        new SQLiteParameter("@Status14", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature14", DbType.String,10) ,            
                        new SQLiteParameter("@Status15", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature15", DbType.String,10) ,            
                        new SQLiteParameter("@Status16", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature16", DbType.String,10) ,            
                        new SQLiteParameter("@Status17", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature17", DbType.String,10) ,            
                        new SQLiteParameter("@Status18", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature18", DbType.String,10) ,            
                        new SQLiteParameter("@Status19", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature19", DbType.String,10) ,            
                        new SQLiteParameter("@Status20", DbType.String,10) ,                
                        new SQLiteParameter("@Temperature20", DbType.String,10) ,            
                        new SQLiteParameter("@Status21", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature21", DbType.String,10) ,            
                        new SQLiteParameter("@Status22", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature22", DbType.String,10) ,            
                        new SQLiteParameter("@Status23", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature23", DbType.String,10) ,            
                        new SQLiteParameter("@Status24", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature24", DbType.String,10) ,            
                        new SQLiteParameter("@Status25", DbType.String,10) ,             
                        new SQLiteParameter("@Temperature25", DbType.String,10) ,            
                        new SQLiteParameter("@Status26", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature26", DbType.String,10) ,            
                        new SQLiteParameter("@Status27", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature27", DbType.String,10) ,            
                        new SQLiteParameter("@Status28", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature28", DbType.String,10) ,            
                        new SQLiteParameter("@Status29", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature29", DbType.String,10) ,            
                        new SQLiteParameter("@Status30", DbType.String,10) ,                
                        new SQLiteParameter("@Temperature30", DbType.String,10) ,            
                        new SQLiteParameter("@Status31", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature31", DbType.String,10) ,            
                        new SQLiteParameter("@Status32", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature32", DbType.String,10) ,            
                        new SQLiteParameter("@Status33", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature33", DbType.String,10) ,            
                        new SQLiteParameter("@Status34", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature34", DbType.String,10) ,            
                        new SQLiteParameter("@Status35", DbType.String,10) ,          
                        new SQLiteParameter("@Temperature35", DbType.String,10) ,            
                        new SQLiteParameter("@Status36", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature36", DbType.String,10) ,            
                        new SQLiteParameter("@Status37", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature37", DbType.String,10) ,            
                        new SQLiteParameter("@Status38", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature38", DbType.String,10) ,            
                        new SQLiteParameter("@Status39", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature39", DbType.String,10) ,            
                        new SQLiteParameter("@Status40", DbType.String,10) ,                 
                        new SQLiteParameter("@Temperature40", DbType.String,10) ,            
                        new SQLiteParameter("@Status41", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature41", DbType.String,10) ,            
                        new SQLiteParameter("@Status42", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature42", DbType.String,10) ,            
                        new SQLiteParameter("@Status43", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature43", DbType.String,10) ,            
                        new SQLiteParameter("@Status44", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature44", DbType.String,10) ,            
                        new SQLiteParameter("@Status45", DbType.String,10) ,           
                        new SQLiteParameter("@Temperature45", DbType.String,10) ,            
                        new SQLiteParameter("@Status46", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature46", DbType.String,10) ,            
                        new SQLiteParameter("@Status47", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature47", DbType.String,10) ,            
                        new SQLiteParameter("@Status48", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature48", DbType.String,10) ,            
                        new SQLiteParameter("@Status49", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature49", DbType.String,10) ,            
                        new SQLiteParameter("@Status50", DbType.String,10) ,         
                        new SQLiteParameter("@Temperature50", DbType.String,10) ,            
                        new SQLiteParameter("@Status51", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature51", DbType.String,10) ,            
                        new SQLiteParameter("@Status52", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature52", DbType.String,10) ,            
                        new SQLiteParameter("@Status53", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature53", DbType.String,10) ,            
                        new SQLiteParameter("@Status54", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature54", DbType.String,10) ,            
                        new SQLiteParameter("@Status55", DbType.String,10) ,           
                        new SQLiteParameter("@Temperature55", DbType.String,10) ,            
                        new SQLiteParameter("@Status56", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature56", DbType.String,10) ,            
                        new SQLiteParameter("@Status57", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature57", DbType.String,10) ,            
                        new SQLiteParameter("@Status58", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature58", DbType.String,10) ,            
                        new SQLiteParameter("@Status59", DbType.String,10) ,            
                        new SQLiteParameter("@Temperature59", DbType.String,10) ,            
                        new SQLiteParameter("@recordTime", DbType.DateTime)  
            };

            for (int i = 0; i < 59; i++)
            {
                parameters[i * 2].Value = ct[i].s;
                parameters[i * 2 + 1].Value = ct[i].t;
            }
            parameters[118].Value = time.Replace("@", " ");

            SQLiteDBHelper sdb = new SQLiteDBHelper(Program.g_dbPath);
            // return SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters) == 1;
            return sdb.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        public List<CriticalData> SelectCricialData(string lcNum, string isuploadstate)
        {
            
            SQLiteParameter[] sqlParams = new SQLiteParameter[2];
            sqlParams[0] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 10);
            sqlParams[1] = new SQLiteParameter(PARAM_ISUPLOADSTATE, DbType.String, 10);
            sqlParams[0].Value = lcNum;
            sqlParams[1].Value = isuploadstate;
            List<CriticalData> criticalDataList = new List<CriticalData>(100);
            SQLiteDBHelper sdb = new SQLiteDBHelper(Program.g_dbPath);
            SQLiteDataReader reader =   null;
            try
            {
                reader = sdb.ExecuteReader(SELECT_CDATA_DATE_ISNOTUPLOAD, sqlParams);
                while (reader.Read())
                {
                    CriticalData criticalData = new CriticalData(reader.GetString(0).Trim(), reader.GetInt32(1), (float)reader.GetDouble(2), (float)reader.GetDouble(3), (float)reader.GetDouble(4), (float)reader.GetDouble(5), (float)reader.GetDouble(6), (float)reader.GetDouble(7), (float)reader.GetDouble(8), (float)reader.GetDouble(9), (float)reader.GetDouble(10), reader.GetInt32(11), reader.GetDateTime(12), reader.GetDateTime(13), reader.GetString(14));
                    criticalDataList.Add(criticalData);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return criticalDataList;


        }
    }
}
