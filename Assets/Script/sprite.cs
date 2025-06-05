using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.clanow == true)
        {
            SpriteRenderer.sprite = sprite1;
        }
        if (GameManager.shinow == true)
        {
            SpriteRenderer.sprite = sprite2;
        }
        if (GameManager.pinnow == true)
        {
            SpriteRenderer.sprite = sprite3;
        }

    }
}
