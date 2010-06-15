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
        protected class AluInput : NonSavingElement
        {
            public AluInput() : base()
            {
            }
            public override void DoOperateToOther()
            {
                HandoverDoOperateToOther();
            }
        }
        protected AluInput InA;
        protected AluInput InB;

        public Alu() : base()
        {
            this.numControlInputs = 1;
            InA = new AluInput();
            InA.AddOutputTarget(this);
            InB = new AluInput();
            InB.AddOutputTarget(this);
            TimingControl.Inst.RegisterElement(this);
        }

        protected void DoCalc()
        {
            // TODO Vom TC die Operation holen
            int inOp=0;
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
                    data = InA.Data;
                    break;
                case OPERATION.ADD:
                    data = InA.Data + InB.Data;
                    break;
                case OPERATION.B:
                    data = InB.Data;
                    break;
                case OPERATION.DEC_A:
                    data = InA.Data - STEP_VALUE;
                    break;
                case OPERATION.DEC_B:
                    data = InB.Data - STEP_VALUE;
                    break;
                case OPERATION.DIV:
                    data = InA.Data / InB.Data;
                    break;
                case OPERATION.INC_A:
                    data = InA.Data + STEP_VALUE;
                    break;
                case OPERATION.INC_B:
                    data = InB.Data + STEP_VALUE;
                    break;
                case OPERATION.MOD:
                    data = InA.Data % InB.Data;
                    break;
                case OPERATION.MUL:
                    data = InA.Data * InB.Data;
                    break;
                case OPERATION.SUB:
                    data = InA.Data - InB.Data;
                    break;
                case OPERATION.RSB:
                    data = InB.Data - InA.Data;
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
