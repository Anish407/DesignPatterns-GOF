using Bridge.Enum;
using System;

namespace Bridge
{
    public interface IShape
    {
        string Draw(DrawApiType type);
    }
}
