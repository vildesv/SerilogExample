// See https://aka.ms/new-console-template for more information
using Serilog;

namespace SerilogExample
{
    class Program
    {
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello, world!");

            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}

/*
    Serilog Example Application
    (https://github.com/serilog/serilog/wiki/Getting-Started)

    The complete example below shows logging in a simple console application, with events sent to the console as well as a date-stamped rolling log file.
    
    Step 1. Create a new Console Application project                                // Made a project called SerilogExample.
    Step 2. Install the core Serilog package and the console sink                   // Packages added using the Package Manager Console. Commands in use: Install-Package Serilog, Install-Package Serilog.Sinks.Console, Install-Package Serilog.Sinks.File
    Step 3. Add the following code to Program.cs                                    // Code added from the tutorial (linked above).
    Step 4. Run the program

*/