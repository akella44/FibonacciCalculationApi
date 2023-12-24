### Description
Simple ASP.NET web API for fibonacci seq calculation with RabbitMq (i.e. after calculation result will be sended in rabbitmq queue, after that second app will read it).
### Requirements
Required user secrets file to run ([offical doc](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows#secret-manager)). It should have following structure:
```json
{
  "RabbitMQ": {
    "NodeIp": "",
    "Port": ,
    "UserName": "",
    "Password": ""
  }
}
```
### How it works
<video width="1300" height="800" src="https://github.com/akella44/FibonacciCalculationApi/assets/61851015/358c66ed-3dfa-47ea-bbe1-73b04b8d32fb"></video>

