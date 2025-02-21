using System;
using System.Collections.Generic;
using BusinessEntity.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessEntity.Data;

public partial class DbAcceso : DbContext
{
    public DbAcceso()
    {
    }

    public DbAcceso(DbContextOptions<DbAcceso> options)
        : base(options)
    {
    }

    public virtual DbSet<SqlsrchSql> SqlsrchSqls { get; set; }

    public virtual DbSet<SygenacsSql> SygenacsSqls { get; set; }

    public virtual DbSet<SygenbzgSql> SygenbzgSqls { get; set; }

    public virtual DbSet<SygendbcSql> SygendbcSqls { get; set; }

    public virtual DbSet<SygengadSql> SygengadSqls { get; set; }

    public virtual DbSet<SygenopcSql> SygenopcSqls { get; set; }

    public virtual DbSet<SygenusrSql> SygenusrSqls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JACKIE;Database=SPANISH;User Id=ADMIN_SQL;Password=FINDEAÑO;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<SqlsrchSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SQLSRCH_SQL");

            entity.HasIndex(e => new { e.SearchFieldId, e.SearchNo }, "ISQLSRCH_SQL0")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.PssSearchTitle)
                .HasMaxLength(45)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pss_search_title");
            entity.Property(e => e.SearchFieldId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_field_id");
            entity.Property(e => e.SearchFiller)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_filler");
            entity.Property(e => e.SearchFormats)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_formats");
            entity.Property(e => e.SearchGroup)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_group");
            entity.Property(e => e.SearchJoins)
                .HasColumnType("text")
                .HasColumnName("search_joins");
            entity.Property(e => e.SearchMaintLiteral)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_maint_literal");
            entity.Property(e => e.SearchMaintProgram)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_maint_program");
            entity.Property(e => e.SearchNo).HasColumnName("search_no");
            entity.Property(e => e.SearchOrderBy)
                .HasColumnType("text")
                .HasColumnName("search_order_by");
            entity.Property(e => e.SearchRetVal)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_ret_val");
            entity.Property(e => e.SearchReturnRows).HasColumnName("search_return_rows");
            entity.Property(e => e.SearchSegmentNum).HasColumnName("search_segment_num");
            entity.Property(e => e.SearchSelect)
                .HasColumnType("text")
                .HasColumnName("search_select");
            entity.Property(e => e.SearchTable)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_table");
            entity.Property(e => e.SearchTablePkg)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_table_pkg");
            entity.Property(e => e.SearchUsername)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_username");
            entity.Property(e => e.SearchWhere)
                .HasColumnType("text")
                .HasColumnName("search_where");
            entity.Property(e => e.SearchWhereDefaults)
                .HasColumnType("text")
                .HasColumnName("search_where_defaults");
            entity.Property(e => e.UseSessionFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("use_session_fg");
        });

        modelBuilder.Entity<SygenacsSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYGENACS_SQL");

            entity.HasIndex(e => new { e.SyUser, e.SyCompany, e.SyMenuCode }, "ISYGENACS_SQL0")
                .IsUnique()
                .IsClustered()
                .HasFillFactor(80);

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.SyCompany)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_company");
            entity.Property(e => e.SyMenuCode)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_menu_code");
            entity.Property(e => e.SyMenuState)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_menu_state");
            entity.Property(e => e.SyUser)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_user");
        });

        modelBuilder.Entity<SygenbzgSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYGENBZG_SQL");

            entity.HasIndex(e => e.BizGrpId, "idx_SYGENBZG_SQL_0").IsUnique();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.BizGrpCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("biz_grp_code");
            entity.Property(e => e.BizGrpDescr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("biz_grp_descr");
            entity.Property(e => e.BizGrpDescrLong)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("biz_grp_descr_long");
            entity.Property(e => e.BizGrpId).HasColumnName("biz_grp_id");
            entity.Property(e => e.BizGrpMainFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("biz_grp_main_fg");
            entity.Property(e => e.BizGrpSpecificUrlFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("biz_grp_specific_url_fg");
            entity.Property(e => e.BizGrpUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("biz_grp_url");
            entity.Property(e => e.BizIsMacFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("biz_is_mac_fg");
        });

        modelBuilder.Entity<SygendbcSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYGENDBC_SQL");

            entity.HasIndex(e => new { e.SyCompany, e.BizGrpId }, "idx_SYGENDBC").IsUnique();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.BizGrpId).HasColumnName("biz_grp_id");
            entity.Property(e => e.SyCompany)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_company");
            entity.Property(e => e.SyCompanyDescr)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_company_descr");
            entity.Property(e => e.SyCompanyLogo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_company_logo");
            entity.Property(e => e.SyDoi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_doi");
            entity.Property(e => e.SyDoiFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_doi_fg");
            entity.Property(e => e.SyShowFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_show_fg");
            entity.Property(e => e.SyShowLogoFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_show_logo_fg");
        });

        modelBuilder.Entity<SygengadSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYGENGAD_SQL");

            entity.HasIndex(e => new { e.SyUser, e.BizGrpId }, "IDX0_SYGENGAD_SQL").IsUnique();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.BizGrpId).HasColumnName("biz_grp_id");
            entity.Property(e => e.IsAdminFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_admin_fg");
            entity.Property(e => e.IsAdminGenFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_admin_gen_fg");
            entity.Property(e => e.IsFreeAccessFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_free_access_fg");
            entity.Property(e => e.SyUser)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_user");
        });

        modelBuilder.Entity<SygenopcSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYGENOPC_SQL");

            entity.HasIndex(e => e.SyMenuCode, "ISYGENOPC_SQL0")
                .IsUnique()
                .IsClustered()
                .HasFillFactor(80);

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.SyMenuCode)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_menu_code");
            entity.Property(e => e.SyMenuLevel).HasColumnName("sy_menu_level");
            entity.Property(e => e.SyMenuName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sy_menu_name");
            entity.Property(e => e.SyMenuParent)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("sy_menu_parent");
            entity.Property(e => e.SyOpcActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_opc_active");
            entity.Property(e => e.SyOpcExec)
                .HasMaxLength(28)
                .IsUnicode(false)
                .HasColumnName("sy_opc_exec");
            entity.Property(e => e.SyOpcLiteral)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sy_opc_literal");
            entity.Property(e => e.SyOpcType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_opc_type");
            entity.Property(e => e.SyPkgId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_pkg_id");
            entity.Property(e => e.SyUrl)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("sy_url");
        });

        modelBuilder.Entity<SygenusrSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYGENUSR_SQL");

            entity.HasIndex(e => e.SyUser, "ISYGENUSR_SQL0")
                .IsUnique()
                .IsClustered()
                .HasFillFactor(80);

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.SyUser)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_user");
            entity.Property(e => e.SyUserDoiFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_user_doi_fg");
            entity.Property(e => e.SyUserGroup)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_user_group");
            entity.Property(e => e.SyUserPsc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_user_psc");
            entity.Property(e => e.SyUserType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_user_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
