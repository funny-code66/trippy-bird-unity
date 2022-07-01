using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_pipespawner : MonoBehaviour
{
    public float maxTime;
    private float timer = 0f;
    public GameObject[] pipes;
    public GameObject player;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = 1.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            if (player.GetComponent<scr_birdcontrols>().canjump == true) {
            GameObject newpipe = Instantiate(pipes[Random.Range(0, 2)]);
            newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            newpipe.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            //Destroy(newpipe, 5);
            timer = 0;
        }
        }

        timer += Time.deltaTime;
    }
}
