using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
    string prompt;

    do
    {
        Console.WriteLine("What would you like to search?");
        prompt = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(prompt))
        {
            string search = $"https://letmegooglethat.com/?q={Uri.EscapeDataString(prompt)}";
            context.Response.Redirect(search);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Please enter a valid search term. \n");
        }
    }
    while (string.IsNullOrWhiteSpace(prompt));

});

app.Run();
