using DAL.Entites;
using Microsoft.EntityFrameworkCore;
using WebApi.Requests;

namespace DAL.Repositories;

public interface IAutomobileRepository
{
    Automobile[] GetRepairingAutomobilesByDate(ReportFilter reportRequest);
}

internal class AutomobileRepository(CarServiceSystemContext context) : IAutomobileRepository
{
    public Automobile[] GetRepairingAutomobilesByDate(ReportFilter reportRequest)
    {
        var query = context.Automobiles
            .Include(a => a.WorkRecords!).ThenInclude(w => w.Master)
            .Where(a => a.WorkRecords!
                .Any(w => w.CompletionDate == null
                    && w.RepairDate >= reportRequest.Start
                    && w.RepairDate <= reportRequest.End
                )
            );

        var sorted = reportRequest.SortBy == SortBy.Brand
            ? reportRequest.SortDir == SortDir.Asc 
                ? query.OrderBy(a => a.Brand) 
                : query.OrderByDescending(a => a.Brand)
            : query;

        return sorted.ToArray();
    }
}
