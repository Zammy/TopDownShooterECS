using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[UpdateBefore(typeof(ProjectileMovementSystem))]
public partial class ProjectileSpawnSystem : SystemBase
{
    protected override void OnUpdate()
    {
        if (Player.Instance.Shoot)
        {
            var prefab = SystemAPI.GetSingleton<ProjectileSpawner>().Prefab;
            var projEntity = EntityManager.Instantiate(prefab);
            var projTransform = EntityManager.GetAspect<TransformAspect>(projEntity);
            projTransform.Position = Player.Instance.Muzzle.position;
            projTransform.LocalRotation = Player.Instance.Muzzle.rotation;

            Player.Instance.Shoot = false;
        }
    }
}