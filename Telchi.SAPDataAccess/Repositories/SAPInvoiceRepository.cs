using RestSharp;
using System.Net;
using System.Text.Json;
using Telchi.Dto.Response.SAP_Repository;
using Telchi.Dto.Response;
using Telchi.Entities.SAP;
using Telchi.SAPDataAccess.Interfaces;

namespace Telchi.SAPDataAccess.Repositories
{
    public class SAPInvoiceRepository : ISAPInvoiceRepository
    {
        #region Metodos
        public async Task<BaseResponse> Update(string _url, CookieCollection cookieCollection, SAPInvoice invoice)
        {
            var response = new BaseResponse();

            try
            {
                CookieContainer cookieContainer = new CookieContainer();

                foreach (Cookie cookie in cookieCollection)
                {
                    cookieContainer.Add(cookie);
                }

                var options = new RestClientOptions(_url + "Invoices(" + invoice.DocEntry + ")")
                {
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
                    CookieContainer = cookieContainer
                };

                var client = new RestClient(options);

                var restRequest = new RestRequest();
                restRequest.Method = Method.Patch;
                restRequest.AddJsonBody(JsonSerializer.Serialize(invoice));

                var restResponse = await client.ExecuteAsync(restRequest);

                if (restResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;

                    if (restResponse.Content != null)
                    {
                        var jsonObject = JsonSerializer.Deserialize<SAPRepositoryErrorResponse>(restResponse.Content);

                        if (jsonObject != null)
                        {
                            response.Error = new ErrorResponse();
                            response.Error.Code = jsonObject.Error.Code;
                            response.Error.Message = "Nº Interno: " + invoice.DocEntry + " - " + jsonObject.Error.Message.Value;
                        }
                        else
                        {
                            response.Error = new ErrorResponse();
                            response.Error.Code = -1;
                            response.Error.Message = "Nº Interno: " + invoice.DocEntry;
                        }
                    }
                    else
                    {
                        response.Error = new ErrorResponse();
                        response.Error.Code = -1;

                        if (restResponse.ErrorMessage != null)
                        {
                            response.Error.Message = "Nº Interno: " + invoice.DocEntry + " - " + restResponse.ErrorMessage;
                        }
                        else
                        {
                            response.Error.Message = "Nº Interno: " + invoice.DocEntry;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                response.Success = false;

                response.Error = new ErrorResponse();
                response.Error.Code = -1;
                response.Error.Message = "Nº Interno: " + invoice.DocEntry + " - " + exception.Message;
            }

            return response;
        }
        #endregion
    }
}