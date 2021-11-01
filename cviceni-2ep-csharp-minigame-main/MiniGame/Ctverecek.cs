using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MiniGame
{
    class Ctverecek
    {
        private GraphicsDevice _zobrazovac { get; set; }

        private int _velikost { get; set; }
        private int _rychlost { get; set; }

        private Color _barva { get; set; }

        private Vector2 _pozice { get; set; }
        private Texture2D _textura { get; set; }

        private SmeroveOvladani _ovladaniPohybu { get; set; }

        public Ctverecek(int velikost, int rychlost, Vector2 pozice, SmeroveOvladani ovladaniPohybu, Rectangle omezeniPohybu, Color barva, GraphicsDevice zobrazovac)
        {
            _velikost = velikost;
            _rychlost = rychlost;

            _ovladaniPohybu = ovladaniPohybu;

            _barva = barva;
            _pozice = pozice;

            _zobrazovac = zobrazovac;
            _textura = PripravitTexturu();
        }

        private Texture2D PripravitTexturu()
        {
            Texture2D vyslednaTextura = new Texture2D(_zobrazovac, _velikost, _velikost);

            Color[] pixely = new Color[_velikost * _velikost];
            for (int i = 0; i < pixely.Length; i++)
                pixely[i] = Color.White;
            vyslednaTextura.SetData(pixely);
            
            return vyslednaTextura;
        }

        private void Pohnout(KeyboardState klavesnice)
        {
            Vector2 smerPohybu = Vector2.Zero;

            if (klavesnice.IsKeyDown(_ovladaniPohybu.Doprava))
                smerPohybu += Vector2.UnitX;
            if (klavesnice.IsKeyDown(_ovladaniPohybu.Doleva))
                smerPohybu -= Vector2.UnitX;
            if (klavesnice.IsKeyDown(_ovladaniPohybu.Nahoru))
                smerPohybu -= Vector2.UnitY;
            if (klavesnice.IsKeyDown(_ovladaniPohybu.Dolu))
                smerPohybu += Vector2.UnitY;

            if (smerPohybu != Vector2.Zero)
                _pozice += _rychlost * Vector2.Normalize(smerPohybu);
        }

        public void Aktualizovat(KeyboardState klavesnice)
        {
            Pohnout(klavesnice);
        }

        public void Vykreslit(SpriteBatch _vykreslovac)
        {
            _vykreslovac.Draw(_textura, _pozice, _barva);
        }
    }
}
