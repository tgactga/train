using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainRemoteControl.Model;
using TrainRemoteControl.utilclass;
using System.Data.SQLite;

namespace TrainRemoteControl.DAl
{
    public class InspectionRecordDAL
    {
        #region SQL语句
        private const string INSERT_XJ = "INSERT INTO InspectionRecords(lcNum,[status],planTime,recordTime,worker,remarks)VALUES(@lcNum,@status,@planTime,@recordTime,@worker,@remarks)";
        private const string SELECT_XJ = "SELECT TOP @topRowCount lcNum,[status],planTime,recordTime,workerremarks FROM InspectionRecords";
        private const string SCALAR_ROWCOUNT = "SELECT COUNT(*) FROM InspectionRecords";
        private const string SELECT_IR = "SELECT lcNum as '车号',[status] as '巡检状态',planTime as '计划时间',recordTime as '巡检时间',worker as '工作人员',remarks as '备注' FROM InspectionRecords WHERE planTime>@startDateTime AND planTime<@endDateTime order by planTime desc";

        private const string SCALAR_RC_D = "SELECT COUNT(*) FROM InspectionRecords WHERE recordTime<@endDateTime AND recordTime >@startDateTime";

        private const string SCALAR_RC_L = "SELECT COUNT(*) FROM InspectionRecords WHERE lcNum=@lcNum";

        private const string SCALAR_RC_S = "SELECT COUNT(*) FROM InspectionRecords WHERE [status]=@status";

        private const string SCALAR_RC_DS = "SELECT COUNT(*) FROM InspectionRecords WHERE [status]=@status AND recordTime<@endDateTime AND recordTime >@startDateTime";

        private const string SCALAR_RC_LD = "SELECT COUNT(*) FROM InspectionRecords WHERE lcNum=@lcNum AND recordTime<@endDateTime AND recordTime >@startDateTime";

        private const string SCALAR_RC_LS = "SELECT COUNT(*) FROM InspectionRecords WHERE lcNum=@lcNum AND [status]=@status";

        private const string SCALAR_RC_LDS = "SELECT COUNT(*) FROM InspectionRecords WHERE lcNum=@lcNum AND [status]=@status AND recordTime<@endDateTime AND recordTime >@startDateTime";



        private const string SP_GIR = "GetPartialInspectionRecords";//code=0
        private const string SP_GIR_D = "GetPartialInspectionRecordsByDate";//code=1
        private const string SP_GIR_L = "GetPartialInspectionRecordsByLCNum";//code=2
        private const string SP_GIR_S = "GetPartialInspectionRecordsByStatus";//code=3

        private const string SP_GIR_DS = "GetPartialInspectionRecordsByDateAndStatus";//code=4
        private const string SP_GIR_LD = "GetPartialInspectionRecordsByLCNumAndDate";//code=5
        private const string SP_GIR_LS = "GetPartialInspectionRecordsByLCNumAndStatus";//code=6
        private const string SP_GIR_LDS = "GetPartialInspectionRecordsByLDS";//code=8

        private const string SP_GSTASTISTICS = "GetRecordsStatistics";//新添加一个命令

        private const string SP_G_S = "GetRecordsStatisticsByLcNumAndDate";

        private const string PARAM_LCNUM = "@lcNum";
        private const string PARAM_STATUS = "@status";
        private const string PARAM_PTIME = "@planTime";
        private const string PARAM_RTIME = "@recordTime";
        private const string PARAM_WORKER = "@worker";
        private const string PARAM_REMARKS = "@remarks";
        private const string PARAM_TOPROWCOUNT = "@topRowCount";
        private const string PARAM_PAGESIZE = "@pageSize";
        private const string PARAM_PAGENUMBER = "@pageNumber";

        private const string PARAM_STARTTIME = "@startDateTime";
        private const string PARAM_ENDTIME = "@endDateTime";
        #endregion


        private const int PAGESIZE = 30;

