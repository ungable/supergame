using Godot;
using System;

public partial class Player : Unit
{
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

}

