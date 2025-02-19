using BusinessData.Interfaces;
using BusinessEntity.Data;
using BusinessEntity.Data.Models;
using Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Data
{
    public class ApvenfilRepository: IApvenfilRepository
    {
        private readonly DbConexion _context;

        public ApvenfilRepository(DbConexion context)
        {
            _context = context;
        }
        public async Task<int> F_InsertarProveedor(ApvenfilSql apvenfilbe,ApvenextSql apvenextbe)
        {
            int filasAfectadas = await _context.Database.ExecuteSqlRawAsync(
                "EXEC usp_ar_insertar_prov @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, " +
                "@p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19, @p20, " +
                "@p21, @p22, @p23, @p24, @p25, @p26, @p27, @p28, @p29, @p30, " +
                "@p31, @p32, @p33, @p34, @p35, @p36, @p37, @p38, @p39, @p40, " +
                "@p41, @p42, @p43, @p44, @p45, @p46, @p47, @p48, @p49, @p50, " +
                "@p51, @p52, @p53, @p54, @p55, @p56, @p57, @p58, @p59, @p60, @p61 ",
                parameters: new object[] { apvenfilbe.VendNo, apvenfilbe.VendName!, apvenfilbe.SortName, apvenfilbe.Addr1, apvenfilbe.Addr2, apvenfilbe.City, apvenfilbe.State, apvenfilbe.Zip, apvenfilbe.Country, apvenfilbe.PhoneNo,
                apvenfilbe.PhoneExt,apvenfilbe.PhoneNo2,apvenfilbe.PhoneExt2,apvenfilbe.FaxNo,apvenfilbe.Contact,apvenfilbe.VendTypeCd,apvenfilbe.ApTermsCd,apvenfilbe.CusNo,apvenfilbe.FobCd,apvenfilbe.ShipViaCd,
                apvenfilbe.UserDefFld1,apvenfilbe.CurrCd,apvenfilbe.TaxSched,apvenfilbe.DfltPoForm,apvenfilbe.EmailAddr,apvenfilbe.UserDefFld2,apvenfilbe.UserDefFld3,1,apvenfilbe.FedIdType,apvenextbe.VenextLocDistrito,
                apvenextbe.VenextLocProvincia,apvenextbe.VenextLocDpto,apvenextbe.VenextDirLegal,apvenextbe.VenextIsNat,apvenextbe.VenextApellidoPat,apvenextbe.VenextApellidoMat,apvenextbe.VenextNombres,apvenextbe.VenextFg01,apvenextbe.VenextUf1,apvenextbe.CusextCd4,
                apvenextbe.VenextUf2,apvenextbe.VenextUf3,apvenextbe.Typify,apvenextbe.UniversalCod,apvenextbe.TypDocIdSnt,apvenextbe.AlfCd,apvenextbe.VenextFg04,apvenextbe.VenextFg05,apvenextbe.BankAcctType,apvenextbe.InterFg,
                apvenextbe.TransferBankAccount,apvenextbe.CountryCd,apvenextbe.ConvenantCd,apvenextbe.LicenseCar,apvenextbe.TrademarkCar,apvenfilbe.ErEmailAddr,apvenfilbe.UbigeoCd,apvenextbe.LcFg,apvenextbe.OfficeCode,apvenextbe.Responsible,apvenextbe.LicenseShipper,apvenextbe.VenextFg02}
            );
            return filasAfectadas;
        }
        // Usar un procedimiento almacenado con parámetros y mapear los resultados a un DTO
        public async Task<IEnumerable<ApvenfilDTO>> F_ListarProveedores()
        {
            // Ejecutamos el procedimiento almacenado
            Type tipoModelo = typeof(ApvenfilDTO);
            bool tieneAtributos= tipoModelo.GetProperties(BindingFlags.Public | BindingFlags.Instance).Any();
            if (tieneAtributos) {
                var resultado = await _context.Database
                .SqlQueryRaw<ApvenfilDTO>("EXEC USP_AP_M06S01N01_LISTAR_PROVEEDORES_APVENFIL_SQL")
                .ToListAsync();
                return resultado;
            } else {
                throw new Exception("El modelo ApvenfilDTO no tiene atributos definidos. No se puede ejecutar la consulta a la BD.");
            }
        }
    }
}
