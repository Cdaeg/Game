using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StealthGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player plaver;
    private Enemy enemy;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        plaver = new Player(0, 0);
        enemy = new Enemy(0, 0);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        plaver.Move();
        enemy.Move();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);


        _spriteBatch.Begin();
        for (int x = 0; x < 25; x++)
        {
            for (int y = 0; y < 25; y++)
            {
                _spriteBatch.Draw(new Texture2D(GraphicsDevice, 15, 15), new Rectangle(x * 25, y * 25, 25, 25), Color.White);
            }
        }
        _spriteBatch.Draw(new Texture2D(GraphicsDevice, 10, 10), plaver.Rect, Color.Beige);
        _spriteBatch.Draw(new Texture2D(GraphicsDevice, 10, 10), enemy.Rect, Color.Red);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
