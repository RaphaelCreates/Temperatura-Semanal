var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UserUrls("hhtp://0.0.0.0:8080"); //configura o host para escutar em todas as interfaces de rede na porta 8080

//configuração de serviços
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500") 
                  .AllowAnyHeader()
                  .WithMethods("GET");
        });
});


var app = builder.Build(); //constroi a aplicação final

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//de http para https
app.UseHttpsRedirection();

app.UseCors("AllowFrontend"); 

app.MapControllers(); 


app.Run();