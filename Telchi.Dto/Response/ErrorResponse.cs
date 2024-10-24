namespace Telchi.Dto.Response
{
    public class ErrorResponse
    {
        #region Propiedades
        public int Code { get; set; }
        public string Message { get; set; }
        #endregion
        #region Constructores
        public ErrorResponse()
        {
            Message = string.Empty;
        }
        #endregion
    }
}