using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Enemy : Object
{
	private Rectangle goal;
	private Rectangle[][] _walls;
	public Enemy(int x, int y, Rectangle[][] walls) : base(x, y)
	{
		this.Speed = 5;
		_walls = walls;
		goal = walls[16][22];
	}
	public void Move()
	{
		if (goal.X > this.X)
		{
			this.X += this.Speed;
		}
		if (goal.X < this.X)
		{
			this.X -= this.Speed;
		}
		if (goal.Y > this.Y)
		{
			this.Y += this.Speed;
		}
        if (goal.Y < this.Y)
        {
            this.Y -= this.Speed;
        }
    }
	public void Search(Rectangle target, int[][] tiles)
	{
		Rectangle origin=_walls[0][0];
		for (int x = 0; x < _walls.Length; x++)
		{
			for (int y = 0; y < _walls[x].Length; y++)
			{
				if (this.Rect.Intersects(_walls[x][y]))
				{
					origin = _walls[x][y];
				}
			}
		}
		if (goal.X < this.X)
		{
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if ((origin.X / 25) - x < 0 || (origin.Y / 25) - y < 0)
                    {
                        x = 5;
                        y = 5;
                        break;
                    }
                    if (_walls[(origin.X / 25) - x][(origin.Y / 25) - y].Intersects(target))
                    {
                        goal = _walls[(origin.X / 25) - x][(origin.Y / 25) - y];
                        x = 5;
                        y = 5;
                    }
                    else if (tiles[(origin.X / 25) - x][(origin.Y / 25) - y] == 1 || tiles[(origin.X / 25) - x][(origin.Y / 25) - y + 1] == 1)
                    {
                        x = 5;
                    }
                }
                for (int x = 0; x < 5; x++)
                {
                    if ((origin.X / 25) + x >= 25|| (origin.Y / 25) - y<0)
                    {
                        x = 5;
                        y = 5;
                        break;
                    }
                    if (_walls[(origin.X / 25) + x][(origin.Y / 25) - y].Intersects(target))
                    {
                        goal = _walls[(origin.X / 25) + x][(origin.Y / 25) - y];
                        x = 5;
                        y = 5;
                    }
                    else if (tiles[(origin.X / 25) + x][(origin.Y / 25) - y] == 1 || tiles[(origin.X / 25) + x][(origin.Y / 25) - y + 1] == 1)
                    {
                        x = 5;
                    }
                }
            }
		}
		else
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if ((origin.Y / 25) + y >= 25 || (origin.X / 25) - x < 0)
                    {
                        x = 5;
                        y = 5;
                        break;
                    }
                    if (_walls[(origin.X / 25) - x][(origin.Y / 25) + y].Intersects(target))
                    {
                        goal = _walls[(origin.X / 25) - x][(origin.Y / 25) + y];
                        x = 5;
                        y = 5;
                    }
                    else if (tiles[(origin.X / 25) - x][(origin.Y / 25) + y] == 1 || tiles[(origin.X / 25) - x][(origin.Y / 25) + y - 1] == 1)
                    {
                        x = 5;
                    }
                }
                for (int x = 0; x < 5; x++)
                {
                    if ((origin.Y / 25) + y >= 25 || (origin.X / 25) + x >= 25)
                    {
                        x = 5;
                        y = 5;
                        break;
                    }
                    if (_walls[(origin.X / 25) + x][(origin.Y / 25) + y].Intersects(target))
                    {
                        goal = _walls[(origin.X / 25) + x][(origin.Y / 25) + y];
                        x = 5;
                        y = 5;
                    }
                    else if (tiles[(origin.X / 25) + x][(origin.Y / 25) + y] == 1 || tiles[(origin.X / 25) + x][(origin.Y / 25) + y - 1] == 1)
                    {
                        x = 5;
                    }
                }
            }
        }
        if (goal.Intersects(this.Rect))
		{
			if (this.Rect.Y > 300)
			{
				goal = _walls[16][4];
			}
			else
			{
				goal = _walls[16][22];
			}
		}
        System.Diagnostics.Debug.WriteLine(goal.X + " " + goal.Y + " " + _walls[16][22].X + " " + _walls[16][22].Y);
	}
}
