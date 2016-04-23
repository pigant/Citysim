using Citysim.Map;

namespace Citysim
{
    public class City
    {
        /// <summary>
        /// Amount of cash available.
        /// </summary>
        public int cash = 10000; // $10,000 starting cash

        /// <summary>
        /// The world. Needs generation.
        /// </summary>
        public World world = new World();
    }
}
