using Payeh.ApplicationService.Common;

namespace Payeh.ApplicationService.Queries
{
    public sealed class QueryResult<TData> : ApplicationServiceResult
    {
        internal TData _data;
        public TData Data
        {
            get
            {
                return _data;
            }
        }
    }
}
