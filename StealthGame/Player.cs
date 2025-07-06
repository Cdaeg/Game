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
			this.X -= this.Speed;
		}
        if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
            this.X += this.Speed;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.W))
        {
            this.Y -= this.Speed;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            this.Y += this.Speed;
        }
    }
}
