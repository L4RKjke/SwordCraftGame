using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class HandleAnimator : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private Transform _target;

    public UnityAction JumpCompleted;

    private readonly int _jumpPower = 1;
    private readonly int _numerOfJumps = 1;
    private readonly int _jumpDurationr = 1;

    private void OnEnable()
    {     
        JumpCompleted += SetParent;
        transform.DORotate(new Vector3(0, 180, 0), 1f);
        transform.DOJump(_target.position, _jumpPower, _numerOfJumps, _jumpDurationr, false).OnComplete(() => JumpCompleted?.Invoke()).SetAutoKill(true);    
    }

    private void OnDisable()
    {
        JumpCompleted -= SetParent;
    }

    private void SetParent()
    {
        gameObject.transform.SetParent(_model.transform, true);
        enabled = false;
    }
}