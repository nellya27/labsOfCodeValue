using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonLogic
{
    public class MoveChecker
    {
        public enum ResultType
        {
            Positive,
            Negative
        }

        public ResultType CheckResult { get; private set; }
        public string Description { get; private set; }

        public MoveChecker(ResultType result,string des)
        {
            CheckResult = result;
            Description = des;
        }

    }
}
