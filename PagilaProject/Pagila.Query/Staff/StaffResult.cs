using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Staff
{
    public class StaffResult : IQueryResult
    {
        public StaffViewModel Staff
        { get; set; }
    }
}