using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainRemoteControl.Model;

namespace TrainRemoteControl.BLL
{
    class CriticalDataBLL
    {
        CriticalDataDAL dal = new CriticalDataDAL();
        public bool GetCricialDataToDataBase(Model.CriticalData cd)
        {
            return dal.SaveCriticalData(cd);
        }

        /// <summary>
        /// 保存端子温度温度
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="time"></param>
        public bool GetTempToDataBase(List<CellTerminal> ct, string time)
        {
            return dal.SaveTempData(ct, time);
        }

        //查询要上传数据
        public List<CriticalData> SelectCricialData(string lcNum, string isuploadstate,int rowCount)
        {
            return dal.SelectCricialData(lcNum, isuploadstate, rowCount);
        }

        //更新
        public void updateCriticalData(List<CriticalData> criticalList,string state)
        {
            foreach (CriticalData cd in criticalList)
            {
                dal.updateCriticalData(cd,state);
            }

        }

        //删除 关键数据
        public bool deleteCricialData(string lcNum, DateTime datetime)
        {
           return  dal.deleteCricialData(lcNum, datetime);
        }

    }
}
