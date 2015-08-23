using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Util.Operations
{
    public interface IOperation
    {
        string Name { get; }
        OperationStatus Status { get; }
        Exception Exception { get; }

        void Execute(IDictionary<string, object> scope);
        void Clean(IDictionary<string, object> scope);

        event Action<IOperation> StatusChanged;
    }
}
