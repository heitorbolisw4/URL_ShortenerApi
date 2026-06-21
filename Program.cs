using URL_ShortnetApi.Data;
using URL_ShortnetApi.Dto;
using URL_ShortnetApi.Service;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapPost("shorten", async (ShortenUrlRequest request,
    UrlShorteningService service,
    AppDbContext db, HttpContext httpContext) =>
{
    if(!Uri.TryCreate(request.Url, UriKind.Absolute, out _))
    {
        return Results.BadRequest("The specified URL is invalid");
    }

    var code = await service.GenerateUniqueCode();
    var request = httpContext.Request;
});

app.Run();
