using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState  {
    void Execute();
    void Enter(StateEnemy enemy);
    void Exit();
    void OnTriggerenter(Collider2D other);
}
