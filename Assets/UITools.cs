using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITools : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleUIElement(GameObject UIElement)
    {
        UIElement.SetActive(!UIElement.activeSelf);
    }
}
