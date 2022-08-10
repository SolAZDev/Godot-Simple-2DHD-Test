using System;
using Godot;

public static class Utils
{
    public static Vector3 TreeScale(Vector3 a, Vector3 b) { return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z); }
}