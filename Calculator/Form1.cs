using System;
using System.Linq;
using System.Windows.Forms;


namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, EventArgs e) => tbDisplay.AppendText("1");

        private void btnTwo_Click(object sender, EventArgs e) => tbDisplay.AppendText("2");

        private void btnThree_Click(object sender, EventArgs e) => tbDisplay.AppendText("3");

        private void btnFour_Click(object sender, EventArgs e) => tbDisplay.AppendText("4");

        private void btnFive_Click(object sender, EventArgs e) => tbDisplay.AppendText("5");

        private void btnSix_Click(object sender, EventArgs e) => tbDisplay.AppendText("6");

        private void btnSeven_Click(object sender, EventArgs e) => tbDisplay.AppendText("7");

        private void btnEight_Click(object sender, EventArgs e) => tbDisplay.AppendText("8");

        private void btnNine_Click(object sender, EventArgs e) => tbDisplay.AppendText("9");

        private void btnZero_Click(object sender, EventArgs e) => tbDisplay.AppendText("0");

        private void btnDivide_Click(object sender, EventArgs e) => Engine.TryAppendSymbol(tbDisplay, " / ");

        private void btnPlus_Click(object sender, EventArgs e) => Engine.TryAppendSymbol(tbDisplay, " + ");

        private void btnMinus_Click(object sender, EventArgs e) => Engine.TryAppendSymbol(tbDisplay, " - ");

        private void btnMultiply_Click(object sender, EventArgs e) => Engine.TryAppendSymbol(tbDisplay, " * ");

        private void btnClear_Click(object sender, EventArgs e) => tbDisplay.Clear();

        private void btnDel_Click(object sender, EventArgs e) => Engine.Delete(tbDisplay);


        private void btnComma_Click(object sender, EventArgs e)
        {
            if (tbDisplay.Text.Length == 0 || tbDisplay.Text.EndsWith(" ")) tbDisplay.AppendText("0,");
            else if (!tbDisplay.Text.Split(' ').Last().Contains(",")) Engine.TryAppendSymbol(tbDisplay, ",");
        }

        private void btnNegativePositive_Click(object sender, EventArgs e)
        {
            string lastNumber = tbDisplay.Text.Split(' ').Last();

            if (double.TryParse(lastNumber, out double x))
            {
                Engine.TryAppendSymbol(tbDisplay, x, lastNumber);
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (tbDisplay.Text.Length > 0)
                Engine.Compute(tbDisplay);
        }


        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.D1:
                case Keys.NumPad1:
                    btnOne_Click(sender, e);
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    btnTwo_Click(sender, e);
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    btnThree_Click(sender, e);
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    btnFour_Click(sender, e);
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    btnFive_Click(sender, e);
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    btnSix_Click(sender, e);
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    btnSeven_Click(sender, e);
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    btnEight_Click(sender, e);
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    btnNine_Click(sender, e);
                    break;
                case Keys.D0:
                case Keys.NumPad0:
                    btnZero_Click(sender, e);
                    break;
                case Keys.OemMinus:
                case Keys.Subtract:
                    btnMinus_Click(sender, e);
                    break;
                case Keys.Oemplus:
                case Keys.Add:
                    btnPlus_Click(sender, e);
                    break;
                case Keys.Oemcomma:
                case Keys.OemPeriod:
                    btnComma_Click(sender, e);
                    break;
                case Keys.Back:
                    btnDel_Click(sender, e);
                    break;
                case Keys.Divide:
                case Keys.OemQuestion:
                    btnDivide_Click(sender, e);
                    break;
                case Keys.Multiply:
                    btnMultiply_Click(sender, e);
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
                case Keys.Space:
                    if (tbDisplay.Text.Length > 0)
                        Engine.Compute(tbDisplay);
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
