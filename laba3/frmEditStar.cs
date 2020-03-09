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
    public partial class frmEditStar : frmEditAstro
    {
        Star star;
        public frmEditStar(): base()
        {
            InitializeComponent();
        }

        public frmEditStar(Star star): base(star)
        {
            InitializeComponent();
            this.star = star;
            for (int i = 0; i < star.Count; i++)
            {
                var item = (AstronomicalObject)star[i];
                lbPlanets.Items.Add(item);
            }
        }


        new void ApplyChanges()
        {
            base.ApplyChanges();
            Star newStar = new Star(star.Name, star.Position, star.Mass, star.Size, star.Temperature);
            foreach(Planet planet in lbPlanets.Items)
            {
                newStar.Add(planet);
            }
            star = newStar;
        }
        public override void btOk_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            this.Close();
        }

        private void frmEditStar_Load(object sender, EventArgs e)
        {

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lbPlanets.SelectedIndex != -1)
            {
                Planet planet = (Planet)lbPlanets.SelectedItem;
                frmEditPlanet frmEdit = new frmEditPlanet(planet, new List<AstronomicalObject>() {planet});
                frmEdit.ShowDialog();
            }
        }

        private void btAddPlanet_Click(object sender, EventArgs e)
        {
            Planet planet = new Planet();
            planet.MainObject = star;
            frmEditPlanet frmEdit = new frmEditPlanet(planet, new List<AstronomicalObject>() {planet});
            frmEdit.ShowDialog();
            star.Add(planet);
        }
    }
}
