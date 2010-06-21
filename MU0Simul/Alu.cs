using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU0Simul
{
    class Alu : NonSavingElement
    {
        const short STEP_VALUE = 1;
        // TODO Logische Befehle (AND,OR,XOR,...) implementieren
        enum OPERATION
        {
            NONE,
            ADD,
            SUB,
            MUL,
            DIV,
            MOD,
            B,
            A,
            INC_A,
            DEC_A,
            INC_B,
            DEC_B,
            RSB,
        };

        protected NonSavingElement inA;
        protected NonSavingElement inB;

        public NonSavingElement InA
        {
            get
            {
                return inA;
            }
        }

        public NonSavingElement InB
        {
            get
            {
                return inB;
            }
        }

        public Alu() : base(1)
        {
            inA = new NonSavingElement();
            inA.AddOutputTarget(this);
            inB = new NonSavingElement();
            inB.AddOutputTarget(this);
            TimingControl.Inst.RegisterElement(this);
        }

        protected void DoCalc()
        {
            int inOp = TimingControl.Inst.GetControlInputs(this.Id)[0];
            OPERATION Op;
            if (Enum.IsDefined(typeof(OPERATION), inOp))
            {
                Op=(OPERATION)inOp;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            switch (Op)
            {
                case OPERATION.A:
                    data = inA.Data;
                    break;
                case OPERATION.ADD:
                    data = inA.Data + inB.Data;
                    break;
                case OPERATION.B:
                    data = inB.Data;
                    break;
                case OPERATION.DEC_A:
                    data = inA.Data - STEP_VALUE;
                    break;
                case OPERATION.DEC_B:
                    data = inB.Data - STEP_VALUE;
                    break;
                case OPERATION.DIV:
                    data = inA.Data / inB.Data;
                    break;
                case OPERATION.INC_A:
                    data = inA.Data + STEP_VALUE;
                    break;
                case OPERATION.INC_B:
                    data = inB.Data + STEP_VALUE;
                    break;
                case OPERATION.MOD:
                    data = inA.Data % inB.Data;
                    break;
                case OPERATION.MUL:
                    data = inA.Data * inB.Data;
                    break;
                case OPERATION.SUB:
                    data = inA.Data - inB.Data;
                    break;
                case OPERATION.RSB:
                    data = inB.Data - inA.Data;
                    break;
            }
        }

        public override void DoOperateToOther()
        {
            DoCalc();
            IEnumerator<Element> It=outputTargets.GetEnumerator();
            HandoverData(It);
            HandoverDoOperateToOther(It);
        }
    }
}
