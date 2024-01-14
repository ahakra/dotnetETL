namespace SharedEntites.Model;

public class MSSMSEntity{
    
    
    public string CallingNumber { get; set; }
    public string CalledNumber { get; set; }
    public decimal Duration { get; set; }
    public DateTime CallTime { get; set; }
    public string Bundle { get; set; }
    public string ServiceClassId { get; set; }
    public string Traffic { get; set; }
    
}