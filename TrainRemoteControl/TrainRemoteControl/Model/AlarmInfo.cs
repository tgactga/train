
namespace TrainRemoteControl.Model
{
    public struct AlarmInfo
    {
        #region 字段
        private string serialNum;
        private int alarmValue;
        #endregion

        #region 属性
        /// <summary>
        /// 下位机序列号
        /// </summary>
        public string SerialNum
        {
            get
            {
                return serialNum;
            }
        }

        public int AlarmValue
        {
            get
            {
                return alarmValue;
            }
            set
            {
                alarmValue = value;
            }
        }

        /// <summary>
        /// 烟火报警
        /// </summary>
        public bool FireAlarm
        {
            get
            {
                return (alarmValue&1)>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=1;
                }
                else
                {
                    alarmValue&=(~1);
                }
            }
        }

        /// <summary>
        /// 上油箱油位报警
        /// </summary>
        public bool UpOilPlace
        {
            get
            {
                return (alarmValue&(1<<1))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<1);
                }
                else
                {
                    alarmValue&=(~(1<<1));
                }
            }
        }

        /// <summary>
        /// 上水箱水位报警
        /// </summary>
        public bool UpWaterPlace
        {
            get
            {
                return (alarmValue&(1<<2))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<2);
                }
                else
                {
                    alarmValue&=~(1<<2);
                }
            }
        }

        /// <summary>
        /// 24v储电池报警
        /// </summary>
        public bool BatteryVoltage
        {
            get
            {
                return (alarmValue&(1<<3))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<3);
                }
                else
                {
                    alarmValue&=~(1<<3);
                }
            }
        }

        /// <summary>
        /// 电机1油压报警
        /// </summary>
        public bool AlarmOP1
        {
            get
            {
                return (alarmValue&(1<<4))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<4);
                }
                else
                {
                    alarmValue&=~(1<<4);
                }
            }
        }

        /// <summary>
        /// 电机2油压报警
        /// </summary>
        public bool AlarmOP2
        {
            get
            {
                return (alarmValue&(1<<5))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<5);
                }
                else
                {
                    alarmValue&=~(1<<5);
                }
            }
        }

        /// <summary>
        /// 电机3油压报警
        /// </summary>
        public bool AlarmOP3
        {
            get
            {
                return (alarmValue&(1<<6))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<6);
                }
                else
                {
                    alarmValue&=~(1<<6);
                }
            }
        }

        /// <summary>
        /// 电机1水温报警
        /// </summary>
        public bool AlarmWT1
        {
            get
            {
                return (alarmValue&(1<<7))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<7);
                }
                else
                {
                    alarmValue&=~(1<<7);
                }
            }
        }

        /// <summary>
        /// 电机2水温报警
        /// </summary>
        public bool AlarmWT2
        {
            get
            {
                return (alarmValue&(1<<8))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<8);
                }
                else
                {
                    alarmValue&=~(1<<8);
                }
            }
        }

        /// <summary>
        /// 电机3水温报警
        /// </summary>
        public bool AlarmWT3
        {
            get
            {
                return (alarmValue&(1<<9))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<9);
                }
                else
                {
                    alarmValue&=~(1<<9);
                }
            }
        }

        /// <summary>
        /// 电机1转速报警
        /// </summary>
        public bool AlarmMS1
        {
            get
            {
                return (alarmValue&(1<<10))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<10);
                }
                else
                {
                    alarmValue&=~(1<<10);
                }
            }
        }

        /// <summary>
        /// 电机2转速报警
        /// </summary>
        public bool AlarmMS2
        {
            get
            {
                return (alarmValue&(1<<11))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<11);
                }
                else
                {
                    alarmValue&=~(1<<11);
                }
            }
        }

        /// <summary>
        /// 电机3转速报警
        /// </summary>
        public bool AlarmMS3
        {
            get
            {
                return (alarmValue&(1<<12))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<12);
                }
                else
                {
                    alarmValue&=~(1<<12);
                }
            }
        }

        /// <summary>
        /// 电机1油管泄露报警
        /// </summary>
        public bool OilLeak1
        {
            get
            {
                return (alarmValue&(1<<13))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<13);
                }
                else
                {
                    alarmValue&=~(1<<13);
                }
            }
        }

        /// <summary>
        /// 电机2油管泄露报警
        /// </summary>
        public bool OilLeak2
        {
            get
            {
                return (alarmValue & (1 << 14)) > 0;
            }
            set
            {
                if (value)
                {
                    alarmValue |= (1 << 14);
                }
                else
                {
                    alarmValue &= ~(1 << 14);
                }
            }
        }

        /// <summary>
        /// 电机3油管泄露报警
        /// </summary>
        public bool OilLeak3
        {
            get
            {
                return (alarmValue&(1<<15))>0;
            }
            set
            {
                if(value)
                {
                    alarmValue|=(1<<15);
                }
                else
                {
                    alarmValue&=~(1<<15);
                }
            }
        } 
        #endregion

        public bool this[int i]
        {
            get
            {
                return (alarmValue & (1 << i)) > 0;
            }
            set
            {
                if (value)
                {
                    alarmValue |= (1 << i);
                }
                else
                {
                    alarmValue &= ~(1 << i);
                }
            }
        }

        public AlarmInfo(int alarmValue, string serialNum)
        {
            this.serialNum = serialNum;
            this.alarmValue = alarmValue;
        }

        /// <summary>
        /// 不同电机报警合并,只限于同时采集的同一列车不同电机报警值
        /// </summary>
        /// <param name="alarmArray"></param>
        public static AlarmInfo AlarmMerge(params AlarmInfo[] alarmArray)
        {
            AlarmInfo alarmInfo=default(AlarmInfo);
            if(alarmArray!=null)
            {
                alarmInfo=new AlarmInfo(0,alarmArray[1].SerialNum);
                for(int i=0;i<alarmArray.Length-1;i++)
                {
                    alarmArray[i].alarmValue=(alarmArray[i].alarmValue<<4)>>4;
                }
                for(int i=0;i<alarmArray.Length;i++)
                {
                    alarmInfo.alarmValue|=alarmArray[i].alarmValue;
                }
            }
            return alarmInfo;
        }

        public static AlarmInfo AlarmMerge(string serialNum, params int[] alarmValueArray)
        {
            for (int i = 0; i < alarmValueArray.Length - 1; i++)
            {
                alarmValueArray[i] = (alarmValueArray[i]<< 4) >> 4;
            }
            for (int i = 0; i < alarmValueArray.Length-1; i++)
            {
                alarmValueArray[alarmValueArray.Length - 1] |= alarmValueArray[i];
            }
            return new AlarmInfo(alarmValueArray[alarmValueArray.Length - 1], serialNum);
        }


    }
}
