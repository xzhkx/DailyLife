using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject jumpDetector;

    private void Awake()
    {
        jumpDetector.SetActive(false);
    }

    public void PlayStart()
    {
        jumpDetector.SetActive(true);
        gameObject.SetActive(false);
    }    
}