        public List<_XJmodel> GetInspectionRecordsByDate(DateTime startDate, DateTime endDate)
        {
            SQLiteDataReader dr = null;
            List<_XJmodel> tempList = new List<_XJmodel>();
            
             SQLiteParameter[] parameters = {
                    new SQLiteParameter(PARAM_STARTTIME, DbType.DateTime),
                    new SQLiteParameter(PARAM_ENDTIME, DbType.DateTime)};
             parameters[0].Value = startDate;
             parameters[1].Value = endDate;
            try
            {
                SQLiteDBHelper sdb = new SQLiteDBHelper(Program.g_dbPath);
                dr = sdb.ExecuteReader(SELECT_IR, parameters);
                while (dr.Read())
                {
                    _XJmodel inspectionRecord = new _XJmodel();
                   
                    inspectionRecord.lcNumber = dr.GetString(0).Trim();
                    inspectionRecord.getStatus = dr.GetString(1).Trim();
                    if (dr[3] != DBNull.Value)
                    {
                        inspectionRecord.getRecordTime = dr.GetDateTime(3);
                    }
                    else
                    {
                        inspectionRecord.getRecordTime = null;
                    }
                    if (dr[4] != DBNull.Value)
                    {
                        inspectionRecord.getWorker = dr.GetString(4).Trim();
                    }
                    else
                    {
                        inspectionRecord.getWorker = "";
                    }
                    
                    
                    tempList.Add(inspectionRecord);
                }
                return tempList;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
        }

        //保存巡检记录
        public bool SaveInspectionRecord(Model._XJmodel inspectionRecord)
        {
            SQLiteParameter[] sqlParams = new SQLiteParameter[6];
            sqlParams[0] = new SQLiteParameter(PARAM_LCNUM, DbType.String, 20);
            sqlParams[1] = new SQLiteParameter(PARAM_STATUS, DbType.String, 10);
            sqlParams[2] = new SQLiteParameter(PARAM_PTIME, DbType.DateTime, 8);
            sqlParams[3] = new SQLiteParameter(PARAM_RTIME, DbType.DateTime, 8);
            sqlParams[4] = new SQLiteParameter(PARAM_WORKER, DbType.String, 20);
            sqlParams[5] = new SQLiteParameter(PARAM_REMARKS, DbType.String, 30);
            sqlParams[0].Value = inspectionRecord.lcNumber;
            sqlParams[1].Value = inspectionRecord.getStatus;
            sqlParams[2].Value = inspectionRecord.getBjtime;
            if (inspectionRecord.getRecordTime == null)
            {
                sqlParams[3].Value = DBNull.Value;
            }
            else
            {
                sqlParams[3].Value = inspectionRecord.getRecordTime;
            }
            sqlParams[4].Value = inspectionRecord.getWorker;
            sqlParams[5].Value = inspectionRecord.getContent == null ? "" : inspectionRecord.getContent;
            SQLiteDBHelper sdb = new SQLiteDBHelper(Program.g_dbPath);
            return sdb.ExecuteNonQuery(INSERT_XJ, sqlParams) > 0;
        }

        //public xjjlmodel GetCheckingStatisticsByLcNumAndDate(DateTime startDate, DateTime endDate, string lcNum)
        //{
        //    SqlParameter paramStartDate = new SqlParameter(PARAM_STARTTIME, SqlDbType.DateTime, 8);
        //    paramStartDate.Value = startDate.Date;
        //    SqlParameter paramEndDate = new SqlParameter(PARAM_ENDTIME, SqlDbType.DateTime, 8);
        //    paramEndDate.Value = endDate.Date;
        //    SqlParameter paramLcNUm = new SqlParameter(PARAM_LCNUM, SqlDbType.NChar, 20);
        //    paramLcNUm.Value = lcNum;
        //    SqlDataReader dr = null;
        //    xjjlmodel model = new xjjlmodel();
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_G_S, CommandType.StoredProcedure, paramStartDate, paramEndDate, paramLcNUm);
        //        if (dr.Read())
        //        {

