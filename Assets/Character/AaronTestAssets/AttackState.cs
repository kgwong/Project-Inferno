using UnityEngine;
using System.Collections;


//just an attack atm, will probably lead to 'combos' later 

public class AttackState : PlayerState {

    private Animator an;
    private Player play;
    // Use this for initialization
    void Start () {
        play = GetComponent<Player>();
        an = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    public override void ComponentUpdate () {
        an.Play("Attack");
        handleInput();
	}

    public override void handleInput()
    {
        if (!Input.GetButtonDown("Attack"))
        {
            play.changeState(StateEnums.RunState);
        }
    }

}
