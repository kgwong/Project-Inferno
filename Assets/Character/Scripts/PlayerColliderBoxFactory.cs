using UnityEngine;

public static class PlayerColliderBoxFactory
{
    public static BoxCollider2D Get(GameObject go, PlayerStateEnum state)
    {
        BoxCollider2D bc = go.AddComponent<BoxCollider2D>();
        switch(state)
        {
            case PlayerStateEnum.TestIdle:
                bc.size = new Vector2(2,2);
                break;
            case PlayerStateEnum.TestMove:
                bc.size = new Vector2(2,2);
                break;
            case PlayerStateEnum.TestRoll:
                bc.size = new Vector2(1,1);
                break;
            case PlayerStateEnum.TestHighAttack:
                break;
            case PlayerStateEnum.TestMidAttack:
                break;
            case PlayerStateEnum.TestLowAttack:
                break;
            case PlayerStateEnum.TestMidAttackCombo:
                break;
            case PlayerStateEnum.TestJump:
                break;
            case PlayerStateEnum.TestAirborneMove:
                bc.size = new Vector2(2,2);
                break;
            default:
                Debug.Log("Warning: " + state + " does not have a BoxCollider set");
                break;
        }
        return bc;
    }
}
