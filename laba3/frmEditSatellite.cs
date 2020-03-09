using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Universe;

namespace OOPLaba3
{
    public partial class frmEditSatellite : frmEditAstro
    {
        Satellite satellite;
        public frmEditSatellite()
        {
            InitializeComponent();
        }

        public frmEditSatellite(Satellite satellite, List<AstronomicalObject> astroObject): base(satellite)
        {
            InitializeComponent();
            this.satellite = satellite;
            foreach(var item in astroObject)
            {
                if (item is Planet)
                {
                    cbPlanet.Items.Add(item);
                }
            }
        }

        public new void ApplyChanges()
        {
            base.ApplyChanges();
            if (cbPlanet.SelectedIndex != -1)
            {
                satellite.MainObject = (AstronomicalObject)cbPlanet.SelectedItem;
                satellite.AddToParent();
            }
        }

        public override void btOk_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            this.Close();
        }

        private void frmEditSatellite_Load(object sender, EventArgs e)
        {

        }
    }
}
