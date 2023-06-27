namespace Apanvi.API.Models
{
    public class User : Person // colocou q a classe user usa a classe Person como referencia
    {
        public String Roles { get; set; } 
        public bool CanEdit { get; set; }
        public bool CanDelete{ get; set; }

        public User(string name, string roles) //construtor  passando name e lista 
        {
            Name = name;
            Roles = roles;
            CanEdit = roles.Contains("Admin") || roles.Contains("SuperAdmin");
            CanDelete = roles.Contains("SuperAdmin");
        }
    }
}


        