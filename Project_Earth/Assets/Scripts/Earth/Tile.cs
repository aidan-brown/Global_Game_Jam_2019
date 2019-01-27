using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    GameObject containedTower = null;
    bool canPlace = true;

    void addTower(int towerID)
    {
        Quaternion rot = Quaternion.FromToRotation(Vector3.right, transform.position);
        GameObject temp = Instantiate(GameStorage.instance.towerPrefabs[towerID], transform.position, rot);
        temp.transform.parent = gameObject.transform;
        containedTower = temp;
        canPlace = false;
        hideTile();
    }

    public void removeTower()
    {

        //if we make a list of towers it must be removed as well
        Destroy(gameObject.transform.GetChild(0).transform.gameObject);
        containedTower = null;
        canPlace = true;
    }

    public void showTile()
    {
        if (canPlace == true)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            Color tmp = Color.red;
            tmp.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = tmp;
        }
      
    }

    public void hideTile()
    {
        Color tmp = Color.red;
        tmp.a = 0.0f;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    //handles adding Towers
    void OnMouseDown()
    {
        if (ItemHolder.instance.HeldItem != null && canPlace == true)
        {
            addTower(ItemHolder.instance.heldTower);
        }
        else if (canPlace == false)
        {
            removeTower();
        }
    }
}
