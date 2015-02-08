using System;

namespace _01.GalacticGPS
{
    public class GPSMain
    {
        public static void Main()
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);

            Console.WriteLine(home);

            Console.ReadKey();
        }
    }
}
