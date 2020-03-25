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
    public partial class frmEditAstro : Form
    {
        public AstronomicalObject astroObject { get; set; }
        /// </summary>
        ///
        public Action ApplyChangesEvent;
        public frmEditAstro()
        {
            InitializeComponent();
            astroObject = new AstronomicalObject();
            FillFields();
        }

        void FillFields()
        {
            tbName.Text = astroObject.Name;
            tbX.Text = astroObject.Position.X.ToString();
            tbY.Text = astroObject.Position.Y.ToString();
            tbMass.Text = astroObject.Mass.ToString();
            tbSize.Text = astroObject.Size.ToString();
        }

        public frmEditAstro(AstronomicalObject astro)
        {
            InitializeComponent();
            this.astroObject = astro;
            FillFields();
           
        }

        private void frmEditAstro_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ApplyChanges()
        {
            astroObject.Name = tbName.Text;
            astroObject.Position = new Universe.Point(double.Parse(tbX.Text), double.Parse(tbY.Text));
            astroObject.Mass = double.Parse(tbMass.Text);
            astroObject.Size = double.Parse(tbSize.Text);
            ApplyChangesEvent?.Invoke();
        }

        public virtual void btOk_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            this.Close();
        }

        private void tbX_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
