namespace Apanvi.API.Models
{
    public class User : Person 
    {
        public String Roles { get; set; } 
        public bool CanEdit { get; set; }
        public bool CanDelete{ get; set; }

        public User(string name, string roles) 
        {
            Name = name;
            Roles = roles;
            CanEdit = roles.Contains("Admin") || roles.Contains("SuperAdmin");
            CanDelete = roles.Contains("SuperAdmin");
        }
    }
}


        