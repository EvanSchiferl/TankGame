using Raylib;
using rl = Raylib.Raylib;
using static Raylib.Raylib;
using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    static class Program
    {
       // static void Main(string[] args)
       // {
       //     Game game = new Game();
       //     Timer gameTime = new Timer();

       //     InitWindow(640, 480, "Tanks for Everything!");

       //     game.Init();

       //     while (!WindowShouldClose())
       //     {
       //         game.Update();
       //         game.Draw();
       //     }


       //     game.Shutdown();

       //     CloseWindow();
       // }

        public static int Main()
        {
            Game game = new Game();
            Timer gameTime = new Timer();

            InitWindow(640, 480, "Tanks for Everything!");

            game.Init();

            while (!WindowShouldClose())
            {
                game.Update();
                game.Draw();
            }


            game.Shutdown();

            CloseWindow();

            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;

            rl.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.RAYWHITE);

                rl.DrawText("Congrats! You created your first window!", 190, 200, 20, Color.LIGHTGRAY);

                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