        //            model.lcNumber = dr.GetString(0).Trim();
        //            model.AllCheckTime = dr[1] == DBNull.Value ? 0 : (int)dr[1];
        //            model.NoCheckTimes = dr[2] == DBNull.Value ? 0 : (int)dr[2];
        //            model.CheckLateTimes = dr[3] == DBNull.Value ? 0 : (int)dr[3];
        //            model.CheckTimes = model.AllCheckTime - model.NoCheckTimes - model.CheckLateTimes;
        //            model.CheckFrequency = Math.Round((double)model.CheckTimes / model.AllCheckTime, 5);
        //            model.CheckLateFrequency = Math.Round((double)model.CheckLateTimes / model.AllCheckTime, 5);
        //        }
        //        return model;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }
        //}

        //public List<_XJmodel> GetInspectionRecordsByDate(DateTime startDate, DateTime endDate)
        //{
        //    SqlDataReader dr = null;
        //    List<_XJmodel> tempList = new List<_XJmodel>();
        //    SqlParameter paramStartDate = new SqlParameter(PARAM_STARTTIME, SqlDbType.DateTime, 8);
        //    paramStartDate.Value = startDate;
        //    SqlParameter paramEndDate = new SqlParameter(PARAM_ENDTIME, SqlDbType.DateTime, 8);
        //    paramEndDate.Value = endDate;
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SELECT_IR, CommandType.Text, paramEndDate, paramStartDate);
        //        while (dr.Read())
        //        {
        //            _XJmodel inspectionRecord = new _XJmodel()
        //            {
        //                lcNumber = dr.GetString(0).Trim(),
        //                getRecord = dr.GetString(1).Trim(),
        //                getBjtime = dr.GetDateTime(2),
        //                getContent = dr.GetString(4).Trim()
        //            };
        //            if (dr[3] != DBNull.Value)
        //            {
        //                inspectionRecord.getRecordTime = dr.GetDateTime(3);
        //            }
        //            else
        //            {
        //                inspectionRecord.getRecordTime = null;
        //            }
        //            tempList.Add(inspectionRecord);
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

        //public List<_XJmodel> GetPartialInspectionRecords(int pageNumber)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[2];
        //    sqlParams[0] = new SqlParameter(PARAM_PAGESIZE, SqlDbType.Int, 4);
        //    sqlParams[1] = new SqlParameter(PARAM_PAGENUMBER, SqlDbType.Int, 4);
        //    sqlParams[0].Value = PAGESIZE;
        //    sqlParams[1].Value = pageNumber;
        //    SqlDataReader dr = null;
        //    List<_XJmodel> tempList = new List<_XJmodel>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GIR, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            _XJmodel inspectionRecord = new _XJmodel()
        //            {
        //                lcNumber = dr.GetString(0).Trim(),
        //                getRecord = dr.GetString(1).Trim(),
        //                getBjtime = dr.GetDateTime(2),
        //                //getWorker=dr.GetString(4).Trim(),
        //                getContent = dr.GetString(4).Trim()
        //            };
        //            if (dr[3] != DBNull.Value)
        //            {
        //                inspectionRecord.getRecordTime = dr.GetDateTime(3);
        //            }
        //            else
        //            {
        //                inspectionRecord.getRecordTime = null;
        //            }
        //            tempList.Add(inspectionRecord);
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

