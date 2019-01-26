using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpExit : MonoBehaviour
{
    public void Close()
    {
        Destroy(this.gameObject);
    }
}
