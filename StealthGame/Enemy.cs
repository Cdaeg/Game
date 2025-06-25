using System;

public class Enemy : Object
{
	public Enemy(int x, int y) : base(x, y)
	{
		this.Speed = 20;
	}
	public void Move()
	{
		this.Y += this.Speed;
	}
}
