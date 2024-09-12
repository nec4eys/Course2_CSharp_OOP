namespace TemperatureTask;

internal class TemperatureConversion
{
    const double absoluteZeroCelsius = -273.15;

    const double absoluteZeroFahrenheit = -459.67;

    const double epsilone = 1.0e-10;

    public static double GetKelvinFromCelsius(double degreesCelsius)
    {
        if (degreesCelsius - absoluteZeroCelsius < -epsilone)
        {
            throw new ArgumentException($"Celsius degrees cannot be less than absolute zero. Specified {nameof(degreesCelsius)}: {degreesCelsius}", nameof(degreesCelsius));
        }

        return degreesCelsius - absoluteZeroCelsius;
    }

    public static double GetFahrenheitFromCelsius(double degreesCelsius)
    {
        if (degreesCelsius - absoluteZeroCelsius < -epsilone)
        {
            throw new ArgumentException($"Celsius degrees cannot be less than absolute zero. Specified {nameof(degreesCelsius)}: {degreesCelsius}", nameof(degreesCelsius));
        }

        return degreesCelsius * 1.8 + 32;
    }

    public static double GetCelsiusFromKelvin(double degreesKelvin)
    {
        if (degreesKelvin < -epsilone)
        {
            throw new ArgumentException($"Kelvin degrees cannot be less than absolute zero. Specified {nameof(degreesKelvin)}: {degreesKelvin}", nameof(degreesKelvin));
        }

        return degreesKelvin + absoluteZeroCelsius;
    }

    public static double GetFahrenheitFromKelvin(double degreesKelvin)
    {
        if (degreesKelvin < -epsilone)
        {
            throw new ArgumentException($"Kelvin degrees cannot be less than absolute zero. Specified {nameof(degreesKelvin)}: {degreesKelvin}", nameof(degreesKelvin));
        }

        return GetFahrenheitFromCelsius(GetCelsiusFromKelvin(degreesKelvin));
    }

    public static double GetCelsiusFromFahrenheit(double degreesFahrenheit)
    {
        if (degreesFahrenheit - absoluteZeroFahrenheit < - epsilone)
        {
            throw new ArgumentException($"Fahrenheit degrees cannot be less than absolute zero. Specified {nameof(degreesFahrenheit)}: {degreesFahrenheit}", nameof(degreesFahrenheit));
        }

        return (degreesFahrenheit - 32) * 1.8;
    }

    public static double GetKelvinFromFahrenheit(double degreesFahrenheit)
    {
        if (degreesFahrenheit - absoluteZeroFahrenheit < -epsilone)
        {
            throw new ArgumentException($"Fahrenheit degrees cannot be less than absolute zero. Specified {nameof(degreesFahrenheit)}: {degreesFahrenheit}", nameof(degreesFahrenheit));
        }

        return GetKelvinFromCelsius(GetCelsiusFromFahrenheit(degreesFahrenheit));
    }
}
