﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Universe;
using UniverseEditor;
using FunctionalPluginAdapter;
using AdditionalProcessing;

namespace OOPLaba3
{
    public partial class frmMain : Form
    { 
        Dictionary<int, EditObject> astroEditors;
        public Dictionary<int, EditObject> astroHashEditors;
        int editorsCounter = 0;
        Service astroService;
        MainFormButtonCreater buttonCreater;

        SerializationFormat SaveTo;
        SerializationFormat SaveFrom;
        SerializationFormat LoadTo;
        SerializationFormat LoadFrom;
        SerializationOptions additionalOptions;

        bool isArchive;
        bool isLoadedFunctionalPlugin = true;
        string settingsFileName = "Settings.ini";

        List<ISerializationProcessing> serializationHandlers;
        List<IAdditionalProcessing> additionalProcessingHandlers;
        ISerializationProcessing eugeneProcessing = null;
        IAdditionalProcessing sharshoonProcessing = null;

        public frmMain()  
        {
            InitializeComponent();

            string path = Path.GetFullPath("../../../XmlToJSonFunctionalPlugin/bin/Debug/netstandard2.0/XmlToJSonFunctionalPlugin.dll");
            serializationHandlers = FunctionalPluginLoader.LoadPlugin(path);
            astroService = new Service();
            if(serializationHandlers != null && serializationHandlers.Count > 0)
            {
                eugeneProcessing = serializationHandlers[0];
            }

            path = Path.GetFullPath("../../../ArchivedAdditionalProcessing/bin/Debug/netstandard2.0/ArchivedAdditionalProcessing.dll");
            additionalProcessingHandlers = FunctionalPluginLoader.LoadSharshoonPlugin(path);
            if (additionalProcessingHandlers != null && additionalProcessingHandlers.Count > 0)
            {
                sharshoonProcessing = additionalProcessingHandlers[0];
            }

            if(LoadSettings())
            {
                ApplySettings();
            }
            else
            {
                astroService.Serializer = new SerializerXml();
                astroService.Deserializer = new SerializerXml();
            }
            astroEditors = new Dictionary<int, EditObject>();//uid-editor
            astroHashEditors = new Dictionary<int, EditObject>();
            astroHashEditors.Add(editorsCounter++, EditAstro);
            astroHashEditors.Add(editorsCounter++, EditStar);
            astroHashEditors.Add(editorsCounter++, EditPlanet);
            astroHashEditors.Add(editorsCounter++, EditSatellite);
            astroHashEditors.Add(editorsCounter++, EditVariableStar);
            astroHashEditors.Add(editorsCounter++, EditNewAstroType);
            tbFilePath.Text = astroService.FileName;
            buttonCreater = new MainFormButtonCreater();
        }

        bool LoadSettings()
        {
            const int optionAmount = 6;
            FileStream fin;
            try
            {
                fin = new FileStream(settingsFileName, FileMode.Open);
            }
            catch
            {
                return false;
            }
            bool result = true;
            try
            {
                byte[] buffer = new byte[optionAmount];
                int amount = fin.Read(buffer, 0, optionAmount);
                if (amount != optionAmount)
                    result = false;
                SaveFrom = (SerializationFormat)buffer[0];
                SaveTo = (SerializationFormat)buffer[1];
                LoadFrom = (SerializationFormat)buffer[2];
                LoadTo = (SerializationFormat)buffer[3];
                additionalOptions = (SerializationOptions)buffer[4];
                isArchive = (buffer[5] != 0);
            }
            catch
            {
                result = false;
            }
            finally
            {
                fin.Close();
            }
            return result;
        }



