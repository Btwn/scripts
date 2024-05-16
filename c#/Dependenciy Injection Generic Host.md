My code with Generic Host:

```c#
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddTransient<ITestInterface, TestClass>();
    })
    .Build();

Test();
Console.ReadKey();

void Test()
{
    var testClass = host.Services.GetRequiredService<ITestInterface>();
    testClass.TestMethod();
}
```
versus

```c#
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();
services.AddTransient<ITestInterface, TestClass>();
var servicesProvider = services.BuildServiceProvider();

Test();
Console.ReadKey();

void Test()
{
    var testClass = servicesProvider.GetRequiredService<ITestInterface>();
    testClass.TestMethod();
}
```
