using Bridge.Enum;
using Bridge.Interface;
using System;

namespace Bridge
{
    public class Rectangle : BaseShape, IRectangle
    {
        public Rectangle(Func<DrawApiType, IDrawApi> drawType) : base(drawType)
        {
        }

    }
}
