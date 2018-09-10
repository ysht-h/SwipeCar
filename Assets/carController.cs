using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{


    float speed = 0.0f;
    enum SPINST
    {
        INIT,
        WAIT,
        RESULT,
    };

    SPINST spinst = SPINST.INIT;
    Vector2 start;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        switch (spinst)
        {
            case SPINST.INIT:
                if (Input.GetMouseButtonDown(0))
                {
                    this.start = Input.mousePosition;
                }
                else
                if (Input.GetMouseButtonUp(0))
                {
                    Vector2 end = Input.mousePosition;
                    float swipe = end.x - start.x;
                    this.speed = swipe / 500.0f;

                    // 効果音再生する
                    GetComponent<AudioSource>().Play();

                    spinst = SPINST.WAIT;
                }

                break;

            case SPINST.WAIT:

                if (this.speed < 0.01f)
                {
                    spinst = SPINST.RESULT;
                }

                break;

            case SPINST.RESULT:

                if (Input.GetMouseButtonUp(0))
                {
                    Vector3 pos = transform.position;
                    pos.x = -7.0f;
                    transform.SetPositionAndRotation(pos, Quaternion.identity);

                    this.speed = 0.0f;
                    spinst = SPINST.INIT;
                }

                break;
        }

        if (spinst < SPINST.RESULT)
        {
            transform.Translate(this.speed, 0.0f, 0.0f);
            this.speed *= 0.98f;
        }
    }

}
