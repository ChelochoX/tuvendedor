namespace sgv.Core.Entities;

public class Articulo
{
    public int IdArticulo { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Grupo { get; set; }
    public List<PlanDePago> PlanesDePago { get; set; }
}

// Clase que representa un plan de financiación
public class PlanDePago
{
    public int IdPlanDePago { get; set; }
    public decimal Entrega { get; set; }
    public int Cuota { get; set; }
    public decimal Importe { get; set; }
    public string Moneda { get; set; }
}
