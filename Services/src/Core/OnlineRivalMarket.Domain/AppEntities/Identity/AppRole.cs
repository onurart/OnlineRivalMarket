namespace OnlineRivalMarket.Domain.AppEntities.Identity;
public sealed class  AppRole : IdentityRole<string>
{
    public AppRole(){}
    public AppRole(string title,string code,string name)
    {
        Id=Guid.NewGuid().ToString();
        Code=code;
        Tİtle =title;
        NormalizedName=name;
    }

    public string Code { get; set; }
    public string Tİtle { get; set; }
}
