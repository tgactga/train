using System;

namespace TrainRemoteControl.Model
{
    public enum AlarmSignal
    {
        FA,//烟火报警
        UOP,// 上油箱报警
        UWP,//上水箱报警
        BV,//储电池报警
        OPA1,//电机1油压报警
        OPA2,
        OPA3,
        WTA1,//电机1水温报警
        WTA2,
        WTA3,
        MSA1,//电机1转速报警
        MSA2,
        MSA3,
        OL1,//电机1油管泄漏
        OL2,
        OL3
    }

    public enum ClientCmd
    {
        login = 0,
        alarmSignal,
        allClear,
    }

    public class Display
    {
        public int Number;
        public float oil_press;
        public float water_temp;
        public float frequency;
        public float motor_speed;
        public float voltage;
        public float current;
        public float motor_power;
        public float power_factor;
        public float oil_mass;  //显示的油箱油量
        public bool fire_alarm; //显示的烟火报警
        public bool up_oil_place;//显示的上油箱油位
        public bool up_water_place; //显示的上水箱水位
        public bool battery_voltage; //显示的24V蓄电池电压

        public bool oil_leak;  //显示的油管泄漏报警信号
        public bool Alarm_OP;  //显示的油压报警信号
        public bool Alarm_WT;  //显示的水温报警信号
        public bool Alarm_MS; //显示的转速报警信号
        public bool alarm;  //延时显示的总报警
        public bool alarm_voice; //输出的报警声音 7050D4；DO；0；0
        public bool OKAlarm; //显示的报警已经确认
        public bool NOAlarm; //显示的报警已经解除
        public bool NCAlarm; //显示的报警无法排除
      
        public DateTime time;
    }
}
