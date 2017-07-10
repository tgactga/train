using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainRemoteControl.Model;
using TrainRemoteControl.BLL;

namespace TrainRemoteControl.utilclass
{
    class BuildMsgUtil
    {

        public string buildXunjianData(Model._XJmodel inspectionRecord )
        {
            string str = "";
            Program.WriteLog(" 组装需要上传巡检数据");
            List<TrainRemoteControl.WebModel.InspectionRecords> inspectRecordsList = new List<WebModel.InspectionRecords>();
            TrainRemoteControl.WebModel.InspectionRecords inspect = new WebModel.InspectionRecords();

            inspect.lcNum = Program.g_lcNumber;
            inspect.id = new Random().Next(1,999999);
            inspect.planTime = DateTime.Now;
            inspect.recordTime = DateTime.Now;
            inspect.status = 1;
            inspect.worker = inspectionRecord.getWorker;
            inspect.trainInfo = null;


            inspectRecordsList.Add(inspect);
            str = Program.ScriptSerialize(inspectRecordsList);
            Program.WriteLog(" 组装后数据"+str);
            return str;
        }

      

        public List<CriticalData> selectCriticalData()
        {
            Program.WriteLog("查询要上传的关键数据");
            CriticalDataBLL bll = new CriticalDataBLL();
            List<CriticalData> listA = bll.SelectCricialData(Program.g_lcNumber, "1", 3); //查询前3条数据
            List<CriticalData> listB = bll.SelectCricialData(Program.g_lcNumber, "0", 3);  //未上传的前90条

            listA.AddRange(listB);//把集合A.B合并
            List<CriticalData> ResultcriticalList = listA.Union(listB).ToList<CriticalData>();          //剔除重复项 
            return ResultcriticalList;
        }

        public  string buildUploadCriticalData( CriticalData []  criticalDataList)
        {
            string str = "";
            Program.WriteLog(" 组装需要上传关键数据");
            List<TrainRemoteControl.WebModel.CriticalData> cdList = new List<WebModel.CriticalData>();
            try
            {
                for (int i = 0; i < criticalDataList.Length; i++)
                {
                    TrainRemoteControl.WebModel.CriticalData cd = new WebModel.CriticalData();
                    cd.alarmValue = criticalDataList[i].AlarmValue;
                    cd.current = criticalDataList[i]._Current;
                    cd.dateTime = criticalDataList[i].Date;
                    cd.frequency = criticalDataList[i].Frequency;
                    cd.generatorId = criticalDataList[i].GeneratorId;
                    cd.lcNum = criticalDataList[i].LcNum;
                    cd.motorPower = criticalDataList[i].MotorPower;
                    cd.motorSpeed = criticalDataList[i].MotorSpeed;
                    cd.oilMass = criticalDataList[i].OilMass;
                    cd.oilPress = criticalDataList[i].OilPress;
                    cd.powerFactor = criticalDataList[i].PowerFactor;
                    cd.trainInfo = null;
                    cd.voltage = criticalDataList[i].Voltage;
                    cd.waterTemp = criticalDataList[i].WaterTemp;
                    cdList.Add(cd);
                }
                  str = Program.ScriptSerialize(cdList);
                  Program.WriteLog("组装后的数据：" + str);
            }
            catch (Exception error)
            {
                Program.WriteLog("" + error.ToString());
            }
            return str;
        }

