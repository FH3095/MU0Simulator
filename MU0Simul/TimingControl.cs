using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    class TimingControl
    {
        protected Dictionary<Element, int[]> controlVars;
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
            nextId = 0;
        }

        public enum STATE
        {
            OUTPUT,
            OPERATE,
            INPUT,
        };

        private int nextId;
        public int createNextId()
        {
            nextId++;
            return nextId;
        }

        public void RegisterElement(Element e)
        {
            int[] Array = new int[e.NumControlInputs];
            controlVars.Add(e, Array);
        }
    }
}
