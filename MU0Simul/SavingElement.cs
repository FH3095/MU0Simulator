using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    class SavingElement : Element
    {
        protected int saveData;
        public int SaveData
        {
            get
            {
                return saveData;
            }
        }

        public SavingElement()
            : base()
        {
        }

        public SavingElement(int NumControlInputs)
            : base(NumControlInputs)
        {
        }

        override public void DoOperateToOther()
        {
        }
        public override void DoReadFromOther()
        {
            this.saveData = this.data;
        }
        public override void DoWriteToOther()
        {
            this.data = this.saveData;
            HandoverData();
        }
    }
}
