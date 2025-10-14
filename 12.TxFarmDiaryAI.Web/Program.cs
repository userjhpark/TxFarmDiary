using TxFarmDiaryAI.Web.Components;
using TxFarmDiaryAI.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    ;

builder.Services.AddDevExpressBlazor(options =>
{
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});
builder.Services.AddMvc();
builder.Services.AddScoped<DxThemesService>();


// 뷰(View)와 함께 사용한다면 AddControllersWithViews()
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // JSON의 프로퍼티 네이밍 정책을 null로 설정
    //(지정된 이름 그대로, 카멜표기범 사용 안함)
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AllowAnonymous();

//등록된 컨트롤러로 요청을 매핑
app.MapControllers();

app.Run();