        //public List<_XJmodel> GetPartialInspectionRecordsByDate(DateTime startDateTime, DateTime endDateTime, int pageNumber)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[4];
        //    sqlParams[0] = new SqlParameter(PARAM_STARTTIME, SqlDbType.DateTime, 8);
        //    sqlParams[1] = new SqlParameter(PARAM_ENDTIME, SqlDbType.DateTime, 8);
        //    sqlParams[2] = new SqlParameter(PARAM_PAGENUMBER, SqlDbType.Int, 4);
        //    sqlParams[3] = new SqlParameter(PARAM_PAGESIZE, SqlDbType.Int, 4);
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    sqlParams[2].Value = pageNumber;
        //    sqlParams[3].Value = PAGESIZE;
        //    SqlDataReader dr = null;
        //    List<_XJmodel> tempList = new List<_XJmodel>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GIR_D, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            _XJmodel inspectionRecord = new _XJmodel()
        //            {
        //                lcNumber = dr.GetString(0).Trim(),
        //                getRecord = dr.GetString(1).Trim(),
        //                getBjtime = dr.GetDateTime(2),
        //                //getWorker = dr.GetString(4).Trim(),
        //                getContent = dr.GetString(5).Trim()
        //            };
        //            if (dr[3] != DBNull.Value)
        //            {
        //                inspectionRecord.getRecordTime = dr.GetDateTime(3);
        //            }
        //            else
        //            {
        //                inspectionRecord.getRecordTime = null;
        //            }
        //            tempList.Add(inspectionRecord);
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


        //public List<_XJmodel> GetPartialInspectionRecordsByLCNum(string lcNum, int pageNumber)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[3];
        //    sqlParams[0] = new SqlParameter(PARAM_LCNUM, SqlDbType.NChar, 20);
        //    sqlParams[1] = new SqlParameter(PARAM_PAGENUMBER, SqlDbType.Int, 4);
        //    sqlParams[2] = new SqlParameter(PARAM_PAGESIZE, SqlDbType.Int, 4);
        //    sqlParams[0].Value = lcNum;
        //    sqlParams[1].Value = pageNumber;
        //    sqlParams[2].Value = PAGESIZE;
        //    SqlDataReader dr = null;
        //    List<_XJmodel> tempList = new List<_XJmodel>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GIR_L, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            _XJmodel inspectionRecord = new _XJmodel()
        //            {
        //                lcNumber = dr.GetString(0).Trim(),
        //                getRecord = dr.GetString(1).Trim(),
        //                getBjtime = dr.GetDateTime(2),
        //                //getWorker = dr.GetString(4).Trim(),
        //                getContent = dr.GetString(5).Trim()
        //            };
        //            if (dr[3] != DBNull.Value)
        //            {
        //                inspectionRecord.getRecordTime = dr.GetDateTime(3);
        //            }
        //            else
        //            {
        //                inspectionRecord.getRecordTime = null;
        //            }
        //            tempList.Add(inspectionRecord);
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

        //public List<_XJmodel> GetPartialInspectionRecordsByStatus(string status, int pageNumber)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[3];
        //    sqlParams[0] = new SqlParameter(PARAM_STATUS, SqlDbType.NChar, 10);
        //    sqlParams[1] = new SqlParameter(PARAM_PAGENUMBER, SqlDbType.Int, 4);
        //    sqlParams[2] = new SqlParameter(PARAM_PAGESIZE, SqlDbType.Int, 4);
        //    sqlParams[0].Value = status;
        //    sqlParams[1].Value = pageNumber;
        //    sqlParams[2].Value = PAGESIZE;
        //    SqlDataReader dr = null;
        //    List<_XJmodel> tempList = new List<_XJmodel>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GIR_S, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            _XJmodel inspectionRecord = new _XJmodel()
        //            {
        //                lcNumber = dr.GetString(0).Trim(),
        //                getRecord = dr.GetString(1).Trim(),
        //                getBjtime = dr.GetDateTime(2),

        //                //getWorker = dr.GetString(4).Trim(),
        //                getContent = dr.GetString(5).Trim()
        //            };
        //            if (dr[3] != DBNull.Value)
        //            {
        //                inspectionRecord.getRecordTime = dr.GetDateTime(3);
        //            }
        //            else
        //            {
        //                inspectionRecord.getRecordTime = null;
        //            }
        //            tempList.Add(inspectionRecord);
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


