using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    class Accumulator : SavingElement
    {
        enum CONTROL_VARS
        {
            OE = 0,
            CE,

            MAX
        };

        public Accumulator()
            : base((int)CONTROL_VARS.MAX)
        {
            TimingControl.Inst.RegisterElement(Id, NumControlInputs);
        }

        public override void DoWriteToOther()
        {
            if (TimingControl.Inst.GetControlInputs(Id)[(int)CONTROL_VARS.OE] == 0)
            {
                return;
            }
            base.DoWriteToOther();
        }

        public override void DoReadFromOther()
        {
            if (TimingControl.Inst.GetControlInputs(Id)[(int)CONTROL_VARS.CE] == 0)
            {
                return;
            }
            base.DoReadFromOther();
        }
    }
}
