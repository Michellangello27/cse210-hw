using System;
using System.Collections.Generic;

public class NonRepeatingStringPicker
{
    private List<string> _all;
    private List<string> _unused;
    private Random _random;

    public NonRepeatingStringPicker(List<string> items)
    {
        if (items == null)
        {
            _all = new List<string>();
        }
        else
        {
            _all = items;
        }

        _unused = new List<string>(_all);
        _random = new Random();
    }

    public string Next()
    {
        if (_all.Count == 0)
        {
            return "";
        }

        if (_unused.Count == 0)
        {
            _unused.AddRange(_all);
        }

        int index = _random.Next(_unused.Count);
        string item = _unused[index];
        _unused.RemoveAt(index);
        return item;
    }

    public int RemainingInCycle()
    {
        return _unused.Count;
    }
}
