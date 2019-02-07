using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace Calculator
{
    public class Engine : TextBox
    {
        public static void TryAppendSymbol(TextBox display, string symbolBtnClicks)
        {
            if (!display.Text.EndsWith(" ") && display.Text.Length > 0)
            {
                string lastNumber = display.Text.Split(' ').Last();

                if (double.TryParse(lastNumber, out double x))
                {
                    int length = lastNumber.Length;
                    int displayLength = display.Text.Length;
                    display.Text = display.Text.Remove(displayLength - length);
                    display.AppendText(x.ToString());
                }

                display.AppendText(symbolBtnClicks);
            }
       }
       
        public static void TryAppendSymbol(TextBox display, double x, string lastNumber)
        {
            int length = lastNumber.Length;
            int displayLength = display.Text.Length;
            display.Text = display.Text.Remove(displayLength - length);
            display.AppendText((x * -1).ToString());
        }

        public static void Delete(TextBox display)
        {
            
            if (display.Text.Length > 0)
                display.Text = (display.Text.EndsWith(" "))
                    ? display.Text.Remove(display.Text.Length - 3, 3)
                    : display.Text.Remove(display.Text.Length - 1);
        }

        public static void Compute(TextBox display)
        {
            if (display.Text.EndsWith(" ")) display.Text = display.Text.Remove(display.Text.Length - 3, 3);

            if (display.Text.Contains(" / 0"))
            {
                MessageBox.Show("    Нельзя делить на ноль!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                display.Text = display.Text.Replace(" / 0", "");
            }
            else
                try
                {
                    double result = Convert.ToDouble(new DataTable().Compute(display.Text.Replace(',','.'), ""));
                    display.Clear();
                    display.AppendText(result.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Значение находится вне пределов нашего простого калькулятора :(" , "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

    }

}
