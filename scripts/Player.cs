using Godot;
using System;

public partial class Player : CharacterBody2D
{
   private int speed = 200;
   private PackedScene bullet = GD.Load<PackedScene>("res://prefabs/bullet.tscn");
   private Node projectileRoot;
   private Node2D projectileSpawnPoint;

   public override void _Ready()
   {
      projectileRoot = GetTree().Root;
      projectileSpawnPoint = GetNode<Node2D>("Gun/ProjectileSpawnPoint");
   }

   public override void _PhysicsProcess(double delta)
   {
      Move();
      Rotate();
      Fire();
   }

   private void Move()
   {
      var inputDirection = Input.GetVector("left", "right", "up", "down");
      Velocity = inputDirection.Normalized() * speed;
      MoveAndSlide();
   }

   private void Rotate()
   {
      var rotationMouse = GetGlobalMousePosition();
      LookAt(rotationMouse);
      Rotation += MathF.PI / -2;
   }

   private void Fire()
   {
      if (Input.IsActionJustPressed("fire"))
      {
         CreateProjectile();
      }
   }

   private void CreateProjectile()
   {
      var projectile = bullet.Instantiate<Bullet>();
      projectile.Position = projectileSpawnPoint.GlobalPosition;
      projectile.Rotation = projectileSpawnPoint.GlobalRotation;
      projectileRoot.AddChild(projectile);
   }
}

