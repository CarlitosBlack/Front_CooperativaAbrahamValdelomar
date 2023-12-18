namespace Front_Cooperativa_AbrahamLincoln.Entidades
{
    public class IAsambleas
    {
        public int Id { get; set; }
        public string _Nombre { get; set; }
        public string _Fecha { get; set; }
        public byte[]? _Convocatoria { get; set; }
        public byte[]? _Actas { get; set; }
        public byte[]? _Anexos { get; set; }
        public byte[]? _Acuerdos { get; set; }
    }
}
