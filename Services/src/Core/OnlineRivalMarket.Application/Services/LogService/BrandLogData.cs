namespace OnlineRivalMarket.Application.Services.LogService;
public static class BrandLogData<T>
{

    public static Logs CreateLogData(T data, string userId, string tableName, string progress)
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
