using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    ResetBobberPos resetBob;
    public Transform bobberTransform;
    public Rigidbody bobberRigidbody;
    public Transform fishingRodTipTransform;
    public GameObject fish;
    public Rigidbody fishRigidbody;
    public Transform hook;
    public Transform playerTransform;

    public float forceFromFish = 0.3f;
    public float minDistForFishing = 4.0f;//If distance between fish and player is less than this, player win
    private Vector3 fishStartPosition;

    public Text textDisplay;

    private GameObject bobber;
    private bool isFishing = false;
    private bool fishIsBiting = false;
    private bool pullState = false;
    private bool playerWin = false;
    private float biteTimer;
    
    private float pullStateTimer = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        bobber = GameObject.FindWithTag("Bobber");
        resetBob = GameObject.FindWithTag("Bobber").GetComponent<ResetBobberPos>();
        fishStartPosition = fish.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWin();
        if (bobber.transform.position.y < 1.2f && !isFishing)//If we launched the bobber and it hit the water, start timer for fishing
        {
            biteTimer = Random.Range(2.0f, 20.0f);
            //biteTimer = 2.0f;
            fishIsBiting = false;
            isFishing = true;
            ResetWin();
        }
        if (isFishing && !fishIsBiting)
        {
            if (biteTimer > 0.0)
            {
                biteTimer -= Time.deltaTime;
            }
            else
            {
                fishIsBiting = true;
                print("time to reel!");
               
            }
        }
        if (isFishing && fishIsBiting) //TODO : Making the fish bite the hook, position it and making it try to make distance with the player
        {
            
            Pull();
        }
        


    }

    private void Pull()
    {
        Vector3 forceDirection;

        

        //Compute force direction, used also to orient fish
        forceDirection.x = -(fishingRodTipTransform.position.x - bobberTransform.position.x);
        forceDirection.y = -(fishingRodTipTransform.position.y - bobberTransform.position.y);
        forceDirection.z = -(fishingRodTipTransform.position.z - bobberTransform.position.z);

        ChangePullStateOfFish();
        if (pullState)
        {
            bobberTransform.transform.LookAt(fishingRodTipTransform);
            bobberRigidbody.AddForce(forceDirection.normalized * forceFromFish);
        }
        
        //Place the fish on the hook
        fish.transform.LookAt(fishingRodTipTransform);
        fish.transform.position = hook.position + (forceDirection.normalized * 0.4f);
    }

    private void ChangePullStateOfFish()
    {
        pullStateTimer -= Time.deltaTime;
        if (pullStateTimer < 0.0)
        {
            pullStateTimer = 5.0f;
            pullState = !pullState;
        }
    }
    
    public void PlayerWin()
    {
        Vector3 line;
        Vector3 tempPos;

        line.x = -(fishingRodTipTransform.position.x - bobberTransform.position.x);
        line.y = -(fishingRodTipTransform.position.y - bobberTransform.position.y);
        line.z = -(fishingRodTipTransform.position.z - bobberTransform.position.z);
        if (line.magnitude < minDistForFishing && isFishing && fishIsBiting)
        {
            //The player win, we save the information and reset fishing variables and bobber. This piece is executed one time
            playerWin = true;
            isFishing = false;
            fishIsBiting = false;
            resetBob.ResetBobber();

        }
        if (playerWin)
        {
            //Winning screen. This piece is executed every frame until playerWin variable is reset.
            tempPos = playerTransform.position + playerTransform.forward * 1.5f;
            fish.transform.position = tempPos;
            textDisplay.text = "Félicitations! Vous avez réussi à pêcher une (grosse) sardine!";
        }

    }
    public void ResetWin()
    {
        playerWin = false;
        textDisplay.text = "";
        fish.transform.position = fishStartPosition;
    }
}
