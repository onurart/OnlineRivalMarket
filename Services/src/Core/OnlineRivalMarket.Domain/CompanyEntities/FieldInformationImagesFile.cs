namespace OnlineRivalMarket.Domain.CompanyEntities;
public  class FieldInformationImagesFile : Entity
{
    public FieldInformationImagesFile(){}
    public FieldInformationImagesFile(string id,string fieldInformationId,string fieldInformationUrls) : base(id)
    {FieldInformationId = fieldInformationId;FieldInformationFileUrls = fieldInformationUrls;}
    [ForeignKey(nameof(FieldInformation))]
    public string FieldInformationId { get; set; }
    public string FieldInformationFileUrls { get; set; }

}
