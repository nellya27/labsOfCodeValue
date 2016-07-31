using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonLogic
{
    public class Move : IComparable<Move>, IEquatable<Move>
    {

        private int sourceField;
        private int targetField;
        private SoldierType checkerType;
        private int Lengh;

       public Move(int newSourceField,int newTargetField,SoldierType type)
        {

            sourceField = newSourceField;
            targetField = newTargetField;
            checkerType = type;
        }

        public int GetSourceField
        {
            get { return sourceField; }
        }

        public int GetTargetField
        {
            get { return targetField; }
        }

        public SoldierType GetChecers
        {
            get { return checkerType; }
        }

        public int GetLengh
        {
            get
            {
                int whiteOut = (int)BordLocation.Oout;
                if(sourceField==whiteOut)
                    return sourceField - targetField - 18;
                int blackOut = (int)BordLocation.XOut;
                if (sourceField ==blackOut)
                    return targetField + 8 - sourceField;
                int bar = (int)BordLocation.Nowhere;
                if(targetField==bar)
                {
                    if (checkerType == SoldierType.O)
                        return 24 - sourceField;
                    else
                        return sourceField + 1;
                }

                return Math.Abs(targetField - sourceField);


            }
        }
        
        public Move EmptyMove(SoldierType color)
        {
            return new Move(0, 0, color);
        }                

        public bool IsEmpty
        {
            get { return sourceField == 0 && targetField == 0; }
        }

        int IComparable<Move>.CompareTo(Move m)
        {
            if (sourceField > m.sourceField) return 1;
            if (sourceField < m.sourceField) return -1;
            if (targetField > m.targetField) return 1;
            if (targetField < m.targetField) return -1;
            if (checkerType > m.GetChecers) return 1;
            if (checkerType < m.GetChecers) return -1;
            return 0;
        }
        bool IEquatable<Move>.Equals(Move m)
        {
            return
                (this.checkerType == m.checkerType) &&
                (this.sourceField == m.sourceField) &&
                (this.targetField == m.targetField);
        }

        public override int GetHashCode()
        {
            int r = 100 * sourceField + targetField;
            if (checkerType == SoldierType.O) r += 30000;
            else r += 50000;
            return r;
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;

            Move m = obj as Move;
            if (m == null) return false;

            return
                (this.checkerType == m.checkerType) &&
                (this.sourceField == m.sourceField) &&
                (this.targetField == m.targetField);
        }
    }
}
