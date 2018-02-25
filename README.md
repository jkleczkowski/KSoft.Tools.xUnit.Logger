
xUnit Logger
======

#### using:

1. Add refernce to package **KSoft.Tools.xUnit.Logger**
2. Add logger to test class 

```csharp
using KSoft.Tools.xUnit.Logger;
using Xunit;
using Xunit.Abstractions;

public class SomeTestClass
{
  protected ITestOutputHelper output;
  private TestLogger logger;

  public SomeTestClass(ITestOutputHelper output)
  {
    this.output = output;
    logger = new TestLogger(output);
  }


  [Fact]
  public void Test1()
  {
    logger.Info("test");
  }
}
```
