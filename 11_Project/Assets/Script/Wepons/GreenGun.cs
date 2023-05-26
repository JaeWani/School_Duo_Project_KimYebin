using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGun : UseWepon
{
    public Player player;
    [SerializeField] GameObject BulletPrefab;


    private void Start() 
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        AttackAction = GreenGunAttack;
    }
    protected void GreenGunAttack()
    {
        switch(player.direction)
        {
            case Direction.Left:
            SpawnBullet(Vector2.left);
            break;
            case Direction.Right:
            SpawnBullet(Vector2.right);
            break;
        }
    }
    private void SpawnBullet(Vector2 vec)
    {
        var obj =  Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        var bullet = obj.GetComponent<Bullet>();
        bullet.vec = vec;
    }
}
