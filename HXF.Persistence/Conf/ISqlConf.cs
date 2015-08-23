using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Conf
{
    public interface ISqlConf
    {
        string GetSql(Statement statement);
    }
}
