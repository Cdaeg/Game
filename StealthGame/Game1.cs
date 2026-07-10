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
    private Texture2D bear;
    private Texture2D penguin;
    private Texture2D fish;
    private int[][] tiles;
    private int level;
    private Rectangle[][] walls;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        tiles = new int[25][];
        walls = new Rectangle[25][];
        player = new Player(25, 300);
        level = 1;
        rand = new Random();
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i] = new int[25];
            for (int j = 0; j < tiles[i].Length; j++)
            {
                if (i == 0 || i == 24 || j == 0 || j == 24)
                {
                    tiles[i][j] = 1;
                }
                else
                {
                    tiles[i][j] = 0;
                }
            }
        }
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i] = new Rectangle[25];
            for (int j = 0; j < walls[i].Length; j++)
            {
                walls[i][j] = new Rectangle(i * 25, j * 25, 25, 25);
            }
        }
        for (int i = 0; i < 6; i++)
        {
            int x = rand.Next(0, 25);
            int y = rand.Next(0, 25);
            while (tiles[x][y] != 0 || walls[x][y].Intersects(player.Rect))
            {
                x = rand.Next(0, 25);
                y = rand.Next(0, 25);
            }
            tiles[x][y] = 2;
        }
        enemy = new Enemy(400, 50, walls);
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
        bear = Content.Load<Texture2D>("Bear");
        penguin = Content.Load<Texture2D>("Penguin");
        fish = Content.Load<Texture2D>("Fish");
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        player.Move();
        switch (level)
        {
            case 1:
                for (int i = 0; i < tiles.Length; i++)
                {
                    for (int j = 0; j < tiles[i].Length; j++)
                    {
                        if (i == 0 || i == 24 || j == 0 || j == 24 || (i == 13 && j > 4 && j < 21))
                        {
                            tiles[i][j] = 1;
                        }
                        else if (tiles[i][j]!=2)
                        {
                            tiles[i][j] = 0;
                        }
                    }
                }
                break;
            case 2:
                for (int i = 0; i < tiles.Length; i++)
                {
                    for (int j = 0; j < tiles[i].Length; j++)
                    {
                        if (i == 0 || i == 24 || j == 0 || j == 24 || (i == 14 && j > 6 && j < 12) || (i == 14 && j > 14 && j < 20) || (i == 10 && j > 6 && j < 12) || (i == 10 && j > 14 && j < 20))
                        {
                            tiles[i][j] = 1;
                        }
                        else if (tiles[i][j] != 2)
                        {
                            tiles[i][j] = 0;
                        }
                    }
                }
                break;
        }
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
        enemy.Search(player.Rect, tiles);
        if (Check_Fish() == false)
        {
            level++;
            player.X = 30;
            player.Y = 30;
            enemy.X = 300;
            enemy.Y = 150;
            enemy.Goal = walls[12][19];
            enemy.StartPoint = walls[12][6];
            enemy.EndPoint = walls[12][19];
            for (int i = 0; i < 6; i++)
            {
                int x = rand.Next(0, 25);
                int y = rand.Next(0, 25);
                while (tiles[x][y] != 0 || walls[x][y].Intersects(player.Rect))
                {
                    x = rand.Next(0, 25);
                    y = rand.Next(0, 25);
                }
                tiles[x][y] = 2;
            }
        }
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
                    _spriteBatch.Draw(fish, walls[x][y], Color.White);
                }
                else
                {
                    _spriteBatch.Draw(floor, walls[x][y], Color.White);
                }
            }
        }
        _spriteBatch.Draw(penguin, player.Rect, Color.White);
        if (enemy.Goal.X > enemy.X)
        {
            _spriteBatch.Draw(bear, enemy.Rect, Color.White);
        }
        else
        {
            _spriteBatch.Draw(bear, enemy.Rect, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
    private bool Check_Fish()
    {
        for (int x = 0; x < tiles.Length; x++)
        {
            for (int y = 0; y < tiles[x].Length; y++)
            {
                if (tiles[x][y] == 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
