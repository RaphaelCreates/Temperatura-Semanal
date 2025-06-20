var builder = WebApplication.CreateBuilder(args);

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