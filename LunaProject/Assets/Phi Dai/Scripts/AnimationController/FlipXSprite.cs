using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipXSprite : MonoBehaviour
{

    SpriteRenderer sprite_;

    void Start()
    {
        sprite_ = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        SetFlip();
    }

    /// <summary>
    /// This references to the player's movement and sets the SpriteRender axis itself depending on the result.
    /// </summary>
    void SetFlip()
    {
        if (PlayerInput.flipX)
            sprite_.flipX = true;
        if (!PlayerInput.flipX)
            sprite_.flipX = false;
    }
}
