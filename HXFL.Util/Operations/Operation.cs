using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Util.Operations
{
    public abstract class Operation: IOperation
    {
        private string name;
        private Exception exception;
        private OperationStatus status;

        public event Action<IOperation> StatusChanged;


        public string Name
        {
            get { return name; }
            protected set
            {
                this.name = value;
            }
        }

        public OperationStatus Status
        {
            get { return status; }
            protected set
            {
                this.status = value;
                if (this.StatusChanged != null)
                {
                    this.StatusChanged(this);
                }
                
            }
        }

        public Exception Exception
        {
            get { return exception; }
            protected set
            {
                this.exception = value;
            }
        }

        public abstract void Execute(IDictionary<string, object> scope);
        public abstract void Clean(IDictionary<string, object> scope);
    }
}
