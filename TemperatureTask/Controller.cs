namespace TemperatureTask;

internal class Controller
{
    private readonly IView _view;

    public Controller(IView view)
    {
        _view = view;
        _view.StartConversion += new EventHandler<EventArgs>(StartConversion);
    }

    private void StartConversion(object? sender, EventArgs e)
    {
        try
        {
            _view.SetResultTemperature(_view.InputDegrees, TemperatureConversion.ConvertTemperatureFromOneScaleToAnother(_view.InputDegrees, _view.InputFromScale, _view.InputToScale));
        }
        catch (Exception ex)
        {
            _view.DisplayErrorForm(ex.Message);
        }
    }
}
