using BusinessData.Interfaces;
using BusinessEntity.Data;
using BusinessEntity.Data.Models;
using Common.Services;
using Common.ViewModels;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData.Data
{
    public class CompfileRepository: ICompfileRepository
    {
        private DbConexion _context;
        private readonly ConnectionManager _connectionmanager;
        public CompfileRepository(DbConexion context, ConnectionManager connectionmanager){
            this._context = context;
            _connectionmanager = connectionmanager;
        }
        public async Task<bool> F_Actualizar(CompfileSql compfileSql){
            // Crear el contexto con la conexión obtenida
            bool resultado = false;
            using (var context = new DbConexion(_connectionmanager.F_ObtenerCredenciales())){
                // Buscar el registro a modificar
                var compania = context.CompfileSqls.FirstOrDefault(c => c.CompKey1 == compfileSql.CompKey1);
                if (compania != null){
                    // Modificar los valores
                    compania.RptName = compfileSql.RptName;
                    compania.DisplayName = compfileSql.DisplayName;
                    compania.AddrLine1 = compfileSql.AddrLine1;
                    compania.AddrLine2 = compfileSql.AddrLine2;
                    compania.AddrLine3 = compfileSql.AddrLine3;
                    compania.PhoneNo = compfileSql.PhoneNo;
                    compania.GlAcctLev1Dgts = compfileSql.GlAcctLev1Dgts;
                    compania.GlAcctLev2Dgts = compfileSql.GlAcctLev2Dgts;
                    compania.GlAcctLev3Dgts = compfileSql.GlAcctLev3Dgts;
                    compania.StartJnlHistNo = compfileSql.StartJnlHistNo;
                    compania.TypeEconomicActivity = compfileSql.TypeEconomicActivity;
                    compania.Employees= compfileSql.Employees;
                    compania.EiCusNo = compfileSql.EiCusNo;
                    compania.RatePct1 = compfileSql.RatePct1;
                    compania.RatePct2 = compfileSql.RatePct2;
                    // Guardar los cambios en la base de datos
                    context.SaveChanges();
                    resultado = true;
                }
            }
            return resultado;
        }
        public async Task<CompfileSql> F_ListarUno(CompfileSql compfileSql){
            CompfileSql compania = new CompfileSql();
            using (var context = new DbConexion(_connectionmanager.F_ObtenerCredenciales())){
                compania = context.CompfileSqls.FirstOrDefault(c => c.CompKey1 == compfileSql.CompKey1);
            }
            if (compania != null){
                foreach (var prop in compania.GetType().GetProperties()){
                    if (prop.PropertyType == typeof(string)){
                        var valor = prop.GetValue(compania) as string;
                        if (valor != null){
                            prop.SetValue(compania, valor.Trim());
                        }
                    }
                }
            }
            return compania;
        }
    }
}
