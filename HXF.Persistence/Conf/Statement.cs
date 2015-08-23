using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXF.Persistence.Conf
{
    public enum Statement
    {
        GET_CATALOGS,
        GET_SCHEMAS,
        GET_TABLES,  
        GET_TABLE_COLUMNS,
        GET_TABLE_CONSTRAINTS,
        GET_CONSTRAINT_COLUMNS,
        GET_FK_CONSTRAINT,
        GET_CHECK_CLAUSE,
        GET_STORED_PROCEDURES,
        GET_STORED_PROCEDURE_PARAMETERS
    }
}
