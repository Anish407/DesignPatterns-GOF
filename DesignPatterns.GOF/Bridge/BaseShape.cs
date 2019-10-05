using Bridge.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    public abstract class BaseShape
    {
        public BaseShape(Func<DrawApiType, IDrawApi> drawType)
        {
            DrawType = drawType;
        }
        public BaseShape()
        {

        }

        public Func<DrawApiType, IDrawApi> DrawType { get; }

        public string Draw(DrawApiType type) => $"Drawn {this.GetType().Name} : {DrawType(type).DrawLine()}";
    }
}
