using UnityEngine;

public class EnemyAudiosboss: MonoBehaviour
{
    public AudioSource EnemyEnergyShot;
    public AudioSource RobotDestroyed;
    public bool EnemyShot;
    private bool _enemyHasShot;
    public bool enemydestroyed;
    private bool _enemyBoom;
    void Start()
    {
        EnemyShot = false;
        _enemyHasShot = false;
        enemydestroyed = false;
        _enemyBoom = false;
    }

    void Update()
    {
        TriggerEnemyShot();
        DestroyedRobot();
    }

    public void TriggerEnemyShot()
    {
        if (EnemyShot == true)
        {
            EnemyEnergyShot.PlayOneShot(EnemyEnergyShot.clip);
            _enemyHasShot = true;
        }

        if (_enemyHasShot == true)
        {
            EnemyShot = false;
            _enemyHasShot = false;
        }
    }

    public void DestroyedRobot()
    {
        if (enemydestroyed == true)
        {
            RobotDestroyed.PlayOneShot(RobotDestroyed.clip);
            _enemyBoom = true;
        }

        if (_enemyBoom == true)
        {
            enemydestroyed = false;
            _enemyBoom = false;
        }
    }
}
