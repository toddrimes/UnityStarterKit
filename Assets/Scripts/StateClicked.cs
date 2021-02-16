using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StateClicked : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private DataBarDisplay _dataBarDisplay;

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
        string myTwoCharName = name.Substring(0, 2);
        foreach(DataUIDisplay.StateCode state in (DataUIDisplay.StateCode[]) Enum.GetValues(typeof(DataUIDisplay.StateCode)))
        {
            if (state.ToString() == myTwoCharName)
            {
                _dataBarDisplay.stateCode1 = _dataBarDisplay.stateCode2;
                _dataBarDisplay.stateCode2 = _dataBarDisplay.stateCode3;
                _dataBarDisplay.stateCode3 = _dataBarDisplay.stateCode4;
                _dataBarDisplay.stateCode4 = _dataBarDisplay.stateCode5;
                _dataBarDisplay.stateCode5 = state;
            }
        }
    }
    
}
