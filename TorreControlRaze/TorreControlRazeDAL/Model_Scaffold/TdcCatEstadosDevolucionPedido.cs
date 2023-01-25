using System;
using System.Collections.Generic;

namespace TorreControlRazeDAL.Model_Scaffold;

public partial class TdcCatEstadosDevolucionPedido
{
    /// <summary>
    /// Código de
    /// metadato
    /// que indica el
    /// grupo
    /// de inserción al
    /// que
    /// pertenece el
    /// registro.
    /// </summary>
    public string MdUuid { get; set; } = null!;

    /// <summary>
    /// Fecha en la que
    /// se
    /// define el grupo de
    /// inserción.
    /// </summary>
    public TimeOnly MdDate { get; set; }

    /// <summary>
    /// Código que
    /// identifica de forma
    /// unívoca el estado
    /// de devolución de
    /// un pedido
    /// </summary>
    public string CodEstadoDevolUcion { get; set; } = null!;

    /// <summary>
    /// Descripción del
    /// estado de
    /// devolución del
    /// pedido
    /// </summary>
    public string? DesEstadoDevolUcion { get; set; }

    public int Id { get; set; }

    public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedido>();
}