        //public List<_XJmodel> GetPartialInspectionRecordsByDateAndStatus(DateTime startDateTime, DateTime endDateTime, string status, int pageNumber)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[5];
        //    sqlParams[0] = new SqlParameter(PARAM_STARTTIME, SqlDbType.DateTime, 8);
        //    sqlParams[1] = new SqlParameter(PARAM_ENDTIME, SqlDbType.DateTime, 8);
        //    sqlParams[2] = new SqlParameter(PARAM_STATUS, SqlDbType.NChar, 10);
        //    sqlParams[3] = new SqlParameter(PARAM_PAGENUMBER, SqlDbType.Int, 4);
        //    sqlParams[4] = new SqlParameter(PARAM_PAGESIZE, SqlDbType.Int, 4);
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    sqlParams[2].Value = status;
        //    sqlParams[3].Value = pageNumber;
        //    sqlParams[4].Value = PAGESIZE;

        //    SqlDataReader dr = null;
        //    List<_XJmodel> tempList = new List<_XJmodel>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GIR_DS, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            _XJmodel inspectionRecord = new _XJmodel()
        //            {
        //                lcNumber = dr.GetString(0).Trim(),
        //                getRecord = dr.GetString(1).Trim(),
        //                getBjtime = dr.GetDateTime(2),
        //                //getWorker = dr.GetString(4).Trim(),
        //                getContent = dr.GetString(5).Trim()
        //            };
        //            if (dr[3] != DBNull.Value)
        //            {
        //                inspectionRecord.getRecordTime = dr.GetDateTime(3);
        //            }
        //            else
        //            {
        //                inspectionRecord.getRecordTime = null;
        //            }
        //            tempList.Add(inspectionRecord);
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

        //public List<_XJmodel> GetPartialInspectionRecordsByDateAndLCNum(DateTime startDateTime, DateTime endDateTime, string lcNum, int pageNumber)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[5];
        //    sqlParams[0] = new SqlParameter(PARAM_STARTTIME, SqlDbType.DateTime, 8);
        //    sqlParams[1] = new SqlParameter(PARAM_ENDTIME, SqlDbType.DateTime, 8);
        //    sqlParams[2] = new SqlParameter(PARAM_LCNUM, SqlDbType.NChar, 20);
        //    sqlParams[3] = new SqlParameter(PARAM_PAGENUMBER, SqlDbType.Int, 4);
        //    sqlParams[4] = new SqlParameter(PARAM_PAGESIZE, SqlDbType.Int, 4);
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    sqlParams[2].Value = lcNum;
        //    sqlParams[3].Value = pageNumber;
        //    sqlParams[4].Value = PAGESIZE;

        //    SqlDataReader dr = null;
        //    List<_XJmodel> tempList = new List<_XJmodel>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GIR_LD, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            _XJmodel inspectionRecord = new _XJmodel()
        //            {
        //                lcNumber = dr.GetString(0).Trim(),
        //                getRecord = dr.GetString(1).Trim(),
        //                getBjtime = dr.GetDateTime(2),
        //                //getWorker = dr.GetString(4).Trim(),
        //                getContent = dr.GetString(5).Trim()
        //            };
        //            if (dr[3] != DBNull.Value)
        //            {
        //                inspectionRecord.getRecordTime = dr.GetDateTime(3);
        //            }
        //            else
        //            {
        //                inspectionRecord.getRecordTime = null;
        //            }
        //            tempList.Add(inspectionRecord);
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

        //public List<_XJmodel> GetPartialInspectionRecordsByLCNumAndStatus(string lcNum, string status, int pageNumber)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[4];
        //    sqlParams[0] = new SqlParameter(PARAM_LCNUM, SqlDbType.NChar, 20);
        //    sqlParams[1] = new SqlParameter(PARAM_STATUS, SqlDbType.NChar, 10);
        //    sqlParams[2] = new SqlParameter(PARAM_PAGENUMBER, SqlDbType.Int, 4);
        //    sqlParams[3] = new SqlParameter(PARAM_PAGESIZE, SqlDbType.Int, 4);
        //    sqlParams[0].Value = lcNum;
        //    sqlParams[1].Value = status;
        //    sqlParams[2].Value = pageNumber;
        //    sqlParams[3].Value = PAGESIZE;
        //    SqlDataReader dr = null;
        //    List<_XJmodel> tempList = new List<_XJmodel>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GIR_LS, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            _XJmodel inspectionRecord = new _XJmodel()
        //            {
        //                lcNumber = dr.GetString(0).Trim(),
        //                getRecord = dr.GetString(1).Trim(),
        //                getBjtime = dr.GetDateTime(2),

