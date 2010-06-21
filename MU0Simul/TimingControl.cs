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

            MAX
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
        protected Dictionary<int, Element> controls;
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

        public void RegisterElement(Element e)
        {
            if (controlVars.ContainsKey(e.Id))
            {
                throw new ArgumentException("Element already registred.");
            }
            if (e.Id <= STATIC_CONTROL_VARS_ID)
            {
                throw new ArgumentException("Element id lower than " + STATIC_CONTROL_VARS_ID);
            }

            controls.Add(e.Id, e);
            if (e.NumControlInputs != 0)
            {
                int[] Array = new int[e.NumControlInputs];
                for (int i = 0; i < Array.Length; ++i)
                {
                    Array[i] = 0;
                }
                controlVars.Add(e.Id, Array);
            }
            else
            {
                controlVars.Add(e.Id, null);
            }
        }

        public bool UnregisterElement(int Id)
        {
            controls.Remove(Id);
            return controlVars.Remove(Id);
        }

        public int[] GetControlInputs(int Id)
        {
            if (!controlVars.ContainsKey(Id))
            {
                return null;
            }
            return controlVars[Id];
        }

        public Element GetElementById(int Id)
        {
            if (!controls.ContainsKey(Id))
            {
                return null;
            }
            return controls[Id];
        }
    }
}
