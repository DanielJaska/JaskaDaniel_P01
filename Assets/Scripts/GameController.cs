using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Transform keyParent;
    [SerializeField] Text keysCollectedText;

    [SerializeField] PlayerShip playerShip;

    [SerializeField] Text timerText;
    [SerializeField] int startingTime;
    private float currentTimer;

    private int numberOfKeysToCollect = 0;

    private int numberOfKeys = 0;

    [SerializeField] GameObject forceField;

    [SerializeField] AudioClip allCollected;

    private void Awake()
    {
        numberOfKeysToCollect = keyParent.childCount;
        keysCollectedText.text = "Keys: " + numberOfKeys + "/" + numberOfKeysToCollect;
    }

    public void IncreaseTime()
    {
        startingTime++;
        timerText.text = "Time: " + startingTime.ToString();
    }

    private void Update()
    {
        if(PlayerShip.isRespawning == false)
        {
            if (currentTimer <= 0)
            {
                startingTime--;

                if (startingTime <= 0)
                {
                    playerShip.Kill();
                }

                timerText.text = "Time: " + startingTime.ToString();
                currentTimer = 1;

            }
            else if (currentTimer > 0)
            {
                currentTimer -= Time.deltaTime;
            }
        }
    }

    public void CollectKey()
    {
        numberOfKeys++;
        keysCollectedText.text = "Keys: " + numberOfKeys + "/" + numberOfKeysToCollect;
        if(numberOfKeys >= numberOfKeysToCollect)
        {
            AudioController.PlayClip(allCollected);
            Destroy(forceField);
        }
    }
}
