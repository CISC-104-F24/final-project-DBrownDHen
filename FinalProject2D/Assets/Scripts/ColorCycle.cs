using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycle : MonoBehaviour
{
    public float red = 0.0f;
    public float green = 0.0f;
    public float blue = 0.0f;
    public float cycleRate = 0.25f;
    public bool colorsCycled = false;

    // Start is called before the first frame update
    void Start()
    {
        red = Random.Range(0.0f, 1.0f);
        blue = Random.Range(0.0f, 1.0f);
        green = Random.Range(0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!colorsCycled)
        {
            if (!(red >= 1.0f))
            {
                red += cycleRate * Time.deltaTime;
            }
            else
            {
                if (!(green >= 1.0f))
                {
                    green += cycleRate * Time.deltaTime;
                }
                else
                {
                    if (!(blue >= 1.0f))
                    {
                        blue += cycleRate * Time.deltaTime;
                    }
                }
            }
            if ((red >= 1.0f) && (green >= 1.0f) && (blue >= 1.0f))
            {
                colorsCycled = true;
            }
        }
        else
        {
            if (!(red <= 0.0f))
            {
                red -= cycleRate * Time.deltaTime;
            }
            else
            {
                if (!(green <= 0.0f))
                {
                    green -= cycleRate * Time.deltaTime;
                }
                else
                {
                    if (!(blue <= 0.0f))
                    {
                        blue -= cycleRate * Time.deltaTime;
                    }
                }
            }
            if ((red <= 0.0f) && (green <= 0.0f) && (blue <= 0.0f))
            {
                colorsCycled = false;
            }
        }
        GetComponent<SpriteRenderer>().color = new Color(red, green, blue);
    }
}
