using Citysim.Map;

namespace Citysim
{
    public class City
    {
        /// <summary>
        /// Amount of cash available. Measured in thousands (k).
        /// </summary>
        public int cash = 50; // $50k starting cash

        /// <summary>
        /// MW (mega watts) of electricity available to the city.
        /// </summary>
        public int power = 0;

        /// <summary>
        /// ML (mega litres) of water available to the city.
        /// </summary>
        public int water = 0;

        /// <summary>
        /// The world. Needs generation.
        /// </summary>
        public World world = new World();
    }
}
