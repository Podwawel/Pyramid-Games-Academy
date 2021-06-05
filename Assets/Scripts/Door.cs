using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] private GameOver gameOver;
    private void Start()
    {
        PopupEvent += InteractableObject_DoorPopup;
    }
    public override void OnMouseDown()
    {
        if (Vector3.Distance(dataContainer.DoorOnScene.transform.position, PlayerManager.instance.transform.position) <= 10f)
            base.OnMouseDown();
    }

    private void InteractableObject_DoorPopup()
    {
        if (dataContainer.IsKeyCollected)
        {
            newCanvas = Instantiate(CanvasPrefab[0]);
        }
        else
        {
            StartCoroutine(ScreenShakeCO());
            newCanvas = Instantiate(CanvasPrefab[1]);
        }
        DisableCollider();
    }

    public void OpenDoor()
    {
        AudioManager.instance.PlaySFX(3);
        Invoke("DelayedGameOver", 1.3f);
        CloseDoorPopup();
        dataContainer.DoorOnScene.GetComponent<Collider>().enabled = false;
    }

    private void DelayedGameOver()
    {
        gameOver.FinishGame();
    }

    public void CloseDoorPopup()
    {
        EnableCollider();
        foreach (Canvas element in FindObjectsOfType<Canvas>())
        {
            if (element.name.Equals("Door Without Key Canvas(Clone)") || element.name.Equals("Door With Key Canvas(Clone)"))
            {
                Destroy(element.gameObject);
            }
        }
    }
    private void EnableCollider()
    {
        dataContainer.DoorOnScene.GetComponent<Collider>().enabled = true;
    }

    private IEnumerator ScreenShakeCO()
    {
        float duration = 0.2f;
        float magnitude = 0.1f;
        Vector3 originalPos = PlayerManager.instance.transform.position;
        float timeElapsed = 0f;

        while(timeElapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            PlayerManager.instance.transform.position = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        PlayerManager.instance.transform.position = originalPos;
    }
}
