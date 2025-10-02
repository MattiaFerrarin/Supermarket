using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class MessageBoxNumericUpDown : Form
    {
        public Decimal Data { get; set; }
        public Func<Decimal, bool> ConditionFunction { get; set; }
        public MessageBoxNumericUpDown(string title, Func<Decimal, bool> condition = null)
        {
            InitializeComponent();
            lbl_title.Text = title;
            if (condition == null)
            {
                ConditionFunction = (n) => { return true; };
            }
            else
            {
                ConditionFunction = condition;
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (ConditionFunction.Invoke(nmu_input.Value))
            {
                Data = nmu_input.Value;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void MessageBoxNumericUpDown_Load(object sender, EventArgs e)
        {
            nmu_input.Select();
        }
    }
}
