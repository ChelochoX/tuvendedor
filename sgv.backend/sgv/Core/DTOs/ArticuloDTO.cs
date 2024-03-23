namespace sgv.Core.DTOs
{
    public class ArticuloDTO
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Grupo { get; set; }
        public List<PlanDePagoDTO> PlanesDePago { get; set; }
    }

    public class PlanDePagoDTO
    {
        public decimal Entrega { get; set; }
        public int Cuota { get; set; }
        public decimal Importe { get; set; }
        public string Moneda { get; set; }
    }
}
