using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainRemoteControl.utilclass;
using TrainRemoteControl.Model;
using TrainRemoteControl.DAl;

namespace TrainRemoteControl
{
    public partial class AlarmForm : Templete
    {
        AlarmInfo alarmInfo = new AlarmInfo();
        DataAcquisition dacquisition = new DataAcquisition();
        public AlarmForm()
        {
            InitializeComponent();
        }


        private void AlarmForm_Load(object sender, EventArgs e)
        {
            Program.WriteLog("==========================>>进入AlarmForm页面");
            //蜂鸣
           
            Program.WriteLog("启动蜂鸣");
            dacquisition.StartAlarm();



        }


        //确认报警
        private void button1_Click(object sender, EventArgs e)
        {
            
          Program.WriteLog("关闭蜂鸣");
          dacquisition.StopAlarm();
          Program.WriteLog("确认报警，上传报警数据");
          AlarmRecordDAL alarmRecord = new AlarmRecordDAL();

          alarmRecord.SaveAlarmRecord(alarmInfo);
          string ret =   WebServiceUtil.uploadAlarmRecords(alarmInfo);
          if ("1".Equals(ret))
          {
              //更新数据库状态
              alarmRecord.updateAlarmRecord(alarmInfo);
              
              
          }


        }

       
    }
}
