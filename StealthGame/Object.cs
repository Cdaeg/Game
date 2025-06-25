using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Object
{
	private Rectangle _rect;
	private int speed;
	public Rectangle Rect
	{
		get { return _rect; }
		set { _rect = value; }
	}
	public int X
	{
		get { return _rect.X; }
		set { _rect.X = value; }
	}
    public int Y
    {
        get { return _rect.Y; }
        set { _rect.Y = value; }
    }
    public int Speed
	{
		get { return speed; }
		set { speed = value; }
	}
	public Object(int x, int y)
	{
		_rect = new Rectangle(x, y, 20, 20);
	}
}
