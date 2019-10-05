using Bridge.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    public class Square : BaseShape, IShape
    {
        public Square(Func<DrawApiType, IDrawApi> drawType) : base(drawType)
        {
        }

    }
}
