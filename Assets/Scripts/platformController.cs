using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{
    private AudioSource _audioSource;
    public Animator animator;
    public bool platSwitch = true;
    public float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("platformSwitch", startTime, 2f);
        InvokeRepeating("PlayTick", 1f, 2f);

        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.1f;

        if (_audioSource == null)
        {
            Debug.LogError("The AudioSource in the player NULL!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayTick()
    {
        _audioSource.Play();
    }

    void platformSwitch()
    {
        _audioSource.Play();

        if(platSwitch == true)
        {
            animator.SetBool("Switch", false);
            platSwitch = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (platSwitch == false)
        {
            animator.SetBool("Switch", true);
            platSwitch = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        
        
    }
}
