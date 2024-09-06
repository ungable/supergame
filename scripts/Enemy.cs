using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
   private int maxHealth = 100;
   private int health = 100;

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
}
