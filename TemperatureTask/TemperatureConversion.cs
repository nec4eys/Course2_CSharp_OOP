namespace TemperatureTask;

internal class TemperatureConversion
{
    const double absoluteZeroCelsius = -273.15;

    const double absoluteZeroFahrenheit = -459.67;

    const double epsilone = 1.0e-10;

    public static double ConvertTemperatureFromOneScaleToAnother(double degrees, string fromScale, string toScale)
    {
        degrees = Math.Round(degrees, 3);

        if (fromScale == "" || toScale == "" || fromScale == toScale)
        {
            throw new ArgumentException("Two different scales should be specified", nameof(fromScale) + " " + nameof(toScale));
        }

        double resultDegrees = (toScale + fromScale) switch
        {
            "KC" => GetKelvinFromCelsius(degrees),
            "KF" => GetKelvinFromFahrenheit(degrees),
            "CK" => GetCelsiusFromKelvin(degrees),
            "CF" => GetCelsiusFromFahrenheit(degrees),
            "FC" => GetFahrenheitFromCelsius(degrees),
            "FK" => GetFahrenheitFromKelvin(degrees),
            _ => throw new ArgumentException("Incorrect temperature scales", nameof(fromScale) + " " + nameof(toScale)),
        };

        return Math.Round(resultDegrees, 3);
    }

    private static double GetKelvinFromCelsius(double degreesCelsius)
    {
        if (degreesCelsius - absoluteZeroCelsius < -epsilone)
        {
            throw new ArgumentException($"Celsius degrees cannot be less than absolute zero. Specified {nameof(degreesCelsius)}: {degreesCelsius}", nameof(degreesCelsius));
        }

        return degreesCelsius - absoluteZeroCelsius;
    }

    private static double GetFahrenheitFromCelsius(double degreesCelsius)
    {
        if (degreesCelsius - absoluteZeroCelsius < -epsilone)
        {
            throw new ArgumentException($"Celsius degrees cannot be less than absolute zero. Specified {nameof(degreesCelsius)}: {degreesCelsius}", nameof(degreesCelsius));
        }

        return degreesCelsius * 1.8 + 32;
    }

    private static double GetCelsiusFromKelvin(double degreesKelvin)
    {
        if (degreesKelvin < -epsilone)
        {
            throw new ArgumentException($"Kelvin degrees cannot be less than absolute zero. Specified {nameof(degreesKelvin)}: {degreesKelvin}", nameof(degreesKelvin));
        }

        return degreesKelvin + absoluteZeroCelsius;
    }

    private static double GetFahrenheitFromKelvin(double degreesKelvin)
    {
        if (degreesKelvin < -epsilone)
        {
            throw new ArgumentException($"Kelvin degrees cannot be less than absolute zero. Specified {nameof(degreesKelvin)}: {degreesKelvin}", nameof(degreesKelvin));
        }

        return GetFahrenheitFromCelsius(GetCelsiusFromKelvin(degreesKelvin));
    }

    private static double GetCelsiusFromFahrenheit(double degreesFahrenheit)
    {
        if (degreesFahrenheit - absoluteZeroFahrenheit < -epsilone)
        {
            throw new ArgumentException($"Fahrenheit degrees cannot be less than absolute zero. Specified {nameof(degreesFahrenheit)}: {degreesFahrenheit}", nameof(degreesFahrenheit));
        }

        return (degreesFahrenheit - 32) * 1.8;
    }

    private static double GetKelvinFromFahrenheit(double degreesFahrenheit)
    {
        if (degreesFahrenheit - absoluteZeroFahrenheit < -epsilone)
        {
            throw new ArgumentException($"Fahrenheit degrees cannot be less than absolute zero. Specified {nameof(degreesFahrenheit)}: {degreesFahrenheit}", nameof(degreesFahrenheit));
        }

        return GetKelvinFromCelsius(GetCelsiusFromFahrenheit(degreesFahrenheit));
    }
}
