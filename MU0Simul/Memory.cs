using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    class Memory : SavingElement
    {
        enum CONTROL_VARS
        {
            MEM_RQ = 0,
            R_NW,

            MAX
        };
        protected int[] memData;
        public int[] MemData
        {
            get
            {
                return memData;
            }
        }

        public const int MEM_START_SIZE = 8;

        public Memory()
            : base((int)CONTROL_VARS.MAX)
        {
            memData = new int[MEM_START_SIZE];
            ZeroMemory(0);
            addressIn = new NonSavingElement();
            addressIn.AddOutputTarget(this);
            dataIn = new NonSavingElement();
            dataIn.AddOutputTarget(this);
            TimingControl.Inst.RegisterElement(this);
        }

        protected void ZeroMemory(int StartPos)
        {
            for (int i = StartPos; i < memData.Length; ++i)
            {
                memData[i] = 0;
            }
        }

        public void ResizeMemory(int NewSize)
        {
            int[] NewMemData = new int[NewSize];
            int MinSize = (NewMemData.Length < memData.Length) ? NewMemData.Length : memData.Length;
            for (int i = 0; i < MinSize; ++i)
            {
                NewMemData[i] = memData[i];
            }
            memData = NewMemData;
            ZeroMemory(MinSize);
        }

        protected NonSavingElement addressIn;
        protected NonSavingElement dataIn;
        public NonSavingElement AddressIn
        {
            get
            {
                return addressIn;
            }
        }
        public NonSavingElement DataIn
        {
            get
            {
                return dataIn;
            }
        }

        public override void DoReadFromOther()
        {
            if (addressIn.Data >= memData.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.data = addressIn.Data;
            this.saveData = dataIn.Data;
            memData[addressIn.Data] = dataIn.Data;
        }

        public override void DoOperateToOther()
        {
            if (addressIn.Data >= memData.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.data = addressIn.Data;
            this.saveData = memData[addressIn.Data];
            HandoverData();
            HandoverDoOperateToOther();
        }

        public override void DoWriteToOther()
        {
        }
    }
}
