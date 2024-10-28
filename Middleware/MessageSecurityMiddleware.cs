using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Text;

public class MessageSecurityMiddleware
{
    private readonly RequestDelegate _next;
    public MessageSecurityMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Decrypt incoming messages
        if (context.Request.Method == HttpMethods.Post)
        {
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var decryptedMessage = DecryptMessage(body);
            context.Items["DecryptedMessage"] = decryptedMessage;
        }

        await _next(context);

        // Encrypt outgoing messages
        if (context.Response.StatusCode == StatusCodes.Status200OK)
        {
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                await _next(context);
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseMessage = await new StreamReader(context.Response.Body).ReadToEndAsync();
                var EncryptedMessage = EncryptMessage(responseMessage);
                await context.Response.WriteAsync(EncryptedMessage);
                context.Response.Body.Seek(0, SeekOrigin.Begin);
            }
        }
    }

    private string EncryptMessage(string message)
    {
        // Implement encryption logic here
    }
    private string DecryptMessage(string message)
    {
        // Implement decryption logic here
    }
}