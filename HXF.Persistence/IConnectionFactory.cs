using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection(ConnectionInfo conInfo);
        string CreateConnectionString(ConnectionInfo conInfo);
    }
}
