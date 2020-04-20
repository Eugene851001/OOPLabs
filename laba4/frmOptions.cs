using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UniverseEditor
{
    public enum SerializationFormat : byte { Xml, Json };
    public enum SerializationOptions : byte { None = 0, WriteIndent = 1};
    public partial class frmOptions : Form 
    {

        const int settingsAmount = 5;
    
        SerializationFormat saveFrom;
        SerializationFormat saveTo;
        SerializationFormat loadFrom;
        SerializationFormat loadTo;
        SerializationOptions additionalOptions;

        string settingsFileName;

        bool loadSettings()
        {
            bool result = true;
            FileStream fin;
            try
            {
                fin = new FileStream(settingsFileName, FileMode.Open);
            }
            catch
            {
                return false;
            }
            try
            {
                int requiredAmount = settingsAmount;//SaveFrom, SaveTo, LoadFrom, LoadTo 
                byte[] buffer = new byte[requiredAmount];
                int amount = fin.Read(buffer, 0, requiredAmount);
                if(amount != requiredAmount)
                {
                    result = false;
                }
                else
                {
                    saveFrom = (SerializationFormat)buffer[0];
                    saveTo = (SerializationFormat)buffer[1];
                    loadFrom = (SerializationFormat)buffer[2];
                    loadTo = (SerializationFormat)buffer[3];
                    additionalOptions = (SerializationOptions)buffer[4];
                }

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

        void setDefaultSettings()
        {
            saveFrom = SerializationFormat.Xml;
            saveTo = SerializationFormat.Xml;
            loadFrom = SerializationFormat.Xml;
            loadTo = SerializationFormat.Xml;
            additionalOptions = SerializationOptions.WriteIndent;
        }

        bool saveSettings()
        {
            bool result = true;
            FileStream fout = new FileStream(settingsFileName, FileMode.Create);
            try
            {
                byte[] buffer = { (byte)saveFrom, (byte)saveTo, (byte)loadFrom, (byte)loadTo, (byte)additionalOptions};
                fout.Write(buffer, 0, settingsAmount);
            }
            catch
            {
                result = false;
            }
            finally
            {
                fout.Close();
            }
            return result;
        }

        public frmOptions(string settingsFileName)
        {
            InitializeComponent();
            this.settingsFileName = settingsFileName;
            if(!loadSettings())
            {
                setDefaultSettings();
                saveSettings();
            }
            cbLoadTo.Items.Add(SerializationFormat.Json);
            cbLoadTo.Items.Add(SerializationFormat.Xml);

            cbLoadFrom.Items.Add(SerializationFormat.Json);
            cbLoadFrom.Items.Add(SerializationFormat.Xml);

            cbSaveTo.Items.Add(SerializationFormat.Json);
            cbSaveTo.Items.Add(SerializationFormat.Xml);

            cbSaveFrom.Items.Add(SerializationFormat.Json);
            cbSaveFrom.Items.Add(SerializationFormat.Xml);

            cbLoadFrom.SelectedItem = loadFrom;
            cbLoadTo.SelectedItem = loadTo;
            cbSaveFrom.SelectedItem = saveFrom;
            cbSaveTo.SelectedItem = saveTo;

            cbWriteIndent.Checked = (additionalOptions & SerializationOptions.WriteIndent) != 0;
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {

        }

        private void btApply_Click(object sender, EventArgs e)
        {
            saveFrom = (SerializationFormat)cbSaveFrom.SelectedItem;
            saveTo = (SerializationFormat)cbSaveTo.SelectedItem;
            loadFrom = (SerializationFormat)cbLoadFrom.SelectedItem;
            loadTo = (SerializationFormat)cbLoadTo.SelectedItem;
            additionalOptions = cbWriteIndent.Checked ? additionalOptions | 
                SerializationOptions.WriteIndent : SerializationOptions.None;//correct later
            saveSettings();
            this.Close();
        }
    }
}
