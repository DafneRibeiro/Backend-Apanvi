

namespace Apanvi.API.Models
{
    public class Animal
    {
        public string Name { get; set; } = string.Empty;
        public Species Species { get; set; }
        public Size Size { get; set; }
        public Genre Genre { get; set; }
        public String? Description { get; set; }
        public Uri? Image { get; set; }

    }
}
