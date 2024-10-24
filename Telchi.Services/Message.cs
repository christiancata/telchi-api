namespace Telchi.Services
{
    public class Message
    {
        #region Metodos
        public static string GetError(int code)
        {
            string error = "";

            switch (code)
            {
                //Errores Generales
                case 1:
                    error = "Los datos son incorrectos.";
                    break;

                //Errores del módulo Configuración SAP.
                case 600:
                    error = "No existe Configuración SAP.";
                    break;
            }

            return error;
        }
        #endregion
    }
}