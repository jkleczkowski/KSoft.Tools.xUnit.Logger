using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xunit.Abstractions;

namespace KSoft.Tools.xUnit.Logger
{
    public class TestLogger
    {
        private readonly ITestOutputHelper output;

        public TestLogger(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Error(Exception ex, [System.Runtime.CompilerServices.CallerMemberName]string module = "")
        {
            this.Error(ex, null, module);
        }

        public void Error(string text, [System.Runtime.CompilerServices.CallerMemberName]string module = "")
        {
            this.Error(null, text, module);
        }

        public void Error(Exception ex, string text, [System.Runtime.CompilerServices.CallerMemberName]string module = "")
        {
            this.output.WriteLine($"[E]({module}) {text}:\n {ex}");
        }

        public void ErrorWithData(Exception ex, string text,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0
        )
        {
            this.output.WriteLine($"[E]({memberName}:Line {sourceLineNumber}:{sourceFilePath}) {text}:\n {ex}");
        }

        public void Info(string text, [System.Runtime.CompilerServices.CallerMemberName]string module = "")
        {
            this.output.WriteLine($"[I]({module}) {text}");
        }

        public void Verbose(string text, object toJsonInLog, [System.Runtime.CompilerServices.CallerMemberName]string module = "")
        {
            string sJsonText = JsonConvert.SerializeObject(toJsonInLog, JsonSettings());
            this.Verbose(text + sJsonText, module);
        }


        public void Verbose(string text, [System.Runtime.CompilerServices.CallerMemberName]string module="")
        {
            this.output.WriteLine($"[V]({module}) {text}");
        }
        public static JsonSerializerSettings JsonSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            settings.Converters.Add(new StringEnumConverter());

            return settings;
        }
    }
}