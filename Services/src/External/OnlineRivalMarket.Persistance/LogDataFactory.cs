using Newtonsoft.Json;
using OnlineRivalMarket.Application.Services.LogService;

namespace OnlineRivalMarket.Persistance
{
    public class LogDataFactory<T> : ILogDataFactory<T>
    {
        public Logs CreateLogData(T data, string userId, string tableName, string progress)
        {
            return new Logs
            {
                Id = Guid.NewGuid().ToString(),
                TableName = tableName,
                Progress = progress,
                UserId = userId,
                Data = JsonConvert.SerializeObject(data)
            };
        }

    }
    }
