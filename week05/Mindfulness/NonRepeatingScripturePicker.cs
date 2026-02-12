using System;
using System.Collections.Generic;

public class NonRepeatingScripturePicker
{
    private List<Scripture> _all;
    private List<Scripture> _unused;
    private Random _random;

    public NonRepeatingScripturePicker(List<Scripture> items)
    {
        if (items == null)
        {
            _all = new List<Scripture>();
        }
        else
        {
            _all = items;
        }

        _unused = new List<Scripture>(_all);
        _random = new Random();
    }

    public Scripture Next()
    {
        if (_all.Count == 0)
        {
            return null;
        }

        if (_unused.Count == 0)
        {
            _unused.AddRange(_all);
        }

        int index = _random.Next(_unused.Count);
        Scripture item = _unused[index];
        _unused.RemoveAt(index);
        return item;
    }

    public int RemainingInCycle()
    {
        return _unused.Count;
    }
}
