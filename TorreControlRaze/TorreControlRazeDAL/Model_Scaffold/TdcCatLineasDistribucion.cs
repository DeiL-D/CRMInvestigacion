using System;
using System.Collections.Generic;

namespace TorreControlRazeDAL.Model_Scaffold;

public partial class TdcCatLineasDistribucion
{
    /// <summary>
    /// Código de metadato que indica el grupo de inserción al que pertenece el registro.
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
    /// unívoca la línea
    /// de distribución por
    /// carretera que
    /// sigue el envío:
    /// codprovincia-cod
    /// municipio-codbarri
    /// </summary>
    public string CodLinea { get; set; } = null!;

    /// <summary>
    /// Código que
    /// identifica de forma
    /// unívoca a la
    /// provincia
    /// </summary>
    public string CodProvincia { get; set; } = null!;

    /// <summary>
    /// Código que
    /// identifica de forma
    /// unívoca el
    /// municipio
    /// </summary>
    public string CodMunicipio { get; set; } = null!;

    /// <summary>
    /// Código que
    /// identifica de forma
    /// unívoca el barrio
    /// </summary>
    public string CodBarrio { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedido>();
}
