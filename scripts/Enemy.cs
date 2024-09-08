using Godot;
using System;
using System.Xml.Serialization;

public partial class Enemy : Unit
{
   private Player player;
   private bool canFire = true;

   [Export]
   private Timer timer;
   public override void _PhysicsProcess(double delta)
   {
      Move();
      Rotate();
      Fire();
   }

   private void Move()
   {
      // var inputDirection = Input.GetVector("left", "right", "up", "down");
      // Velocity = inputDirection.Normalized() * speed;
      // MoveAndSlide();
   }

   private void Rotate()
   {
      if (player == null || !Godot.GodotObject.IsInstanceValid(player))
      {
         return;
      }
      // var rotationMouse = GetGlobalMousePosition();
      // LookAt(rotationMouse);
      LookAt(player.GlobalPosition);
      Rotation += MathF.PI / -2;
   }

   private void Fire()
   {
      // IsIbstanceValid
      // GD.Print(player);
      if (player == null || !Godot.GodotObject.IsInstanceValid(player))
      {
         return;
      }
      if (canFire && player.GlobalPosition.DistanceTo(GlobalPosition) < 150)
      {
         CreateProjectile();
         canFire = false;
         timer.Start();
      }
   }

   public void SetPlayer(Player target)
   {
      player = target;
   }

   private void OnTimerTimeout()
   {
      canFire = true;
   }
}
