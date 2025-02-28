namespace BusinessEntity.Data.Models;

public partial class CmcurrteSql
{
    public string RateExtCode { get; set; } = null!;

    public int RateExtEfe { get; set; }

    public decimal? RateVenDia { get; set; }

    public decimal? RateComPub { get; set; }

    public decimal? RateVenPub { get; set; }

    public decimal? RateComPro { get; set; }

    public decimal? RateVenPro { get; set; }

    public string? Filler { get; set; }

    public decimal A4glidentity { get; set; }

    public decimal? RateComCanc { get; set; }

    public decimal? RateVenCanc { get; set; }
}
