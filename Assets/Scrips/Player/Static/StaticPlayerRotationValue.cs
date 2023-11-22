using UnityEngine;

public class StaticPlayerRotationValue : MonoBehaviour
{
    private static Quaternion _upAndRightRotation = new Quaternion(0, 0.38f, 0, 0.923f);
    private static Quaternion _upAndLeftRotation = new Quaternion(0, -0.38f, 0, 0.923f);
    private static Quaternion _downAndRightRotation = new Quaternion(0, 0.924f, 0, 0.383f);
    private static Quaternion _downAndLeftRotation = new Quaternion(0, 0.924f, 0, -0.383f);
    private static Quaternion _upRotation = new Quaternion(0, 0, 0, 1);
    private static Quaternion _downRotation = new Quaternion(0, 1, 0, 0);
    private static Quaternion _rightRotation = new Quaternion(0, 0.70711f, 0, 0.70711f);
    private static Quaternion _leftRotation = new Quaternion(0, 0.70711f, 0, -0.70711f);

    public static Quaternion UpAndRightRotation => _upAndRightRotation;
    public static Quaternion UpAndLeftRotation => _upAndLeftRotation;
    public static Quaternion DownAndRightRotation => _downAndRightRotation;
    public static Quaternion DownAndLeftRotation => _downAndLeftRotation;
    public static Quaternion UpRotation => _upRotation;
    public static Quaternion DownRotation => _downRotation;
    public static Quaternion RightRotation => _rightRotation;
    public static Quaternion LeftRotation => _leftRotation;
}