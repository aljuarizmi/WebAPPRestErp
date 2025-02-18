using BusinessData.Interfaces;
using BusinessEntity.Data.Models;
using BusinessEntity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Common.ViewModels;

namespace BusinessData.Data
{
    public class ApvenextRepository: IApvenextRepository
    {
        private readonly DbConexion _context;

        public ApvenextRepository(DbConexion context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<ApvenextSql> items, int totalCount)> GetAllAsync(string searchQuery, int pageNumber, int pageSize)
        {
            //return await _context.ApvenextSqls.ToListAsync();
            var query = _context.ApvenextSqls.AsQueryable();

            // Búsqueda: filtrar por un campo específico (por ejemplo, nombre)
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(a => a.VenextNo.Contains(searchQuery)); // Suponiendo que AlfCd es un campo en ApvenextSql
            }

            // Paginación: aplicar los parámetros de página
            var totalCount = await query.CountAsync(); // Total de registros que cumplen con la búsqueda
            var items = await query
                .Skip((pageNumber - 1) * pageSize) // Descartar los registros previos a la página actual
                .Take(pageSize) // Tomar solo la cantidad de registros correspondiente a la página
                .ToListAsync(); // Ejecutar la consulta y obtener los registros

            return (items, totalCount); // Devolver los registros y el total de registros encontrados
        }

        public async Task<ApvenextSql> GetByIdAsync(int id)
        {
            return await _context.ApvenextSqls.FindAsync(id);
        }

        public async Task AddAsync(ApvenextSql entity)
        {
            await _context.ApvenextSqls.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ApvenextSql entity)
        {
            _context.ApvenextSqls.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ApvenextSqls.FindAsync(id);
            if (entity != null)
            {
                _context.ApvenextSqls.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Usar un procedimiento almacenado con parámetros y mapear los resultados a un DTO
        public async Task<IEnumerable<ApvenextDTO>> GetByStoredProcedureAsync()
        {
            //var parameterName = new SqlParameter("@ParameterName", parameter);

            // Ejecutamos el procedimiento almacenado
            var resultado = await _context.Database
            .SqlQueryRaw<ApvenextDTO>("EXEC USP_AP_M06S01N01_LISTAR_PROVEEDORES_APVENFIL_SQL")
            .ToListAsync();
            return resultado;
        }
    }
}
