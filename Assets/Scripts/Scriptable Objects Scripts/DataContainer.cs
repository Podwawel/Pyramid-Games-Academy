using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Gameplay Data Container")]
public class DataContainer : ScriptableObject
{
    public GameObject[] DoorVariants;
    public GameObject Chest;
    public GameObject Key;
    public bool IsKeyCollected;
    public float CurrentScore;

    public GameObject ChestOnScene, KeyOnScene, DoorOnScene;
}
