using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MiniGame
{
    public class MiniGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int _sirkaOkna = 800;
        private int _vyskaOkna = 600;

        private Ctverecek _ctverecek;

        public MiniGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "MiniGame";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = _sirkaOkna;
            _graphics.PreferredBackBufferHeight = _vyskaOkna;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _ctverecek = new Ctverecek(
                50, 5,
                new Vector2((_sirkaOkna - 50) / 2, (_vyskaOkna - 50) / 2),
                new SmeroveOvladani(Keys.Left, Keys.Right, Keys.Up, Keys.Down),
                new Rectangle(0, 0, _sirkaOkna, _vyskaOkna),
                Color.Black, GraphicsDevice
            );
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState klavesnice = Keyboard.GetState();

            if (klavesnice.IsKeyDown(Keys.Escape))
                Exit();

            _ctverecek.Aktualizovat(klavesnice);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            _ctverecek.Vykreslit(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