        //                //getWorker = dr.GetString(4).Trim(),
        //                getContent = dr.GetString(5).Trim()
        //            };
        //            if (dr[3] != DBNull.Value)
        //            {
        //                inspectionRecord.getRecordTime = dr.GetDateTime(3);
        //            }
        //            else
        //            {
        //                inspectionRecord.getRecordTime = null;
        //            }
        //            tempList.Add(inspectionRecord);
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

        //public List<_XJmodel> GetPartialInspectionRecordsByLDS(DateTime startDateTime, DateTime endDateTime, string lcNum, string status, int pageNumber)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[6];
        //    sqlParams[0] = new SqlParameter(PARAM_STARTTIME, SqlDbType.DateTime, 8);
        //    sqlParams[1] = new SqlParameter(PARAM_ENDTIME, SqlDbType.DateTime, 8);
        //    sqlParams[2] = new SqlParameter(PARAM_LCNUM, SqlDbType.NChar, 20);
        //    sqlParams[3] = new SqlParameter(PARAM_PAGENUMBER, SqlDbType.Int, 4);
        //    sqlParams[4] = new SqlParameter(PARAM_STATUS, SqlDbType.NChar, 10);
        //    sqlParams[5] = new SqlParameter(PARAM_PAGESIZE, SqlDbType.Int, 4);
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    sqlParams[2].Value = lcNum;
        //    sqlParams[3].Value = pageNumber;
        //    sqlParams[4].Value = lcNum;
        //    sqlParams[5].Value = PAGESIZE;

