using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationState : MonoBehaviour
{
    private Animator _animator;
    public static int animationState;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetInteger("DoorState", animationState);

    }
}
