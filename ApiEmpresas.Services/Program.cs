using ApiEmpresas.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

//Confiurando os controllers da aplicação
builder.Services.AddControllers();

//Adicionar a vconfiguração do Swagger
SwaggerConfiguretions.AddSwagger(builder);

//adicionando a configuraçaõ do EntityFramework
EntityFrameworkConfiguration.AddEntityFramework(builder);

//Adicionando a configuração do AutoMapper
AutoMapperConfiguration.AddAutoMapper(builder);

//Adcionando a configuração do JWT
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

//Executer os serviços
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();