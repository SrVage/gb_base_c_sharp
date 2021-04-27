using System;
using UnityEngine.UIElements;

namespace Code
{
    public sealed class LessNullException:Exception
    {
        public float Value { get; }

        public LessNullException(string message, float val) : base(message)
        {
            Value = val;
        }
    }
}