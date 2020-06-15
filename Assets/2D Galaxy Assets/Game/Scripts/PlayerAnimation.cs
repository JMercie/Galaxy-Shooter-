using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    // Use this for initialization
    void Start()
    {
        _anim = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _anim.SetBool("turnLeft", true);
            _anim.SetBool("turnRight", false);
        }

        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _anim.SetBool("turnLeft", false);
            _anim.SetBool("turnRight", false);
        }

        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _anim.SetBool("turnRight", true);
            _anim.SetBool("turnLeft", false);
        }

        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _anim.SetBool("turnRight", false);
            _anim.SetBool("turnLeft", false);
        }


    }
}
