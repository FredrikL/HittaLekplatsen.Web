namespace Lekplatser.Dto
{
    public class Location
    {
        public Location() : this(0,0) { }

        public Location(float lat, float lng)
        {
            Lat = lat;
            Long = lng;
        }

        public float Lat { get; set; }
        public float Long { get; set; }

    }
}