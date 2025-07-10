using System;

public class Enemy : Object
{
	public Enemy(int x, int y) : base(x, y)
	{
		this.Speed = 5;
	}
	public void Move()
	{
		this.Y += this.Speed;
		if (this.Y+this.Rect.Height > 600)
		{
			this.Speed = -5;
		}
        if (this.Y < 50)
        {
            this.Speed = 5;
        }
    }
}
