namespace Miniskr.Libraries.Cache.Redis
{
    public class RedisOptions
    {
        public string ConnectString { get; set; } = "localhost:6379";
        public string InstanceName { get; set; } = "miniskr_";
    }
}
