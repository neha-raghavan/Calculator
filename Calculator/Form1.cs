namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResult.Text += button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtResult.Text += button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtResult.Text += button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtResult.Text += button4.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtResult.Text += button12.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtResult.Text += button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtResult.Text += button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtResult.Text += button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtResult.Text += button8.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtResult.Text += button11.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtResult.Text += button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtResult.Text += button10.Text;
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            txtResult.Text += btnPoint.Text;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtResult.Text += btnPlus.Text;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            txtResult.Text += btnMinus.Text;
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            txtResult.Text += btnMul.Text;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            txtResult.Text += btnDiv.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }
    }
}