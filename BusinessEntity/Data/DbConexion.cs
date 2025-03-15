using System;
using System.Collections.Generic;
using BusinessEntity.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessEntity.Data;

public partial class DbConexion : DbContext
{
    private readonly string _connectionString;
    public DbConexion()
    {
    }

    public DbConexion(DbContextOptions<DbConexion> options)
        : base(options)
    {
    }
    public DbConexion(string connectionString)
    {
        _connectionString = connectionString;
    }
    public virtual DbSet<ApopnfilSql> ApopnfilSqls { get; set; }

    public virtual DbSet<ApopnhstSql> ApopnhstSqls { get; set; }

    public virtual DbSet<ApvenextSql> ApvenextSqls { get; set; }

    public virtual DbSet<ApvenfilSql> ApvenfilSqls { get; set; }

    public virtual DbSet<ArcusextSql> ArcusextSqls { get; set; }

    public virtual DbSet<ArcusfilSql> ArcusfilSqls { get; set; }

    public virtual DbSet<CmcurratSql> CmcurratSqls { get; set; }

    public virtual DbSet<CmcurrteSql> CmcurrteSqls { get; set; }

    public virtual DbSet<CompfileSql> CompfileSqls { get; set; }

    public virtual DbSet<SyactfilSql> SyactfilSqls { get; set; }

    public virtual DbSet<SycshfilSql> SycshfilSqls { get; set; }

    public virtual DbSet<SyprdfilSql> SyprdfilSqls { get; set; }

    public virtual DbSet<TaxdetlSql> TaxdetlSqls { get; set; }

    public virtual DbSet<TaxschedSql> TaxschedSqls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(_connectionString);
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=JACKIE;Database=DATA_400;User Id=ADMIN_SQL;Password=FINDEAÑO;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApopnfilSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("APOPNFIL_SQL", tb => tb.HasTrigger("TR_APOPNFIL_AUDI"));

