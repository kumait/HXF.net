using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HXF.Util.Operations
{
    public class NullOperation: Operation
    {
        private int waitTime;
        private bool shouldSucceed;

        public NullOperation(string name, int waitTime, bool shouldSucceed = true)
        {
            this.Name = name;
            this.waitTime = waitTime;
            this.shouldSucceed = shouldSucceed;
        }

        public override void Execute(IDictionary<string, object> scope)
        {
            this.Status = OperationStatus.RUNNING;
            Thread.Sleep(this.waitTime);
            if (shouldSucceed)
            {
                this.Status = OperationStatus.COMPLETED;
            }
            else
            {
                this.Exception = new Exception("Operation Failed");
                this.Status = OperationStatus.FAILED;
               
                throw this.Exception;
            }
            
        }

        public override void Clean(IDictionary<string, object> scope)
        {
            
        }
    }
}
