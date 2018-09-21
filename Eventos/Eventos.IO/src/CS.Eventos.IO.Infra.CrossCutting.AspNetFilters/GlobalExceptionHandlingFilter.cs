using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;


namespace CS.Eventos.IO.Infra.CrossCutting.AspNetFilters
{
    public class GlobalExceptionHandlingFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionHandlingFilter> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        public GlobalExceptionHandlingFilter(ILogger<GlobalExceptionHandlingFilter> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        //VALIDA QUE TIPO DE ERRO ACONTECEU
        //AÇÕES: ENVIAR E-MAIL, QUAL PÁGINA DEVE SER REDIRECIONADA...

        public void OnException(ExceptionContext context)
        {
            if (!_hostingEnvironment.IsDevelopment())
            {
                _logger.LogError(1, context.Exception, context.Exception.Message);
                return;
            }

            _logger.LogError(1, context.Exception, context.Exception.Message);

            //Redireciona a para a pagina de erro
            var result = new Microsoft.AspNetCore.Mvc.ViewResult() { ViewName = "Error" };
            var modelData = new EmptyModelMetadataProvider();
            result.ViewData = new ViewDataDictionary(modelData, context.ModelState)
            {
                {"MensagemErro", context.Exception.Message}
            };

            context.ExceptionHandled = true; //diz que foi tratada para não registrar nos logs do Windows, "pesando a aplicação"
            context.Result = result;

        }
    }
}
