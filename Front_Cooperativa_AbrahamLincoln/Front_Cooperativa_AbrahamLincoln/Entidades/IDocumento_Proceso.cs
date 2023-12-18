namespace Front_Cooperativa_AbrahamLincoln.Entidades
{
    public class IDocumento_Proceso
    {
        public int Id { get; set; }
        //public string _Fecha { get; set; }
        public string _Nombre_Proceso { get; set; }

        public string _Nombre_Documento { get; set; }
        public byte[] _Documento { get; set; }
    }
}
