using Microsoft.OpenApi.Models;

namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// Classe para configuração da documentação do Swagger
    /// </summary>
    public static class SwaggerConfiguretions
    {
        /// <summary>
        /// Configurar o conteudo da documentação do Swagger
        /// </summary>
        public static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para controle de empresas",
                    Description = "Projeo desenvolvido em NET¨API com EntityFramework sqlServer",
                    Contact = new OpenApiContact
                    {
                        Name = "Romulo Correa",
                        Url = new Uri("http://www.cotiinformatica.com.br"),
                        Email = "romuloc4444@gmail.com"
                    }
                });
            });
        }
    }
}
