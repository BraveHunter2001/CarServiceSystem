using DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;
public interface IMasterRepository
{
    Dictionary<Master, int> GetPercentageOfMasterWorkload(DateTime startDate, DateTime endDate);
}
internal class MasterRepository(CarServiceSystemContext context) : IMasterRepository
{
    public Dictionary<Master, int> GetPercentageOfMasterWorkload(DateTime startDate, DateTime endDate)
    {
        var workRecordsQuery = context.WorkRecords
            .Include(w=>w.Master)
            .Where(w => w.RepairDate >= startDate && w.RepairDate <= endDate);

        float workRecordsCount = (float) workRecordsQuery.Count();

        var masters = workRecordsQuery.GroupBy(w => w.Master!)
            .ToDictionary(
                k => k.Key,
                v => (int) (MathF.Round(v.Count() / workRecordsCount, 2) * 100)
            );

        return masters;
    }
}
