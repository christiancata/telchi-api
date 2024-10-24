namespace Telchi.Dto.Response
{
    public class BaseResponse
    {
        #region Propiedades
        public bool Success { get; set; }
        public ErrorResponse Error { get; set; }
        #endregion
        #region Constructores
        public BaseResponse()
        {
            Error = new ErrorResponse();
        }
        #endregion
    }
}