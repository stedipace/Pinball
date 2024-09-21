using UnityEngine;

public class Teleporter : ReceiverBase
{
    [SerializeField] private Transform destination;

    protected override void OnEnter(Collider2D collision)
    {
        base.OnEnter(collision);

        var animator = collision.GetComponentInChildren<Animator>(true);
        animator.gameObject.SetActive(true);
        animator.Play("Teleport");
    }

    protected override void OnExit(Collider2D collision)
    {
        base.OnExit(collision);

        var animator = collision.GetComponentInChildren<Animator>();
        animator.gameObject.SetActive(false);
        collision.transform.position = destination.position;
    }
}
