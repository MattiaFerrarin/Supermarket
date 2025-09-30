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
        public float Data { get; set; }
        public string SpecialConditions { get; set; }
        /*
         * Special Condition Standard:
         *   c (= comparison operation) + [==|!=|>=|>|<=|<] + float
         *   "" (= noOperation (always true))
         */
        public MessageBoxNumericUpDown(string title, string specialConditions = "")
        {
            InitializeComponent();
            lbl_title.Text = title;
            SpecialConditions = specialConditions;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            bool condition = true;
            if (SpecialConditions.StartsWith("c"))
            {
                if (SpecialConditions.Substring(1, 2) == "==")
                {
                    condition = (float)(nmu_input.Value) == float.Parse(SpecialConditions.Substring(3));
                }
                else if (SpecialConditions.Substring(1, 2) == "!=")
                {
                    condition = (float)(nmu_input.Value) != float.Parse(SpecialConditions.Substring(3));
                }
                else if (SpecialConditions[1] == '>')
                {
                    if (SpecialConditions[2] == '=')
                    {
                        condition = (float)(nmu_input.Value) >= float.Parse(SpecialConditions.Substring(3));
                    }
                    else
                    {
                        condition = (float)(nmu_input.Value) > float.Parse(SpecialConditions.Substring(2));
                    }
                }
                else if (SpecialConditions[1] == '<')
                {
                    if (SpecialConditions[2] == '=')
                    {
                        condition = (float)(nmu_input.Value) <= float.Parse(SpecialConditions.Substring(3));
                    }
                    else
                    {
                        condition = (float)(nmu_input.Value) < float.Parse(SpecialConditions.Substring(3));
                    }
                }
            }

            if (condition)
            {
                Data = (float)nmu_input.Value;
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
