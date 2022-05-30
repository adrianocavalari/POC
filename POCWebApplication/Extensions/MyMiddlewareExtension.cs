namespace POCWebApplication.Extensions
{
    public static class MyMiddlewareExtension
    {
        public static void AddMyMiddleware(this IServiceCollection services, Action<MyMiddlewareOptions>? options = null)
        {
            if (options == null)
                return;

            services.Configure(options);

            //var myMiddlewareOptions = new MyMiddlewareOptions();
            //options?.Invoke(myMiddlewareOptions);
        }
    }

    public class MyMiddlewareOptions
    {
        public string Test1 { get; set; }

        public string Test2 { get; set; }
    }
}
