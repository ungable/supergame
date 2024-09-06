using Godot;
using System;

public partial class Bullet : RigidBody2D
{
   private float _speed = 200;
   private Vector2 _movement;

   public override void _Ready()
   {
      _movement = new Vector2(0, _speed).Rotated(Rotation);
   }

   public override void _PhysicsProcess(double delta)
   {
      MoveAndCollide(_movement * (float)delta);
   }

   private void OnTimerTimeout()
   {
      QueueFree();
   }
}
