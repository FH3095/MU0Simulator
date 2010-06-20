using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    class NonSavingElement : Element
    {
        public NonSavingElement() : base()
        {
        }

        public NonSavingElement(int NumControlInputs)
            : base(NumControlInputs)
        {
        }

        override public void DoWriteToOther()
        {
        }
        override public void DoReadFromOther()
        {
        }
        public override void DoOperateToOther()
        {
            HandoverData();
            HandoverDoOperateToOther();
        }
    }
}
