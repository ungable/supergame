using Godot;

public partial class Game : Node2D
{
   [Export]
   private Player player;
   [Export]
   private Godot.Collections.Array<Enemy> enemies;

   public override void _Ready()
   {
      PrepareEnemies();
   }

   private void PrepareEnemies()
   {
      foreach (var enemy in enemies)
      {
         enemy.SetPlayer(player);
      }
   }
}
