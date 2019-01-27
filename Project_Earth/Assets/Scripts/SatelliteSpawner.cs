using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SatelliteSpawner : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Temporary storage for a satellite while choosing a place to spawn
    private GameObject interimSat;

    private Camera cam;

    //Position of the Earth for rotation purposes
    public Transform earth;

    //How far away the satellites spawn from the camera
    public int spawnDistance;

    public int satelliteID = 0;

    void Start()
    {
        cam = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(interimSat == null);
        interimSat = Instantiate(GameStorage.instance.satellitePrefabs[satelliteID], earth.position, earth.rotation);
    }

    public void OnDrag(PointerEventData eventData)
    {
        interimSat.transform.GetChild(0).position = cam.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, spawnDistance));
        if (GameStorage.instance.playerCurrency >= GameStorage.instance.satellitePrefabs[satelliteID].GetComponent<Tower>().cost)
            interimSat.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        else
            interimSat.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (interimSat.GetComponentInChildren<Collider2D>().OverlapCollider(new ContactFilter2D(), new Collider2D[1]) != 0)//This is for 3d collisions: interimSat.GetComponentInChildren<SatelliteScript>().targets.Count != 0)
        {
            Destroy(interimSat);
        }
        else
        {
            if (GameStorage.instance.playerCurrency >= GameStorage.instance.satellitePrefabs[satelliteID].GetComponent<Tower>().cost)
                GameStorage.instance.playerCurrency -= GameStorage.instance.satellitePrefabs[satelliteID].GetComponent<Tower>().cost;
            else
                Destroy(interimSat);
        }
        interimSat = null;
    }
}
