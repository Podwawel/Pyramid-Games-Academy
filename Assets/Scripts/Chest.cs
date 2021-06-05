using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : InteractableObject
{
    private void Start()
    {
        PopupEvent += InteractableObject_ChestPopup;
    }
    public override void OnMouseDown()
    {
        if (Vector3.Distance(dataContainer.ChestOnScene.transform.position,PlayerManager.instance.transform.position) <=10f)
        {
            base.OnMouseDown();
        }
    }

    private void InteractableObject_ChestPopup()
    {
        newCanvas = Instantiate(CanvasPrefab[0]);
        DisableCollider();
    }

    public void OpenChest()
    {
        dataContainer.ChestOnScene.GetComponent<BoxCollider>().enabled = false;
        dataContainer.ChestOnScene.GetComponent<Animator>().SetBool("Open", true);
        AudioManager.instance.PlaySFX(1);
        CloseChestPopup();
    }

    public void CloseChestPopup()
    {
        foreach (Canvas element in FindObjectsOfType<Canvas>())
        {
            if (element.name.Equals("Chest Canvas(Clone)"))
            {
                Destroy(element.gameObject);
            }
        }
    }
    public void EnableCollider()
    {
        dataContainer.ChestOnScene.GetComponent<Collider>().enabled = true;
    }
}
