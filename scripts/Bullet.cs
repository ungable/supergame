using Godot;

public partial class Bullet : RigidBody2D
{
   private float speed = 300;
   private int damage = 50;
   private Vector2 _movement;

   public override void _Ready()
   {
      _movement = new Vector2(0, speed).Rotated(Rotation);
   }

   public override void _PhysicsProcess(double delta)
   {
      var collision = MoveAndCollide(_movement * (float)delta);
      var collider = collision?.GetCollider();
      if (collider != null)
      {
         if (collider is Unit unit)
         {
            unit.ReceiveDamage(damage);
         }
         QueueFree();
      }
   }

   private void OnTimerTimeout()
   {
      QueueFree();
   }
}
