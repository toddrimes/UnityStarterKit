using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using Object = System.Object;
using Random = UnityEngine.Random;

public class DataManager : MonoBehaviour
{

    string url = "https://covidtracking.com/api/v1/states/current.json";

    StateData[] m_States;
    bool m_DataCaptured;

    public bool dataCaptured
    {
        get => m_DataCaptured;
    }

    void OnEnable()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error occured with web request");
            }
            else
            {
                m_DataCaptured = true;
                try
                {
                    m_States = JsonConvert.DeserializeObject<StateData[]>(webRequest.downloadHandler.text);
                }
                catch (JsonSerializationException ex)
                {
                    Console.WriteLine(ex.Message);
                    m_DataCaptured = false;
                }
            }
        }        
    }

    public int GetStatePositiveCases(DataUIDisplay.StateCode stateCode)
    {
        if (m_DataCaptured)
        {
            return (int) m_States[GetStateIndex(stateCode)].positive;
        }
        else
        {
            return -1;
        }
    }
    
    public int GetStateIndex(DataUIDisplay.StateCode stateCode)
    {
        return (int)stateCode;
    }
}



public class StateData
{
    public int date;
    public string state; 
    public int? positive; 
    public int? probable; 
    public int? negative; 
    public int? pending; 
    public string totalTestResultsSource; 
    public int? totalTestResults; 
    public int? hospitalizedCurrently; 
    public int? hospitalizedCumulative; 
    public int? inIcuCurrently; 
    public int? inIcuCumulative; 
    public int? onVentilatorCurrently; 
    public int? onVentilatorCumulative; 
    public int? recovered; 
    public string dataQualityGrade;
    public string lastUpdateEt; 
    public DateTime? dateModified;
    public string checkTimeEt; 
    public int? death; 
    public int? hospitalized;
    public DateTime? dateChecked;
    public int? totalTestsViral;
    public int? positiveTestsViral;
    public int? negativeTestsViral;
    public int? positiveCasesViral;
    public int? deathConfirmed;
    public int? deathProbable;
    public int? totalTestEncountersViral;
    public int? totalTestsPeopleViral;
    public int? totalTestsAntibody;
    public int? positiveTestsAntibody;
    public int? negativeTestsAntibody;
    public int? totalTestsPeopleAntibody;
    public int? positiveTestsPeopleAntibody;
    public int? negativeTestsPeopleAntibody;
    public int? totalTestsPeopleAntigen;
    public int? positiveTestsPeopleAntigen;
    public int? totalTestsAntigen;
    public int? positiveTestsAntigen;
    public string fips;
    public int? positiveIncrease;
    public int? negativeIncrease;
    public int? total;
    public int? totalTestResultsIncrease;
    public int? posNeg;
    public int? deathIncrease;
    public int? hospitalizedIncrease;
    public string hash;
    public int? commercialScore;
    public int? negativeRegularScore;
    public int? negativeScore;
    public int? positiveScore;
    public int? score;
    public string grade;
}
