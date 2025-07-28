using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace StealthGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player player;
    private Enemy enemy;
    private Random rand;
    private Texture2D floor;
    private Texture2D obj;
    private int[][] tiles;
    private Rectangle[][] walls;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        player = new Player(25, 300);
        enemy = new Enemy(400, 50);
        tiles = new int[25][];
        walls = new Rectangle[25][];
        rand = new Random();
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = new int[25];
            for (int j = 0; j < tiles[i].Length; j++)
            {
                if (i == 0 || i == 24 || j == 0 || j == 24 || (i == 13 && j > 4 && j < 21))
                {
                    tiles[i][j] = 1;
                }
                else
                {
                    tiles[i][j] = 0;
                }
            }
        }
        for (int i = 0; i < 6; i++)
        {
            int x = rand.Next(0, 25);
            int y = rand.Next(0, 25);
            while (tiles[x][y] != 0)
            {
                x = rand.Next(0, 25);
                y = rand.Next(0, 25);
            }
            tiles[x][y] = 2;
        }
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i] = new Rectangle[25];
            for (int j = 0; j < walls[i].Length; j++)
            {
                walls[i][j] = new Rectangle(i * 25, j * 25, 25, 25);
            }
        }
        _graphics.IsFullScreen = false;
        _graphics.PreferredBackBufferWidth = 625;
        _graphics.PreferredBackBufferHeight = 625;
        _graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        floor = Content.Load<Texture2D>("Floor");
        obj = Content.Load<Texture2D>("Object");
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        player.Move();
        for (int x = 0; x < walls.Length; x++)
        {
            for (int y = 0; y < walls[x].Length; y++)
            {
                if (player.Rect.Intersects(walls[x][y]) && tiles[x][y] == 1)
                {
                    if ((x*25) < player.X)
                    {
                        player.DirMove("right");
                    }
                    if ((x*25) > player.X)
                    {
                        player.DirMove("left");
                    }
                    if ((y*25) < player.Y)
                    {
                        player.DirMove("down");
                    }
                    if ((y*25) > player.Y)
                    {
                        player.DirMove("up");
                    }
                    System.Diagnostics.Debug.WriteLine(player.X + "  " + player.Y + "   " + x + "  " + y);
                }
                if (player.Rect.Intersects(walls[x][y]) && tiles[x][y] == 2)
                {
                    tiles[x][y] = 0;
                }
            }
        }
        if (player.Rect.Intersects(enemy.Rect))
        {
            player.X = 30;
            player.Y = 30;
        }
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
                if (tiles[x][y] == 1)
                {
                    _spriteBatch.Draw(floor, walls[x][y], Color.Black);
                }
                else if (tiles[x][y] == 2)
                {
                    _spriteBatch.Draw(floor, walls[x][y], Color.Green);
                }
                else
                {
                    _spriteBatch.Draw(floor, walls[x][y], Color.White);
                }
            }
        }
        _spriteBatch.Draw(obj, player.Rect, Color.Blue);
        _spriteBatch.Draw(obj, enemy.Rect, Color.Red);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
