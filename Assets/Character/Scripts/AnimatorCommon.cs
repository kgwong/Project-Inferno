using UnityEngine;

public static class AnimatorCommon
{
	public static void FaceRight(Animator animator)
    {
        animator.SetBool("facingRight", true);
    }

	public static void FaceLeft(Animator animator)
    {
        animator.SetBool("facingRight", false);
    }

	public static bool FacingRight(Animator animator)
    {
        return animator.GetBool("facingRight");
    }

	public static bool FacingLeft(Animator animator)
    {
		return !animator.GetBool("facingRight");
    }

	public static void FlipSpriteCorrectDirection(Animator animator, SpriteRenderer spriteRenderer)
    {
        spriteRenderer.flipX = FacingLeft(animator);
    }

	public static void SetState(Animator animator, int val)
    {
        animator.SetInteger("state", val);
    }

    public static void RestartCurrentAnimation(Animator animator)
    {
        string name = ((PlayerStateEnum)GetState(animator)).ToString();
        animator.Play(name, -1, 0);
    }

	public static int GetState(Animator animator)
    {
        return animator.GetInteger("state");
    }
}
