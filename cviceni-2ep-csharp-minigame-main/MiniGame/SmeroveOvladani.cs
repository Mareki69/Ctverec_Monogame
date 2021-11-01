using Microsoft.Xna.Framework.Input;

namespace MiniGame
{
    class SmeroveOvladani
    {
        public Keys Doprava { get; private set; }
        public Keys Doleva{ get; private set; }
        public Keys Nahoru { get; private set; }
        public Keys Dolu { get; private set; }

        public SmeroveOvladani(Keys doleva, Keys doprava, Keys nahoru, Keys dolu)
        {
            Doprava = doprava;
            Doleva = doleva;
            Nahoru = nahoru;
            Dolu = dolu;
        }
    }
}
