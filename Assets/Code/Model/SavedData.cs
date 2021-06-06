using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Code
{
    [Serializable]
    public sealed class SavedData
    {
        public string NameOfObject;
        public Vector3Save PositionOfObject;
        public bool IsEnabled;

        public override string ToString() =>
            $"(Name = {NameOfObject} Position = {PositionOfObject} Status = {IsEnabled})";
    }

    [Serializable]
    public struct Vector3Save
    {
        public float X;
        public float Y;
        public float Z;

        private Vector3Save(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public static implicit operator Vector3(Vector3Save value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator Vector3Save(Vector3 value)
        {
            return new Vector3Save(value.x, value.y, value.z);
        }

        public override string ToString() => $"(X = {X} Y = {Y} Z = {Z})";
    }
}