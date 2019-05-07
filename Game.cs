using System;

namespace KJX
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Nez.Core
    {
        public Game() : base(isFullScreen: false, enableEntitySystems: true, windowTitle: "KJX", width: 1280, height: 720)
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            exitOnEscapeKeypress = false;
            scene = new GameScene();
        }
    }
}
