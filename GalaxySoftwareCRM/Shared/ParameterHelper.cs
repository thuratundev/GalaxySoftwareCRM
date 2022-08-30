using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySoftwareCRM.Shared
{
    public class ParameterHelper
    {
        public string? PsqlParameterName { get; set; }
        public NpgsqlDbType PsqlDbTypes { get; set; }
        public ParameterDirection PsqlParameterDirection { get; set; }
        public dynamic? PsqlParameterValue { get; set; }
    }
}
