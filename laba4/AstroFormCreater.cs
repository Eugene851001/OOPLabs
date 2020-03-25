using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using OOPLaba3;
using System.Windows.Forms;
using Universe;

namespace UniverseEditor
{
    class AstroFormCreater: IAstroFormGetter
    {
        
        const int startY = 109;
        const int startX = 22;
        const int deltaHeight = 10;
        const int height = 50;
        const int width = 50;
        const int ListBoxSize = 100;

        frmEditAstro editor;

        delegate void CreateField(PropertyInfo prop, AstronomicalObject obj, ref int counter);
        Dictionary<Type, CreateField> fieldsConstructors;

        System.Drawing.Point GetLocation(int counter)
        {
            return new System.Drawing.Point(startX, startY + deltaHeight
                + (deltaHeight + height) * counter);
        }

        Label GetLabel(PropertyInfo prop, int counter)
        {
            Label label = new Label();
            label.Name = "lb" + prop.Name;
            label.Text = prop.Name;
            label.Location = GetLocation(counter);
            label.Height = height;
            label.Width = width;
            return label;
        }

        TextBox GetTextBox(PropertyInfo prop, AstronomicalObject obj, int counter)
        {
            TextBox textBox = new TextBox();
            textBox.Name = "tb" + prop.Name;
            textBox.Text = prop.GetValue(obj).ToString();
            textBox.Location = GetLocation(counter);
            textBox.Location = new System.Drawing.Point(textBox.Location.X + width, textBox.Location.Y);
            textBox.Height = height;
            textBox.Width = width;
            return textBox;
        }

        ListBox GetListBox(PropertyInfo prop, AstronomicalObject obj, int counter)
        {
            ListBox listBox = new ListBox();
            List<AstronomicalObject> astroObjects = (List<AstronomicalObject>)prop.GetValue(obj);
            foreach(var astroObject in astroObjects)
            {
                listBox.Items.Add(astroObject);
            }
            listBox.Name = "lb" + prop.Name;
            listBox.Location = GetLocation(counter);
            listBox.Location = new System.Drawing.Point() {X = listBox.Location.X + width, Y = listBox.Location.Y };
            listBox.Height = listBox.Width = ListBoxSize;
            return listBox;
        }

        void AddIntField(PropertyInfo prop, AstronomicalObject obj, ref int counter)
        {
            Label label = GetLabel(prop, counter);
            TextBox textBox = GetTextBox(prop, obj, counter);
            editor.ApplyChangesEvent += delegate {
                prop.SetValue(editor.astroObject,
                int.Parse(textBox.Text));
            };
            editor.Controls.Add(label);
            editor.Controls.Add(textBox);
            counter++;
        }

        void AddStringField(PropertyInfo prop, AstronomicalObject obj, ref int counter)
        {
            Label label = GetLabel(prop, counter);
            TextBox textBox = GetTextBox(prop, obj, counter);
            editor.ApplyChangesEvent += delegate {
                prop.SetValue(editor.astroObject,
                textBox.Text);
            };
            editor.Controls.Add(label);
            editor.Controls.Add(textBox);
            counter++;
        }

        void AddAstroObjectGroupField(PropertyInfo prop, AstronomicalObject obj, ref int counter)
        {
            Label label = GetLabel(prop, counter);
            ListBox listBox = GetListBox(prop, obj, counter);
            editor.Controls.Add(label);
            editor.Controls.Add(listBox);
            counter += ListBoxSize / (deltaHeight + height);
        }

        void AddPropertyField(PropertyInfo prop, AstronomicalObject obj, ref int counter)
        {
             
        }

        public AstroFormCreater()
        {
            fieldsConstructors = new Dictionary<Type, CreateField>();
            fieldsConstructors.Add(typeof(int), AddIntField);
            fieldsConstructors.Add(typeof(string), AddStringField);
            fieldsConstructors.Add(typeof(List<AstronomicalObject>), AddAstroObjectGroupField);
        }

        public frmEditAstro GetForm(Type astroObjectsType, AstronomicalObject obj)
        {
            editor = new frmEditAstro(obj);
            int counter = 0;
            PropertyInfo[] properties = astroObjectsType.GetProperties();
            foreach(var prop in properties)
            {
                if (fieldsConstructors.ContainsKey(prop.PropertyType) && prop.Name != "Count")
                {
                    fieldsConstructors[prop.PropertyType](prop, obj, ref counter);
                }
            }
            return editor;
        }


    }
}
