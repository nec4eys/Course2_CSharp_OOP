namespace TemperatureTask
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static void DisplayErrorForm(string message)
        {
            DialogResult result = MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (result == DialogResult.OK)
            {
                return;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                temperatureOutputText.Text = "";

                double enteredTemperature = Convert.ToDouble(temperatureInput.Text);
                enteredTemperature = Math.Round(enteredTemperature, 3);

                if (temperatureTypeInput.Text == "" || temperatureTypeOutput.Text == "" || temperatureTypeInput.Text == temperatureTypeOutput.Text)
                {
                    throw new ArgumentException("Two different scales should be specified", nameof(temperatureTypeInput) + " " + nameof(temperatureTypeOutput));
                }

                double resultTemperature = (temperatureTypeOutput.Text + temperatureTypeInput.Text) switch
                {
                    "KC" => TemperatureConversion.GetKelvinFromCelsius(enteredTemperature),
                    "KF" => TemperatureConversion.GetKelvinFromFahrenheit(enteredTemperature),
                    "CK" => TemperatureConversion.GetCelsiusFromKelvin(enteredTemperature),
                    "CF" => TemperatureConversion.GetCelsiusFromFahrenheit(enteredTemperature),
                    "FC" => TemperatureConversion.GetFahrenheitFromCelsius(enteredTemperature),
                    "FK" => TemperatureConversion.GetFahrenheitFromKelvin(enteredTemperature),
                    _ => throw new ArgumentException("Incorrect temperature scales", nameof(temperatureTypeInput) + " " + nameof(temperatureTypeOutput)),
                };

                resultTemperature = Math.Round(resultTemperature, 3);

                temperatureOutputText.Text = enteredTemperature.ToString() + " " + temperatureTypeInput.Text + " = " + resultTemperature.ToString() + " " + temperatureTypeOutput.Text;
            }
            catch (Exception ex)
            {
                DisplayErrorForm(ex.Message);
            }
        }
    }
}
