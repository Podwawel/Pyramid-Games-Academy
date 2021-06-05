using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Key : InteractableObject
{
    private void Start()
    {
        PopupEvent += InteractableObject_KeyPopup;
    }
    public override void OnMouseDown()
    {
        if (Vector3.Distance(dataContainer.KeyOnScene.transform.position, PlayerManager.instance.transform.position) <= 10f)
            base.OnMouseDown();
    }
    private void InteractableObject_KeyPopup()
    {
        newCanvas = Instantiate(CanvasPrefab[0]);
        DisableCollider();
    }

    public void TakeKey()
    {
        dataContainer.KeyOnScene.SetActive(false);
        AudioManager.instance.PlaySFX(2);
        dataContainer.IsKeyCollected = true;
        CloseKeyPopup();
    }
    public void CloseKeyPopup()
    {
        foreach (Canvas element in FindObjectsOfType<Canvas>())
        {
            if (element.name.Equals("Key Canvas(Clone)"))
            {
                Destroy(element.gameObject);
            }
        }      
    }
    public void EnableCollider()
    {
        dataContainer.KeyOnScene.GetComponent<Collider>().enabled = true;
    }
}
