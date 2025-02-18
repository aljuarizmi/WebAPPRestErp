using System;
using System.Collections.Generic;
using BusinessEntity.Data.Models;
using Common.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BusinessEntity.Data;

public partial class DbConexion : DbContext
{
    public DbConexion()
    {
    }

    public DbConexion(DbContextOptions<DbConexion> options)
        : base(options)
    {
    }

    public virtual DbSet<ApvenextSql> ApvenextSqls { get; set; }

    public virtual DbSet<ApvenfilSql> ApvenfilSqls { get; set; }

    public virtual DbSet<ArcusextSql> ArcusextSqls { get; set; }

    public virtual DbSet<ArcusfilSql> ArcusfilSqls { get; set; }

    // Esto es necesario para que EF Core pueda mapear los resultados del procedimiento almacenado
    //public virtual DbSet<ApvenextDTO> ApvenextDto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JACKIE;Database=DATA_400;User Id=ADMIN_SQL;Password=FINDEAÑO;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApvenextSql>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("APVENEXT_SQL", tb => tb.HasTrigger("TR_APVENEXT_AUDI"));

            entity.HasIndex(e => e.VenextNo, "IAPVENEXT_SQL0")
                .IsUnique()
                .IsClustered();

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
                .IsFixedLength()
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
                .ToTable("APVENFIL_SQL", tb => tb.HasTrigger("TR_APVENFIL_AUDI"));

            entity.HasIndex(e => e.VendNo, "IAPVENFIL_SQL0")
                .IsUnique()
                .IsClustered()
                .HasFillFactor(80);

            entity.HasIndex(e => new { e.SortName, e.A4glidentity }, "IAPVENFIL_SQL1")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => new { e.Zip, e.A4glidentity }, "IAPVENFIL_SQL2")
                .IsUnique()
                .HasFillFactor(80);

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
                .HasMaxLength(50)
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
                .ToTable("ARCUSEXT_SQL", tb => tb.HasTrigger("TR_ARCUSEXT_AUDI"));

            entity.HasIndex(e => e.UniversalCod, "ARCUSEXT_SQL1");

            entity.HasIndex(e => e.CusextNo, "IARCUSEXT_SQL0")
                .IsUnique()
                .IsClustered()
                .HasFillFactor(80);

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
                .IsFixedLength()
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
                .ToTable("ARCUSFIL_SQL", tb => tb.HasTrigger("TR_ARCUSFIL_AUDI"));

            entity.HasIndex(e => e.CusNo, "IARCUSFIL_SQL0")
                .IsUnique()
                .IsClustered()
                .HasFillFactor(80);

            entity.HasIndex(e => new { e.SearchName, e.A4glidentity }, "IARCUSFIL_SQL1")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => new { e.Zip, e.A4glidentity }, "IARCUSFIL_SQL2")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => new { e.SlspsnNo, e.A4glidentity }, "IARCUSFIL_SQL3")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => new { e.Collector, e.A4glidentity }, "IARCUSFIL_SQL4")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => new { e.CusTypeCd, e.A4glidentity }, "IARCUSFIL_SQL5")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => new { e.PhoneNo, e.A4glidentity }, "IARCUSFIL_SQL6")
                .IsUnique()
                .HasFillFactor(80);

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
                .HasMaxLength(50)
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

        //modelBuilder.Entity<ApvenextDTO>().HasNoKey();  // ❌ Evita error de clave primaria

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
