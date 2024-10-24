using RestSharp;
using System.Net;
using System.Text.Json;
using Telchi.Dto.Request.SAP;
using Telchi.Dto.Response;
using Telchi.Dto.Response.SAP_Repository;
using Telchi.Entities.Telchi;

namespace Telchi.Services.Implementations.SAP
{
    public class SAPConnectionService
    {
        #region Propiedades
        private readonly Encryption _encryption;
        #endregion
        #region Constructores
        public SAPConnectionService()
        {
            _encryption = new Encryption();
        }
        #endregion
        #region Metodos
        public async Task<BaseResponseGeneric<CookieCollection>> Login(ConfiguracionSAP configuracionSAP)
        {
            var response = new BaseResponseGeneric<CookieCollection>();

            try
            {
                var loginRequest = new DtoSAPRequestLogin();
                loginRequest.CompanyDB = configuracionSAP.Schema;
                loginRequest.UserName = configuracionSAP.UserName;
                loginRequest.Password = _encryption.Decrypt(configuracionSAP.Password)!;
                loginRequest.Language = "25";

                var options = new RestClientOptions(configuracionSAP.ServiceLayerUrl + "Login")
                {
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
                    CookieContainer = new CookieContainer()
                };

                var client = new RestClient(options);

                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddJsonBody(JsonSerializer.Serialize(loginRequest));

                var restResponse = await client.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    if (restResponse.Cookies != null)
                    {
                        response.Success = true;
                        response.Result = restResponse.Cookies;
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
                            response.Error = new ErrorResponse();
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
        public async Task<BaseResponse> Logout(string url, CookieCollection cookieCollection)
        {
            var response = new BaseResponse();

            try
            {
                CookieContainer cookieContainer = new CookieContainer();

                foreach (Cookie cookie in cookieCollection)
                {
                    cookieContainer.Add(cookie);
                }

                var options = new RestClientOptions(url + "Logout")
                {
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
                    CookieContainer = cookieContainer
                };

                var client = new RestClient(options);

                var request = new RestRequest();
                request.Method = Method.Post;

                var restResponse = await client.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
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
        #endregion
    }
}