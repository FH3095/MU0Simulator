using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    class Multiplexer : NonSavingElement
    {
        public Multiplexer() : base(1)
        {
            in0 = new NonSavingElement();
            in0.AddOutputTarget(this);
            in1 = new NonSavingElement();
            in1.AddOutputTarget(this);
            TimingControl.Inst.RegisterElement(this);
        }

        protected NonSavingElement in0;
        protected NonSavingElement in1;

        public NonSavingElement In0
        {
            get
            {
                return in0;
            }
        }

        public NonSavingElement In1
        {
            get
            {
                return in1;
            }
        }

        public override void DoOperateToOther()
        {
            int InputChannel = TimingControl.Inst.GetControlInputs(this.Id)[0];
            this.data = (InputChannel == 0) ? in0.Data : in1.Data;
            base.DoOperateToOther();
        }
    }
}
