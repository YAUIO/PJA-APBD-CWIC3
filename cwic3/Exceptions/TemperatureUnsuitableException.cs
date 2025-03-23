namespace cwic3.Exceptions;

public class TemperatureUnsuitableException(double expected, double actual)
    : Exception("Expected temperature to be " + expected + " or lower, got " + actual);