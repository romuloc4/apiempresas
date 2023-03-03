namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// Classe de Configuração do AutoMapper
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Método para configuração do uso do automaper
        /// </summary>
        public static void AddAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
