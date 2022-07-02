using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Staff
{
    public class StaffList : IQueryResult
    {
        public List<StaffViewModel> Staffs
        { get; set; }
    }
}