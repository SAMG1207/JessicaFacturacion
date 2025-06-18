namespace JessicaFacturacion.Middlewares
{
    public class SessionMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context) 
        {
            var path = context.Request.Path.ToString().ToLower();

            if (path.Contains("/login"))
            {
                await _next(context);
                return;
            }

            var sessionActiva = context.Session.GetString("Jessica_Luengo_Alcibar");
            if (string.IsNullOrEmpty(sessionActiva))
            {
                context.Response.Redirect("/Home/Login");
                return;
            }

            await _next(context);
        }
    }
}
