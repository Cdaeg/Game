using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : Object
{

	public Player(int x, int y) : base(x, y)
	{
		this.Speed = 10;
	}
	public void Move()
	{
		if (Keyboard.GetState().IsKeyDown(Keys.A))
		{
            DirMove("left");
		}
        if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
            DirMove("right");
        }
        if (Keyboard.GetState().IsKeyDown(Keys.W))
        {
            DirMove("up");
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            DirMove("down");
        }
    }
    public void DirMove(string direction)
    {
        if (direction == "up")
        {
            this.Y -= this.Speed;
        }
        if (direction == "down")
        {
            this.Y += this.Speed;
        }
        if (direction == "left")
        {
            this.X -= this.Speed;
        }
        if (direction == "right")
        {
            this.X += this.Speed;
        }
    }
}
