using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Simply copies the given source text once for each state and prints the state name and founded date. Results are sorted by founding date by default.
public class StateListDebug : MonoBehaviour {

    public TextMesh SourceText;

    // Use this for initialization
    IEnumerator Start()
    {
        var states = FindObjectOfType<StatesInfo>();
        if (states == null)
            yield break;

        while (states.AllStates.Length <= 0) yield return null;

        states.SortByFounded();

        for (int i = 0; i < states.AllStates.Length; i++)
        {
            var newText = (Instantiate(SourceText.gameObject) as GameObject).GetComponent<TextMesh>();
            newText.text = states.AllStates[i].StateId + ": " + states.AllStates[i].StateName + " - " + states.AllStates[i].Founded.ToShortDateString();
            newText.transform.parent = SourceText.transform.parent;
            newText.transform.position = SourceText.transform.position + Vector3.down * i * newText.GetComponent<Renderer>().bounds.size.y * 0.84f;
            newText.gameObject.name = states.AllStates[i].StateName;
        }
        SourceText.gameObject.SetActive(false);
    }

}
