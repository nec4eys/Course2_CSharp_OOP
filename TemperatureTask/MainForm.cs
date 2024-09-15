
namespace TemperatureTask
{
    public partial class MainForm : Form, IView
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public double InputDegrees => Convert.ToDouble(temperatureInput.Text);

        public string InputFromScale => temperatureTypeInput.Text;

        public string InputToScale => temperatureTypeOutput.Text;

        public event EventHandler<EventArgs>? StartConversion;

        public void SetResultTemperature(double degreesFrom, double degreesTo)
        {
            temperatureOutputText.Text = degreesFrom.ToString() + " " + temperatureTypeInput.Text + " = " + degreesTo.ToString() + " " + temperatureTypeOutput.Text;
        }

        public void DisplayErrorForm(string message)
        {
            DialogResult result = MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (result == DialogResult.OK)
            {
                return;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (StartConversion != null)
            {
                StartConversion(this, EventArgs.Empty);
            }
        }
    }
}
