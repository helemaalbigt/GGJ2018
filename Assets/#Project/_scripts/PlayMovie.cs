using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovie : MonoBehaviour
{
    MovieTexture movie;
    void Start()
    {
        movie = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);
        movie.Play();
        movie.loop = true;
    }
}
