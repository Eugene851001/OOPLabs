using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Universe;

namespace OOPLaba3
{
    public partial class frmMain : Form
    { 
        List<AstronomicalObject> astroObjects;
        Dictionary<int, EditObject> astroEditors;
        public Dictionary<int, EditObject> astroHashEditors;

        Service astroService;

        public frmMain()  
        {
            InitializeComponent();
            astroObjects = new List<AstronomicalObject>();
            astroEditors = new Dictionary<int, EditObject>();//uid-editor
            astroService = new Service();
            astroHashEditors = new Dictionary<int, EditObject>();
            astroHashEditors.Add(0, EditAstro);
            astroHashEditors.Add(1, EditStar);
            astroHashEditors.Add(2, EditPlanet);
            astroHashEditors.Add(3, EditSatellite);
        }

        public void UpdateListBox()
        {
            lbStars.Items.Clear();
            foreach(AstronomicalObject item in astroObjects)
            {
                if (item != null)
                    lbStars.Items.Add(item);
            }
        }

        public void UpdateObjectList(AstronomicalObject obj)
        {
            if (obj is IComplexObj)
            {
                var item = obj as IComplexObj;
                for (int i = 0; i < item.Count; i++)
                {
                    UpdateObjectList((AstronomicalObject)item[i]);
                }
                if (obj.uid > astroObjects[astroObjects.Count - 1].uid)
                {
                    astroObjects.Add(obj);
                }
            }
        }

        public void HelpDeleteObject(AstronomicalObject astroObject)
        {
            if (astroObject is IComplexObj)
            {
                var item = astroObject as IComplexObj;
                for (int i = 0; i < item.Count; i++)
                {
                    HelpDeleteObject((AstronomicalObject)item[i]);
                }
            }
            astroObject.IsDestroy = true;
        }

        public void DeleteObject(AstronomicalObject astroObject)
        {
            if (astroObject is IParticle)
            {
                var item = astroObject as IParticle;
                item.RemoveFromParent();
            }
            HelpDeleteObject(astroObject);
           
        }

        public void UpdateObjects()
        {
            int counter = 0;
            while(counter < astroObjects.Count)
            {
                AstronomicalObject item = astroObjects[counter];
                if (item != null && item.IsDestroy)
                {
                    astroObjects.Remove(item);
                }
                else
                {
                    counter++;
                }
            }
            UpdateListBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btShow_Click(object sender, EventArgs e)
        {
            Invalidate();
        }

        public void DrawPlanets(Graphics g)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.White), this.ClientRectangle);
        }

        private void btSerialize_Click(object sender, EventArgs e)
        {
            FileStream fout;
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                string FileName = SaveFile.FileName;
                fout = new FileStream(FileName,  FileMode.Create);
                try
                {
                    SaveInfo info = new SaveInfo(astroObjects, astroEditors, astroHashEditors);
                    XmlSerializer formatter = new XmlSerializer(typeof(SaveInfo));
                    formatter.Serialize(fout, info);
                }
                finally
                {
                    fout.Close();
                }
            }
        }

        AstronomicalObject GetParent(int uid)
        {
            bool IsFound = false;
            int i;
            for (i = 0; !IsFound && i < astroObjects.Count; i++)
            {
                if (astroObjects[i].uid == uid)
                    IsFound = true;
            }
            return astroObjects[i - 1];
        }

        private void btDeserialize_Click(object sender, EventArgs e)
        {
            FileStream fin;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                string FileName = OpenFile.FileName;

                fin = new FileStream(FileName, FileMode.Open);
                try
                {
                    SaveInfo info;
                    XmlSerializer formatter = new XmlSerializer(typeof(SaveInfo));
                    info = (SaveInfo)formatter.Deserialize(fin);
                    astroEditors = info.GetAstroEditors(astroHashEditors);
                    astroObjects = info.AstroObjects;
                }
                finally
                {
                    fin.Close();
                }
            }
            for (int i = 0; i < astroObjects.Count; i++)
            {              
                if (astroObjects[i] is IParticle)
                {
                    var item = astroObjects[i] as IParticle;
                    item.MainObject = GetParent(item.MainObject.uid);   
                    item.AddToParent();
                }
            }
            UpdateListBox();
        }
         

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lbStars.SelectedIndex != -1)
            {
                AstronomicalObject obj = (AstronomicalObject)lbStars.SelectedItem;
                astroEditors[obj.uid](obj);
                UpdateObjectList(obj);
                UpdateListBox();
            }
        }

        private void lbStars_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lbStars.SelectedIndex != -1)
            {
                astroService.Remove((AstronomicalObject)lbStars.SelectedItem);
                DeleteObject((AstronomicalObject)lbStars.SelectedItem);
                UpdateObjects();
            }
        }

        void AddNewAstroObject(AstronomicalObject obj)
        {
            astroEditors[obj.uid](obj);
            astroObjects.Add(obj);
            astroService.Add(obj);
            UpdateObjectList(obj);
            UpdateListBox();
        }

        private void btAddStar_Click(object sender, EventArgs e)
        {
            Star star = new Star();
            astroEditors.Add(star.uid, EditStar);
            AddNewAstroObject(star);
        }

        public void EditStar(AstronomicalObject obj)
        {
            frmEditStar frmEdit = new frmEditStar((Star)obj);
            frmEdit.ShowDialog();
        }

        public void EditPlanet(AstronomicalObject obj)
        {
            frmEditPlanet frmEdit = new frmEditPlanet((Planet)obj, astroObjects);
            frmEdit.ShowDialog();
        }

        public void EditAstro(AstronomicalObject obj)
        {
            frmEditAstro frmEdit = new frmEditAstro(obj);
            frmEdit.ShowDialog();

        }

        public void EditSatellite(AstronomicalObject obj)
        {
            frmEditSatellite frmEdit = new frmEditSatellite((Satellite)obj, astroObjects);
            frmEdit.ShowDialog();
        }

        private void btPlanet_Click(object sender, EventArgs e)
        {
            Planet planet = new Planet();
            astroEditors.Add(planet.uid, EditPlanet);
            AddNewAstroObject(planet);
        }

        private void btAddSatellite_Click(object sender, EventArgs e)
        {
            Satellite satellite = new Satellite();
            astroEditors.Add(satellite.uid, EditSatellite);
            AddNewAstroObject(satellite);
        }
    }
}
