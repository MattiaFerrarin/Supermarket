using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace Supermarket
{
    public partial class MessageBoxTextbox : Form
    {
        public string Data { get; set; }
        public Func<string,bool> ConditionFunction { get; set; }
        public MessageBoxTextbox(string title, Func<string, bool> condition = null)
        {
            InitializeComponent();
            lbl_title.Text = title;
            if (condition == null)
            {
                ConditionFunction = (s) => { return true; };
            }
            else
            {
                ConditionFunction = condition;
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (ConditionFunction.Invoke(txb_input.Text))
            {
                Data = txb_input.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void MessageBoxTextbox_Load(object sender, EventArgs e)
        {
            txb_input.Select();
        }
    }
}
