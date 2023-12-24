# FibonacciCalculationApi
Simple ASP.NET web API for fibonacci seq calculation with RabbitMq (i.e. after calculation result will be sended in rabbitmq queue, where second app will read it).

Required user secrets file to run (https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows#secret-manager). It should have following structure: "
"RabbitMQ": {
  "NodeIp": "",
  "Port": ,
  "UserName": "",
  "Password": ""
}
"

How it works:
https://github.com/akella44/FibonacciCalculationApi/assets/61851015/f9d1a717-0eb5-41ed-b26a-96d7ded3b6a9

