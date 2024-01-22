using GalaxySoftwareCRM.Shared;
using GalaxySoftwareCRM.Shared.Models;
using Microsoft.AspNetCore.Components;
using NpgsqlTypes;
using System;
using System.Text.Json;

namespace GalaxySoftwareCRM.Client.Services

{
    public class CustomerService 
    {
        private readonly IDataService service;

        public CustomerService(IDataService _service)
        {
            service = _service;
        }

        public async Task<IEnumerable<Township>> GetTownshipSource(int recordcount = 0)
        {
            IEnumerable<Township> TownshipSource;
            List<ParameterHelper>? parameters = new()
            {
            new ParameterHelper{ PsqlDbTypes = NpgsqlDbType.Integer, PsqlParameterName = "_townshipid", PsqlParameterValue = -9, PsqlParameterDirection = System.Data.ParameterDirection.Input}
            };

            ApiHelper apiHelper = new ApiHelper { IsStoredProcedure = true, StoredProcedureName = "usp_gettownshipinfo", Parameters = parameters, SqlExecutionType = SqlExecutionTypes.ExecuteResult };

            TownshipSource = await service.GetDataByProcedure<Township>(apiHelper);

            return TownshipSource.Take(recordcount == 0 ? int.MaxValue : recordcount);
        }

        public async Task<IEnumerable<CustomerGroup>> GetCustomerGroupSource()
        {
            dynamic CustomerGroupSource;
            List<ParameterHelper>? parameters = new()
            {
            new ParameterHelper{ PsqlDbTypes = NpgsqlDbType.Integer, PsqlParameterName = "_custgroupid", PsqlParameterValue = -9, PsqlParameterDirection = System.Data.ParameterDirection.Input}
            };

            ApiHelper apiHelper = new ApiHelper { IsStoredProcedure = true, StoredProcedureName = "usp_getcustomergroupinfo", Parameters = parameters, SqlExecutionType = SqlExecutionTypes.ExecuteResult };

            CustomerGroupSource = await service.GetDataByProcedure<CustomerGroup>(apiHelper);

            return CustomerGroupSource;
        }

        public async Task<int?> Save(List<Customer> _customer)
        {
            string? _JsonCustomer;

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            /*Here, we use System.Text.Json For Only Reason for Non-blocking Async 
             */
            _JsonCustomer = System.Text.Json.JsonSerializer.Serialize(_customer,jsonSerializerOptions);


            List<ParameterHelper>? parameters = new()
            {
            new ParameterHelper{ PsqlDbTypes = NpgsqlDbType.Json, PsqlParameterName = "_jsondata", PsqlParameterValue = _JsonCustomer, PsqlParameterDirection = System.Data.ParameterDirection.Input}
            };

            ApiHelper apiHelper = new ApiHelper { IsStoredProcedure = true, StoredProcedureName = "usp_savecustomer", Parameters = parameters, SqlExecutionType = SqlExecutionTypes.ExecuteOnly };

            var result = await service.SetDataByProcedure<int?>(apiHelper);

            return result;
        }
    }
}
