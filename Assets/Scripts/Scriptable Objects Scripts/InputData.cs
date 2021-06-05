using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Input Data Container")]
public class InputData : ScriptableObject
{
    public KeyCode moveForward, moveBackward, moveLeft, moveRight;
    public KeyCode rotateRight, rotateLeft;
}