        public   string buildUploadTemperatureData(List<CellTerminal> temperatuelist)
        {
            string str = "";
            Program.WriteLog(" 组装需要上传温度数据");
            List<TrainRemoteControl.WebModel.tab_temperature> tempList = new List<WebModel.tab_temperature>();
            try
            {
                TrainRemoteControl.WebModel.tab_temperature temp = new WebModel.tab_temperature();
                temp.guid = System.Guid.NewGuid().ToString();
                temp.lcnum = Program.g_lcNumber;
                temp.sendtime = DateTime.Now;

                double[] tArr = new double[57];
                int[] sArr = new int[57];
                for (int i = 0; i < temperatuelist.Count; i++)
                {
                    //sArr[temperatuelist[i].n] = temperatuelist[i].s;
                    //tArr[temperatuelist[i].n] = temperatuelist[i].t;
                    switch(temperatuelist[i].n)
                    {
                        case 1:
                            temp.s1 = temperatuelist[i].s;
                            temp.t1 = temperatuelist[i].t;
                            break;
                        case 2:
                            temp.s2 = temperatuelist[i].s;
                            temp.t2 = temperatuelist[i].t;
                            break;
                        case 3:
                            temp.s3 = temperatuelist[i].s;
                            temp.t3 = temperatuelist[i].t;
                            break;
                        case 4:
                            temp.s4 = temperatuelist[i].s;
                            temp.t4 = temperatuelist[i].t;
                            break;
                        case 5:
                            temp.s5 = temperatuelist[i].s;
                            temp.t5 = temperatuelist[i].t;
                            break;
                        case 6:
                            temp.s6 = temperatuelist[i].s;
                            temp.t6 = temperatuelist[i].t;
                            break;
                        case 7:
                            temp.s7 = temperatuelist[i].s;
                            temp.t7 = temperatuelist[i].t;
                            break;
                        case 8:
                            temp.s8 = temperatuelist[i].s;
                            temp.t8 = temperatuelist[i].t;
                            break;
                        case 9:
                            temp.s9 = temperatuelist[i].s;
                            temp.t9 = temperatuelist[i].t;
                            break;
                        case 10:
                            temp.s10 = temperatuelist[i].s;
                            temp.t10 = temperatuelist[i].t;
                            break;

                        case 11:
                            temp.s11 = temperatuelist[i].s;
                            temp.t11 = temperatuelist[i].t;
                            break;
                      
                        case 12:
                            temp.s12 = temperatuelist[i].s;
                            temp.t12 = temperatuelist[i].t;
                            break;
                        case 13:
                            temp.s13 = temperatuelist[i].s;
                            temp.t13 = temperatuelist[i].t;
                            break;
                        case 14:
                            temp.s14 = temperatuelist[i].s;
                            temp.t14 = temperatuelist[i].t;
                            break;
                        case 15:
                            temp.s15 = temperatuelist[i].s;
                            temp.t15 = temperatuelist[i].t;
                            break;
                        case 16:
                            temp.s16 = temperatuelist[i].s;
                            temp.t16 = temperatuelist[i].t;
                            break;
                        case 17:
                            temp.s17 = temperatuelist[i].s;
                            temp.t17 = temperatuelist[i].t;
                            break;
                        case 18:
                            temp.s18 = temperatuelist[i].s;
                            temp.t18 = temperatuelist[i].t;
                            break;
                        case 19:
                            temp.s19 = temperatuelist[i].s;
                            temp.t19 = temperatuelist[i].t;
                            break;
                        case 20:
                            temp.s20 = temperatuelist[i].s;
                            temp.t20 = temperatuelist[i].t;
                            break;

                        case 31:
                            temp.s31 = temperatuelist[i].s;
                            temp.t31 = temperatuelist[i].t;
                            break;
                        case 32:
                            temp.s32 = temperatuelist[i].s;
                            temp.t32 = temperatuelist[i].t;
                            break;
                        case 33:
                            temp.s33 = temperatuelist[i].s;
                            temp.t33 = temperatuelist[i].t;
                            break;
                        case 34:
                            temp.s34 = temperatuelist[i].s;
                            temp.t34 = temperatuelist[i].t;
                            break;
                        case 35:
                            temp.s35 = temperatuelist[i].s;
                            temp.t35 = temperatuelist[i].t;
                            break;
                        case 36:
                            temp.s36 = temperatuelist[i].s;
                            temp.t36 = temperatuelist[i].t;
                            break;
                        case 37:
                            temp.s37 = temperatuelist[i].s;
                            temp.t37 = temperatuelist[i].t;
                            break;
                        case 38:
                            temp.s38 = temperatuelist[i].s;
                            temp.t38 = temperatuelist[i].t;
                            break;
                        case 39:
                            temp.s39 = temperatuelist[i].s;
                            temp.t39 = temperatuelist[i].t;
                            break;
                        case 40:
                            temp.s40 = temperatuelist[i].s;
                            temp.t40 = temperatuelist[i].t;
                            break;

                        case 51:
                            temp.s51 = temperatuelist[i].s;
                            temp.t51 = temperatuelist[i].t;
                            break;
                        case 52:
                            temp.s52 = temperatuelist[i].s;
                            temp.t52 = temperatuelist[i].t;
                            break;
                        case 53:
                            temp.s53 = temperatuelist[i].s;
                            temp.t53 = temperatuelist[i].t;
                            break;
                        case 54:
                            temp.s54 = temperatuelist[i].s;
                            temp.t54 = temperatuelist[i].t;
                            break;
                        case 55:
                            temp.s55 = temperatuelist[i].s;
                            temp.t55 = temperatuelist[i].t;
                            break;
                        case 56:
                            temp.s56 = temperatuelist[i].s;
                            temp.t56 = temperatuelist[i].t;
                            break;
                        case 57:
                            temp.s57 = temperatuelist[i].s;
                            temp.t57 = temperatuelist[i].t;
                            break;
             

                    }             
                   
                }
  

                tempList.Add(temp);
                str = Program.ScriptSerialize(tempList);
                Program.WriteLog("组装后的数据：" + str);
            }
            catch (Exception error)
            {
                Program.WriteLog("" + error.ToString());
            }
            return str;
        }



    }
}
