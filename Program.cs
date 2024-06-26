using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddSingleton<FileWatcherService>(provider =>
{
  var userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
  var defaultFilePath = Path.Combine(userProfilePath, "AppData", "LocalLow", "Skirmish Mode Games, Inc", "BeyondATC", "Player.log");
  var logFileLocationPath = Path.Combine(userProfilePath, "logfile_location.txt");
  var filePath = File.Exists(logFileLocationPath) ? File.ReadAllText(logFileLocationPath) : defaultFilePath;
  var lastLineFilePath = Path.Combine(Path.GetTempPath(), "lastline.txt");
  var hubContext = provider.GetRequiredService<IHubContext<MyHub>>();
  return new FileWatcherService(hubContext, filePath, lastLineFilePath, true);
});

var fileProvider = new ManifestEmbeddedFileProvider(Assembly.GetAssembly(type: typeof(Program))!, "wwwroot");
var app = builder.Build();
app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = fileProvider,
  RequestPath = string.Empty,
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapHub<MyHub>("/hub");

app.MapGet("/lastline", async context =>
{
  var lastLineFilePath = Path.Combine(Path.GetTempPath(), "lastline.txt");
  if (File.Exists(lastLineFilePath))
  {
    var lastLine = await File.ReadAllTextAsync(lastLineFilePath);
    await context.Response.WriteAsync(lastLine);
  }
  else
  {
    context.Response.StatusCode = 404;
  }
});

// Start the file watcher service
var fileWatcherService = app.Services.GetRequiredService<FileWatcherService>();

Console.WriteLine("------------------------------------------------------------------");
Console.WriteLine("Welcome to fearlessfrog's AtcLogWatcher! v0.3.0");
Console.WriteLine("Listening on: http://localhost:41716");
Console.WriteLine("See filters.txt for the list of filters to exclude.");
Console.WriteLine("Press Ctrl+C to exit.");
Console.WriteLine("------------------------------------------------------------------");

app.Run();
