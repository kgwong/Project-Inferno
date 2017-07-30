using UnityEngine;

public static class CollisionCommon 
{
	public static bool IsGrounded(GameObject go)
	{
		float colliderDistToGround = GetActiveCollider(go).bounds.extents.y;
		const float pad = .15f;
		RaycastHit2D hit = Physics2D.Raycast(go.transform.position, Vector2.down, colliderDistToGround + pad);
		return hit.collider != null;
	}

    public static Collider2D GetActiveCollider(GameObject go)
    {
        foreach (Collider2D collider in go.GetComponents<Collider2D>())
        {
            if (collider.enabled)
                return collider;
        }
        return null;
    }
}
