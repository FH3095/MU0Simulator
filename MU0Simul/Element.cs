using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    abstract class Element
    {
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
        public void SetData(int data)
        {
            SetData(data,null);
        }
        public void SetData(int data,Element by)
        {
            this.data = data;
            changed = true;
        }

        readonly protected int id;
        public int Id
        {
            get
            {
                return id;
            }
        }

        protected int numControlInputs;
        public int NumControlInputs
        {
            get
            {
                return numControlInputs;
            }
        }

        public Element()
        {
            this.id = TimingControl.Inst.createNextId();
            outputTargets = new LinkedList<Element>();
            numControlInputs = 0;
            TimingControl.Inst.RegisterElement(this);
        }

        public Element(int NumControlInputs)
        {
            this.id = TimingControl.Inst.createNextId();
            outputTargets = new LinkedList<Element>();
            numControlInputs = NumControlInputs;
        }

        public void AddOutputTarget(Element e)
        {
            outputTargets.AddLast(e);
        }
        public bool RemoveOutputTarget(Element e)
        {
            return outputTargets.Remove(e);
        }

        abstract public void DoWriteToOther();
        abstract public void DoOperateToOther();
        abstract public void DoReadFromOther();

        protected void HandoverDoOperateToOther()
        {
            HandoverDoOperateToOther(outputTargets.GetEnumerator());
        }
        protected void HandoverDoOperateToOther(IEnumerator<Element> It)
        {
            It.Reset();
            while (It.MoveNext())
            {
                It.Current.DoOperateToOther();
            }
        }

        protected void HandoverData()
        {
            HandoverData(outputTargets.GetEnumerator());
        }
        protected void HandoverData(IEnumerator<Element> It)
        {
            It.Reset();
            while (It.MoveNext())
            {
                It.Current.SetData(this.data, this);
            }
        }
    }
}
