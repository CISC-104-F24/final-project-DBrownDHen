using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.Timeline.Actions;
using UnityEngine.SceneManagement;

public class CompletionScreenTrigger : MonoBehaviour
{
    public GameObject Percentage;
    public GameObject CompletionScreen;

    // Start is called before the first frame update
    void Start()
    {
        CompletionScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Percentage.GetComponent<OnScreenPercentage>().progress >= 100)
        {
            CompletionScreen.SetActive(true);
        }
    }
}
