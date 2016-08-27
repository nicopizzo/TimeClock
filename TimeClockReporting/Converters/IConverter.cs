namespace TimeClock.Reporting.Converters
{
    public interface IConverter
    {
        string ConvertReport(BaseReport report);
    }
}
