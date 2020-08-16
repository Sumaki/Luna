﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    #region Animator Variables
    public Animator ani;
    public enum State {idle, walk, jump, interact, land };
    public static State playerState;
    #endregion

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        CheckVariables();
    }

    /// <summary>
    /// Sets the animation status depending on the player's inputs.
    /// </summary>
    void CheckVariables()
    {
        switch (playerState)
        {
            case (State.idle):
                ani.SetBool("idle", true);
                ani.SetBool("walk", false);
                ani.SetBool("jump", false);
                ani.SetBool("interact", false);
                ani.SetBool("land", false);
                break;
            case (State.walk):
                ani.SetBool("idle", false);
                ani.SetBool("walk", true);
                ani.SetBool("jump", false);
                ani.SetBool("interact", false);
                ani.SetBool("land", false);
                break;
            case (State.jump):
                ani.SetBool("idle", false);
                ani.SetBool("walk", false);
                ani.SetBool("jump", true);
                ani.SetBool("interact", false);
                ani.SetBool("land", false);
                break;
            case (State.interact):
                ani.SetBool("idle", false);
                ani.SetBool("walk", false);
                ani.SetBool("jump", false);
                ani.SetBool("interact", true);
                ani.SetBool("land", false);
                break;
            case (State.land):
                ani.SetBool("idle", false);
                ani.SetBool("walk", false);
                ani.SetBool("jump", false);
                ani.SetBool("interact", false);
                ani.SetBool("land", true);
                break;
        }
    }
}
