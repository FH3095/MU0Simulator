using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    abstract class NonSavingElement : Element
    {
        public NonSavingElement() : base()
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
