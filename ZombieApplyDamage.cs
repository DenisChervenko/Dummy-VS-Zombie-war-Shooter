using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieApplyDamage : MonoBehaviour
{
    [Header("DamageOption")]
    [SerializeField] private int _damageBlueDummy;
    [SerializeField] private int _damageYellowDummy;
    [SerializeField] private int _damageRegDummy;

    [Header("HealthOption")]
    [SerializeField] private int _health;

    [Header("ParticleOption")]
    [SerializeField] private ParticleSystem _applyDamageEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BlueDummyBullet"))
        {
            ApplyDamage(0);
        }
        else if(other.gameObject.CompareTag("YellowDummyBullet"))
        {
            ApplyDamage(1);
        }
        else if(other.gameObject.CompareTag("RedDummyBullet"))
        {
            ApplyDamage(2);
        }

        CheckForAliveGameObject();
    }

    private void ApplyDamage(int determineDummyBullet)
    {
        _health -= (determineDummyBullet == 0 ? _damageBlueDummy : (determineDummyBullet == 1 ? _damageYellowDummy : (determineDummyBullet == 2 ? _damageRegDummy : 0)));

        _applyDamageEffect.Play();

        CheckForAliveGameObject();
    }

    private void CheckForAliveGameObject()
    {
        if(_health <= 0 || !gameObject.activeSelf)
        {
            _applyDamageEffect.Stop();
            gameObject.SetActive(false);
        }
    }
}
