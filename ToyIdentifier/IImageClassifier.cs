﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ToyIdentifier
{
    public struct ImageClassification
    {
        public ImageClassification(string tag, double probability)
        {
            Tag = tag;
            Probability = probability;
        }

        public string Tag { get; }
        public double Probability { get; }

        public override string ToString() => $"Tag={Tag}, Probability={Probability:N2}";
    }

    public class ImageClassifierException : Exception
    {
        public ImageClassifierException(string message) : base(message) { }
        public ImageClassifierException(string message, Exception innerException) : base(message, innerException) { }
        protected ImageClassifierException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }


    public interface IImageClassifier
    {
        void Init(string modelName);
        Task<IReadOnlyList<ImageClassification>> ClassifyImage(Stream imageStream);
    }
}
