namespace TemperatureTask;

internal interface IView
{
    void SetResultTemperature(double degreesFrom, double degreesTo);

    void DisplayErrorForm(string message);

    double InputDegrees { get; }

    string InputFromScale { get; }

    string InputToScale { get; }

    event EventHandler<EventArgs> StartConversion;
}
