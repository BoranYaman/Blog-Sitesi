namespace HifiBlog.Entity;
public class Blog
{
 public int BlogId{ get; set; }
 public string? BlogImg { get; set; }
 public string? BlogName { get; set;}
 public string? BlogText{ get; set; }
   public DateTime? PublishedOn { get; set; } 
   public string? TypeOfUse{ get; set; }
   public string? ConnectionType{get; set; }
   public string? JakType{ get; set; } 
   public string? FrequencyRange { get;set;} 
   public string? SoundLoudity { get; set; } 
    public string? Weight { get; set; } 
    public string? DriveType{ get; set; }
    public string? ActiveNoiseCanceling { get; set; }  
    public string? Impedance { get; set; } 
    public string? BlogTag { get; set; }
    public string? IsActive{ get; set; }
    public string?  HighlightsValue {get;set;}
    
    
}