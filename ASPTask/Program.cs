using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();


app.MapGet("/", async context => {
    Console.WriteLine(context.Connection.RemoteIpAddress);

    foreach(var header in context.Request.Headers){
        Console.WriteLine($"{header.Key} {header.Value}");
    };

    await context.Response.WriteAsync(
    "<h1>Hello</h2>" +
    "<p>This is my first ASP.NET Core project</p>" +
    "<button onclick=\"window.location.href ='https://localhost:7115/time.html';\"><b>Here you can get the current time</b></button>" +
    "<button onclick=\"window.location.href ='https://localhost:7115/date.html';\"><b>Here you can get the current date</b></button>");
});

app.Run();
