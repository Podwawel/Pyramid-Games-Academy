using UnityEngine;
using System;
[CreateAssetMenu(menuName = "ScriptableObjects/Game Over")]
public class GameOver : ScriptableObject
{
    public event Action FinishGameplayEvent;
    public event Action DestroyObjectsEvent;
    public event Action DisableInputEvent;
    
    public void FinishGame()
    {
        DestroyObjectsEvent?.Invoke();
        FinishGameplayEvent?.Invoke();
        DisableInputEvent?.Invoke();
    }
}
