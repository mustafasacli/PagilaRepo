using SI.Query.Core;

namespace Pagila.Query.Staff
{
    public class StaffReadAllQuery : IQuery<StaffList>
    {
        public StaffReadAllQuery()
        {
        }

        public static StaffReadAllQuery GetEmptyInstance()
        {
            return new StaffReadAllQuery();
        }
    }
}