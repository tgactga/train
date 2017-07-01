using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainRemoteControl.Model
{
    class CellTerminal
    {

         private float temperature;
        private int status;
        private int no;

        public float t//温度
        {
            get 
            {
                return temperature;
            }
            set
            {
                this.temperature = value;
            }
        }

        public int s//状态值0-5
        {
            get
            {
                return status;
            }
            set
            {
                this.status = value;
            }
        }

        public int n //序号
        {
            get
            {
                return no;
            }
            set
            {
                this.no = value;
            }
        }
    
    }
}
