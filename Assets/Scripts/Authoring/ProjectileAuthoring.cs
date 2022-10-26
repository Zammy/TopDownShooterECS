using Unity.Entities;
using UnityEngine;

class ProjectileAuthoring : MonoBehaviour
{
}

class ProjectileBaker : Baker<ProjectileAuthoring>
{
    public override void Bake(ProjectileAuthoring authoring)
    {
        AddComponent(new Projectile { });
    }
}