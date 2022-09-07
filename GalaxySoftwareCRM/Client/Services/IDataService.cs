using GalaxySoftwareCRM.Shared;

namespace GalaxySoftwareCRM.Client.Services
{
    public interface IDataService
    {
        Task<IEnumerable<T>> GetDataByProcedure<T>(ApiHelper apiHelper) where T : class;

        Task<T?> SetDataByProcedure<T>(ApiHelper apiHelper);
    }
}