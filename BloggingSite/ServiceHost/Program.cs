#region using
using _0_Framework.Application;
using BlogManagement.Configuration;
using ServiceHost;
using System.Text.Encodings.Web;
using System.Text.Unicode;
#endregion

#region builder
var builder = WebApplication.CreateBuilder(args);
#endregion

#region connection string
var connectionString = builder.Configuration.GetConnectionString("BloggingSiteDb");
BlogManagementBoostrapper.Configure(builder.Services, connectionString);
#endregion

#region add services
builder.Services.AddTransient<IFileUploader, FileUploader>();

builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
#endregion

#region middleware 
builder.Services.AddRazorPages();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
#endregion