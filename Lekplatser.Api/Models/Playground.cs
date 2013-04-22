namespace Lekplatser.Api.Models
{
    public class Playground
    {
        public string PlaygroundId { get; set; }

        public string Name { get; set; }

        public float Lat { get; set; }
        public float Long { get; set; }

        public float Rating { get; set; }

        public bool HasSwing { get; set; }
        public bool HasSlide { get; set; }
        public bool HasSandbox { get; set; }

        public bool HasBenches { get; set; }
        public bool HasPublicToilet { get; set; }
    }
}