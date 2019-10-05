using Bridge.Enum;
using Bridge.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    public class Rectangle : BaseShape, IRectangle
    {
        public Rectangle(Func<DrawApiType, IDrawApi> drawType) : base(drawType)
        {
        }

    }
}
