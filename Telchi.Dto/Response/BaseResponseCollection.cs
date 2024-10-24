namespace Telchi.Dto.Response
{
    public class BaseResponseCollection
    {
        #region Propiedades
        public bool Success { get; set; }
        public ICollection<ErrorResponse> ErrorList { get; set; }
        #endregion
        #region Constructores
        public BaseResponseCollection()
        {
            ErrorList = new List<ErrorResponse>();
        }
        #endregion
    }
}