        void ApplySettings()
        {
            CompositeProcessing processing = new CompositeProcessing();
            SpecialSerializer specialSerializer = new SpecialSerializer();
            if(SaveFrom == SaveTo)
            {
                 if(SaveFrom == SerializationFormat.Xml)
                 {
                     specialSerializer.Serializer = new SerializerXml();
                 }
                 else
                 {
                    specialSerializer.Serializer = new SerializerJson();
                 }
             }
             else
             {
                 if(SaveTo == SerializationFormat.Json && eugeneProcessing != null)
                 {
                    specialSerializer.Serializer = new SerializerXml();
                    processing.Add(eugeneProcessing);
                    //astroService.Serializer = new SpecialSerializer(serializationHandlers[0], (byte)additionalOptions);
                 }
                 else
                 {
                    specialSerializer.Serializer = new SerializerXml();
                 }
             }

            if(sharshoonProcessing != null)
            {
                if (isArchive)
                    processing.Add(new SharshoonAdapter(sharshoonProcessing));
            }
           /*  if (LoadFrom == LoadTo)
             {
                 if (LoadFrom == SerializationFormat.Xml)
                 {
                     astroService.Deserializer = new SerializerXml();
                 }
                 else
                 {
                     astroService.Deserializer = new SerializerJson();
                 }
             }
             else
             {
                 if (LoadTo == SerializationFormat.Json)
                 {
                     astroService.Deserializer = new SpecialSerializer(serializationHandlers[0], (byte)additionalOptions);
                 }
                 else
                 {
                     astroService.Deserializer = new SerializerXml();
                 }
             }*/
            astroService.Serializer = new SpecialSerializer(processing, (byte)additionalOptions);
            astroService.Deserializer = new SpecialSerializer(processing, (byte)additionalOptions);

        }

        void EditNewAstroType(AstronomicalObject astroObj)
        {
            AstroFormCreater formCreater = new AstroFormCreater();
            frmEditAstro frmEditor = formCreater.GetForm(astroObj.GetType(),
                astroObj, astroService.AstroObjects);
            frmEditor.ShowDialog();
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

     /*   public void UpdateObjectList(AstronomicalObject obj)
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
        }*/

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
     

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lbStars.SelectedIndex != -1)
            {
                AstronomicalObject obj = (AstronomicalObject)lbStars.SelectedItem;
                try
                {
                    astroEditors[obj.uid](obj);
                }
                catch
                {
                    MessageBox.Show("It was not possible to determine the specific type " +
                        "of this astronomical object", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    frmEditAstro frmAstro = new frmEditAstro(obj);
                    frmAstro.ShowDialog();
                }
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
                astroEditors?.Remove(((AstronomicalObject)lbStars.SelectedItem).uid);
                astroService.Remove((AstronomicalObject)lbStars.SelectedItem, astroEditors, astroHashEditors);
                UpdateListBox();
            }
        }

        void AddNewAstroObject(AstronomicalObject obj)
        {
            astroEditors[obj.uid](obj);
            astroService.Add(obj, astroEditors, astroHashEditors);
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

        public void EditAstronomicalObject(AstronomicalObject obj)
        {
            frmEditAstro frmEdit = new frmEditAstro(obj);
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


        private void btAstroObject_Click(object sender, EventArgs e)
        {
            AstronomicalObject astro = new AstronomicalObject();
            astroEditors.Add(astro.uid, EditAstro);
            AddNewAstroObject(astro);
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
            astroEditors = info?.GetAstroEditors(astroHashEditors);
            UpdateListBox();
        }


       /* EditObject GetDelegate(Type astroType)
        {
            return new EditObject((AstronomicalObject astroObj) =>
            {
                AstroFormCreater formCreater = new AstroFormCreater();
                frmEditAstro frmEditor = formCreater.GetForm(astroType, astroObj, astroService.AstroObjects);
                frmEditor.ShowDialog();
            });
        }*/

        private void btLoadPlugin_Click(object sender, EventArgs e)
        {
            if (OpenPluginFile.ShowDialog() == DialogResult.OK) 
            {
                
                List<Type> types = AstroPluginLoader.LoadPlugin(OpenPluginFile.FileName);
                if (types == null)
                    return;
                astroService.AddTypes(types);
                foreach (Type astroType in types)
                {
                    Button btNew = buttonCreater.GetButton("tb" + astroType.Name, astroType.Name);
                    Type tempAstroType = astroType; 
                    EventHandler create = delegate
                    {
                        AstronomicalObject obj = (AstronomicalObject)Activator.CreateInstance(astroType);
                        astroEditors.Add(obj.uid, astroHashEditors[editorsCounter - 1]);
                        AddNewAstroObject(obj);
                    };
                    btNew.Click += create;
                    this.Controls.Add(btNew);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void msMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoadedFunctionalPlugin)
            {
                frmOptions frm = new frmOptions(settingsFileName);
                frm.ShowDialog();
                LoadSettings();
                ApplySettings();
            }
            else
            { 
                MessageBox.Show("The required functional plugin is not loaded", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
