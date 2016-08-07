using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonLogic
{
    public class Move : IComparable<Move>, IEquatable<Move>
    {

        public int sourceField { get; private set; }
        public int targetField { get; private set; }
        public SoldierType checkerType { get; private set; }
        private int Lengh;

        public Move(int newSourceField, int newTargetField, SoldierType type)
        {

            sourceField = newSourceField;
            targetField = newTargetField;
            checkerType = type;
        }       

        public int GetLengh
        {
            get
            {
                int blackOut = (int)BordLocation.XOut;
                int whiteOut = (int)BordLocation.Oout;
                int nowhere = (int)BordLocation.Nowhere;
                if (sourceField==whiteOut)
                    return sourceField - targetField - 18;              
                if (sourceField ==blackOut)
                    return targetField + 8 - sourceField;               
                if(targetField==nowhere)
                {
                    if (checkerType == SoldierType.O)
                        return 24 - sourceField;
                    else
                        return sourceField + 1;
                }

                return Math.Abs(targetField - sourceField);
            }
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
            if (checkerType > m.checkerType) return 1;
            if (checkerType < m.checkerType) return -1;
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
