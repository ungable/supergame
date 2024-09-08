using Godot;
using System;

public partial class Unit : CharacterBody2D
{
   public int maxHealth = 100;
   public int health = 100;
   public int speed = 200;

   protected PackedScene bullet = GD.Load<PackedScene>("res://prefabs/bullet.tscn");

   private Node projectileRoot;
   private Node2D projectileSpawnPoint;

   public override void _Ready()
   {
      projectileRoot = GetTree().Root;
      projectileSpawnPoint = GetNode<Node2D>("Gun/ProjectileSpawnPoint");
   }

   public void ReceiveDamage(int amount)
   {
      if (amount < 0)
      {
         throw new ArgumentException("Amount should be positive value", nameof(amount));
      }
      health = Math.Max(0, health - amount);
      if (health == 0)
      {
         QueueFree();
      }
   }

   public void Heal(int amount)
   {
      if (amount < 0)
      {
         throw new ArgumentException("Amount should be positive value", nameof(amount));
      }
      health = Math.Min(maxHealth, health + amount);
   }

   protected void CreateProjectile()
   {
      var projectile = bullet.Instantiate<Bullet>();
      projectile.Position = projectileSpawnPoint.GlobalPosition;
      projectile.Rotation = projectileSpawnPoint.GlobalRotation;
      projectileRoot.AddChild(projectile);
   }
}
