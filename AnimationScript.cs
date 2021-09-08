using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationScript : MonoBehaviour {

    [Space]

    public string animFolder;

    [Space]

    [Range(0, 1)]
    public float sec;

    [Space]

    public Sprite[] frames;

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    SpriteRenderer sr;
    float time;
    int f = 0;
    string old_folder = "none";

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void Awake(){

        f = 0;
        sr = GetComponent<SpriteRenderer>();
        setAnim();
        
    }

    void Start(){

        newFrames();
        
    }

    void Update(){

        time += Time.deltaTime;

        newFrames();
        setAnim();
        sr.sprite = frame();
        
    }

    /*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

    void setAnim() => frames = Resources.LoadAll<Sprite>($"{animFolder}");

    Sprite frame(){

        if ( time >= sec ){ time = 0; f++; }

        if ( f == frames.Length ) f = 1;

        return frames[f];

    }

    void newFrames(){ if ( animFolder != old_folder ){ old_folder = animFolder; f = 0; } }

}