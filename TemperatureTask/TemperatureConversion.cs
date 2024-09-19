namespace TemperatureTask;

internal class TemperatureConversion
{
    private const double AbsoluteZeroCelsius = -273.15;

    private const double AbsoluteZeroFahrenheit = -459.67;

    private const double Epsilon = 1.0e-10;

    public static double ConvertTemperatureFromOneScaleToAnother(double degrees, string fromScale, string toScale)
    {
        if (fromScale == toScale)
        {
            return Math.Round(degrees, 3, MidpointRounding.AwayFromZero);
        }

        var resultDegrees = (toScale + fromScale) switch
        {
            "KC" => GetKelvinFromCelsius(degrees),
            "KF" => GetKelvinFromFahrenheit(degrees),
            "CK" => GetCelsiusFromKelvin(degrees),
            "CF" => GetCelsiusFromFahrenheit(degrees),
            "FC" => GetFahrenheitFromCelsius(degrees),
            "FK" => GetFahrenheitFromKelvin(degrees),
            _ => throw new ArgumentException("Incorrect temperature scales", nameof(fromScale) + " " + nameof(toScale)),
        };

        return Math.Round(resultDegrees, 3, MidpointRounding.AwayFromZero);
    }

    private static double GetKelvinFromCelsius(double degreesCelsius)
    {
        if (degreesCelsius - AbsoluteZeroCelsius < -Epsilon)
        {
            throw new ArgumentException($"Celsius degrees cannot be less than absolute zero. Specified {nameof(degreesCelsius)}: {degreesCelsius}", nameof(degreesCelsius));
        }

        return degreesCelsius - AbsoluteZeroCelsius;
    }

    private static double GetFahrenheitFromCelsius(double degreesCelsius)
    {
        if (degreesCelsius - AbsoluteZeroCelsius < -Epsilon)
        {
            throw new ArgumentException($"Celsius degrees cannot be less than absolute zero. Specified {nameof(degreesCelsius)}: {degreesCelsius}", nameof(degreesCelsius));
        }

        return degreesCelsius * 1.8 + 32;
    }

    private static double GetCelsiusFromKelvin(double degreesKelvin)
    {
        if (degreesKelvin < -Epsilon)
        {
            throw new ArgumentException($"Kelvin degrees cannot be less than absolute zero. Specified {nameof(degreesKelvin)}: {degreesKelvin}", nameof(degreesKelvin));
        }

        return degreesKelvin + AbsoluteZeroCelsius;
    }

    private static double GetFahrenheitFromKelvin(double degreesKelvin)
    {
        if (degreesKelvin < -Epsilon)
        {
            throw new ArgumentException($"Kelvin degrees cannot be less than absolute zero. Specified {nameof(degreesKelvin)}: {degreesKelvin}", nameof(degreesKelvin));
        }

        return GetFahrenheitFromCelsius(GetCelsiusFromKelvin(degreesKelvin));
    }

    private static double GetCelsiusFromFahrenheit(double degreesFahrenheit)
    {
        if (degreesFahrenheit - AbsoluteZeroFahrenheit < -Epsilon)
        {
            throw new ArgumentException($"Fahrenheit degrees cannot be less than absolute zero. Specified {nameof(degreesFahrenheit)}: {degreesFahrenheit}", nameof(degreesFahrenheit));
        }

        return (degreesFahrenheit - 32) * 1.8;
    }

    private static double GetKelvinFromFahrenheit(double degreesFahrenheit)
    {
        if (degreesFahrenheit - AbsoluteZeroFahrenheit < -Epsilon)
        {
            throw new ArgumentException($"Fahrenheit degrees cannot be less than absolute zero. Specified {nameof(degreesFahrenheit)}: {degreesFahrenheit}", nameof(degreesFahrenheit));
        }

        return GetKelvinFromCelsius(GetCelsiusFromFahrenheit(degreesFahrenheit));
    }
}
