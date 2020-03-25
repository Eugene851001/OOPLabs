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
    public partial class frmEditVariableStar : frmEditStar
    {
        VariableStar star;
        public frmEditVariableStar()
        {
            InitializeComponent();
        }

        public frmEditVariableStar(VariableStar star): base(star)
        {
            InitializeComponent();
            tbLuminocity.Text = star.AverageLuminosity.ToString();
            tbDelta.Text = star.DeltaLuminosity.ToString();
            this.star = star;
        }

        new void ApplyChanges()
        {
            base.ApplyChanges();
            star.AverageLuminosity = double.Parse(tbLuminocity.Text);
            star.DeltaLuminosity = double.Parse(tbDelta.Text);
            VariableStar newStar = new VariableStar(star.Name, star.Position, star.Mass, 
                star.Size, star.Temperature, star.AverageLuminosity, star.DeltaLuminosity);
            star = newStar;
        }

        public override void btOk_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            this.Close();
        }

        private void frmEditVariableStar_Load(object sender, EventArgs e)
        {

        }

        private void tbLuminocity_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
