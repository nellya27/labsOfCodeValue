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

        private readonly ResultType checkResult;
        private readonly string description;

        public MoveChecker(ResultType result,string des)
        {
            checkResult = result;
            description = des;
        }

        public ResultType GetCheckResult
        {
            get { return checkResult; }
        }

        public string GetDescription
        {
            get { return description; }
        }

    }
}
