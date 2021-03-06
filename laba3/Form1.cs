﻿using System;
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
        Dictionary<int, EditObject> astroEditors;
        public Dictionary<int, EditObject> astroHashEditors;

        Service astroService;

        public frmMain()  
        {
            InitializeComponent();
            astroEditors = new Dictionary<int, EditObject>();//uid-editor
            astroService = new Service();
            astroHashEditors = new Dictionary<int, EditObject>();
            astroHashEditors.Add(0, EditAstro);
            astroHashEditors.Add(1, EditStar);
            astroHashEditors.Add(2, EditPlanet);
            astroHashEditors.Add(3, EditSatellite);
            tbFilePath.Text = astroService.FileName;
        }

        public void UpdateListBox()
        {
            lbStars.Items.Clear();
            foreach(AstronomicalObject item in astroService.astroObjects)
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
                    astroService.UpdateObjectList((AstronomicalObject)item[i]);
                }
                if (obj.uid > astroService.astroObjects[astroService.astroObjects.Count - 1].uid)
                {
                    astroService.astroObjects.Add(obj);
                }
            }
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


        AstronomicalObject GetParent(int uid)
        {
            bool IsFound = false;
            int i;
            for (i = 0; !IsFound && i < astroService.astroObjects.Count; i++)
            {
                if (astroService.astroObjects[i].uid == uid)
                    IsFound = true;
            }
            return astroService.astroObjects[i - 1];
        }
         

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lbStars.SelectedIndex != -1)
            {
                AstronomicalObject obj = (AstronomicalObject)lbStars.SelectedItem;
                astroEditors[obj.uid](obj);
                astroService.UpdateObjectList(obj);
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
                astroService.Remove((AstronomicalObject)lbStars.SelectedItem, astroEditors, astroHashEditors);
                UpdateListBox();
            }
        }

        void AddNewAstroObject(AstronomicalObject obj)
        {
            astroEditors[obj.uid](obj);
            astroService.Add(obj, astroEditors, astroHashEditors);
            //UpdateObjectList(obj);
            astroService.UpdateObjectList(obj);
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
            frmEditPlanet frmEdit = new frmEditPlanet((Planet)obj, astroService.astroObjects);
            frmEdit.ShowDialog();
        }

        public void EditAstro(AstronomicalObject obj)
        {
            frmEditAstro frmEdit = new frmEditAstro(obj);
            frmEdit.ShowDialog();

        }

        public void EditSatellite(AstronomicalObject obj)
        {
            frmEditSatellite frmEdit = new frmEditSatellite((Satellite)obj, astroService.astroObjects);
            frmEdit.ShowDialog();
        }

        public void EditBlackHole(AstronomicalObject obj)
        {
            frmEditBlackHole frmEdit = new frmEditBlackHole((BlackHole)obj);
            frmEdit.ShowDialog();
        }

        public void EditVariableStar(AstronomicalObject obj)
        {
            frmEditVariableStar frmEdit = new frmEditVariableStar((VariableStar)obj);
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

        private void btBlackHole_Click(object sender, EventArgs e)
        {
            BlackHole blackHole = new BlackHole();
            astroEditors.Add(blackHole.uid, EditBlackHole);
            AddNewAstroObject(blackHole);
        }

        private void btVariableStar_Click(object sender, EventArgs e)
        {
            VariableStar star = new VariableStar();
            astroEditors.Add(star.uid, EditVariableStar);
            AddNewAstroObject(star);
        }

        private void OpenFile_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btChangeFile_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = OpenFile.FileName;
                astroService.ChangeFileName(fileName);
                tbFilePath.Text = astroService.FileName;
            }
        }

        private void btLoadAll_Click(object sender, EventArgs e)
        {
            SaveInfo info =  astroService.GetAll();
            astroEditors = info.GetAstroEditors(astroHashEditors);
            UpdateListBox();
        }
    }
}
