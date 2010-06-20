using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    class TimingControl
    {
        public enum STATE
        {
            OUTPUT=0,
            OPERATE,
            INPUT,
        };

        public enum STATIC_CONTROL_VARS
        {
            OPCODE=0,
            RESET,
            STEP,
            ACC_Z,
            ACC_15,

            MAX
        };

        public const int STATIC_CONTROL_VARS_ID = 0;

        protected Dictionary<int, int[]> controlVars;
        private static readonly TimingControl instance = new TimingControl();
        public static TimingControl Inst
        {
            get
            {
                return instance;
            }
        }

        private TimingControl()
        {
            nextId = STATIC_CONTROL_VARS_ID + 1;
            this.controlVars = new Dictionary<int, int[]>();

            int[] Array = new int[(int)STATIC_CONTROL_VARS.MAX];
            for (int i = 0; i < Array.Length; ++i)
            {
                Array[i] = 0;
            }
            this.controlVars.Add(STATIC_CONTROL_VARS_ID, Array);
        }

        private int nextId;
        public int createNextId()
        {
            int Id=nextId;
            nextId++;
            return Id;
        }

        public void RegisterElement(int Id,int NumControlInputs)
        {
            if (controlVars.ContainsKey(Id))
            {
                throw new Exception("Element already registred.");
            }

            if (NumControlInputs != 0)
            {
                int[] Array = new int[NumControlInputs];
                for (int i = 0; i < Array.Length; ++i)
                {
                    Array[i] = 0;
                }
                controlVars.Add(Id, Array);
            }
            else
            {
                controlVars.Add(Id, null);
            }
        }

        public bool UnregisterElement(int Id)
        {
            return controlVars.Remove(Id);
        }

        public int[] GetControlInputs(int Id)
        {
            if (!controlVars.ContainsKey(Id))
            {
                throw new ArgumentOutOfRangeException("int id("+Id+")", "No such element-id.");
            }
            return controlVars[Id];
        }
    }
}
