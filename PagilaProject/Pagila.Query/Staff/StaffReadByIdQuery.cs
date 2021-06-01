using SI.Query.Core;

namespace Pagila.Query.Staff
{
    public class StaffReadByIdQuery : IQuery<StaffResult>
    {
        public int? Id
        { get; set; }
    }
}