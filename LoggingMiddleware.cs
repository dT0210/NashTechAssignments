
using System.IO;
using System.Reflection;

namespace CustomMiddleware {
    public class LoggingMiddleware {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            var schema = context.Request.Scheme;
            var host = context.Request.Host;
            var path = context.Request.Path;
            var queryString = context.Request.QueryString;
            var requestBody = await GetRequestBody(context);

            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/logs";
            string dateString = DateTime.Now.ToString("MM-dd-yyyy");
            string timeString = DateTime.Now.ToString("HH:mm:ss");
            string fileName = "Log_" + dateString + ".txt";

            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
            // file data nam trong thu muc bin/Debug/net8.0/logs
            
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(directory, fileName), true)) {
                outputFile.WriteLine(timeString);
                outputFile.WriteLine("schema: " + schema);
                outputFile.WriteLine("host: " + host);
                outputFile.WriteLine("path: " + path);
                outputFile.WriteLine("queryString: " + queryString);
                outputFile.WriteLine("requestBody: " + requestBody);
                outputFile.WriteLine();
            }

            await _next(context);
        }
        public async Task<string> GetRequestBody(HttpContext context) {
            string bodyString;
            using (var bodyStream = new StreamReader(context.Request.Body)) {
                bodyString = await bodyStream.ReadToEndAsync();
            }
            return bodyString;
        }
    }

    public static class LoggingMiddlewareExtentsions {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder) {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}