using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    }
}
