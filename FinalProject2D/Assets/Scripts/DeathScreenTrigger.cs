using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.Timeline.Actions;
using UnityEngine.SceneManagement;

public class DeathScreenTrigger : MonoBehaviour
{
    public GameObject CubeHitbox;
    public GameObject DeathScreen;
    public float deathCooldown = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        DeathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeHitbox.GetComponent<PHitbox>().isAlive == false)
        {
            deathCooldown -= 1.0f * Time.deltaTime;
        }
        if (deathCooldown <= 0.0f)
        {
            if (!(Input.GetKey(KeyCode.Space)))
            {
                DeathScreen.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
