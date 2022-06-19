using Core.Puertto;
using Core.Puertto.Exceptions;
using Infrastructure.Context.General;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using PuerttoAPI.Interfaces;
using System.Net;

namespace PuerttoAPI.Services
{
    public class ExampleServices : IExample
    {
       
        private readonly Func<GeneralContext> _contextGeneralFactory;

        public ExampleServices(IConfiguration configuration, Func<GeneralContext> contextGeneralFactory)
        {
           
            _contextGeneralFactory = contextGeneralFactory;

        }

        public async Task SaveDataExample(Example example)
        {
            using IUnitOfWork<GeneralContext> unitOfWork = new UnitOfWork<GeneralContext>(_contextGeneralFactory);
            try
            {
                unitOfWork.BeginTransaction();

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                var friendlyMessage = "Lamentamos los inconvenientes, por favor intente de nuevo.";
                var httpStatusCode = (int)HttpStatusCode.InternalServerError;
                throw new HttpException(ex.Message, friendlyMessage, httpStatusCode, ex.InnerException);
            }
        }
    }
}
