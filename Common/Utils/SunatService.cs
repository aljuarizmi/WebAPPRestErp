using Common.Interfaces;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class SunatService:ISunatService
    {
        private readonly HttpClient _httpClient;
        public SunatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SunatTDO> ConsultaSUNAT(string dato, EnumTipoDato tipo)
        {
            var result = new SunatTDO();
            try
            {
                string url = tipo switch
                {
                    EnumTipoDato.RUC => $"https://api.apis.net.pe/v1/ruc?numero={dato}",
                    EnumTipoDato.DNI => $"https://api.apis.net.pe/v1/dni?numero={dato}",
                    EnumTipoDato.TipoCambio => $"https://api.apis.net.pe/v1/tipo-cambio-sunat?fecha={dato}",
                    _ => throw new ArgumentException("Tipo no permitido.")
                };

                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    result.out_band = 1;
                    result.mensaje = $"Error al consultar: {response.ReasonPhrase}";
                    return result;
                }

                string json = await response.Content.ReadAsStringAsync();
                var objSunat = JsonSerializer.Deserialize<SunatTDO>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return objSunat ?? new SunatTDO { mensaje = "No se pudo deserializar la respuesta", out_band = 1 };
            }
            catch (Exception ex)
            {
                result.out_band = 1;
                result.mensaje = ex.Message;
                return result;
            }
        }
    }
}
