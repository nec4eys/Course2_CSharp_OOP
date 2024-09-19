
namespace TemperatureTask
{
    public partial class MainForm : Form, IView
    {
        public MainForm()
        {
            InitializeComponent();

            temperatureInput.Text = "Введите температуру";
            temperatureInput.ForeColor = Color.Gray;

            temperatureTypeInput.DropDownStyle = ComboBoxStyle.DropDownList;
            temperatureTypeInput.SelectedIndex = 0;

            temperatureTypeOutput.DropDownStyle = ComboBoxStyle.DropDownList;
            temperatureTypeOutput.SelectedIndex = 1;
        }

        public double Degrees => Convert.ToDouble(temperatureInput.Text);

        public string FromScale => temperatureTypeInput.Text;

        public string ToScale => temperatureTypeOutput.Text;

        public event EventHandler<EventArgs>? StartConversion;

        public void SetResultTemperature(double degreesFrom, double degreesTo)
        {
            temperatureOutputText.Text = degreesFrom + " " + temperatureTypeInput.Text + " = " + degreesTo + " " + temperatureTypeOutput.Text;
        }

        public void DisplayErrorForm(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            StartConversion?.Invoke(this, EventArgs.Empty);
        }

        private void temperatureInput_Enter(object sender, EventArgs e)
        {
            temperatureInput.Text = null;
            temperatureInput.ForeColor = Color.Black;
        }

        private void temperatureInput_Leave(object sender, EventArgs e)
        {
            if (temperatureInput.Text == "")
            {
                temperatureInput.Text = "Введите температуру";
                temperatureInput.ForeColor = Color.Gray;
            }

        }
    }
}
