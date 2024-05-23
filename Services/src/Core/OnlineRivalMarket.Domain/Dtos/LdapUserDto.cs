namespace OnlineRivalMarket.Domain.Dtos
{
    public class LdapUserDto
    {
        public Data Data { get; set; }
        public List<string> ErrorMessages { get; set; }
        public bool IsSuccessful { get; set; }
    }

    public class Data
    {
        public string Id { get; set; }
        public string SamAccountName { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string SidValue { get; set; }
        public string EmailAddress { get; set; }
        // public string Password { get; set; }
    }


    public class LdapUserDtos
    {
        public List<Data> Data { get; set; } // Changed to List<UserData>
        public List<string> ErrorMessages { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