        //    SqlDataReader dr = null;
        //    List<_XJmodel> tempList = new List<_XJmodel>(PAGESIZE);
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GIR_LDS, CommandType.StoredProcedure, sqlParams);
        //        while (dr.Read())
        //        {
        //            _XJmodel inspectionRecord = new _XJmodel()
        //            {
        //                lcNumber = dr.GetString(0).Trim(),
        //                getRecord = dr.GetString(1).Trim(),
        //                getBjtime = dr.GetDateTime(2),
        //                //getWorker = dr.GetString(4).Trim(),
        //                getContent = dr.GetString(5).Trim()
        //            };
        //            if (dr[3] != DBNull.Value)
        //            {
        //                inspectionRecord.getRecordTime = dr.GetDateTime(3);
        //            }
        //            else
        //            {
        //                inspectionRecord.getRecordTime = null;
        //            }
        //            tempList.Add(inspectionRecord);
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
        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_ROWCOUNT);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByDate(DateTime startDateTime, DateTime endDateTime)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[]
        //    {
        //        new SqlParameter(PARAM_STARTTIME,SqlDbType.DateTime,8),
        //        new SqlParameter(PARAM_ENDTIME,SqlDbType.DateTime,8)
        //    };
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_RC_D, sqlParams);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByLCNum(string lcNum)
        //{
        //    SqlParameter serialNum = new SqlParameter(PARAM_LCNUM, SqlDbType.NChar, 20);
        //    serialNum.Value = lcNum;
        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_RC_L, serialNum);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByStatus(string status)
        //{
        //    SqlParameter paramStatus = new SqlParameter(PARAM_STATUS, SqlDbType.NChar, 10);
        //    paramStatus.Value = status;
        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_RC_S, paramStatus);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByDateAndStatus(DateTime startDateTime, DateTime endDateTime, string status)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[]
        //    {
        //        new SqlParameter(PARAM_STARTTIME,SqlDbType.DateTime,8),
        //        new SqlParameter(PARAM_ENDTIME,SqlDbType.DateTime,8),
        //        new SqlParameter(PARAM_STATUS,SqlDbType.NChar,10)
        //    };
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    sqlParams[2].Value = status;

        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_RC_DS, sqlParams);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByDateAndLCNum(DateTime startDateTime, DateTime endDateTime, string lcNum)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[]
        //    {
        //        new SqlParameter(PARAM_STARTTIME,SqlDbType.DateTime,8),
        //        new SqlParameter(PARAM_ENDTIME,SqlDbType.DateTime,8),
        //        new SqlParameter(PARAM_LCNUM,SqlDbType.NChar,10)
        //    };
        //    sqlParams[0].Value = startDateTime;
        //    sqlParams[1].Value = endDateTime;
        //    sqlParams[2].Value = lcNum;

        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_RC_LD, sqlParams);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public int GetPageTotalByLCNumAndStatus(string lcNum, string status)
        //{
        //    SqlParameter serialNum = new SqlParameter(PARAM_LCNUM, SqlDbType.NChar, 20);
        //    serialNum.Value = lcNum;
        //    SqlParameter paramStatus = new SqlParameter(PARAM_STATUS, SqlDbType.NChar, 10);
        //    paramStatus.Value = status;
        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_RC_S, paramStatus, serialNum);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;

        //}

        //public int GetPageTotalByLDS(string lcNum, DateTime startDateTime, DateTime endDateTime, string status)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[4];
        //    sqlParams[0] = new SqlParameter(PARAM_LCNUM, SqlDbType.NChar, 20);
        //    sqlParams[1] = new SqlParameter(PARAM_STARTTIME, SqlDbType.DateTime, 8);
        //    sqlParams[2] = new SqlParameter(PARAM_ENDTIME, SqlDbType.DateTime, 8);
        //    sqlParams[3] = new SqlParameter(PARAM_STATUS, SqlDbType.NChar, 10);
        //    sqlParams[0].Value = lcNum;
        //    sqlParams[1].Value = startDateTime;
        //    sqlParams[2].Value = endDateTime;
        //    sqlParams[3].Value = status;
        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_RC_LDS, sqlParams);
        //    int total = (int)objTotal;
        //    return (total - 1) / PAGESIZE + 1;
        //}

        //public xjjlmodel GetCheckingStatisticsByLCNum(string lcNum)
        //{
        //    SqlParameter serialNum = new SqlParameter(PARAM_LCNUM, SqlDbType.NChar, 20);
        //    serialNum.Value = lcNum;
        //    object objTotal = SQLHelper.ExecuteScalar(SCALAR_RC_L, serialNum);
        //    SqlParameter paramStatus = new SqlParameter(PARAM_STATUS, SqlDbType.NChar, 10);
        //    paramStatus.Value = "已检";
        //    object objCheckedTotal = SQLHelper.ExecuteScalar(SCALAR_RC_LS, serialNum, paramStatus);

        //    paramStatus.Value = "晚检";
        //    object objLateCheckedTotal = SQLHelper.ExecuteScalar(SCALAR_RC_LS, serialNum, paramStatus);

        //    paramStatus.Value = "未检";
        //    object objNonCheckedTotal = SQLHelper.ExecuteScalar(SCALAR_RC_LS, serialNum, paramStatus);
        //    xjjlmodel statics = new xjjlmodel();
        //    statics.AllCheckTime = (int)objTotal;
        //    statics.CheckTimes = (int)objCheckedTotal;
        //    statics.CheckLateTimes = (int)objLateCheckedTotal;
        //    statics.NoCheckTimes = (int)objNonCheckedTotal;
        //    statics.lcNumber = lcNum;
        //    statics.CheckFrequency = Math.Round(((double)statics.CheckTimes) / statics.AllCheckTime, 5);
        //    statics.CheckLateFrequency = Math.Round(((double)statics.CheckLateTimes) / statics.AllCheckTime, 5);
        //    return statics;

        //}

        //public List<xjjlmodel> GetCheckingStatistics()
        //{
        //    List<xjjlmodel> tempList = new List<xjjlmodel>();
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SP_GSTASTISTICS, CommandType.StoredProcedure);
        //        while (dr.Read())
        //        {
        //            xjjlmodel model = new xjjlmodel();
        //            model.lcNumber = dr.GetString(0).Trim();
        //            model.AllCheckTime = dr[1] == DBNull.Value ? 0 : (int)dr[1];
        //            model.CheckTimes = dr[2] == DBNull.Value ? 0 : (int)dr[2];
        //            model.CheckLateTimes = dr[3] == DBNull.Value ? 0 : (int)dr[3];
        //            model.NoCheckTimes = model.AllCheckTime - model.CheckTimes - model.CheckLateTimes;
        //            model.CheckFrequency = Math.Round((double)model.CheckTimes / model.AllCheckTime, 5);
        //            model.CheckLateFrequency = Math.Round((double)model.CheckLateTimes / model.AllCheckTime, 5);
        //            tempList.Add(model);
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

        //public bool SaveInspectionRecord(Model._XJmodel inspectionRecord)
        //{
        //    SqlParameter[] sqlParams = new SqlParameter[6];
        //    sqlParams[0] = new SqlParameter(PARAM_LCNUM, SqlDbType.NChar, 20);
        //    sqlParams[1] = new SqlParameter(PARAM_STATUS, SqlDbType.NChar, 10);
        //    sqlParams[2] = new SqlParameter(PARAM_PTIME, SqlDbType.DateTime, 8);
        //    sqlParams[3] = new SqlParameter(PARAM_RTIME, SqlDbType.DateTime, 8);
        //    sqlParams[4] = new SqlParameter(PARAM_WORKER, SqlDbType.NChar, 20);
        //    sqlParams[5] = new SqlParameter(PARAM_REMARKS, SqlDbType.NChar, 30);
        //    sqlParams[0].Value = inspectionRecord.lcNumber;
        //    sqlParams[1].Value = inspectionRecord.getRecord;
        //    sqlParams[2].Value = inspectionRecord.getBjtime;
        //    if (inspectionRecord.getRecordTime == null)
        //    {
        //        sqlParams[3].Value = DBNull.Value;
        //    }
        //    else
        //    {
        //        sqlParams[3].Value = inspectionRecord.getRecordTime;
        //    }
        //    sqlParams[4].Value = "";
        //    sqlParams[5].Value = inspectionRecord.getContent == null ? "" : inspectionRecord.getContent;
        //    return SQLHelper.ExecuteNonQuery(INSERT_XJ, CommandType.Text, sqlParams) > 0;
        //}



        //public List<Model._XJmodel> GetInspectionRecords(int rowCount)
        //{
        //    SqlParameter paramRowCount = new SqlParameter(PARAM_TOPROWCOUNT, SqlDbType.Int, 4);
        //    paramRowCount.Value = rowCount;
        //    List<Model._XJmodel> list = new List<Model._XJmodel>(rowCount);
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        dr = SQLHelper.ExecuteReader(SELECT_XJ, CommandType.Text, paramRowCount);
        //        while (dr.Read())
        //        {
        //            Model._XJmodel irecord = new Model._XJmodel()
        //            {
        //                lcNumber = dr.GetString(0).Trim(),
        //                getRecord = dr.GetString(1).Trim(),
        //                getBjtime = dr.GetDateTime(2),

        //                //getWorker = dr.GetString(4).Trim(),
        //                getContent = dr.GetString(5).Trim()
        //            };
        //            if (dr[3] != DBNull.Value)
        //            {
        //                irecord.getRecordTime = dr.GetDateTime(3);
        //            }
        //            else
        //            {
        //                irecord.getRecordTime = null;
        //            }
        //            list.Add(irecord);
        //        }
        //        return list;
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }
        //}





    }
}