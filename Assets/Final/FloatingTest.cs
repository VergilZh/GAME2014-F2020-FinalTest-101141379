/*
    File Name: FloatingTest.cs
    Student Name: Han Zhan
    Student ID: 101141379
    Date last Modified: 2020/12/18
    Program description: Create float platform.
    Revision History: 
    2020.12.16 Add shrink and recovery funtion;
    2020.12.16 Add Audio Source;
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTest : MonoBehaviour
{
    public GameObject FloatPlatform;
    private Rigidbody2D rigidbody2D;
    public AudioSource Ticking;
    public AudioSource Bigger;
    public float PlatformLength;
    public bool IsPlayerStand;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //Ticking = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlayerStand && PlatformLength >= 0.0f)
        {
            Shrink();
        }
        if(!IsPlayerStand && PlatformLength <= 8.0f)
        {
            resize();
        }
        
    }

    private void Shrink()
    {
        PlatformLength -= 2.0f * Time.deltaTime;
        FloatPlatform.transform.localScale = new Vector3(PlatformLength, 2.0f, 0.0f);
    }

    private void resize()
    {
        PlatformLength += 1.0f * Time.deltaTime;
        FloatPlatform.transform.localScale = new Vector3(PlatformLength, 2.0f, 0.0f);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsPlayerStand = true;
            Ticking.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsPlayerStand = false;
            Ticking.Stop();
            Bigger.Play();
        }
    }
}
