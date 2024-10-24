using Microsoft.AspNetCore.Mvc;
using Telchi.Dto.Request.SAP;
using Telchi.Dto.Response;
using Telchi.Entities;
using Telchi.Services.Interfaces.SAP;

namespace Telchi.API.Controllers.SAP
{
    [Route(Constants.SAPDefaultRoute)]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        #region Propiedades
        private readonly ISAPQuotationService _service;
        #endregion
        #region Constructores
        public QuotationController(ISAPQuotationService service)
        {
            _service = service;
        }
        #endregion
        #region Metodos
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseGeneric<ICollection<int>>), 200)]
        [ProducesResponseType(typeof(BaseResponseGeneric<ICollection<int>>), 400)]
        public async Task<IActionResult> Add(DtoSAPRequestQuotationCollection request)
        {
            var response = await _service.Add(request);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("Cancel/{docEntry}")]
        [ProducesResponseType(typeof(BaseResponse), 200)]
        [ProducesResponseType(typeof(BaseResponse), 400)]
        public async Task<IActionResult> Cancel(int docEntry)
        {
            var response = await _service.Cancel(docEntry);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        #endregion
    }
}