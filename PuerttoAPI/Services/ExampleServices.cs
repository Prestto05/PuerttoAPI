using AutoMapper;
using Core.Puertto;
using Core.Puertto.Exceptions;
using Infrastructure.Context.General;
using Infrastructure.Context.Security;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Repositories.GeneralRepository;
using PuerttoAPI.Interfaces;
using System.Net;

namespace PuerttoAPI.Services
{
    public class ExampleServices : IExample
    {
        private readonly IMapper _mapper;
        private readonly IExaampleRepository _exaampleRepository;
        //private readonly Func<GeneralContext> _contextGeneralFactory;

        public ExampleServices(IConfiguration configuration, IMapper mapper, IExaampleRepository exaampleRepository)
        {
            _mapper = mapper;
            _exaampleRepository = exaampleRepository;
            //_contextGeneralFactory = contextGeneralFactory;
           // _contextSecurityContext = contextSecurityContext;

        }

        public async Task<List<Example>> All()
        {
            try
            {
                var x = await _exaampleRepository.Reaad();
                var reponse = _mapper.Map<List<Example>>(x);
                return reponse;
            }
            catch (Exception ex)
            {
                var friendlyMessage = "Lamentamos los inconvenientes, por favor intente de nuevo.";
                var httpStatusCode = (int)HttpStatusCode.InternalServerError;
                throw new HttpException(ex.Message, friendlyMessage, httpStatusCode, ex.InnerException);
            }
        }

        public async Task SaveDataExample(Example example)
        {
            var exampleEntityi = new ExampleEntity();
            //using IUnitOfWork<GeneralContext> unitOfWork = new UnitOfWork<GeneralContext>(_contextGeneralFactory);
            try
            {
                
                var exam = _mapper.Map<ExampleEntity>(example);
                var x = _exaampleRepository.Insert(exampleEntityi).ConfigureAwait(false);
                //var x = (await unitOfWork.Repository<IExaampleRepository, ExampleRepository>()
                //       .AddAsync(exam)
                //       .ConfigureAwait(true));

                //unitOfWork.Commit();
            }
            catch (Exception ex)
            {                
                var friendlyMessage = "Lamentamos los inconvenientes, por favor intente de nuevo.";
                var httpStatusCode = (int)HttpStatusCode.InternalServerError;
                throw new HttpException(ex.Message, friendlyMessage, httpStatusCode, ex.InnerException);
            }
        }
    }
}
