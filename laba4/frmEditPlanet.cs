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
    public partial class frmEditPlanet : frmEditAstro
    {
        Planet planet;
        public frmEditPlanet(): base()
        {
            InitializeComponent();
        }

        public frmEditPlanet(Planet planet, List<AstronomicalObject> astroObjects) : base(planet)
        {
            InitializeComponent();
            this.planet = planet;
            foreach(var item in astroObjects)
            {
                if (item is Star)
                    cbStars.Items.Add(item);
            }

            cbStars.SelectedIndex = cbStars.Items.IndexOf(planet.MainObject);
            for (int i = 0; i < planet.Count; i++)
            {
                lbSatellites.Items.Add(planet[i]);
            }
        }

        new void ApplyChanges()
        {
            base.ApplyChanges();
            Planet newPlanet = new Planet(planet.Name, planet.Position, planet.Mass, 
                planet.Size, (Star)planet.MainObject, planet.Albedo);
            foreach(Satellite satellite in lbSatellites.Items)
            {
                newPlanet.Add(satellite);
            }
            if (cbStars.SelectedIndex != -1)
            {
                planet.MainObject = (AstronomicalObject)cbStars.SelectedItem;
            }
            planet.AddToParent();
        }

        public override void btOk_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            this.Close();
        }

        private void frmEditPlanet_Load(object sender, EventArgs e)
        {

        }


        private void lbSatellites_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbMainStar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
