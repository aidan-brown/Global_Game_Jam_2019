using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    GameObject containedTower = null;
    bool canPlace = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addTower(GameObject tower)
    {
        Quaternion rot = Quaternion.FromToRotation(Vector3.right, transform.position);
        GameObject temp = Instantiate(tower, transform.position, rot);
        temp.transform.parent = gameObject.transform;
        containedTower = temp;
        canPlace = false;
        hideTile();
    }

    void removeTower()
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
            addTower(ItemHolder.instance.HeldItem);
        }
        else if (canPlace == false)
        {
            removeTower();
        }
    }
}
