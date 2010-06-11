using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    abstract class Element
    {
        protected TimingControl tc;
        protected TimingControl.STATE curState;
        public TimingControl.STATE CurState
        {
            set
            {
                if (value == TimingControl.STATE.OUTPUT && curState == TimingControl.STATE.INPUT)
                {
                    changed = false;
                }
                curState = value;
            }
        }
        protected bool changed;
        public bool Changed
        {
            get
            {
                return changed;
            }
        }
        protected LinkedList<Element> outputTargets;
        protected int data;
        public int Data
        {
            get
            {
                return data;
            }
        }
        abstract public void SetData(Element by, int data);
        protected int id;
        public int Id
        {
            get
            {
                return id;
            }
        }
        protected int numInputs;
        public int NumInputs
        {
            get
            {
                return numInputs;
            }
        }

        public Element(TimingControl tc,int id)
        {
            this.id = id;
            outputTargets = new LinkedList<Element>();
            numInputs = 0;
            this.tc = tc;
        }

        public void AddOutputTarget(Element e)
        {
            outputTargets.AddLast(e);
        }

        abstract public void DoWriteToOther();
        abstract public void DoOperateToOther();
        abstract public void DoReadFromOther();
    }
}
