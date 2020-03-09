using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Universe
{

    public struct ViewInfo
    {
        public Point camera;
        public int width, height;
    }
    public static class DrawUniverse
    {
        public static bool IsViewField(Point camera, AstronomicalObject obj, int width, int height)
        {
            return (camera.X < obj.Position.X + width
                && camera.X > obj.Position.X - width
                && camera.Y > obj.Position.Y - height
                && camera.Y < obj.Position.Y + height);
        }

        public static void DrawCircle(Point camera, AstronomicalObject obj, Color color, Graphics g)
        {
            Point pos = new Point(obj.Position.X - camera.X, obj.Position.Y - camera.Y);
            g.FillEllipse(new SolidBrush(color), (int)(pos.X - obj.Size),
                (int)(pos.Y - obj.Size), (int)(pos.X + obj.Size), (int)(pos.Y + obj.Size));
        }

        public static Color GetColor(Star star)
        {
            Color color = Color.Red;
            if (star.Temperature < 3500)
            {
                color = Color.FromArgb(255, 160, 64);
            }
            else if (star.Temperature < 5000)
            {
                color = Color.FromArgb(255, 228, 111);
            }
            else if (star.Temperature < 6000)
            {
                color = Color.FromArgb(255, 242, 161);
            }
            else if (star.Temperature < 7500)
            {
                color = Color.FromArgb(248, 247, 255);
            }
            else if (star.Temperature < 10000)
            {
                color = Color.FromArgb(248, 247, 255);
            }
            else if (star.Temperature < 30000)
            {
                color = Color.FromArgb(202, 215, 255);
            }
            else if (star.Temperature < 60000)
                color = Color.FromArgb(170, 191, 255);
            return color;
        }
        //звезда главной послеовательности
        public static void DrawStar(Star star, Point camera, int height, int width, Graphics g)
        {
           
            if (IsViewField(camera, star, width, height))
            {
                Color color = GetColor(star); 
                DrawCircle(camera, star, color, g);
                
            }
        }

        public static void DrawStarSystem(Star star, Point camera, Graphics g, int width, int height)
        {
            Color color = GetColor(star);
            g.FillEllipse(new SolidBrush(color), (int)(width / 2 - camera.X), (int)(height / 2 - camera.Y),
                    (int)star.Size, (int)star.Size);
            for (int i = 0; i < star.PlanetsAmount; i++)
                DrawPlanet((Planet)star[i], camera, height, width, g);
        }

        public static void DrawPlanet(Planet planet, Point camera, int height, int width, Graphics g)
        {
            Color color = Color.Blue;
            if (IsViewField(camera, planet, width, height))
            {
                DrawCircle(camera, planet, color, g);
            }
        }
    }
}
