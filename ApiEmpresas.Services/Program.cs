using ApiEmpresas.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

//Confiurando os controllers da aplica��o
builder.Services.AddControllers();

//Adicionar a vconfigura��o do Swagger
SwaggerConfiguretions.AddSwagger(builder);

//adicionando a configura�a� do EntityFramework
EntityFrameworkConfiguration.AddEntityFramework(builder);

//Adicionando a configura��o do AutoMapper
AutoMapperConfiguration.AddAutoMapper(builder);

//Adcionando a configura��o do JWT
JwtConfiguration.AddJwt(builder);

builder.Services.AddCors(s => s.AddPolicy("DefaultPolicy", builder => {
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

// Add services to the container.
var app = builder.Build();

//Habilitar as rotas e andpoints da API
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//Configurando o descritor da API 
app.UseSwagger();
app.UseSwaggerUI(S =>
{
    S.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI");
});

app.UseCors("DefaultPolicy");

//Executer os servi�os
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();