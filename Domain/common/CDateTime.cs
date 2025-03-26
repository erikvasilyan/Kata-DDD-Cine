namespace Domain.common;

public class CDateTime : ValueObject
{
    private DateTime Value { get; init; }
    
    private CDateTime(DateTime value) => Value = value;
    
    public static CDateTime Now => new(DateTime.Now);
}