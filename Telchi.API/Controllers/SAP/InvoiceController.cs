using Microsoft.AspNetCore.Mvc;
using Telchi.Dto.Request.SAP;
using Telchi.Dto.Response;
using Telchi.Entities;
using Telchi.Services.Interfaces.SAP;

namespace Telchi.API.Controllers.SAP
{
    [Route(Constants.SAPDefaultRoute)]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        #region Propiedades
        private readonly ISAPInvoiceService _service;
        #endregion
        #region Constructores
        public InvoiceController(ISAPInvoiceService service)
        {
            _service = service;
        }
        #endregion
        #region Metodos
        [HttpPatch]
        [ProducesResponseType(typeof(BaseResponseCollection), 200)]
        [ProducesResponseType(typeof(BaseResponseCollection), 400)]
        public async Task<IActionResult> Update(DtoSAPRequestInvoiceCollection request)
        {
            var response = await _service.Update(request);

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