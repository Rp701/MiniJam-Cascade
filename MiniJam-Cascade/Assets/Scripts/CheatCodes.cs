using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheatCodes : MonoBehaviour
{
    [Tooltip("The Key that you press to continue/start the cheat")]
    public KeyCode[] CheatCode;
    [Tooltip("Just attach the gameobject where the CheatCodes script is on")]
    public UnityEvent CheatEvent;
    [Tooltip("The amount of time the player has in between inputs to continue the code.")]
    public float AllowedDelay = 1f;

    private float _delayTimer;
    private int _index = 0;

    void Update()
    {
        _delayTimer += Time.deltaTime;
        //This resets the cheatcode input if the player takes too long to actually do the whole thing
        if (_delayTimer > AllowedDelay)
        {
            ResetCheatInput();
        }

        //If the key that the player is pressing
        if (Input.anyKeyDown)
        {
            //If its the next Key in the sequence, move onto the next
            if (Input.GetKeyDown(CheatCode[_index]))
            {
                //Move onto the next one
                _index++;
                //Keep giving the player time
                _delayTimer = 0f;
            }
            else //If it's not, reset the cheatcode input
            {
                ResetCheatInput();
            }
        }

        if (_index == CheatCode.Length)
        {
            ResetCheatInput();
            CheatEvent.Invoke();
        }
    }

    //Simply resets the cheat code, basically nothing happened
    void ResetCheatInput()
    {
        _index = 0;
        _delayTimer = 0f;
    }

    //Here's where you would put whatever cheatcode you want!
    public void Cheat()
    {
        Debug.Log("CHEAT ACTIVATED");
        //increase the player's run speed by 3x
        GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovement>().runSpeed *= 3;
    }
}
