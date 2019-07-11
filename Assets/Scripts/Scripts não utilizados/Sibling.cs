using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sibling : MonoBehaviour
{
   //Use this to change the hierarchy of the GameObject siblings
    public int m_IndexNumber;

    void Update()
    {
        //Initialise the Sibling Index to 0
        //m_IndexNumber = 3;
        //Set the Sibling Index
        transform.parent.SetSiblingIndex(m_IndexNumber);
        //Output the Sibling Index to the console
        Debug.Log("Sibling Index : " + transform.GetSiblingIndex());
    }
}
