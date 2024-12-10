using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnScreenPercentage : MonoBehaviour
{
    public TextMeshProUGUI screenText;
    public GameObject GoalMarker;
    public GameObject Player;
    public float levelLength;
    public float currentDistance;
    public float progress;

    // Start is called before the first frame update
    void Start()
    {
        levelLength = GoalMarker.transform.position.x - Player.transform.position.x;
        Debug.Log(levelLength);
    }

    // Update is called once per frame
    void Update()
    {
        if (progress < 100)
        {
            currentDistance = GoalMarker.transform.position.x - Player.transform.position.x;
            progress = (100 - (currentDistance / levelLength) * 100);
        }
        screenText.text = ((int)progress + "%");
    }
}
