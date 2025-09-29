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
    public partial class MessageBoxTextbox : Form
    {
        public string Data { get; set; }
        public string SpecialConditions { get; set; }
        /*
         * Special Condition Standard:
         *   d (= differentThan) + string
         *   l (= length operation) + [==|!=|>=|>|<=|<] + int
         *   "" (= noOperation (always true))
         */
        public MessageBoxTextbox(string title, string specialConditions = "")
        {
            InitializeComponent();
            lbl_title.Text = title;
            SpecialConditions = specialConditions;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            bool condition = true;
            if (SpecialConditions.StartsWith("d"))
            {
                if (SpecialConditions[1] == '!')
                {
                    if(SpecialConditions.Length > 2)
                    {
                        condition = txb_input.Text != SpecialConditions.Substring(2);
                    }
                    else
                    {
                        condition = txb_input.Text != "";
                    }
                }
            }
            else if (SpecialConditions.StartsWith("l"))
            {
                if(SpecialConditions.Substring(1,2) == "==")
                {
                    condition = txb_input.Text.Length == int.Parse(SpecialConditions.Substring(3));
                }
                else if (SpecialConditions.Substring(1, 2) == "!=")
                {
                    condition = txb_input.Text.Length != int.Parse(SpecialConditions.Substring(3));
                }
                else if (SpecialConditions[1] == '>')
                {
                    if (SpecialConditions[2] == '=')
                    {
                        condition = txb_input.Text.Length >= int.Parse(SpecialConditions.Substring(3));
                    }
                    else
                    {
                        condition = txb_input.Text.Length > int.Parse(SpecialConditions.Substring(2));
                    }
                }
                else if (SpecialConditions[1] == '<')
                {
                    if (SpecialConditions[2] == '=')
                    {
                        condition = txb_input.Text.Length <= int.Parse(SpecialConditions.Substring(3));
                    }
                    else
                    {
                        condition = txb_input.Text.Length < int.Parse(SpecialConditions.Substring(2));
                    }
                }
            }

            if (condition)
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
