namespace TemperatureTask;

internal interface IView
{
    void SetResultTemperature(double degreesFrom, double degreesTo);

    void DisplayErrorForm(string message);

    double Degrees { get; }

    string FromScale { get; }

    string ToScale { get; }

    event EventHandler<EventArgs> StartConversion;
}
