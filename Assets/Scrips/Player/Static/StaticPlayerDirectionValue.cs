using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticPlayerDirectionValue
{
    private static Vector3 _upDirection = new Vector3(0, 0, 1);
    private static Vector3 _downDirection = new Vector3(0, 0, -1);
    private static Vector3 _rightDirection = new Vector3(1, 0, 0);
    private static Vector3 _leftDirection = new Vector3(-1, 0, 0);
    private static Vector3 _upAndRightDirection = new Vector3(0.707f, 0, 0.707f);
    private static Vector3 _upAndLeftDirection = new Vector3(-0.707f, 0, 0.707f);
    private static Vector3 _downAndRightDirection = new Vector3(0.707f, 0, -0.707f);
    private static Vector3 _downAndLeftDirection = new Vector3(-0.707f, 0, -0.707f);
    private static Vector3 _null = new Vector3(0, 0, 0);

    public static Vector3 UpDirection => _upDirection;
    public static Vector3 DownDirection => _downDirection;
    public static Vector3 RightDirection => _rightDirection;
    public static Vector3 LeftDirection => _leftDirection;
    public static Vector3 UpAndRightDirection => _upAndRightDirection;
    public static Vector3 UpAndLeftDirection => _upAndLeftDirection;
    public static Vector3 DownAndRightDirection => _downAndRightDirection;
    public static Vector3 DownAndLeftDirection => _downAndLeftDirection;
    public static Vector3 Null => _null;
}