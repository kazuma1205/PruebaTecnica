using PruebaTecnica.Data;
using System.Text;

public class ValidateUser
{
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _serviceProvider;

    public ValidateUser(RequestDelegate next, IServiceProvider serviceProvider)
    {
        _next = next;
        _serviceProvider = serviceProvider;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.StatusCode = 401; // No autorizado
            context.Response.Headers.Add("WWW-Authenticate", "Basic");
            await context.Response.WriteAsync("Authorization header missing.");
            return;
        }

        var authHeader = context.Request.Headers["Authorization"].ToString();
        if (authHeader.StartsWith("Basic "))
        {
            var encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials)).Split(':');

            var username = credentials[0];
            var password = credentials[1];

            // Crear un scope para resolver los servicios Scoped
            using (var scope = _serviceProvider.CreateScope())
            {
                var userService = scope.ServiceProvider.GetRequiredService<UsuariosServices>();

                if (await userService.ValidateCredentialsAsync(username, password))
                {
                    // Almacenar el usuario autenticado en el contexto
                    context.Items["User"] = username;  // O almacenar más datos si lo deseas
                    await _next(context);
                    return;
                }
            }
        }

        context.Response.StatusCode = 401; // No autorizado
        context.Response.Headers.Add("WWW-Authenticate", "Basic");
        await context.Response.WriteAsync("Invalid credentials.");
    }
}
