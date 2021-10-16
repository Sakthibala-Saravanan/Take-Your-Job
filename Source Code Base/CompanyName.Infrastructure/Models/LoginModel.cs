namespace AspireSystems.Infrastructure.Models
{
    public class LoginModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string[] Roles { get; set; }
        public string[] Privileges { get; set; }
    }
    public class MembershipModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }
        public string Privileges { get; set; }
    }
}
