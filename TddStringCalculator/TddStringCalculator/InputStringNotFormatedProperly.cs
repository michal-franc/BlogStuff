using System;
using System.Runtime.Serialization;

namespace TddStringCalculator
{
    [Serializable]
    public class InputStringNotFormatedProperly : Exception
    {
        public InputStringNotFormatedProperly() { } 

        public InputStringNotFormatedProperly(string message) :base(message) { } 

        public InputStringNotFormatedProperly(string message, Exception innerException)
            :base(message, innerException) { }

        public InputStringNotFormatedProperly(SerializationInfo info, StreamingContext context)
            :base(info, context) { }

    }
}