using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth : MonoBehaviour
{
    [SerializeField] int RotationSpeed;
    [SerializeField] GameObject tile; // tile to create
    [SerializeField] int tileAmount;
    [SerializeField] List<GameObject> spaces;

    public Slider hpBar;
    private int totalHP = 100;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 center = transform.position;
        for (int i = 0; i < tileAmount; i++)
        {
            Vector3 pos = placeOnCircle(center, 2.2f, i * 20);
            Quaternion rot = Quaternion.FromToRotation(Vector3.right, center - pos);
            GameObject temp = Instantiate(tile, pos, rot);
            temp.transform.parent = gameObject.transform;
            spaces.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rotate earth
        transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
        hpBar.value = 100 - totalHP;
    }


    Vector3 placeOnCircle(Vector3 center, float radius, int angle)
    {
        float ang = angle;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    public void showTiles()
    {
        foreach (GameObject t in spaces)
        {
            t.GetComponent<Tile>().showTile();

        }
    }

    public void hideTiles()
    {
        foreach (GameObject t in spaces)
        {
            t.GetComponent<Tile>().hideTile();
        }
    }

    public void TakeDamage()
    {
        totalHP -= 5;
    }
}



