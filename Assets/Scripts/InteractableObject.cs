using UnityEngine;
using System;

public class InteractableObject : MonoBehaviour
{
    protected event Action PopupEvent;
    [SerializeField] protected GameObject[] CanvasPrefab;
    [SerializeField] protected DataContainer dataContainer;
    [SerializeField] protected MeshRenderer[] meshRenderer;
    protected GameObject newCanvas;

    public virtual void OnMouseEnter()
    {
        foreach (MeshRenderer element in meshRenderer)
        {
            Color newColor = new Color(element.material.color.r + 0.2f, element.material.color.g + 0.2f, element.material.color.b + 0.2f);
            element.material.color = newColor;
        }
    }

    public virtual void OnMouseDown()
    {
        PopupEvent?.Invoke();
        AudioManager.instance.PlaySFX(4);
    }

    public virtual void OnMouseExit()
    {
        foreach (MeshRenderer element in meshRenderer)
        {
            Color newColor = new Color(element.material.color.r - 0.2f, element.material.color.g - 0.2f, element.material.color.b - 0.2f);
            element.material.color = newColor;
        }
    }

    protected void DisableCollider()
    {
        GetComponent<Collider>().enabled = false;
    }
}
