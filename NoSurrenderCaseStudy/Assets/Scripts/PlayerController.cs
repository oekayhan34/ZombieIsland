using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private bool _isJumping = false;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.Play("HumanoidRun");
        }
        else if (!_isJumping)
        {
            _animator.Play("HumanoidIdle");
        }
    } //Playerin hareketi bir joystick üzerine baðlandý ve hareket ederse HumanoidRun animasyonu etmez ise HumanoidIdle animasyonu çalýþtýrýldý

    public void Jump()
    {
        if (!_isJumping)
        {
            _isJumping = true;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _animator.Play("HumanoidCrouchIdle");
            StartCoroutine(ResetJump());
        }
    }// Jump metodunda ise fonksiyon bir buttona atandý ve oyuncunun eðilmesine yönelik animasyonlar kodlar eklendi.

    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(1f); // Eðilme animasyonunun süresine göre belirlendi.
        _isJumping = false;
    }
}
