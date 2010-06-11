using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    class Bus : NonSavingElement
    {
        Bus(TimingControl tc, int id)
            : base(tc, id)
        {
        }
        public override void DoOperateToOther()
        {
        }
    }
}
