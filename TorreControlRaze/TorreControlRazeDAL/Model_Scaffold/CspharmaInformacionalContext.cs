using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TorreControlRazeDAL.Model_Scaffold;

public partial class CspharmaInformacionalContext : DbContext
{
    public CspharmaInformacionalContext()
    {
    }

    public CspharmaInformacionalContext(DbContextOptions<CspharmaInformacionalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DlkCatAccEmpleado> DlkCatAccEmpleados { get; set; }

    public virtual DbSet<TdcCatEstadosDevolucionPedido> TdcCatEstadosDevolucionPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosEnvioPedido> TdcCatEstadosEnvioPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosPagoPedido> TdcCatEstadosPagoPedidos { get; set; }

    public virtual DbSet<TdcCatLineasDistribucion> TdcCatLineasDistribucions { get; set; }

    public virtual DbSet<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=cspharma_informacional;User Id=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DlkCatAccEmpleado>(entity =>
        {
            entity.HasKey(e => e.CodEmpleado).HasName("dlk_cat_empleado_pkey");

            entity.ToTable("dlk_cat_acc_empleados", "dlk_informacional");

            entity.Property(e => e.CodEmpleado)
                .HasColumnType("character varying")
                .HasColumnName("cod_empleado");
            entity.Property(e => e.ClaveEmpleado)
                .HasColumnType("character varying")
                .HasColumnName("clave_empleado");
            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('dlk_informacional.dlk_cat_empleado_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.MdDate).HasColumnName("md_date");
            entity.Property(e => e.Mmuid)
                .HasColumnType("character varying")
                .HasColumnName("mmuid");
            entity.Property(e => e.NivelAccesosEmpleado).HasColumnName("nivel_accesos_empleado");
        });

        modelBuilder.Entity<TdcCatEstadosDevolucionPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoDevolUcion).HasName("tdc_cat_estados_devolucion_pedido_pkey");

            entity.ToTable("tdc_cat_estados_devolucion_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoDevolUcion)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde devolución de\nun pedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_devol ucion");
            entity.Property(e => e.DesEstadoDevolUcion)
                .HasComment("Descripción del\nestado de\ndevolución del\npedido")
                .HasColumnType("character varying")
                .HasColumnName("des_estado_devol ucion");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que\nse\ndefine el grupo de\ninserción.")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de\nmetadato\nque indica el\ngrupo\nde inserción al\nque\npertenece el\nregistro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosEnvioPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoEnvio).HasName("tdc_cat_estados_envio_pedido_pkey");

            entity.ToTable("tdc_cat_estados_envio_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoEnvio)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde envío de un\npedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.DesEstadoEnvio)
                .HasComment("Descripción del\nestado de envío\ndel pedido")
                .HasColumnType("character varying")
                .HasColumnName("des_estado_envio");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que\nse\ndefine el grupo de\ninserción.")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de\nmetadato\nque indica el\ngrupo\nde inserción al\nque\npertenece el\nregistro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosPagoPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoPago).HasName("pk2");

            entity.ToTable("tdc_cat_estados_pago_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoPago)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde pago de un\npedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_pago");
            entity.Property(e => e.DesEstadoPago)
                .HasComment("Descripción del\nestado de pago\ndel pedido")
                .HasColumnType("character varying")
                .HasColumnName("des_estado_pago");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que\nse\ndefine el grupo de\ninserción.")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de\nmetadato\nque indica el\ngrupo\nde inserción al\nque\npertenece el\nregistro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatLineasDistribucion>(entity =>
        {
            entity.HasKey(e => e.CodLinea).HasName("PK1");

            entity.ToTable("tdc_cat_lineas_distribucion", "dwh_torrecontrol");

            entity.Property(e => e.CodLinea)
                .HasComment("Código que\nidentifica de forma\nunívoca la línea\nde distribución por\ncarretera que\nsigue el envío:\ncodprovincia-cod\nmunicipio-codbarri")
                .HasColumnType("character varying")
                .HasColumnName("cod_linea");
            entity.Property(e => e.CodBarrio)
                .HasComment("Código que\nidentifica de forma\nunívoca el barrio")
                .HasColumnType("character varying")
                .HasColumnName("cod_barrio");
            entity.Property(e => e.CodMunicipio)
                .HasComment("Código que\nidentifica de forma\nunívoca el\nmunicipio")
                .HasColumnType("character varying")
                .HasColumnName("cod_municipio");
            entity.Property(e => e.CodProvincia)
                .HasComment("Código que\nidentifica de forma\nunívoca a la\nprovincia")
                .HasColumnType("character varying")
                .HasColumnName("cod_provincia");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que\nse\ndefine el grupo de\ninserción.")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de metadato que indica el grupo de inserción al que pertenece el registro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcTchEstadoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk3");

            entity.ToTable("tdc_tch_estado_pedidos", "dwh_torrecontrol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodEstadoDevolucion)
                .HasComment("Código que identifica de forma unívoca el estado de devolución de un pedido.")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_devolucion");
            entity.Property(e => e.CodEstadoEnvio)
                .HasComment("Código que identifica de forma unívoca el estado de envío de un pedido.")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.CodEstadoPago)
                .HasComment("Código que identifica de forma unívoca el estado de pago de un pedido.")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_pago ");
            entity.Property(e => e.CodLinea)
                .HasComment("Código que identifica de forma unívoca la línea de distribución por carretera que \nsigue el envío: codprovincia-codmunicipio-codbarrio")
                .HasColumnType("character varying")
                .HasColumnName("cod_linea ");
            entity.Property(e => e.CodPedido)
                .HasComment("Código que identifica de forma unívoca un pedido. Se construye con: provincia-codfarmacia-id.")
                .HasColumnType("character varying")
                .HasColumnName("cod_pedido");
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que se define el grupo de inserción.")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de metadato que indica el grupo de inserción al que pertenece el registro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");

            entity.HasOne(d => d.CodEstadoDevolucionNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasForeignKey(d => d.CodEstadoDevolucion)
                .HasConstraintName("pedidos_devolucion_fk");

            entity.HasOne(d => d.CodEstadoEnvioNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasForeignKey(d => d.CodEstadoEnvio)
                .HasConstraintName("fk1");

            entity.HasOne(d => d.CodLineaNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasForeignKey(d => d.CodLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidos_lineas_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
