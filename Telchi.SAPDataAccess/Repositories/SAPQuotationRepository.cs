using RestSharp;
using System.Net;
using System.Text.Json;
using Telchi.Dto.Request.SAP;
using Telchi.Dto.Response;
using Telchi.Dto.Response.SAP_Repository;
using Telchi.Entities.SAP;
using Telchi.SAPDataAccess.Interfaces;

namespace Telchi.SAPDataAccess.Repositories
{
    public class SAPQuotationRepository : ISAPQuotationRepository
    {
        #region Metodos
        public async Task<BaseResponseGeneric<int>> Add(string _url, CookieCollection cookieCollection, SAPQuotation quotation)
        {
            var response = new BaseResponseGeneric<int>();

            try
            {
                CookieContainer cookieContainer = new CookieContainer();

                foreach (Cookie cookie in cookieCollection)
                {
                    cookieContainer.Add(cookie);
                }

                var options = new RestClientOptions(_url + "Quotations")
                {
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
                    CookieContainer = cookieContainer
                };

                var client = new RestClient(options);

                var restRequest = new RestRequest();
                restRequest.Method = Method.Post;
                restRequest.AddJsonBody(JsonSerializer.Serialize(quotation));

                var restResponse = await client.ExecuteAsync(restRequest);

                if (restResponse.StatusCode == HttpStatusCode.Created)
                {
                    if (restResponse.Content != null)
                    {
                        var jsonObject = JsonSerializer.Deserialize<DtoSAPRepositoryResponseQuotation>(restResponse.Content);

                        if (jsonObject != null)
                        {
                            response.Success = true;
                            response.Result = jsonObject.DocEntry;
                        }
                        else
                        {
                            response.Success = false;
                            response.Error.Code = -1;
                            response.Error.Message = "";
                        }
                    }
                    else
                    {
                        string errorMessage = "";

                        if (restResponse.ErrorMessage != null)
                        {
                            errorMessage = restResponse.ErrorMessage;
                        }

                        response.Success = false;
                        response.Error.Code = -1;
                        response.Error.Message = errorMessage;
                    }
                }
                else
                {
                    response.Success = false;

                    if (restResponse.Content != null)
                    {
                        var jsonObject = JsonSerializer.Deserialize<SAPRepositoryErrorResponse>(restResponse.Content);

                        if (jsonObject != null)
                        {
                            response.Error.Code = jsonObject.Error.Code;
                            response.Error.Message = jsonObject.Error.Message.Value;
                        }
                        else
                        {
                            response.Error.Code = -1;
                            response.Error.Message = "";
                        }
                    }
                    else
                    {
                        string errorMessage = "";

                        if (restResponse.ErrorMessage != null)
                        {
                            errorMessage = restResponse.ErrorMessage;
                        }

                        response.Error.Code = -1;
                        response.Error.Message = errorMessage;
                    }
                }
            }
            catch (Exception exception)
            {
                response.Success = false;
                response.Error.Code = -1;
                response.Error.Message = exception.Message;
            }

            return response;
        }
        public async Task<BaseResponse> Cancel(string _url, CookieCollection cookieCollection, int docEntry)
        {
            var response = new BaseResponse();

            try
            {
                CookieContainer cookieContainer = new CookieContainer();

                foreach (Cookie cookie in cookieCollection)
                {
                    cookieContainer.Add(cookie);
                }

                var options = new RestClientOptions(_url + "Quotations(" + docEntry + ")/Cancel")
                {
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
                    CookieContainer = cookieContainer
                };

                var client = new RestClient(options);

                var restRequest = new RestRequest();
                restRequest.Method = Method.Post;

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
                            response.Error.Message = jsonObject.Error.Message.Value;
                        }
                        else
                        {
                            response.Error = new ErrorResponse();
                            response.Error.Code = -1;
                            response.Error.Message = "";
                        }
                    }
                    else
                    {
                        response.Error = new ErrorResponse();
                        response.Error.Code = -1;

                        if (restResponse.ErrorMessage != null)
                        {
                            response.Error.Message = restResponse.ErrorMessage;
                        }
                        else
                        {
                            response.Error.Message = "";
                        }
                    }
                }
            }
            catch(Exception exception)
            {
                response.Success = false;

                response.Error = new ErrorResponse();
                response.Error.Code = -1;
                response.Error.Message = exception.Message;
            }

            return response;
        }
        #endregion
    }
}