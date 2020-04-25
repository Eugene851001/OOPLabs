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

        const int settingsAmount = 6;
    
        SerializationFormat saveFrom;
        SerializationFormat saveTo;
        SerializationFormat loadFrom;
        SerializationFormat loadTo;
        SerializationOptions additionalOptions;
        bool isArchive;

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
                    isArchive = (buffer[5] != 0);
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
            isArchive = false;
        }

        bool saveSettings()
        {
            bool result = true;
            FileStream fout = new FileStream(settingsFileName, FileMode.Create);
            try
            {
                byte[] buffer = { (byte)saveFrom, (byte)saveTo, (byte)loadFrom, 
                    (byte)loadTo, (byte)additionalOptions, (byte)(isArchive ? 1 : 0) };
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
            cbArchive.Checked = isArchive;

            cbWriteIndent.Checked = (additionalOptions & SerializationOptions.WriteIndent) != 0;
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {

        }

        bool  checkOptions()
        {
            bool result = true;
            string message = "conversion from json to xml is not possible";
            if ((SerializationFormat)cbSaveFrom.SelectedItem == SerializationFormat.Json 
                && (SerializationFormat)cbSaveTo.SelectedItem == SerializationFormat.Xml)
            {
                MessageBox.Show(message, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbSaveFrom.SelectedItem = SerializationFormat.Xml;
                result = false;
            }
            if((SerializationFormat)cbLoadFrom.SelectedItem == SerializationFormat.Json 
                && (SerializationFormat)cbLoadTo.SelectedItem == SerializationFormat.Xml)
            {
                MessageBox.Show(message, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbLoadFrom.SelectedItem = SerializationFormat.Xml;
                result = false;
            }
            return result;
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            if (!checkOptions())
                return;
            saveFrom = (SerializationFormat)cbSaveFrom.SelectedItem;
            saveTo = (SerializationFormat)cbSaveTo.SelectedItem;
            loadFrom = (SerializationFormat)cbLoadFrom.SelectedItem;
            loadTo = (SerializationFormat)cbLoadTo.SelectedItem;
            isArchive = cbArchive.Checked;
            additionalOptions = 0;
            additionalOptions = cbWriteIndent.Checked ? 
                additionalOptions | SerializationOptions.WriteIndent 
                : additionalOptions;
            saveSettings();
            this.Close();
        }
    }
}
