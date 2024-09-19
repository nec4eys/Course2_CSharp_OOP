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
            _view.SetResultTemperature(Math.Round(_view.Degrees, 3, MidpointRounding.AwayFromZero), 
                TemperatureConversion.ConvertTemperatureFromOneScaleToAnother(_view.Degrees, _view.FromScale, _view.ToScale));
        }
        catch (Exception ex)
        {
            _view.DisplayErrorForm(ex.Message);
        }
    }
}