            entity.HasIndex(e => new { e.VendNo, e.VchrNo, e.VchrChkCd, e.VchrChkType, e.ApOpnDt, e.ApOpnTm }, "IAPOPNFIL_SQL0")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.AltCurrCd, e.AltVendNo, e.ApplyToNo, e.VchrChkType1, e.TrxDt, e.A4glidentity }, "IAPOPNFIL_SQL1").IsUnique();

            entity.HasIndex(e => new { e.OpnClosCd, e.Alt1CurrCd, e.Alt1VendNo, e.SepChkFg, e.Alt1ApplyToNo, e.Alt1TrxDt, e.A4glidentity }, "IAPOPNFIL_SQL2").IsUnique();

            entity.HasIndex(e => new { e.Status, e.A4glidentity }, "IAPOPNFIL_SQL3").IsUnique();

            entity.HasIndex(e => new { e.Alt3VchrCd, e.CashMnNo, e.CashSbNo, e.CashDpNo, e.ChkNo, e.SeqNo, e.A4glidentity }, "IAPOPNFIL_SQL4").IsUnique();

            entity.HasIndex(e => new { e.Alt5InvCd, e.Alt5CurrCd, e.Alt5VendNo, e.Alt5ApplyToNo, e.Alt5TrxDt, e.A4glidentity }, "IAPOPNFIL_SQL5").IsUnique();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.AlfCd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alf_cd");
            entity.Property(e => e.Alt1ApplyToNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt1_apply_to_no");
            entity.Property(e => e.Alt1CurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt1_curr_cd");
            entity.Property(e => e.Alt1TrxDt).HasColumnName("alt1_trx_dt");
            entity.Property(e => e.Alt1VendNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt1_vend_no");
            entity.Property(e => e.Alt3VchrCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt3_vchr_cd");
            entity.Property(e => e.Alt5ApplyToNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt5_apply_to_no");
            entity.Property(e => e.Alt5CurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt5_curr_cd");
            entity.Property(e => e.Alt5InvCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt5_inv_cd");
            entity.Property(e => e.Alt5TrxDt).HasColumnName("alt5_trx_dt");
            entity.Property(e => e.Alt5VendNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt5_vend_no");
            entity.Property(e => e.AltCurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt_curr_cd");
            entity.Property(e => e.AltVendNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt_vend_no");
            entity.Property(e => e.Amt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt");
            entity.Property(e => e.Ap1099Fg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_1099_fg");
            entity.Property(e => e.ApDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_dp_no");
            entity.Property(e => e.ApMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_mn_no");
            entity.Property(e => e.ApOpenBaseImponi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_open_base_imponi");
            entity.Property(e => e.ApOpenCodAduana)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_open_cod_aduana");
            entity.Property(e => e.ApOpenDocImport)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_open_doc_import");
            entity.Property(e => e.ApOpenFechaRendicion).HasColumnName("ap_open_fecha_rendicion");
            entity.Property(e => e.ApOpenMontoAdv)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("ap_open_monto_adv");
            entity.Property(e => e.ApOpenMontoFlt).HasColumnName("ap_open_monto_flt");
            entity.Property(e => e.ApOpenMontoFob)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("ap_open_monto_fob");
            entity.Property(e => e.ApOpenMontoSgr)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("ap_open_monto_sgr");
            entity.Property(e => e.ApOpenNroPoliza)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_open_nro_poliza");
            entity.Property(e => e.ApOpenPercTax)
                .HasColumnType("decimal(6, 4)")
                .HasColumnName("ap_open_perc_tax");
            entity.Property(e => e.ApOpenRetenFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_open_reten_flg");
            entity.Property(e => e.ApOpenTcVenpub)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("ap_open_tc_venpub");
            entity.Property(e => e.ApOpenTipoReg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_open_tipo_reg");
            entity.Property(e => e.ApOpnDt).HasColumnName("ap_opn_dt");
            entity.Property(e => e.ApOpnTm).HasColumnName("ap_opn_tm");
            entity.Property(e => e.ApPoNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_po_no");
            entity.Property(e => e.ApSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_sb_no");
            entity.Property(e => e.ApTermCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_term_code");
            entity.Property(e => e.ApplyToNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("apply_to_no");
            entity.Property(e => e.AssetTypeCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("asset_type_cd");
            entity.Property(e => e.CashAcctCurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_acct_curr_cd");
            entity.Property(e => e.CashDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_dp_no");
            entity.Property(e => e.CashMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_mn_no");
            entity.Property(e => e.CashSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_sb_no");
            entity.Property(e => e.ChkDt).HasColumnName("chk_dt");
            entity.Property(e => e.ChkNo).HasColumnName("chk_no");
            entity.Property(e => e.ChkPrtFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("chk_prt_fg");
            entity.Property(e => e.ChkVchrNo).HasColumnName("chk_vchr_no");
            entity.Property(e => e.CurrTrxRt)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("curr_trx_rt");
            entity.Property(e => e.CurrTrxRt2)
                .HasColumnType("numeric(11, 6)")
                .HasColumnName("curr_trx_rt_2");
            entity.Property(e => e.DebtSwapCd).HasColumnName("debt_swap_cd");
            entity.Property(e => e.DetracGroup).HasColumnName("detrac_group");
            entity.Property(e => e.DetracPayedBySystemFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("detrac_payed_by_system_fg");
            entity.Property(e => e.DiscAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("disc_amt");
            entity.Property(e => e.DiscDt).HasColumnName("disc_dt");
            entity.Property(e => e.DiscTaken)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("disc_taken");
            entity.Property(e => e.DueDt).HasColumnName("due_dt");
            entity.Property(e => e.EdCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ed_cd");
            entity.Property(e => e.ErCd)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("er_cd");
            entity.Property(e => e.ExogenousFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("exogenous_fg");
            entity.Property(e => e.Filler0001)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0001");
            entity.Property(e => e.FrdDt).HasColumnName("frd_dt");
            entity.Property(e => e.FullyPaidDt).HasColumnName("fully_paid_dt");
            entity.Property(e => e.GainLossAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("gain_loss_amt");
            entity.Property(e => e.InvNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("inv_no");
            entity.Property(e => e.IsAdvancementFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_advancement_fg");
            entity.Property(e => e.IsExrBaseFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_exr_base_fg");
            entity.Property(e => e.IsExrFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_exr_fg");
            entity.Property(e => e.IsPeFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_pe_fg");
            entity.Property(e => e.LastDateProssDt).HasColumnName("Last_date_pross_dt");
            entity.Property(e => e.LastDateProssDt2).HasColumnName("Last_date_pross_dt_2");
            entity.Property(e => e.LastRevalDt).HasColumnName("last_reval_dt");
            entity.Property(e => e.OpnClosCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("opn_clos_cd");
            entity.Property(e => e.OrigTrxRt)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("orig_trx_rt");
            entity.Property(e => e.OrigTrxRt2)
                .HasColumnType("numeric(11, 6)")
                .HasColumnName("orig_trx_rt_2");
            entity.Property(e => e.PayAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("pay_amt");
            entity.Property(e => e.PoChgFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("po_chg_fg");
            entity.Property(e => e.Reference)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("reference");
            entity.Property(e => e.ReferenceSp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("reference_sp");
            entity.Property(e => e.ReferencialApplyToNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("referencial_apply_to_no");
            entity.Property(e => e.ReferencialVchrNo).HasColumnName("referencial_vchr_no");
            entity.Property(e => e.RetRenNo).HasColumnName("ret_ren_no");
            entity.Property(e => e.RetentionRatePct)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("retention_rate_pct");
            entity.Property(e => e.SepChkFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sep_chk_fg");
            entity.Property(e => e.SeqNo).HasColumnName("seq_no");
            entity.Property(e => e.SlInverseFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sl_inverse_fg");
            entity.Property(e => e.SlType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sl_type");
            entity.Property(e => e.SlVchrNo).HasColumnName("sl_vchr_no");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.TrxDt).HasColumnName("trx_dt");
            entity.Property(e => e.VchrBank)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vchr_bank");
            entity.Property(e => e.VchrChkCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vchr_chk_cd");
            entity.Property(e => e.VchrChkType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vchr_chk_type");
            entity.Property(e => e.VchrChkType1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vchr_chk_type_1");
            entity.Property(e => e.VchrDetrac)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vchr_detrac");
            entity.Property(e => e.VchrDt).HasColumnName("vchr_dt");
            entity.Property(e => e.VchrNo).HasColumnName("vchr_no");
            entity.Property(e => e.VchrType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vchr_type");
            entity.Property(e => e.VendNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vend_no");
            entity.Property(e => e.VoidChkDt).HasColumnName("void_chk_dt");
        });

        modelBuilder.Entity<ApopnhstSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("APOPNHST_SQL", tb => tb.HasTrigger("TR_APOPNHST_AUDI"));

            entity.HasIndex(e => new { e.VendNo, e.ApOpnDt, e.ApOpnTm, e.VchrNo, e.VchrChkCd, e.VchrChkType }, "IAPOPNHST_SQL0")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.AltCurrCd, e.AltVendNo, e.ApplyToNo, e.VchrChkType1, e.TrxDt, e.A4glidentity }, "IAPOPNHST_SQL1").IsUnique();

            entity.HasIndex(e => new { e.OpnClosCd, e.Alt1CurrCd, e.Alt1VendNo, e.SepChkFg, e.Alt1ApplyToNo, e.Alt1TrxDt, e.A4glidentity }, "IAPOPNHST_SQL2").IsUnique();

            entity.HasIndex(e => new { e.Status, e.A4glidentity }, "IAPOPNHST_SQL3").IsUnique();

            entity.HasIndex(e => new { e.Alt3VchrCd, e.CashMnNo, e.CashSbNo, e.CashDpNo, e.ChkNo, e.SeqNo, e.A4glidentity }, "IAPOPNHST_SQL4").IsUnique();

            entity.HasIndex(e => new { e.Alt5InvCd, e.Alt5CurrCd, e.Alt5VendNo, e.Alt5ApplyToNo, e.Alt5TrxDt, e.A4glidentity }, "IAPOPNHST_SQL5").IsUnique();

            entity.HasIndex(e => new { e.JnlCd, e.JnlBatchId, e.JnlDocNo, e.A4glidentity }, "IAPOPNHST_SQL6").IsUnique();

            entity.HasIndex(e => new { e.IdNo, e.A4glidentity }, "IAPOPNHST_SQL7").IsUnique();

            entity.HasIndex(e => new { e.DocNo, e.DocDt, e.A4glidentity }, "IAPOPNHST_SQL8").IsUnique();

            entity.HasIndex(e => new { e.CashMnNo, e.CashSbNo, e.CashDpNo, e.ChkNo, e.VchrDt, e.JnlCd }, "IAPOPNHST_SQL9");

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.Alt1ApplyToNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt1_apply_to_no");
            entity.Property(e => e.Alt1CurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt1_curr_cd");
            entity.Property(e => e.Alt1TrxDt).HasColumnName("alt1_trx_dt");
            entity.Property(e => e.Alt1VendNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt1_vend_no");
            entity.Property(e => e.Alt3VchrCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt3_vchr_cd");
            entity.Property(e => e.Alt5ApplyToNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt5_apply_to_no");
            entity.Property(e => e.Alt5CurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt5_curr_cd");
            entity.Property(e => e.Alt5InvCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt5_inv_cd");
            entity.Property(e => e.Alt5TrxDt).HasColumnName("alt5_trx_dt");
            entity.Property(e => e.Alt5VendNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt5_vend_no");
            entity.Property(e => e.AltCurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt_curr_cd");
            entity.Property(e => e.AltVendNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt_vend_no");
            entity.Property(e => e.Amt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt");
            entity.Property(e => e.ApDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_dp_no");
            entity.Property(e => e.ApHstBaseImponi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_hst_base_imponi");
            entity.Property(e => e.ApHstCodAduana)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_hst_cod_aduana");
            entity.Property(e => e.ApHstDocImport)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_hst_doc_import");
            entity.Property(e => e.ApHstFechaRendicion).HasColumnName("ap_hst_fecha_rendicion");
            entity.Property(e => e.ApHstMontoAdv)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("ap_hst_monto_adv");
            entity.Property(e => e.ApHstMontoFlt).HasColumnName("ap_hst_monto_flt");
            entity.Property(e => e.ApHstMontoFob)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("ap_hst_monto_fob");
            entity.Property(e => e.ApHstMontoSgr)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("ap_hst_monto_sgr");
            entity.Property(e => e.ApHstNroPoliza)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_hst_nro_poliza");
            entity.Property(e => e.ApHstPercTax)
                .HasColumnType("decimal(6, 4)")
                .HasColumnName("ap_hst_perc_tax");
            entity.Property(e => e.ApHstRetenFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_hst_reten_flg");
            entity.Property(e => e.ApHstTcVenpub)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("ap_hst_tc_venpub");
            entity.Property(e => e.ApHstTermCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_hst_term_code");
            entity.Property(e => e.ApHstTipoReg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_hst_tipo_reg");
            entity.Property(e => e.ApMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_mn_no");
            entity.Property(e => e.ApOpnDt).HasColumnName("ap_opn_dt");
            entity.Property(e => e.ApOpnTm).HasColumnName("ap_opn_tm");
            entity.Property(e => e.ApPoNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_po_no");
            entity.Property(e => e.ApSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_sb_no");
            entity.Property(e => e.ApplyToNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("apply_to_no");
            entity.Property(e => e.CancelationProcessedFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cancelation_processed_fg");
            entity.Property(e => e.CashAcctCurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_acct_curr_cd");
            entity.Property(e => e.CashDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_dp_no");
            entity.Property(e => e.CashMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_mn_no");
            entity.Property(e => e.CashSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_sb_no");
            entity.Property(e => e.ChkDt).HasColumnName("chk_dt");
            entity.Property(e => e.ChkNo).HasColumnName("chk_no");
            entity.Property(e => e.ChkVchrNo).HasColumnName("chk_vchr_no");
            entity.Property(e => e.CjaCd)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cja_cd");
            entity.Property(e => e.CurrTrxRt)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("curr_trx_rt");
            entity.Property(e => e.DebtSwapCd).HasColumnName("debt_swap_cd");
            entity.Property(e => e.DeferredGroup).HasColumnName("deferred_group");
            entity.Property(e => e.DiscAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("disc_amt");
            entity.Property(e => e.DiscDt).HasColumnName("disc_dt");
            entity.Property(e => e.DiscTaken)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("disc_taken");
            entity.Property(e => e.DocDt).HasColumnName("doc_dt");
            entity.Property(e => e.DocNo).HasColumnName("doc_no");
            entity.Property(e => e.DueDt).HasColumnName("due_dt");
            entity.Property(e => e.EdCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ed_cd");
            entity.Property(e => e.Filler0001)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0001");
            entity.Property(e => e.FreightAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("freight_amt");
            entity.Property(e => e.FullyPaidDt).HasColumnName("fully_paid_dt");
            entity.Property(e => e.GainLossAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("gain_loss_amt");
            entity.Property(e => e.GstAmount)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("gst_amount");
            entity.Property(e => e.IdNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_no");
            entity.Property(e => e.InvAmount)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("inv_amount");
            entity.Property(e => e.InvNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("inv_no");
            entity.Property(e => e.IsAdvancementFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_advancement_fg");
            entity.Property(e => e.IsGeneratedByFfFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_generated_by_ff_fg");
            entity.Property(e => e.IsGeneratedByReFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_generated_by_re_fg");
            entity.Property(e => e.JnlBatchId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("jnl_batch_id");
            entity.Property(e => e.JnlCd)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("jnl_cd");
            entity.Property(e => e.JnlDocNo).HasColumnName("jnl_doc_no");
            entity.Property(e => e.LastRevalDt).HasColumnName("last_reval_dt");
            entity.Property(e => e.LiquidationCd)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("liquidation_cd");
            entity.Property(e => e.MiscChrgAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("misc_chrg_amt");
            entity.Property(e => e.NoAccEntryReference).HasColumnName("no_acc_entry_reference");
            entity.Property(e => e.NoAccountingEntry)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("no_accounting_entry");
            entity.Property(e => e.NonDiscAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("non_disc_amt");
            entity.Property(e => e.Open1099VchrFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("open_1099_vchr_fg");
            entity.Property(e => e.OpnClosCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("opn_clos_cd");
            entity.Property(e => e.OrigTrxRt)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("orig_trx_rt");
            entity.Property(e => e.PayAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("pay_amt");
            entity.Property(e => e.PoChgFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("po_chg_fg");
            entity.Property(e => e.Reference)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("reference");
            entity.Property(e => e.ReferencialApplyToNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("referencial_apply_to_no");
            entity.Property(e => e.SepChkFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sep_chk_fg");
            entity.Property(e => e.SeqNo).HasColumnName("seq_no");
            entity.Property(e => e.SlVchrNo).HasColumnName("sl_vchr_no");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.TaxAmount)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("tax_amount");
            entity.Property(e => e.TrxDt).HasColumnName("trx_dt");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");
            entity.Property(e => e.VchrChkCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vchr_chk_cd");
            entity.Property(e => e.VchrChkType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vchr_chk_type");
            entity.Property(e => e.VchrChkType1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vchr_chk_type_1");
            entity.Property(e => e.VchrDt).HasColumnName("vchr_dt");
            entity.Property(e => e.VchrNo).HasColumnName("vchr_no");
            entity.Property(e => e.VchrType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vchr_type");
            entity.Property(e => e.VendNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vend_no");
            entity.Property(e => e.VoidAdLtFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("void_ad_lt_fg");
            entity.Property(e => e.VoidChkDt).HasColumnName("void_chk_dt");
            entity.Property(e => e.VoidNcFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("void_nc_fg");
        });

        modelBuilder.Entity<ApvenextSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("APVENEXT_SQL");

            entity.HasIndex(e => e.VenextNo, "APVENEXT_SQL0").IsClustered();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.AlfCd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alf_cd");
            entity.Property(e => e.ApvenextFiller)
                .HasMaxLength(79)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("apvenext_filler");
            entity.Property(e => e.BankAcctType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("bank_acct_type");
            entity.Property(e => e.ConvenantCd)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("convenant_cd");
            entity.Property(e => e.CountryCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country_cd");
            entity.Property(e => e.CusextCd4)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_cd_4");
            entity.Property(e => e.InterFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("inter_fg");
            entity.Property(e => e.LcFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lc_fg");
            entity.Property(e => e.LicenseCar)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("license_car");
            entity.Property(e => e.LicenseShipper)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("license_shipper");
            entity.Property(e => e.OfficeCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("office_code");
            entity.Property(e => e.Responsible)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("responsible");
            entity.Property(e => e.TrademarkCar)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("trademark_car");
            entity.Property(e => e.TransferBankAccount)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transfer_bank_account");
            entity.Property(e => e.TypDocIdSnt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("typ_doc_id_snt");
            entity.Property(e => e.Typify)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("typify");
            entity.Property(e => e.UniversalCod)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("universal_cod");
            entity.Property(e => e.VenextApellidoMat)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_Apellido_mat");
            entity.Property(e => e.VenextApellidoPat)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_Apellido_pat");
            entity.Property(e => e.VenextDirLegal)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_dir_legal");
            entity.Property(e => e.VenextFg01)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_fg_01");
            entity.Property(e => e.VenextFg02)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_fg_02");
            entity.Property(e => e.VenextFg03)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_fg_03");
            entity.Property(e => e.VenextFg04)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_fg_04");
            entity.Property(e => e.VenextFg05)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_fg_05");
            entity.Property(e => e.VenextInd1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_ind_1");
            entity.Property(e => e.VenextInd2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_ind_2");
            entity.Property(e => e.VenextInd3)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_ind_3");
            entity.Property(e => e.VenextInd4)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_ind_4");
            entity.Property(e => e.VenextInd5)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_ind_5");
            entity.Property(e => e.VenextIsNat)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_is_nat");
            entity.Property(e => e.VenextLocDistrito)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_loc_distrito");
            entity.Property(e => e.VenextLocDpto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_loc_dpto");
            entity.Property(e => e.VenextLocProvincia)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_loc_provincia");
            entity.Property(e => e.VenextNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_no");
            entity.Property(e => e.VenextNombres)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_Nombres");
            entity.Property(e => e.VenextTipoRetencion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_tipo_retencion");
            entity.Property(e => e.VenextUf1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_uf_1");
            entity.Property(e => e.VenextUf2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_uf_2");
            entity.Property(e => e.VenextUf3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_uf_3");
            entity.Property(e => e.VenextUf4)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_uf_4");
            entity.Property(e => e.VenextUf5)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_uf_5");
            entity.Property(e => e.VenextVenNameExt)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("venext_ven_name_ext");
        });

        modelBuilder.Entity<ApvenfilSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("APVENFIL_SQL");

            entity.HasIndex(e => e.VendNo, "IAPVENFIL_SQL0")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.SortName, e.A4glidentity }, "IAPVENFIL_SQL1").IsUnique();

            entity.HasIndex(e => new { e.Zip, e.A4glidentity }, "IAPVENFIL_SQL2").IsUnique();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.AcctDt).HasColumnName("acct_dt");
            entity.Property(e => e.AcknowledgeFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("acknowledge_fg");
            entity.Property(e => e.ActiveFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("active_fg");
            entity.Property(e => e.Addr1)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("addr_1");
            entity.Property(e => e.Addr2)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("addr_2");
            entity.Property(e => e.AmtAgePrd1)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_age_prd_1");
            entity.Property(e => e.AmtAgePrd2)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_age_prd_2");
            entity.Property(e => e.AmtAgePrd3)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_age_prd_3");
            entity.Property(e => e.AmtAgePrd4)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_age_prd_4");
            entity.Property(e => e.AmtLstYr1099)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_lst_yr_1099");
            entity.Property(e => e.AmtPdLastYr)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_pd_last_yr");
            entity.Property(e => e.AmtPdYtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_pd_ytd");
            entity.Property(e => e.AmtYtd1099)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_ytd_1099");
            entity.Property(e => e.ApTermsCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ap_terms_cd");
            entity.Property(e => e.AutoDistFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("auto_dist_fg");
            entity.Property(e => e.AvgCstVarPct)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("avg_cst_var_pct");
            entity.Property(e => e.AvgDaysLate).HasColumnName("avg_days_late");
            entity.Property(e => e.AvgLeadTm)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("avg_lead_tm");
            entity.Property(e => e.AvgRejItemPct)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("avg_rej_item_pct");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("balance");
            entity.Property(e => e.BuyerContact)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("buyer_contact");
            entity.Property(e => e.Cat1099)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cat_1099");
            entity.Property(e => e.ChkNo).HasColumnName("chk_no");
            entity.Property(e => e.City)
                .HasMaxLength(26)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("city");
            entity.Property(e => e.CommodityCd1)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("commodity_cd_1");
            entity.Property(e => e.CommodityCd2)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("commodity_cd_2");
            entity.Property(e => e.CommodityCd3)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("commodity_cd_3");
            entity.Property(e => e.CommodityCd4)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("commodity_cd_4");
            entity.Property(e => e.CommodityCd5)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("commodity_cd_5");
            entity.Property(e => e.ConfirmFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("confirm_fg");
            entity.Property(e => e.Contact)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contact");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.CurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("curr_cd");
            entity.Property(e => e.CusNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cus_no");
            entity.Property(e => e.DfltPoForm).HasColumnName("dflt_po_form");
            entity.Property(e => e.DiscLastYr)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("disc_last_yr");
            entity.Property(e => e.DiscLostLstYr)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("disc_lost_lst_yr");
            entity.Property(e => e.DiscLostYtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("disc_lost_ytd");
            entity.Property(e => e.DiscYtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("disc_ytd");
            entity.Property(e => e.EmailAddr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("email_addr");
            entity.Property(e => e.ErEmailAddr)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("er_email_addr");
            entity.Property(e => e.FaxNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("fax_no");
            entity.Property(e => e.FedIdNo).HasColumnName("fed_id_no");
            entity.Property(e => e.FedIdType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("fed_id_type");
            entity.Property(e => e.Filler0001)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0001");
            entity.Property(e => e.FobCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("fob_cd");
            entity.Property(e => e.LandedCostCd)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("landed_cost_cd");
            entity.Property(e => e.LandedCostCd10)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("landed_cost_cd_10");
            entity.Property(e => e.LandedCostCd2)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("landed_cost_cd_2");
            entity.Property(e => e.LandedCostCd3)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("landed_cost_cd_3");
            entity.Property(e => e.LandedCostCd4)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("landed_cost_cd_4");
            entity.Property(e => e.LandedCostCd5)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("landed_cost_cd_5");
            entity.Property(e => e.LandedCostCd6)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("landed_cost_cd_6");
            entity.Property(e => e.LandedCostCd7)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("landed_cost_cd_7");
            entity.Property(e => e.LandedCostCd8)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("landed_cost_cd_8");
            entity.Property(e => e.LandedCostCd9)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("landed_cost_cd_9");
            entity.Property(e => e.LastActiveDt).HasColumnName("last_active_dt");
            entity.Property(e => e.LastChkAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("last_chk_amt");
            entity.Property(e => e.LateLinesYtd).HasColumnName("late_lines_ytd");
            entity.Property(e => e.LineItemYtd).HasColumnName("line_item_ytd");
            entity.Property(e => e.LstChkDt).HasColumnName("lst_chk_dt");
            entity.Property(e => e.LstStmntAgeDt).HasColumnName("lst_stmnt_age_dt");
            entity.Property(e => e.Note1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("note_1");
            entity.Property(e => e.Note2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("note_2");
            entity.Property(e => e.Note3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("note_3");
            entity.Property(e => e.Note4)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("note_4");
            entity.Property(e => e.Note5)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("note_5");
            entity.Property(e => e.NullFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("null_fg");
            entity.Property(e => e.PayeeName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("payee_name");
            entity.Property(e => e.PaymentMeth)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("payment_meth");
            entity.Property(e => e.PctLateLastY)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("pct_late_last_y");
            entity.Property(e => e.PerceptorLastChgDt).HasColumnName("Perceptor_last_chg_dt");
            entity.Property(e => e.PerceptorLastValueRetention)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Perceptor_last_value_retention");
            entity.Property(e => e.PhoneExt)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_ext");
            entity.Property(e => e.PhoneExt2)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_ext_2");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.PhoneNo2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no_2");
            entity.Property(e => e.PosYtd).HasColumnName("pos_ytd");
            entity.Property(e => e.PrintPriceFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("print_price_fg");
            entity.Property(e => e.PurchLastYr)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("purch_last_yr");
            entity.Property(e => e.PurchYtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("purch_ytd");
            entity.Property(e => e.RfcNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rfc_no");
            entity.Property(e => e.ShipViaCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ship_via_cd");
            entity.Property(e => e.SortName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sort_name");
            entity.Property(e => e.State)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.TaxSched)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_sched");
            entity.Property(e => e.UbigeoCd).HasColumnName("ubigeo_cd");
            entity.Property(e => e.UserAmount)
                .HasColumnType("decimal(13, 4)")
                .HasColumnName("user_amount");
            entity.Property(e => e.UserDefFld1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_1");
            entity.Property(e => e.UserDefFld2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_2");
            entity.Property(e => e.UserDefFld3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_3");
            entity.Property(e => e.UserDefFld4)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_4");
            entity.Property(e => e.UserDefFld5)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_5");
            entity.Property(e => e.UserDt).HasColumnName("user_dt");
            entity.Property(e => e.VendAltAdrCd)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vend_alt_adr_cd");
            entity.Property(e => e.VendName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vend_name");
            entity.Property(e => e.VendNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vend_no");
            entity.Property(e => e.VendTypeCd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vend_type_cd");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("zip");
        });

        modelBuilder.Entity<ArcusextSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ARCUSEXT_SQL");

            entity.HasIndex(e => e.UniversalCod, "ARCUSEXT_SQL1");

            entity.HasIndex(e => e.CusextNo, "IARCUSEXT_SQL0")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.ArcusextFiller)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("arcusext_filler");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.ClassCusNo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("class_cus_no");
            entity.Property(e => e.Comment)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.CrLmtGrp)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("cr_lmt_grp");
            entity.Property(e => e.CrLmtMat)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("cr_lmt_mat");
            entity.Property(e => e.CusextCd1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_cd_1");
            entity.Property(e => e.CusextCd2)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_cd_2");
            entity.Property(e => e.CusextCd3)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_cd_3");
            entity.Property(e => e.CusextCd4)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_cd_4");
            entity.Property(e => e.CusextCd5)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_cd_5");
            entity.Property(e => e.CusextCodigoAval1)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_codigo_aval_1");
            entity.Property(e => e.CusextCodigoAval2)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_codigo_aval_2");
            entity.Property(e => e.CusextCusNameExt)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_cus_name_ext");
            entity.Property(e => e.CusextDirLegal)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_dir_legal");
            entity.Property(e => e.CusextFg1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_fg_1");
            entity.Property(e => e.CusextFg2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_fg_2");
            entity.Property(e => e.CusextFg3)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_fg_3");
            entity.Property(e => e.CusextFg4)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_fg_4");
            entity.Property(e => e.CusextFg5)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_fg_5");
            entity.Property(e => e.CusextFlagMoroso)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_flag_moroso");
            entity.Property(e => e.CusextLocDistrito)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_loc_distrito");
            entity.Property(e => e.CusextLocDpto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_loc_dpto");
            entity.Property(e => e.CusextLocProvincia)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_loc_provincia");
            entity.Property(e => e.CusextMontoMaximoLetra)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("cusext_monto_maximo_letra");
            entity.Property(e => e.CusextMontoMinimoLetra)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("cusext_monto_minimo_letra");
            entity.Property(e => e.CusextNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_no");
            entity.Property(e => e.CusextTipoRetencion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_tipo_retencion");
            entity.Property(e => e.CusextTopCustomer)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_top_customer");
            entity.Property(e => e.CusextUf1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_uf_1");
            entity.Property(e => e.CusextUf2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_uf_2");
            entity.Property(e => e.CusextUf3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_uf_3");
            entity.Property(e => e.CusextUf4)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_uf_4");
            entity.Property(e => e.CusextUf5)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_uf_5");
            entity.Property(e => e.CusextUf6)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cusext_uf_6");
            entity.Property(e => e.InnerFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("inner_fg");
            entity.Property(e => e.PaFgDgh)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pa_fg_DGH");
            entity.Property(e => e.ParGrpFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("par_grp_fg");
            entity.Property(e => e.ParMatFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("par_mat_fg");
            entity.Property(e => e.ParMatNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("par_mat_no");
            entity.Property(e => e.ShoesSize)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("shoes_size");
            entity.Property(e => e.TypDocIdSnt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("typ_doc_id_snt");
            entity.Property(e => e.Typify)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("typify");
            entity.Property(e => e.UniversalCod)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("universal_cod");
        });

        modelBuilder.Entity<ArcusfilSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ARCUSFIL_SQL");

            entity.HasIndex(e => e.CusNo, "IARCUSFIL_SQL0")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.SearchName, e.A4glidentity }, "IARCUSFIL_SQL1").IsUnique();

            entity.HasIndex(e => new { e.Zip, e.A4glidentity }, "IARCUSFIL_SQL2").IsUnique();

            entity.HasIndex(e => new { e.SlspsnNo, e.A4glidentity }, "IARCUSFIL_SQL3").IsUnique();

            entity.HasIndex(e => new { e.Collector, e.A4glidentity }, "IARCUSFIL_SQL4").IsUnique();

            entity.HasIndex(e => new { e.CusTypeCd, e.A4glidentity }, "IARCUSFIL_SQL5").IsUnique();

            entity.HasIndex(e => new { e.PhoneNo, e.A4glidentity }, "IARCUSFIL_SQL6").IsUnique();

            entity.HasIndex(e => new { e.UserDefFld1, e.A4glidentity }, "IARCUSFIL_SQL7");

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.ActiveFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("active_fg");
            entity.Property(e => e.Addr1)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("addr_1");
            entity.Property(e => e.Addr2)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("addr_2");
            entity.Property(e => e.AllowBo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("allow_bo");
            entity.Property(e => e.AllowPartShip)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("allow_part_ship");
            entity.Property(e => e.AllowSbItem)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("allow_sb_item");
            entity.Property(e => e.AmtAgeOeTerm)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_age_oe_term");
            entity.Property(e => e.AmtAgePrd1)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_age_prd_1");
            entity.Property(e => e.AmtAgePrd2)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_age_prd_2");
            entity.Property(e => e.AmtAgePrd3)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_age_prd_3");
            entity.Property(e => e.AmtAgePrd4)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amt_age_prd_4");
            entity.Property(e => e.ArTermsCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ar_terms_cd");
            entity.Property(e => e.AvgPayLastYr).HasColumnName("avg_pay_last_yr");
            entity.Property(e => e.AvgPayYtd).HasColumnName("avg_pay_ytd");
            entity.Property(e => e.BalMeth)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("bal_meth");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("balance");
            entity.Property(e => e.City)
                .HasMaxLength(26)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("city");
            entity.Property(e => e.Cmt1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cmt_1");
            entity.Property(e => e.Cmt2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cmt_2");
            entity.Property(e => e.Collector)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("collector");
            entity.Property(e => e.Contact)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contact");
            entity.Property(e => e.Contact2)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contact_2");
            entity.Property(e => e.CostLastYr)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("cost_last_yr");
            entity.Property(e => e.CostPtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("cost_ptd");
            entity.Property(e => e.CostYtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("cost_ytd");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.CountryCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country_cd");
            entity.Property(e => e.CrCard1Acct)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cr_card_1_acct");
            entity.Property(e => e.CrCard1Desc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cr_card_1_desc");
            entity.Property(e => e.CrCard1ExpDt).HasColumnName("cr_card_1_exp_dt");
            entity.Property(e => e.CrCard2Acct)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cr_card_2_acct");
            entity.Property(e => e.CrCard2Desc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cr_card_2_desc");
            entity.Property(e => e.CrCard2ExpDt).HasColumnName("cr_card_2_exp_dt");
            entity.Property(e => e.CrLmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("cr_lmt");
            entity.Property(e => e.CrRating)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cr_rating");
            entity.Property(e => e.CurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("curr_cd");
            entity.Property(e => e.CusAltAdrCd)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cus_alt_adr_cd");
            entity.Property(e => e.CusName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cus_name");
            entity.Property(e => e.CusNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cus_no");
            entity.Property(e => e.CusOrigin)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cus_origin");
            entity.Property(e => e.CusTypeCd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cus_type_cd");
            entity.Property(e => e.DfltInvForm).HasColumnName("dflt_inv_form");
            entity.Property(e => e.DscPct)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("dsc_pct");
            entity.Property(e => e.EiEmailAddr)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ei_email_addr");
            entity.Property(e => e.EmailAddr)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("email_addr");
            entity.Property(e => e.ExemptNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("exempt_no");
            entity.Property(e => e.FaxNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("fax_no");
            entity.Property(e => e.Filler0002)
                .HasMaxLength(17)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0002");
            entity.Property(e => e.Filler0003)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0003");
            entity.Property(e => e.FinChgFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("fin_chg_fg");
            entity.Property(e => e.HighBalance)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("high_balance");
            entity.Property(e => e.HoldFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("hold_fg");
            entity.Property(e => e.InvLastYr).HasColumnName("inv_last_yr");
            entity.Property(e => e.InvYtd).HasColumnName("inv_ytd");
            entity.Property(e => e.LastPayAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("last_pay_amt");
            entity.Property(e => e.LastPayDt).HasColumnName("last_pay_dt");
            entity.Property(e => e.LastSaleAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("last_sale_amt");
            entity.Property(e => e.LastSaleDt).HasColumnName("last_sale_dt");
            entity.Property(e => e.LastStmAgeDt).HasColumnName("last_stm_age_dt");
            entity.Property(e => e.Loc)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("loc");
            entity.Property(e => e.Note1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("note_1");
            entity.Property(e => e.Note2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("note_2");
            entity.Property(e => e.Note3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("note_3");
            entity.Property(e => e.Note4)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("note_4");
            entity.Property(e => e.Note5)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("note_5");
            entity.Property(e => e.NullFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("null_fg");
            entity.Property(e => e.PaidInvYtd).HasColumnName("paid_inv_ytd");
            entity.Property(e => e.ParCusFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("par_cus_fg");
            entity.Property(e => e.ParCusNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("par_cus_no");
            entity.Property(e => e.PhoneExt)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_ext");
            entity.Property(e => e.PhoneExt2)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_ext_2");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.PhoneNo2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no_2");
            entity.Property(e => e.PrintDunnFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("print_dunn_fg");
            entity.Property(e => e.RfcNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rfc_no");
            entity.Property(e => e.SearchName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_name");
            entity.Property(e => e.ShipViaCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ship_via_cd");
            entity.Property(e => e.SlsLastYr)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("sls_last_yr");
            entity.Property(e => e.SlsPtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("sls_ptd");
            entity.Property(e => e.SlsYtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("sls_ytd");
            entity.Property(e => e.SlspsnNo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("slspsn_no");
            entity.Property(e => e.StartDt).HasColumnName("start_dt");
            entity.Property(e => e.State)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state");
            entity.Property(e => e.StmFreq)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("stm_freq");
            entity.Property(e => e.TaxCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd");
            entity.Property(e => e.TaxCd2)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_2");
            entity.Property(e => e.TaxCd3)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_3");
            entity.Property(e => e.TaxSched)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_sched");
            entity.Property(e => e.Terr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("terr");
            entity.Property(e => e.TxblFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("txbl_fg");
            entity.Property(e => e.UbigeoCd).HasColumnName("ubigeo_cd");
            entity.Property(e => e.UpsZone)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ups_zone");
            entity.Property(e => e.UserAmount)
                .HasColumnType("decimal(13, 4)")
                .HasColumnName("user_amount");
            entity.Property(e => e.UserDefFld1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_1");
            entity.Property(e => e.UserDefFld2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_2");
            entity.Property(e => e.UserDefFld3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_3");
            entity.Property(e => e.UserDefFld4)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_4");
            entity.Property(e => e.UserDefFld5)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_5");
            entity.Property(e => e.UserDt).HasColumnName("user_dt");
            entity.Property(e => e.VendNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vend_no");
            entity.Property(e => e.YtdDscGiven)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("ytd_dsc_given");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("zip");
        });

        modelBuilder.Entity<CmcurratSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CMCURRAT_SQL");

            entity.HasIndex(e => new { e.CurrCd, e.CurrRtEffDt }, "ICMCURRAT_SQL0")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.CurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("curr_cd");
            entity.Property(e => e.CurrRt)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("curr_rt");
            entity.Property(e => e.CurrRtCmt)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("curr_rt_cmt");
            entity.Property(e => e.CurrRtEffDt).HasColumnName("curr_rt_eff_dt");
            entity.Property(e => e.Filler0001)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0001");
        });

        modelBuilder.Entity<CmcurrteSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CMCURRTE_SQL");

            entity.HasIndex(e => new { e.RateExtCode, e.RateExtEfe }, "ICMCURRTE_SQL0")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.Filler)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler");
            entity.Property(e => e.RateComCanc)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("rate_com_canc");
            entity.Property(e => e.RateComPro)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("rate_com_pro");
            entity.Property(e => e.RateComPub)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("rate_com_pub");
            entity.Property(e => e.RateExtCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rate_ext_code");
            entity.Property(e => e.RateExtEfe).HasColumnName("rate_ext_efe");
            entity.Property(e => e.RateVenCanc)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("rate_ven_canc");
            entity.Property(e => e.RateVenDia)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("rate_ven_dia");
            entity.Property(e => e.RateVenPro)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("rate_ven_pro");
            entity.Property(e => e.RateVenPub)
                .HasColumnType("decimal(11, 6)")
                .HasColumnName("rate_ven_pub");
        });

        modelBuilder.Entity<CompfileSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("COMPFILE_SQL");

            entity.HasIndex(e => e.CompKey1, "ICOMPFILE_SQL0")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.AcctAudtTrail)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("acct_audt_trail");
            entity.Property(e => e.AddrLine1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("addr_line_1");
            entity.Property(e => e.AddrLine2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("addr_line_2");
            entity.Property(e => e.AddrLine3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("addr_line_3");
            entity.Property(e => e.BtrieveOwnerName)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("btrieve_owner_name");
            entity.Property(e => e.CompKey1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("comp_key_1");
            entity.Property(e => e.CompNoOfDec).HasColumnName("comp_no_of_dec");
            entity.Property(e => e.CompanyVersion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_version");
            entity.Property(e => e.CstDecimal).HasColumnName("cst_decimal");
            entity.Property(e => e.DatabaseTp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("database_tp");
            entity.Property(e => e.DefLocalPrter).HasColumnName("def_local_prter");
            entity.Property(e => e.DefLpt1PrtCd).HasColumnName("def_lpt1_prt_cd");
            entity.Property(e => e.DefLpt2PrtCd).HasColumnName("def_lpt2_prt_cd");
            entity.Property(e => e.DefLpt3PrtCd).HasColumnName("def_lpt3_prt_cd");
            entity.Property(e => e.DefNet0PrtCd).HasColumnName("def_net0_prt_cd");
            entity.Property(e => e.DefNet1PrtCd).HasColumnName("def_net1_prt_cd");
            entity.Property(e => e.DefNet2PrtCd).HasColumnName("def_net2_prt_cd");
            entity.Property(e => e.DefNet3PrtCd).HasColumnName("def_net3_prt_cd");
            entity.Property(e => e.DefNet4PrtCd).HasColumnName("def_net4_prt_cd");
            entity.Property(e => e.DefNtwrkPrter).HasColumnName("def_ntwrk_prter");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("display_name");
            entity.Property(e => e.DtFormat)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dt_format");
            entity.Property(e => e.EiCusNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ei_cus_no");
            entity.Property(e => e.Employees).HasColumnName("employees");
            entity.Property(e => e.Filler0001)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0001");
            entity.Property(e => e.GlAcctLev1Dgts).HasColumnName("gl_acct_lev_1_dgts");
            entity.Property(e => e.GlAcctLev2Dgts).HasColumnName("gl_acct_lev_2_dgts");
            entity.Property(e => e.GlAcctLev3Dgts).HasColumnName("gl_acct_lev_3_dgts");
            entity.Property(e => e.HasMultPrint)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("has_mult_print");
            entity.Property(e => e.HrsDecimal).HasColumnName("hrs_decimal");
            entity.Property(e => e.LocalKitFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("local_kit_fg");
            entity.Property(e => e.NoAccountingEntry)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("no_accounting_entry");
            entity.Property(e => e.NoOfDecCstPrc).HasColumnName("no_of_dec_cst_prc");
            entity.Property(e => e.NoOfLocPrt).HasColumnName("no_of_loc_prt");
            entity.Property(e => e.NoOfNetPrt).HasColumnName("no_of_net_prt");
            entity.Property(e => e.PhoneFormat)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_format");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone_no");
            entity.Property(e => e.PurgePassword)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("purge_password");
            entity.Property(e => e.RatePct1)
                .HasColumnType("decimal(15, 3)")
                .HasColumnName("rate_pct_1");
            entity.Property(e => e.RatePct2)
                .HasColumnType("decimal(15, 3)")
                .HasColumnName("rate_pct_2");
            entity.Property(e => e.RfcNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rfc_no");
            entity.Property(e => e.RoundingDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rounding_dp_no");
            entity.Property(e => e.RoundingFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rounding_fg");
            entity.Property(e => e.RoundingMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rounding_mn_no");
            entity.Property(e => e.RoundingSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rounding_sb_no");
            entity.Property(e => e.RptName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rpt_name");
            entity.Property(e => e.SpolToDskFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("spol_to_dsk_fg");
            entity.Property(e => e.SpoolToDiskDef)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("spool_to_disk_def");
            entity.Property(e => e.SpoolToNtwrkDef)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("spool_to_ntwrk_def");
            entity.Property(e => e.StartJnlHistNo).HasColumnName("start_jnl_hist_no");
            entity.Property(e => e.TypeEconomicActivity)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Type_economic_activity");
            entity.Property(e => e.UbigeoId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ubigeo_id");
            entity.Property(e => e.UserDecimal).HasColumnName("user_decimal");
            entity.Property(e => e.UsesAdDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_ad_drive");
            entity.Property(e => e.UsesAdFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_ad_fg");
            entity.Property(e => e.UsesApDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_ap_drive");
            entity.Property(e => e.UsesApFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_ap_fg");
            entity.Property(e => e.UsesArDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_ar_drive");
            entity.Property(e => e.UsesArFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_ar_fg");
            entity.Property(e => e.UsesBbDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_bb_drive");
            entity.Property(e => e.UsesBbFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_bb_fg");
            entity.Property(e => e.UsesBcDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_bc_drive");
            entity.Property(e => e.UsesBcFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_bc_fg");
            entity.Property(e => e.UsesBompDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_bomp_drive");
            entity.Property(e => e.UsesBompFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_bomp_fg");
            entity.Property(e => e.UsesCmDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_cm_drive");
            entity.Property(e => e.UsesCmFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_cm_fg");
            entity.Property(e => e.UsesCrpDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_crp_drive");
            entity.Property(e => e.UsesCrpFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_crp_fg");
            entity.Property(e => e.UsesDeDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_de_drive");
            entity.Property(e => e.UsesDeFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_de_fg");
            entity.Property(e => e.UsesEdDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_ed_drive");
            entity.Property(e => e.UsesEdFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_ed_fg");
            entity.Property(e => e.UsesGlDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_gl_drive");
            entity.Property(e => e.UsesGlFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_gl_fg");
            entity.Property(e => e.UsesImDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_im_drive");
            entity.Property(e => e.UsesImFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_im_fg");
            entity.Property(e => e.UsesJcDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_jc_drive");
            entity.Property(e => e.UsesJcFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_jc_fg");
            entity.Property(e => e.UsesJeDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_je_drive");
            entity.Property(e => e.UsesJeFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_je_fg");
            entity.Property(e => e.UsesLpDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_lp_drive");
            entity.Property(e => e.UsesLpFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_lp_fg");
            entity.Property(e => e.UsesMmDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_mm_drive");
            entity.Property(e => e.UsesMmFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_mm_fg");
            entity.Property(e => e.UsesMrpDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_mrp_drive");
            entity.Property(e => e.UsesMrpFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_mrp_fg");
            entity.Property(e => e.UsesMsDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_ms_drive");
            entity.Property(e => e.UsesMsFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_ms_fg");
            entity.Property(e => e.UsesMvDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_mv_drive");
            entity.Property(e => e.UsesMvFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_mv_fg");
            entity.Property(e => e.UsesOeDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_oe_drive");
            entity.Property(e => e.UsesOeFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_oe_fg");
            entity.Property(e => e.UsesPoDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_po_drive");
            entity.Property(e => e.UsesPoFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_po_fg");
            entity.Property(e => e.UsesPpDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_pp_drive");
            entity.Property(e => e.UsesPpFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_pp_fg");
            entity.Property(e => e.UsesPrDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_pr_drive");
            entity.Property(e => e.UsesPrFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_pr_fg");
            entity.Property(e => e.UsesRmDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_rm_drive");
            entity.Property(e => e.UsesRmFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_rm_fg");
            entity.Property(e => e.UsesSfcDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_sfc_drive");
            entity.Property(e => e.UsesSfcFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_sfc_fg");
            entity.Property(e => e.UsesSpcDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_spc_drive");
            entity.Property(e => e.UsesSpcFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_spc_fg");
            entity.Property(e => e.UsesSprDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_spr_drive");
            entity.Property(e => e.UsesSprFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_spr_fg");
            entity.Property(e => e.UsesSyDrive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_sy_drive");
            entity.Property(e => e.UsesSyFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_sy_fg");
            entity.Property(e => e.UsesTtsFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_tts_fg");
            entity.Property(e => e.UsesTtsTrxFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("uses_tts_trx_fg");
            entity.Property(e => e.VersOfSftwr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vers_of_sftwr");
            entity.Property(e => e.VersionFg)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("version_fg");
        });

        modelBuilder.Entity<SyactfilSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYACTFIL_SQL");

            entity.HasIndex(e => new { e.MnNo, e.SbNo, e.DpNo }, "ISYACTFIL_SQL0")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.SearchDesc, e.A4glidentity }, "ISYACTFIL_SQL1").IsUnique();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.AcctDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("acct_desc");
            entity.Property(e => e.AcctDesc2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("acct_desc_2");
            entity.Property(e => e.AnalisisFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("analisis_fg");
            entity.Property(e => e.AutoDistCd).HasColumnName("auto_dist_cd");
            entity.Property(e => e.CBalDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("c_bal_dp_no");
            entity.Property(e => e.CBalMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("c_bal_mn_no");
            entity.Property(e => e.CBalSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("c_bal_sb_no");
            entity.Property(e => e.ClassId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("class_id");
            entity.Property(e => e.CompCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("comp_cd");
            entity.Property(e => e.ConslDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("consl_dp_no");
            entity.Property(e => e.ConslMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("consl_mn_no");
            entity.Property(e => e.ConslSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("consl_sb_no");
            entity.Property(e => e.DcsApFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dcs_ap_fg");
            entity.Property(e => e.DcsFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dcs_fg");
            entity.Property(e => e.DcsMixFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dcs_mix_fg");
            entity.Property(e => e.DpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dp_no");
            entity.Property(e => e.Filler0001)
                .HasMaxLength(67)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0001");
            entity.Property(e => e.FinStmtTp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("fin_stmt_tp");
            entity.Property(e => e.GlobalDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("global_dp_no");
            entity.Property(e => e.GlobalFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("global_fg");
            entity.Property(e => e.GlobalMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("global_mn_no");
            entity.Property(e => e.GlobalSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("global_sb_no");
            entity.Property(e => e.GpId).HasColumnName("gp_id");
            entity.Property(e => e.InflationType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("inflation_type");
            entity.Property(e => e.IsLocalFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_local_fg");
            entity.Property(e => e.JobFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("job_fg");
            entity.Property(e => e.LocalCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("local_cd");
            entity.Property(e => e.MnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mn_no");
            entity.Property(e => e.NotShowDistributionFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("not_show_distribution_fg");
            entity.Property(e => e.NullFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("null_fg");
            entity.Property(e => e.ParCtlCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("par_ctl_cd");
            entity.Property(e => e.RatioTp)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ratio_tp");
            entity.Property(e => e.SafTp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("saf_tp");
            entity.Property(e => e.SbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sb_no");
            entity.Property(e => e.SearchDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_desc");
            entity.Property(e => e.SfmcpFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sfmcp_fg");
            entity.Property(e => e.StatFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("stat_fg");
            entity.Property(e => e.SubtotalDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("subtotal_desc");
            entity.Property(e => e.SyCurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_curr_cd");
            entity.Property(e => e.SyTypeCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sy_type_cd");
            entity.Property(e => e.TbSbTotLev).HasColumnName("tb_sb_tot_lev");
            entity.Property(e => e.UseId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("use_id");
            entity.Property(e => e.UserDefFld1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_1");
            entity.Property(e => e.UserDefFld2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_2");
            entity.Property(e => e.UserDefFld3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_3");
            entity.Property(e => e.UserDefFld4)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_4");
            entity.Property(e => e.UserDefFld5)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_5");
            entity.Property(e => e.ValidAp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_ap");
            entity.Property(e => e.ValidAr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_ar");
            entity.Property(e => e.ValidBb)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_bb");
            entity.Property(e => e.ValidBc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_bc");
            entity.Property(e => e.ValidBm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_bm");
            entity.Property(e => e.ValidCc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_cc");
            entity.Property(e => e.ValidCm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_cm");
            entity.Property(e => e.ValidCr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_cr");
            entity.Property(e => e.ValidDe)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_de");
            entity.Property(e => e.ValidFx)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_fx");
            entity.Property(e => e.ValidGl)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_gl");
            entity.Property(e => e.ValidIm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_im");
            entity.Property(e => e.ValidJe)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_je");
            entity.Property(e => e.ValidLp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_lp");
            entity.Property(e => e.ValidMc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_mc");
            entity.Property(e => e.ValidMr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_mr");
            entity.Property(e => e.ValidMs)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_ms");
            entity.Property(e => e.ValidOe)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_oe");
            entity.Property(e => e.ValidPo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_po");
            entity.Property(e => e.ValidPp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_pp");
            entity.Property(e => e.ValidPr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_pr");
            entity.Property(e => e.ValidRm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_rm");
            entity.Property(e => e.ValidSc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_sc");
            entity.Property(e => e.ValidSf)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_sf");
            entity.Property(e => e.ValidSr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("valid_sr");
        });

        modelBuilder.Entity<SycshfilSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYCSHFIL_SQL");

            entity.HasIndex(e => new { e.MnNo, e.SbNo, e.DpNo }, "ISYCSHFIL_SQL0")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.CashAcctDesc, e.A4glidentity }, "ISYCSHFIL_SQL1").IsUnique();

            entity.HasIndex(e => new { e.SearchAcctDesc, e.A4glidentity }, "ISYCSHFIL_SQL2").IsUnique();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.BankBal)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("bank_bal");
            entity.Property(e => e.BankBalance)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("bank_balance");
            entity.Property(e => e.BankId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("bank_id");
            entity.Property(e => e.BankName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("bank_name");
            entity.Property(e => e.CashAcctDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_acct_desc");
            entity.Property(e => e.CashExchDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_exch_dp_no");
            entity.Property(e => e.CashExchMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_exch_mn_no");
            entity.Property(e => e.CashExchSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cash_exch_sb_no");
            entity.Property(e => e.ChkControlProcessFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("chk_control_process_fg");
            entity.Property(e => e.CshHomeCurrFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("csh_home_curr_fg");
            entity.Property(e => e.CurrCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("curr_cd");
            entity.Property(e => e.DcsBbFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dcs_bb_fg");
            entity.Property(e => e.DpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dp_no");
            entity.Property(e => e.Filler0001)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0001");
            entity.Property(e => e.Filler0002)
                .HasMaxLength(26)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0002");
            entity.Property(e => e.LastBankUpdate).HasColumnName("last_bank_update");
            entity.Property(e => e.LastReconDt).HasColumnName("last_recon_dt");
            entity.Property(e => e.LetToGenerateCheckFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("let_to_generate_check_fg");
            entity.Property(e => e.MnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mn_no");
            entity.Property(e => e.NextApChk).HasColumnName("next_ap_chk");
            entity.Property(e => e.NextPrChk).HasColumnName("next_pr_chk");
            entity.Property(e => e.NoGenerateBbFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("no_generate_bb_fg");
            entity.Property(e => e.NullFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("null_fg");
            entity.Property(e => e.RecBalance)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("rec_balance");
            entity.Property(e => e.SbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sb_no");
            entity.Property(e => e.SearchAcctDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("search_acct_desc");
        });

        modelBuilder.Entity<SyprdfilSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SYPRDFIL_SQL");

            entity.HasIndex(e => e.PrdKey, "ISYPRDFIL_SQL0")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.CurrentPrd).HasColumnName("current_prd");
            entity.Property(e => e.DefPrdCd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("def_prd_cd");
            entity.Property(e => e.EndDt1).HasColumnName("end_dt_1");
            entity.Property(e => e.EndDt10).HasColumnName("end_dt_10");
            entity.Property(e => e.EndDt11).HasColumnName("end_dt_11");
            entity.Property(e => e.EndDt12).HasColumnName("end_dt_12");
            entity.Property(e => e.EndDt13).HasColumnName("end_dt_13");
            entity.Property(e => e.EndDt2).HasColumnName("end_dt_2");
            entity.Property(e => e.EndDt3).HasColumnName("end_dt_3");
            entity.Property(e => e.EndDt4).HasColumnName("end_dt_4");
            entity.Property(e => e.EndDt5).HasColumnName("end_dt_5");
            entity.Property(e => e.EndDt6).HasColumnName("end_dt_6");
            entity.Property(e => e.EndDt7).HasColumnName("end_dt_7");
            entity.Property(e => e.EndDt8).HasColumnName("end_dt_8");
            entity.Property(e => e.EndDt9).HasColumnName("end_dt_9");
            entity.Property(e => e.Filler0001)
                .HasMaxLength(87)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0001");
            entity.Property(e => e.NoOfValPrd).HasColumnName("no_of_val_prd");
            entity.Property(e => e.PrdKey)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("prd_key");
            entity.Property(e => e.StrDt1).HasColumnName("str_dt_1");
            entity.Property(e => e.StrDt10).HasColumnName("str_dt_10");
            entity.Property(e => e.StrDt11).HasColumnName("str_dt_11");
            entity.Property(e => e.StrDt12).HasColumnName("str_dt_12");
            entity.Property(e => e.StrDt13).HasColumnName("str_dt_13");
            entity.Property(e => e.StrDt2).HasColumnName("str_dt_2");
            entity.Property(e => e.StrDt3).HasColumnName("str_dt_3");
            entity.Property(e => e.StrDt4).HasColumnName("str_dt_4");
            entity.Property(e => e.StrDt5).HasColumnName("str_dt_5");
            entity.Property(e => e.StrDt6).HasColumnName("str_dt_6");
            entity.Property(e => e.StrDt7).HasColumnName("str_dt_7");
            entity.Property(e => e.StrDt8).HasColumnName("str_dt_8");
            entity.Property(e => e.StrDt9).HasColumnName("str_dt_9");
            entity.Property(e => e.TmpYrClsFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tmp_yr_cls_fg");
            entity.Property(e => e.WarnOrPrev)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("warn_or_prev");
            entity.Property(e => e.WrnprvGlprdFg1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprd_fg_1");
            entity.Property(e => e.WrnprvGlprdFg2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprd_fg_2");
            entity.Property(e => e.WrnprvGlprdFg3)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprd_fg_3");
            entity.Property(e => e.WrnprvGlprdFg4)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprd_fg_4");
            entity.Property(e => e.WrnprvGlprdFg5)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprd_fg_5");
            entity.Property(e => e.WrnprvGlprdFg6)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprd_fg_6");
            entity.Property(e => e.WrnprvGlprdFg7)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprd_fg_7");
            entity.Property(e => e.WrnprvGlprdFg8)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprd_fg_8");
            entity.Property(e => e.WrnprvGlprdFg9)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprd_fg_9");
            entity.Property(e => e.WrnprvGlprdfg10)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprdfg_10");
            entity.Property(e => e.WrnprvGlprdfg11)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprdfg_11");
            entity.Property(e => e.WrnprvGlprdfg12)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprdfg_12");
            entity.Property(e => e.WrnprvGlprdfg13)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("wrnprv_glprdfg_13");
        });

        modelBuilder.Entity<TaxdetlSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TAXDETL_SQL");

            entity.HasIndex(e => new { e.PkgId, e.TaxCd }, "ITAXDETL_SQL0")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.AltTaxCd, e.A4glidentity }, "ITAXDETL_SQL1").IsUnique();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.AltTaxCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alt_tax_cd");
            entity.Property(e => e.AmountBaseReten)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("amount_base_reten");
            entity.Property(e => e.ApplyMinMax)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("apply_min_max");
            entity.Property(e => e.BaseTaxCalc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("base_tax_calc");
            entity.Property(e => e.DifDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dif_dp_no");
            entity.Property(e => e.DifMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dif_mn_no");
            entity.Property(e => e.DifSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dif_sb_no");
            entity.Property(e => e.DpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("dp_no");
            entity.Property(e => e.ExpDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("exp_dp_no");
            entity.Property(e => e.ExpMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("exp_mn_no");
            entity.Property(e => e.ExpSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("exp_sb_no");
            entity.Property(e => e.Filler0001)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0001");
            entity.Property(e => e.FrtFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("frt_fg");
            entity.Property(e => e.LowerCdsFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lower_cds_fg");
            entity.Property(e => e.MaxTaxAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("max_tax_amt");
            entity.Property(e => e.MinTaxAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("min_tax_amt");
            entity.Property(e => e.MiscChgFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("misc_chg_fg");
            entity.Property(e => e.MiscPtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("misc_ptd");
            entity.Property(e => e.MiscYtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("misc_ytd");
            entity.Property(e => e.MnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mn_no");
            entity.Property(e => e.PkgId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pkg_id");
            entity.Property(e => e.RetDpNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ret_dp_no");
            entity.Property(e => e.RetMnNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ret_mn_no");
            entity.Property(e => e.RetSbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ret_sb_no");
            entity.Property(e => e.RetenBaseAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("reten_base_amt");
            entity.Property(e => e.RetenPct)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("reten_pct");
            entity.Property(e => e.SbNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sb_no");
            entity.Property(e => e.SlsPtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("sls_ptd");
            entity.Property(e => e.SlsYtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("sls_ytd");
            entity.Property(e => e.TaxAmt)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("tax_amt");
            entity.Property(e => e.TaxCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd");
            entity.Property(e => e.TaxCdDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_desc");
            entity.Property(e => e.TaxMeth)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_meth");
            entity.Property(e => e.TaxPct)
                .HasColumnType("decimal(6, 4)")
                .HasColumnName("tax_pct");
            entity.Property(e => e.TaxTxblFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_txbl_fg");
            entity.Property(e => e.TaxesPtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("taxes_ptd");
            entity.Property(e => e.TaxesYtd)
                .HasColumnType("decimal(14, 2)")
                .HasColumnName("taxes_ytd");
            entity.Property(e => e.TermMonths).HasColumnName("term_months");
            entity.Property(e => e.UserDefFld1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_1");
            entity.Property(e => e.UserDefFld2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_2");
            entity.Property(e => e.UserDefFld3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_3");
            entity.Property(e => e.UserDefFld4)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_4");
            entity.Property(e => e.UserDefFld5)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_5");
        });

        modelBuilder.Entity<TaxschedSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TAXSCHED_SQL");

            entity.HasIndex(e => e.TaxSched, "ITAXSCHED_SQL0")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.MiscTaxSched, e.A4glidentity }, "ITAXSCHED_SQL1").IsUnique();

            entity.HasIndex(e => new { e.FrtTaxSched, e.A4glidentity }, "ITAXSCHED_SQL2").IsUnique();

            entity.Property(e => e.A4glidentity)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("A4GLIdentity");
            entity.Property(e => e.ApplyRdpFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("apply_rdp_fg");
            entity.Property(e => e.CalculationSystemCd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("calculation_system_cd");
            entity.Property(e => e.EiTaxSched)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ei_tax_sched");
            entity.Property(e => e.ExportFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("export_fg");
            entity.Property(e => e.Filler0001)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("filler_0001");
            entity.Property(e => e.FreeTitleFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("free_title_fg");
            entity.Property(e => e.FrtTaxSched)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("frt_tax_sched");
            entity.Property(e => e.InTaxSched)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("in_tax_sched");
            entity.Property(e => e.MiscTaxSched)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("misc_tax_sched");
            entity.Property(e => e.RentCd)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rent_cd");
            entity.Property(e => e.TaxCd)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd");
            entity.Property(e => e.TaxCd02)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_02");
            entity.Property(e => e.TaxCd03)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_03");
            entity.Property(e => e.TaxCd04)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_04");
            entity.Property(e => e.TaxCd05)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_05");
            entity.Property(e => e.TaxCd06)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_06");
            entity.Property(e => e.TaxCd07)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_07");
            entity.Property(e => e.TaxCd08)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_08");
            entity.Property(e => e.TaxCd09)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_09");
            entity.Property(e => e.TaxCd10)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_10");
            entity.Property(e => e.TaxCd11)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_11");
            entity.Property(e => e.TaxCd12)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_12");
            entity.Property(e => e.TaxCd13)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_13");
            entity.Property(e => e.TaxCd14)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_14");
            entity.Property(e => e.TaxCd15)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_15");
            entity.Property(e => e.TaxCd16)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_16");
            entity.Property(e => e.TaxCd17)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_17");
            entity.Property(e => e.TaxCd18)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_18");
            entity.Property(e => e.TaxCd19)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_19");
            entity.Property(e => e.TaxCd20)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_20");
            entity.Property(e => e.TaxCd21)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_21");
            entity.Property(e => e.TaxCd22)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_22");
            entity.Property(e => e.TaxCd23)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_23");
            entity.Property(e => e.TaxCd24)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_24");
            entity.Property(e => e.TaxCd25)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_25");
            entity.Property(e => e.TaxCd26)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_26");
            entity.Property(e => e.TaxCd27)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_27");
            entity.Property(e => e.TaxCd28)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_28");
            entity.Property(e => e.TaxCd29)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_29");
            entity.Property(e => e.TaxCd30)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_30");
            entity.Property(e => e.TaxCd31)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_31");
            entity.Property(e => e.TaxCd32)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_32");
            entity.Property(e => e.TaxCd33)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_33");
            entity.Property(e => e.TaxCd34)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_34");
            entity.Property(e => e.TaxCd35)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_35");
            entity.Property(e => e.TaxCd36)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_36");
            entity.Property(e => e.TaxCd37)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_37");
            entity.Property(e => e.TaxCd38)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_38");
            entity.Property(e => e.TaxCd39)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_39");
            entity.Property(e => e.TaxCd40)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_40");
            entity.Property(e => e.TaxCd41)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_41");
            entity.Property(e => e.TaxCd42)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_42");
            entity.Property(e => e.TaxCd43)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_43");
            entity.Property(e => e.TaxCd44)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_44");
            entity.Property(e => e.TaxCd45)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_45");
            entity.Property(e => e.TaxCd46)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_46");
            entity.Property(e => e.TaxCd47)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_47");
            entity.Property(e => e.TaxCd48)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_48");
            entity.Property(e => e.TaxCd49)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_49");
            entity.Property(e => e.TaxCd50)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_50");
            entity.Property(e => e.TaxCd51)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_51");
            entity.Property(e => e.TaxCd52)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_52");
            entity.Property(e => e.TaxCd53)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_53");
            entity.Property(e => e.TaxCd54)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_54");
            entity.Property(e => e.TaxCd55)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_55");
            entity.Property(e => e.TaxCd56)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_56");
            entity.Property(e => e.TaxCd57)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_57");
            entity.Property(e => e.TaxCd58)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_58");
            entity.Property(e => e.TaxCd59)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_59");
            entity.Property(e => e.TaxCd60)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_60");
            entity.Property(e => e.TaxCd61)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_61");
            entity.Property(e => e.TaxCd62)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_62");
            entity.Property(e => e.TaxCd63)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_63");
            entity.Property(e => e.TaxCd64)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_64");
            entity.Property(e => e.TaxCd65)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_65");
            entity.Property(e => e.TaxCd66)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_66");
            entity.Property(e => e.TaxCd67)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_67");
            entity.Property(e => e.TaxCd68)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_68");
            entity.Property(e => e.TaxCd69)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_69");
            entity.Property(e => e.TaxCd70)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_70");
            entity.Property(e => e.TaxCd71)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_71");
            entity.Property(e => e.TaxCd72)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_72");
            entity.Property(e => e.TaxCd73)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_73");
            entity.Property(e => e.TaxCd74)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_74");
            entity.Property(e => e.TaxCd75)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_75");
            entity.Property(e => e.TaxCd76)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_76");
            entity.Property(e => e.TaxCd77)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_77");
            entity.Property(e => e.TaxCd78)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_78");
            entity.Property(e => e.TaxCd79)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_79");
            entity.Property(e => e.TaxCd80)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_80");
            entity.Property(e => e.TaxCd81)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_81");
            entity.Property(e => e.TaxCd82)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_82");
            entity.Property(e => e.TaxCd83)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_83");
            entity.Property(e => e.TaxCd84)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_84");
            entity.Property(e => e.TaxCd85)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_85");
            entity.Property(e => e.TaxCd86)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_86");
            entity.Property(e => e.TaxCd87)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_87");
            entity.Property(e => e.TaxCd88)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_88");
            entity.Property(e => e.TaxCd89)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_89");
            entity.Property(e => e.TaxCd90)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_90");
            entity.Property(e => e.TaxCd91)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_91");
            entity.Property(e => e.TaxCd92)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_92");
            entity.Property(e => e.TaxCd93)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_93");
            entity.Property(e => e.TaxCd94)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_94");
            entity.Property(e => e.TaxCd95)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_95");
            entity.Property(e => e.TaxCd96)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_96");
            entity.Property(e => e.TaxCd97)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_97");
            entity.Property(e => e.TaxCd98)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_98");
            entity.Property(e => e.TaxCd99)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_cd_99");
            entity.Property(e => e.TaxPurchasesSalesFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_purchases_sales_fg");
            entity.Property(e => e.TaxSched)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_sched");
            entity.Property(e => e.TaxSchedDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_sched_desc");
            entity.Property(e => e.TaxZeroFg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_zero_fg");
            entity.Property(e => e.TypeAffectationCd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type_affectation_cd");
            entity.Property(e => e.UnTaxSched)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("un_tax_sched");
            entity.Property(e => e.UserDefFld1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_1");
            entity.Property(e => e.UserDefFld2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_2");
            entity.Property(e => e.UserDefFld3)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_3");
            entity.Property(e => e.UserDefFld4)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_4");
            entity.Property(e => e.UserDefFld5)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("user_def_fld_5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
