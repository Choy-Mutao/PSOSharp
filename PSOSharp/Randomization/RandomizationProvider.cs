namespace PSOSharp.Randomization
{
    public static class RandomizationProvider
    {

        /// <summary>
        /// Gets or sets the current IRandomization implementation.
        /// </summary>
        /// <value>The current.</value>
        public static IRandomization KISS { get; set; }

        /// <summary>
        /// Initializes static members of the <see cref="RandomizationProvider"/> class.
        /// </summary>
        static RandomizationProvider()
        {
            KISS = new KISSRandomization();
        }
    }
}
