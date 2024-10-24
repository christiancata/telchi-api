namespace Telchi.Dto.Response
{
    public class BaseResponseGeneric<TClass> : BaseResponse
    {
        #region Propiedades
        public TClass Result { get; set; }
        #endregion
    }
}