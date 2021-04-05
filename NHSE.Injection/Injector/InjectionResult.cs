namespace NHSE.Injection
{
    public enum InjectionResult
    {
        Skipped,
        Success,
        FailValidate,
        FailConnectionError,
        FailBadSize,
        Same,
    }
}
