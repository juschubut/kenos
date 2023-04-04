using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kenos.Common
{
    public class FormularioBase : Form
    {
        public FormularioBase()
        {
            this.Load += FormularioBase_Load;
        }

        void FormularioBase_Load(object sender, EventArgs e)
        {
            AplicarEstilos();
        }

        public virtual void AplicarEstilos()
        {
            this.BackColor = Styles.ColorFondoSecundario;

            foreach (Control control in this.Controls)
            {
                AplicarEstiloControl(control);
            }
        }

        protected virtual void AplicarEstiloControl(Control control)
        {
            if (control is Label)
                AplicarEstiloLabel((Label)control);
            else if (control is Panel)
                AplicarEstiloPanel((Panel)control);
            else if (control is GroupBox)
                AplicarEstiloGroupBox((GroupBox)control);
            else if (control is Button)
                AplicarEstiloButton((Button)control);
        
        }

        protected virtual void AplicarEstiloButton(Button button)
        {
            if (IsInFooter(button.Parent))
            {
                button.BackColor = Styles.ColorFondoPrimario;
                button.ForeColor = Styles.ColorFuentePrimario;
            }
            else
            {
                button.BackColor = Styles.ColorFondoSecundario;
                button.ForeColor = Styles.ColorFuenteSecundario;
            }
        }

        protected virtual void AplicarEstiloGroupBox(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                AplicarEstiloControl(control);
            }
        }

        protected virtual void AplicarEstiloPanel(Panel panel)
        {
            if (IsInFooter(panel))
            {
                panel.BackColor = Styles.ColorFondoPrimario;
            }

            foreach (Control control in panel.Controls)
            {
                AplicarEstiloControl(control);
            }
        }

        protected virtual void AplicarEstiloLabel(Label label)
        {
            if (label.Name.StartsWith("label", StringComparison.InvariantCultureIgnoreCase))
                label.ForeColor = Styles.ColorFuenteSecundario;
        }

        protected virtual bool IsInFooter(Control control)
        {
            return control.Name.StartsWith("pnlBotonera", StringComparison.InvariantCultureIgnoreCase)
                || control.Name.StartsWith("footer", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
