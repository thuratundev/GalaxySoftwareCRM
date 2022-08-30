using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySoftwareCRM.Shared
{
    public class ApiHelper
    {
        public bool IsStoredProcedure { get; set; }
        public string? SqlQuery { get; set; }
        public string? StoredProcedureName { get; set; }
        public List<ParameterHelper>? Parameters { get; set; }
        public SqlExecutionTypes SqlExecutionType { get; set; }
    }

    public enum SqlExecutionTypes
    {
        ExecuteOnly = 0,
        ExecuteOutput,
        ExecuteResult
    }

}
