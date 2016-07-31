namespace TimeClockReporting.Converters
{
    public interface IConverter
    {
        string ConvertReport(BaseReport report);
    }
}
