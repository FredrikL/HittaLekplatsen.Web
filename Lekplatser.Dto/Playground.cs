namespace Lekplatser.Dto
{
    public class Playground
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }
//        public float Rating { get; set; }

        public bool HasSwing { get; set; }
        public bool HasSlide { get; set; }
        public bool HasSandbox { get; set; }

        public bool HasBenches { get; set; }
        public bool HasPublicToilet { get; set; }
    }
}
