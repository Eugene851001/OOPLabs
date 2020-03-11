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
        AstronomicalObject astro;
        /// </summary>
        public frmEditAstro()
        {
            InitializeComponent();
            astro = new AstronomicalObject();
            FillFields();
        }

        void FillFields()
        {
            tbName.Text = astro.Name;
            tbX.Text = astro.Position.X.ToString();
            tbY.Text = astro.Position.Y.ToString();
            tbMass.Text = astro.Mass.ToString();
            tbSize.Text = astro.Size.ToString();
        }

        public frmEditAstro(AstronomicalObject astro)
        {
            InitializeComponent();
            this.astro = astro;
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
            astro.Name = tbName.Text;
            astro.Position = new Universe.Point(double.Parse(tbX.Text), double.Parse(tbY.Text));
            astro.Mass = double.Parse(tbMass.Text);
            astro.Size = double.Parse(tbSize.Text);
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
