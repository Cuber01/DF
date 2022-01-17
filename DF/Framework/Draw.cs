using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DF.Framework
{
	public class DrawUtils
	{
		private static Texture2D pixel;
		private readonly GraphicsDevice graphicsDevice;
		private readonly SpriteBatch spriteBatch;

		public DrawUtils(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
		{
			this.spriteBatch = spriteBatch;
			this.graphicsDevice = graphicsDevice;

			pixel = new Texture2D(this.graphicsDevice, 1, 1);
			pixel.SetData(new[] { Color.White });
		}
		
		public void spixel(int x, int y, Color color)
		{
			spriteBatch.Draw(pixel, new Vector2(x, y), color);
		}

		public void circle(int x, int y, int r, Color color)
		{
			for (double i = 0; i < 2 * Math.PI; i = i + 0.1)
			{
				spixel((int)(x + r * Math.Sin(i)), (int)(y + r * Math.Cos(i)), color);
			}
		}
		
		private void straightLine(int x1, int y1, int x2, int y2, Color color)
		{
			if (x1 == x2 && y1 == y2)
			{
				spixel(x1, x2, color);
			}
			else if (x1 < x2 && y1 == y2)
			{
				for (int x = x1; x <= x2; x++)
				{
					spixel(x, y1, color);
				}
			}
			else if (x1 > x2 && y1 == y2)
			{
				for (int x = x1; x >= x2; x--)
				{
					spixel(x, y1, color);
				}
			}
			else if (x1 == x2 && y1 < y2)
			{
				for (int y = y1; y <= y2; y++)
				{
					spixel(x1, y, color);
				}
			}
			else if (x1 == x2 && y1 > y2)
			{
				for (int y = y1; y >= y2; y--)
				{
					spixel(x1, y1, color);
				}
			}
			else
			{
				throw new Exception("Straight lines have straight coordinates. Dummy.");
			}


		}

		public void bersenhamLine(int x1, int y1, int x2, int y2, Color color)
		{
			int x, y, xe, ye, i;

			int dx = x2 - x1;
			int dy = y2 - y1;

			int dx1 = Math.Abs(dx);
			int dy1 = Math.Abs(dy);

			int px = 2 * dy1 - dx1;
			int py = 2 * dx1 - dy1;

			if (dy1 <= dx1)
			{
				if (dx >= 0)
				{
					x = x1;
					y = y1;
					xe = x2;
				}
				else
				{
					x = x2;
					y = y2;
					xe = x1;
				}

				spixel(x, y, color);

				for (i = 0; x < xe; i++)
				{
					x = x + 1;
					if (px < 0)
					{
						px = px + 2 * dy1;
					}
					else
					{
						if ((dx < 0 && dy < 0) || (dx > 0 && dy > 0))
						{
							y = y + 1;
						}
						else
						{
							y = y - 1;
						}

						px = px + 2 * (dy1 - dx1);
					}

					spixel(x, y, color);
				}
			}
			else
			{
				if (dy >= 0)
				{
					x = x1;
					y = y1;
					ye = y2;
				}
				else
				{
					x = x2;
					y = y2;
					ye = y1;
				}

				spixel(x, y, color);
				for (i = 0; y < ye; i++)
				{
					y = y + 1;
					if (py <= 0)
					{
						py = py + 2 * dx1;
					}
					else
					{
						if ((dx < 0 && dy < 0) || (dx > 0 && dy > 0))
						{
							x = x + 1;
						}
						else
						{
							x = x - 1;
						}

						py = py + 2 * (dx1 - dy1);
					}


					spixel(x, y, color);
				}
			}
		}

		public void drawRectangle(Rectangle rect, Color color, bool filled)
		{
			if (filled)
			{
				spriteBatch.Draw(pixel, rect, color);
			}
			else
			{
				straightLine(rect.X,                 rect.Y,                  rect.X + rect.Width -1,  rect.Y,                  color);
				straightLine(rect.X,                 rect.Y,                  rect.X,                  rect.Y + rect.Height -1, color);
				straightLine(rect.X + rect.Width -1, rect.Y,                  rect.X + rect.Width -1,  rect.Y + rect.Height -1, color);
				straightLine(rect.X,                 rect.Y + rect.Height -1, rect.X + rect.Width -1,  rect.Y + rect.Height -1, color);
			}
		}

	}
}