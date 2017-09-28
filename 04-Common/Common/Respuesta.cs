namespace Common
{
    public abstract class RespuestaBase
    {
        public bool Response { get; set; }
        public string Message { get; set; }
        public string Function { get; set; }
        public string Href { get; set; }

        protected void RespuestaPreparada(bool r, string m = "")
        {
            Response = r;

            if (r)
            {
                Message = m;
            }
            else
            {
                Message = (m == "" ? "ocurrió un error inesperado" : m);
            }
        }

        public RespuestaBase()
        {
            Response = false;
            Message = "ocurrió un error inesperado";
        }
    }

    public class ComplementoDeRespuesta : RespuestaBase
    {
        public dynamic Result { get; set; }

        public ComplementoDeRespuesta SetRespuesta(bool r, string m = "")
        {
            RespuestaPreparada(r, m);
            return this;
        }
    }

    public class ComplementoDeRespuesta<T> : RespuestaBase where T : class
    {
        public T Result { get; set; }

        public ComplementoDeRespuesta<T> SetRespuesta(bool r, string m = "")
        {
            RespuestaPreparada(r, m);
            return this;
        }
    }
}
