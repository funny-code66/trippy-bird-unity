using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_sparkly : MonoBehaviour
{
    public float maxTime = 1f;
    private float timer = 0f;

    public RectTransform rt;
    public Animator anim;
    //public GameObject sparklemedal;

    public GameObject scorer;
    public bool cansparkle1;

    // Start is called before the first frame update
    void Start()
    {
        cansparkle1 = scorer.GetComponent<scr_score>().cansparkle;
        //anim = sparklemedal.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            if (cansparkle1)
            {

            rt.localPosition = new Vector3(Random.Range(-12f, 12f), Random.Range(-12f, 12f), 0);
            anim.Play("anim_sparkle", -1, 0f);
            timer = 0;

            }
            else
            {
                timer = 0;
            }

        }


        timer += Time.deltaTime;
    }
}
