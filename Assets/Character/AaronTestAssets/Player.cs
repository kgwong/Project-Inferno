using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private PlayerStates state_;
    private float rollCDTimer;
    private float bStepCDTimer;
    private bool rollUsed;
    private bool bStepUsed;
    private OnGround og;
    // Use this for initialization
    private IdleState idle;
    private RunState run;
    private RollState roll;
    private AttackState attack;
    private BackstepState backstep;
    private AirborneState airborne;
    private ArrayList stateList = new ArrayList();

    void Start () {
        idle = GetComponent<IdleState>();
        run = GetComponent<RunState>();
        roll = GetComponent<RollState>();
        attack = GetComponent<AttackState>();
        backstep = GetComponent<BackstepState>();
        airborne = GetComponent<AirborneState>();
        state_ = idle;
        og = GetComponent<OnGround>();
        rollUsed = false;
        bStepUsed = false;

        stateList.Add(idle);
        stateList.Add(run);
        stateList.Add(attack);
        stateList.Add(airborne);
        stateList.Add(roll);
        stateList.Add(backstep);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(rollUsed)
        {
            rollCDTimer += Time.deltaTime;
            if(Constant.cooldownBSR < rollCDTimer)
            {
                rollUsed = false;
            }
        }

        if(bStepUsed)
        {
            bStepCDTimer += Time.deltaTime;
            if(Constant.cooldownBSR < bStepCDTimer)
            {
                bStepUsed = false;
            }
        }
        state_.setGrounded(og.checkGrounded());
        Debug.Log(og.checkGrounded());
        state_.ComponentUpdate();
	}

    public void changeState(StateEnums state)
    {
        int s = (int)state;
        state_ = (PlayerStates)stateList[s]; 
    }



    public void setRollCD()
    {
        rollCDTimer = 0;
        rollUsed = true;
    }

    public void setBStepCD()
    {
        bStepCDTimer = 0;
        bStepUsed = true;
    }

    public bool getRollUsed()
    {
        return rollUsed;
    }

    public bool getBStepUsed()
    {
        return bStepUsed;
    }

    public RunState getRun()
    {
        return run;
    }

    public RollState getRoll()
    {
        return roll;
    }

    public BackstepState getBack()
    {
        return backstep;
    }
}
