using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/Game Setup")]
public class GameSetup: ScriptableObject
{
    public event Action SpawnObjectsEvent;
    public event Action StartGameplayEvent;
    public event Action EnableInputEvent;

    [SerializeField] private DataContainer dataContainer;

    public void StartGame()
    {
        SpawnObjectsEvent?.Invoke();
        StartGameplayEvent?.Invoke();
        EnableInputEvent?.Invoke();
    }
}
