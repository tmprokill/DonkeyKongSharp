namespace FileWorkLib;

public class InstructionsGetter
{
    public static string GetInstructions()
    {
        return@"
        Welcome to the 2D game where your objective is to progress through levels one by one, 
        collecting as many points as possible while managing your three lives. 
        Points are awarded for completing each level (10k) and for collecting coins (1k each).

        Game Elements:
        1. Cannons: These shoot projectiles.
        2. Bonfires: Creates moving fireballs.
        3. Walls: Impassable barriers.
        4. Doors: Some doors are open, but there's one locked door.
        5. Key: Unlocks the locked door.
        6. Health Booster: Adds +1 to your health.
        7. Cupcake: Temporarily freezes all enemies.
        8. Dog: Chases Player when he tries to come closer to the exit.

        Controls:
        - Use WASD keys to move your character.

        Gameplay:
        1. Your character starts each level with three lives.
        2. Navigate through the level, avoiding obstacles like fireballs and cannons.
        3. Collect coins scattered throughout the level to earn points.
        4. Find the key to unlock the locked door if there is one.
        5. Pick up health boosters to increase your health.
        6. Use cupcakes strategically to freeze enemies temporarily.
        7. Reach the end of the level to proceed to the next one.
        8. If you lose all three lives, the game is over.

        Scoring:
        - Completing each level: +10,000 points.
        - Collecting each coin: +1,000 points.

        Objective:
        - Progress through as many levels as possible while maximizing your score.
        - Challenge yourself to reach higher levels with fewer mistakes and more points.

        Good luck and enjoy the game!
        Press any button to continue";
    }
}