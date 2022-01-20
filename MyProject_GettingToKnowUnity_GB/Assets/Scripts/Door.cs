using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animation _animation;

    [SerializeField] private bool isOpen;

    public void Open()
    {
        if (!_animation.isPlaying)
            StartCoroutine(Opening());
    }

    private IEnumerator Opening()
    {
        _animation?.Play();
        yield return new WaitWhile(()=> _animation?.isPlaying == true);
        isOpen = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !isOpen)
        {
            Open();
        }
    }
}
