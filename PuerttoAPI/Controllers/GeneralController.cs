using Core.Puertto.DTOs.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuerttoAPI.Interfaces;

namespace PuerttoAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("puertto/general")]
    //[Authorize]
    public class GeneralController : ControllerBase
    {

        private readonly IGeneralServices _generalServices;
        public GeneralController(IGeneralServices generalServices)
        {
            _generalServices = generalServices;
        }

        /// <summary>
        /// Recuperar img para el banner inicial dependiendo del contexto de inicio de session
        /// </summary>
        /// <param name="isSingIn"></param>
        /// <returns></returns>
        [HttpGet("bannerindex")]
        public async Task<List<BannerIndex>> RetrieveBannerIndexAsyn(bool isSingIn)
        {
            return await _generalServices.GetBannerByIndex(isSingIn).ConfigureAwait(true);
        }

        
        [HttpGet("bannercruzindex")]
        public async Task<List<BannerIndex>> RetrieveBannerCruzIndexAsyn()
        {
            return await _generalServices.GetBannerCruzIndex().ConfigureAwait(true);
        }
    }

}
