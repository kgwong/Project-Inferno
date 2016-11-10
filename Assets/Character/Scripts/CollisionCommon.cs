using UnityEngine;

public static class CollisionCommon // Better Name?
{
	public static bool IsGrounded(GameObject go)
	{
		float colliderDistToGround = go.GetComponent<Collider2D>().bounds.extents.y;
		float pad = .1f;
		RaycastHit2D hit = Physics2D.Raycast(go.transform.position, Vector2.down, colliderDistToGround + pad);
		return hit.collider != null;
	}
}
