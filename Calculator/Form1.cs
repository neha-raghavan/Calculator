using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;



namespace Calculator
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string expression, data;
        double result;
        int CommunicatedRecordsCount;

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

        static double EvaluateExpression(string expression)
        {
            // Add a multiplication operator (*) before a bracket if no operator is present
            expression = Regex.Replace(expression, @"([\d.]+)\s*\(", "$1 * (");

            // Evaluate the modified expression
            return Evaluate(expression);
        }

        static double Evaluate(string expression)
        {
            var dataTable = new System.Data.DataTable();
            var result = dataTable.Compute(expression, "");
            return Convert.ToDouble(result);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            CommunicatedRecordsCount = 0;
            if (button.Text == "=")
            {

                try
                {
                    con.Open();
                    string query = "select * from Calc where Exp like '" + txtResult.Text + "'";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                CommunicatedRecordsCount = (int)reader[0];
                                data = (string)reader[2];

                            }
                            reader.Close();
                            con.Close();
                        }
                    }

                    if (CommunicatedRecordsCount > 0)
                    {
                        txtResult.Text = data;

                    }

                    else
                    {
                        expression = txtResult.Text;
                        result = EvaluateExpression(expression);
                        txtResult.Text = result.ToString();

                        string qry = "INSERT INTO Calc  (Exp,Result) VALUES (@Exp, @Result)";


                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(qry, con))
                        {
                            cmd.Parameters.AddWithValue("@Exp", expression);
                            cmd.Parameters.AddWithValue("@Result", result);

                            cmd.ExecuteNonQuery();
                        }


                        con.Close();
                        MessageBox.Show("Inserted sucessfully");

                    }


                }
                catch
                {
                    txtResult.Text = "Error";
                }
            }

        }
    }
}



