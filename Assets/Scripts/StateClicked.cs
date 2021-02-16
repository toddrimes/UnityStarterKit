using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StateClicked : MonoBehaviour, IPointerClickHandler
{

    //Detect current clicks on the GameObject (the one with the script attached)
    private void Update()
    {   
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1))
        {
            Debug.Log($"I hit this thing: {hit.transform.name}");
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"I hit this thing: {name}");
    }
    
}
