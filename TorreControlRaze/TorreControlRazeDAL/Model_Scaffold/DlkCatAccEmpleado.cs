using System;
using System.Collections.Generic;

namespace TorreControlRazeDAL.Model_Scaffold;

public partial class DlkCatAccEmpleado
{
    public DlkCatAccEmpleado( string codEmpleado, string claveEmpleado)
    {
       
        CodEmpleado = codEmpleado;
        ClaveEmpleado = claveEmpleado;
     
        Mmuid = "sadasdas";
       
    }

    public string Mmuid { get; set; } = null!;

    public TimeOnly MdDate { get; set; }

    public int Id { get; set; }

    public string CodEmpleado { get; set; } = null!;

    public string ClaveEmpleado { get; set; } = null!;

    public long NivelAccesosEmpleado { get; set; }

}
