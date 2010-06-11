using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    abstract class SavingElement : Element
    {
        public SavingElement(TimingControl tc, int id)
            : base(tc, id)
        {
        }
        override public void DoOperateToOther()
        {
        }
    }
}
