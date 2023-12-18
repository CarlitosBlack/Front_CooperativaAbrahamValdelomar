namespace Front_Cooperativa_AbrahamLincoln.Entidades
{
    public class IInfo_Socio_Gerencia
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        //public string _Fecha { get; set; }
        public string _Nombre { get; set; }

        public byte[] _Documento { get; set; }
    }
}
