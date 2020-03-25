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
    public partial class frmEditBlackHole : frmEditAstro
    {
        BlackHole blackHole;
        public frmEditBlackHole()
        {
            InitializeComponent();
        }

        public frmEditBlackHole(BlackHole blackHole): base(blackHole)
        {
            InitializeComponent();

            this.blackHole = blackHole;
        }

        new void ApplyChanges()
        {
            base.ApplyChanges();
            BlackHole newBlackHole = new BlackHole(blackHole.Name, blackHole.Position, blackHole.Mass);
            //blackHole.Size = BlackHole.GetRadius(blackHole.Mass);
            blackHole = newBlackHole;
        }

        public override void btOk_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            this.Close();
        }

        private void frmEditBlackHole_Load(object sender, EventArgs e)
        {
            
        }


    }
}
