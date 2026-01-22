using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        // Constructor that has no parameters that initializes the number to 1/1.
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int wholeNumber)
    {
        //Constructor that has one parameter for the top and that initializes the denominator to 1
        _numerator = wholeNumber;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        //Constructor that has two parameters, one for the numerator and one for the denominator.
        _numerator = numerator;
        _denominator = denominator;
    }

    public string GetFractionString()
    {
        string text = $"{_numerator}/{_denominator}";
        return text;
    }

    public double GetDecimalValue()
    {
        
        return (double)_numerator / (double)_denominator;
    }
}