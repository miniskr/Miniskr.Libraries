### Redis 使用方法

#### application.json 配置：

```json
"redis": {
  "connectString": "locaohost:6379",
  "instanceName": "miniskr_"
}
```

#### service 注册：

```CSharp
serivce.AddRedis(option => this.Configure.GetSection("redis").bind(option));
```

#### 使用：

```CSharp
using Miniskr.Libraries.Cache.Redis;

// 增加redis 值
RedisDistributeExtensions.SetRedisAsync<T>(string recordId, T data, TimeSpan? absoluteExpireTime, TimeSpan? unusedExpireTime)

// 获取redis 值
var t = RedisDistributeExtensions.GetRedisAsync<T>(string recordId);

```
