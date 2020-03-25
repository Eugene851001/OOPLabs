using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UniverseEditor
{
    class MainFormButtonCreater
    {
        int counter;

        const int startX = 300;
        const int startY = 90;
        const int deltaY = 10;
        const int deltaX = 10;
        const int width = 75;
        const int height = 20;

        public MainFormButtonCreater()
        {
            counter = 0;
        }

        Point GetLocation()
        {
            return new Point(startX, startY + (deltaY + height) * counter);
        }

        public Button GetButton(string name, string text)
        {
            Button result = new Button();
            result.Name = name;
            result.Text = text;
            result.Location = GetLocation();
            result.Width = width;
            result.Height = height;
            counter++;
            return result;
        }

    }
}
