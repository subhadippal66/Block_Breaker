using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour
{
    Level level; 
    [SerializeField] AudioClip breakSound;
    GameStatus game_status;
    [SerializeField] GameObject particleEffectsVFX;


    int currentNoOfHits; //handles the current no of hits

    [SerializeField] Sprite[] sprite_1; //to assign damages sprites

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableObject();
        }
             game_status = FindObjectOfType<GameStatus>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleSprites();

        }
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void HandleSprites()
    {
        int maxHits = sprite_1.Length + 1;
        currentNoOfHits++;
        if (currentNoOfHits >= maxHits)
        {
            DestroyBreakableBlocks();
        }

        else
        {
            ShowNextSprites();
        }
    }

    private void ShowNextSprites()
    {
        int spriteNo = currentNoOfHits - 1;
        GetComponent<SpriteRenderer>().sprite = sprite_1[spriteNo];
        game_status.AddToScore_1();
    }

    private void DestroyBreakableBlocks()
    {
        Destroy(gameObject, 0.0f);
        TriggerParticleOnDestroy();
        game_status.AddToScore();
        level.BlockDestroyed();
    }

    private void TriggerParticleOnDestroy()
    {
        GameObject sparkleVFX = Instantiate(particleEffectsVFX, transform.position, transform.rotation);
        Destroy(sparkleVFX, 1f);
    }
}


