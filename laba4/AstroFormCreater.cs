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
        const int deltaHeight = 3;
        const int height = 25;
        const int width = 50;
        const int ListBoxSize = 100;

        public delegate object Parser(string s);
        frmEditAstro editor;

        delegate void CreateField(PropertyInfo prop, AstronomicalObject obj, 
            List<AstronomicalObject> astroObjects, ref int counter);
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

        public ComboBox GetComboBox(PropertyInfo prop, List<AstronomicalObject> astroObjects, 
            Type requiredType, ref int counter)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Name = prop.Name;
            foreach(AstronomicalObject astroObject in astroObjects)
            {
                if(requiredType.IsAssignableFrom(astroObject.GetType()))
                    comboBox.Items.Add(astroObject);
            }
            comboBox.Location = GetLocation(counter);
            comboBox.Location = new System.Drawing.Point() { X = comboBox.Location.X + width, Y = comboBox.Location.Y };
            comboBox.Height = height;
            comboBox.Width = width;
            return comboBox;
        }

        //заполняет listbox через индексатор
        ListBox GetListBox(PropertyInfo prop, AstronomicalObject obj, int counter)
        {
            ListBox listBox = new ListBox();
            var complexObj = (IComplexObj)obj;
            for(int i = 0; i < complexObj.Count; i++)
            {
                listBox.Items.Add(complexObj[i]);
            }
            listBox.Name = "lb" + prop.Name;
            listBox.Location = GetLocation(counter);
            listBox.Location = new System.Drawing.Point() {X = listBox.Location.X + width, Y = listBox.Location.Y };
            listBox.Height = listBox.Width = ListBoxSize;
            return listBox;
        }

        void AddRegularField(PropertyInfo prop, AstronomicalObject obj, ref int counter, Parser getChanges)
        {
            Label label = GetLabel(prop, counter);
            TextBox textBox = GetTextBox(prop, obj, counter);
            //если элемент с таким именем уже присутствует на форме, то лучше не добавлять его
            if (editor.Controls.ContainsKey(textBox.Name) || editor.Controls.ContainsKey(label.Name))
                return;
            editor.ApplyChangesEvent += delegate {
                prop.SetValue(editor.astroObject,
                getChanges(textBox.Text));
            };
            editor.Controls.Add(label);
            editor.Controls.Add(textBox);
            counter++;
        }

        void AddIntField(PropertyInfo prop, AstronomicalObject obj, List<AstronomicalObject> astroObjects, 
            ref int counter)
        {
            Parser parser = delegate(string s){ return int.Parse(s);};
            AddRegularField(prop, obj, ref counter, parser);
        }


        void AddFloatField(PropertyInfo prop, AstronomicalObject obj, List<AstronomicalObject> astroObjects,
            ref int counter)
        {
            Parser parser = delegate (string s) { return float.Parse(s); };
            AddRegularField(prop, obj, ref counter, parser);
        }

        void AddDoubleField(PropertyInfo prop, AstronomicalObject obj, List<AstronomicalObject> astroObjects, 
            ref int counter)
        {
            Parser parser = delegate (string s) { return double.Parse(s); };
            AddRegularField(prop, obj, ref counter, parser);
        }

        void AddStringField(PropertyInfo prop, AstronomicalObject obj, List<AstronomicalObject> astroObjects,
            ref int counter)
        {
            Parser parser = delegate (string s) { return (object)s; };
            AddRegularField(prop, obj, ref counter, parser);
        }

        void AddChooseAstroObjectField(PropertyInfo prop, AstronomicalObject obj, List<AstronomicalObject> astroObjects, 
            ref int counter)
        {
            Label label = GetLabel(prop, counter);
            ComboBox comboBox = GetComboBox(prop, astroObjects, ((IParticle)obj).MainObject.GetType(), ref counter);
            var participleAstroObject = obj as IParticle;
            if (participleAstroObject.MainObject != null)
                comboBox.SelectedItem = participleAstroObject.MainObject;
            editor.Controls.Add(label);
            editor.Controls.Add(comboBox);
            editor.ApplyChangesEvent += delegate { if (comboBox.SelectedIndex != -1) 
                                                    {
                                                        ((IParticle)obj).MainObject = (AstronomicalObject)comboBox.SelectedItem;
                                                    }
                                                    ((IParticle)obj).AddToParent();
                                                 };
            counter++;
        }

        void AddAstroObjectGroupField(PropertyInfo prop, AstronomicalObject obj, List<AstronomicalObject> astroObjects, 
            ref int counter)
        {
            Label label = GetLabel(prop, counter);
            ListBox listBox = GetListBox(prop, obj, counter);
            if (editor.Controls.ContainsKey(listBox.Name) || editor.Controls.ContainsKey(label.Name))
                return;
            editor.Controls.Add(label);
            editor.Controls.Add(listBox);
            counter += ListBoxSize / (deltaHeight + height);
        }


        public AstroFormCreater()
        {
            fieldsConstructors = new Dictionary<Type, CreateField>();
            fieldsConstructors.Add(typeof(int), AddIntField);
            fieldsConstructors.Add(typeof(string), AddStringField);
            fieldsConstructors.Add(typeof(List<AstronomicalObject>), AddAstroObjectGroupField);
            fieldsConstructors.Add(typeof(float), AddFloatField);
            fieldsConstructors.Add(typeof(double), AddDoubleField);
            fieldsConstructors.Add(typeof(AstronomicalObject), AddChooseAstroObjectField);
        }

        public frmEditAstro GetForm(Type astroObjectsType, AstronomicalObject obj, 
            List<AstronomicalObject> astroObjects)
        {
            editor = new frmEditAstro(obj);
            int counter = 0;
            PropertyInfo[] properties = astroObjectsType.GetProperties();
            foreach(var prop in properties)
            {
                if (fieldsConstructors.ContainsKey(prop.PropertyType) && prop.Name != "Count")
                {
                    fieldsConstructors[prop.PropertyType](prop, obj, astroObjects, ref counter);
                }
            }
            //если для данный объект представляет собой систему из других объектов, 
            //то выводим список объектов этой системы
            if (obj is IComplexObj)
            {
                //свойство Item - индексатор
                AddAstroObjectGroupField(astroObjectsType.GetProperty("Item"), 
                    obj, astroObjects, ref counter);
            }
            editor.Name = "frm" + astroObjectsType.Name;
            editor.Text = "Edit " + astroObjectsType.Name;
            return editor;
        }
    }
}
