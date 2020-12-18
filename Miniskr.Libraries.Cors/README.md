### 配置 Cors 使用方法

application.json 配置：

```json
"cors": {
  "allowAnyHeader": true,
  "allowAnyMethod": true,
  "allowAnyOrigin": false,
  "allowCredentials": false,
  "origins": [],
  "headers":[],
  "methods": ["GET", "POST", "PUT", "PATCH", "DELETE", "OPTIONS", "HEAD" ]
}
```

ServiceCollection 配置:

```CSharp
services.AddConfigurableCors(option => this.Configure.GetSection("cors").bind(option));
```

Application 配置：

```CSharp
app.UseConfigurableCors();
```
