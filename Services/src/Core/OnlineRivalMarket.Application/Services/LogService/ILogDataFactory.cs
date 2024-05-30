using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Services.LogService
{
    public interface ILogDataFactory<T>
    {
        Logs CreateLogData(T data, string userId, string tableName, string progress);
    }

}
