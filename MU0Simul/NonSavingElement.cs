using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    abstract class NonSavingElement : Element
    {
        public NonSavingElement(TimingControl tc, int id) : base(tc,id)
        {
        }
        override public void DoWriteToOther()
        {
        }
        override public void DoReadFromOther()
        {
        }
    }
}
