using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        Texture2D Floor;
        Texture2D player1RightTexture;
        Texture2D player1LeftTexture;
        Texture2D player2RightTexture;
        Texture2D player2LeftTexture;
        Texture2D billyHealthBarOverlayPVP;
        Texture2D neddyHealthBarOverlayPVP;
        Texture2D billyHealthBarOverlayPVAI;
        Texture2D neddyHealthBarOverlayPVAI;
        Texture2D alienHealthBarOverlayPVAI;
        Texture2D alienTexture;
        Texture2D hpPickUp;
        Texture2D newGameButton;
        Texture2D settingsButton;
        Texture2D settingsBButton;
        Texture2D settingsYes1Button;
        Texture2D settingsYes2Button;
        Texture2D settingsYes3Button;
        Texture2D settingsNo1Button;
        Texture2D settingsNo2Button;
        Texture2D settingsNo3Button;
        Texture2D gameModeBButton;
        Texture2D gameModeNeddyVSBillyButton;
        Texture2D gameModeNeddyVSAlienButton;
        Texture2D gameModeBillyVSAlienButton;
        Texture2D exitButton;
        Texture2D missileTexture;
        Texture2D missile2Texture;
        Texture2D laserTexture;
        Texture2D bulletSprite;
        Rectangle bulletRect;
        Point bulletStartPos;
        public int bulletVelocity = 10;
        float bulletDelay = 50;
        EnemyManager enemy;
        ShotManager shotManager;
        IncreaseWeaponFire iwf;
        Texture2D iwfTexture;
        Vector2 iwfPosition;
        List<EnemyManager> enemies = new List<EnemyManager>();
        Texture2D enemyTex01;
        Texture2D mainMenuScreen, settingsMenuScreen, gameModeSelectionScreen, gameLevelPVPScreen, gameLevelP1VAIScreen, gameLevelP2VAIScreen, gameOverScreen, gameWinScreen;
        public Rectangle playerRect;
        Rectangle playerLeftRect;
        Rectangle player2RightRect;
        Rectangle player2LeftRect;
        Rectangle billyHBOPVPRect;
        Rectangle neddyHBOPVPRect;
        Rectangle billyHBOPVAIRect;
        Rectangle neddyHBOPVAIRect;
        Rectangle alienHBOPVAIRect;
        Rectangle alienRect;
        Rectangle hppuRect;
        Rectangle floorRect;
        Rectangle newGBRect;
        Rectangle settingsBRect;
        Rectangle settingsBBRect;
        Rectangle settingsYes1BRect;
        Rectangle settingsYes2BRect;
        Rectangle settingsYes3BRect;
        Rectangle settingsNo1BRect;
        Rectangle settingsNo2BRect;
        Rectangle settingsNo3BRect;
        Rectangle gameModeBBRect;
        Rectangle gameModeNVSBBRect;
        Rectangle gameModeNVSABRect;
        Rectangle gameModeBVSABRect;
        Rectangle exitGBRect;
        Rectangle missileRect;
        Rectangle missile2Rect;
        Rectangle laserRect;
        int score;
        int buttonX, buttonY;
        int speed = 5;
        int gravity = 5;
        int fallspeed = 5;
        int jumpHeight = 50;
        int hpXPos = 450;
        int hpYPos = 500;
        float alienmovementSpeed = 4f;
        float player1movementSpeed = 5f;
        float player2movementSpeed = 8f;
        float fallSpeed = 5f;
        int player1JumpHeight = 15;
        int player1MaxHealth = 100;
        int player2JumpHeight = 15;
        int player2MaxHealth = 100;
        float missileVelocity = 4f;
        float laserVelocity = 6f;
        float laserWidth = 1f;
        float laserCooldown = 1f;
        float missileCooldown = 1f;
        Point missileStartPosLeft;
        Point missileStartPosRight;
        Point laserStartPosD;
        Point laserStartPosA;
        const int player1noHealth = 0;
        const int player2noHealth = 0;
        float player1CurrentHealth = 100f;
        float player2CurrentHealth = 100f;
        float newGameOpacity = 1f;
        float settingsOpacity = 1f;
        float exitOpacity = 1f;
        float Yes1Opacity = 0.5f;
        float Yes2Opacity = 0.5f;
        float Yes3Opacity = 0.5f;
        float no1Opacity = 1f;
        float no2Opacity = 1f;
        float no3Opacity = 1f;
        float backButtonSOpacity = 0.5f;
        float backButtonGMOpacity = 0.5f;
        float gameMode1Opacity = 0.75f;
        float gameMode2Opacity = 1f;
        float gameMode3Opacity = 0.75f;
        float player1LeftTexOpacity = 1f;
        float player1RightTexOpacity = 1f;
        float player2LeftTexOpacity = 1f;
        float player2RightTexOpacity = 1f;
        float missileDelay = 20f;
        float laserDelay = 20f;
        public enum GameState { mainMenu, settingsMenu, gameModeSelection, gameLevelP1VAI, gameLevelP2VAI, gameLevelPVP, gameOver, gameWon }
        public GameState gameState = GameState.mainMenu;
        public enum Player1FacingState { facingP1Left, facingP1Right }
        public Player1FacingState player1FacingState = Player1FacingState.facingP1Left;
        public enum Player2FacingState { facingP2Left, facingP2Right }
        public Player2FacingState player2FacingState = Player2FacingState.facingP2Left;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            DefaultScreenSize();
            Window.IsBorderless = false;
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            font = Content.Load<SpriteFont>("Fonts/myFont");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player1LeftTexture = Content.Load<Texture2D>("player1LeftTex");
            playerLeftRect = new Rectangle(100, 590, player1LeftTexture.Width, player1LeftTexture.Height);
            player1RightTexture = Content.Load<Texture2D>("player1RightTex");
            playerRect = new Rectangle(100, 590, player1RightTexture.Width, player1RightTexture.Height);
            player2LeftTexture = Content.Load<Texture2D>("player2LeftTex");
            player2LeftRect = new Rectangle(800, 375, player2LeftTexture.Width, player2LeftTexture.Height);
            player2RightTexture = Content.Load<Texture2D>("player2RightTex");
            player2RightRect = new Rectangle(800, 375, player2RightTexture.Width, player2RightTexture.Height);

            billyHealthBarOverlayPVP = Content.Load<Texture2D>("billysHealthBarOverlay");
            billyHBOPVPRect = new Rectangle(600, 25, billyHealthBarOverlayPVP.Width, billyHealthBarOverlayPVP.Height);
            neddyHealthBarOverlayPVP = Content.Load<Texture2D>("neddysHealthBarOverlay");
            neddyHBOPVPRect = new Rectangle(25, 25, neddyHealthBarOverlayPVP.Width, neddyHealthBarOverlayPVP.Height);
            billyHealthBarOverlayPVAI = Content.Load<Texture2D>("billysHealthBarOverlay");
            billyHBOPVAIRect = new Rectangle(25, 25, billyHealthBarOverlayPVAI.Width, billyHealthBarOverlayPVAI.Height);
            neddyHealthBarOverlayPVAI = Content.Load<Texture2D>("neddysHealthBarOverlay");
            neddyHBOPVAIRect = new Rectangle(25, 25, neddyHealthBarOverlayPVAI.Width, neddyHealthBarOverlayPVAI.Height);
            alienHealthBarOverlayPVAI = Content.Load<Texture2D>("aliensHealthBarOverlay");
            alienHBOPVAIRect = new Rectangle(600, 25, alienHealthBarOverlayPVAI.Width, alienHealthBarOverlayPVAI.Height);

            alienTexture = Content.Load<Texture2D>("alienTex");
            alienRect = new Rectangle(500, 519, alienTexture.Width, alienTexture.Height);
            //enemies.Add(enemy = new EnemyManager(alienTexture, new Vector2(200, 200), 2));
            hpPickUp = Content.Load<Texture2D>("healthPickUp");
            hppuRect = new Rectangle(hpXPos, hpYPos, hpPickUp.Width, hpPickUp.Height);

            iwfTexture = Content.Load<Texture2D>("powerUp1");
            iwfPosition = new Vector2(100, -50);
            iwf = new IncreaseWeaponFire(iwfTexture, iwfPosition);

            mainMenuScreen = Content.Load<Texture2D>("MainMenuBackground");

            newGameButton = Content.Load<Texture2D>("newGameButton");
            newGBRect = new Rectangle(590, 250, newGameButton.Width, newGameButton.Height);

            settingsButton = Content.Load<Texture2D>("settingsGameButton");
            settingsBRect = new Rectangle(590, 350, settingsButton.Width, settingsButton.Height);

            exitButton = Content.Load<Texture2D>("exitGameButton");
            exitGBRect = new Rectangle(590, 450, exitButton.Width, exitButton.Height);

            settingsYes1Button = Content.Load<Texture2D>("settingsYes1Selected");
            settingsYes1BRect = new Rectangle(608, 144, settingsYes1Button.Width, settingsYes1Button.Height);
            settingsYes2Button = Content.Load<Texture2D>("settingsYes2Selected");
            settingsYes2BRect = new Rectangle(608, 229, settingsYes2Button.Width, settingsYes2Button.Height);
            settingsYes3Button = Content.Load<Texture2D>("settingsYes3Selected");
            settingsYes3BRect = new Rectangle(608, 314, settingsYes3Button.Width, settingsYes3Button.Height);

            settingsNo1Button = Content.Load<Texture2D>("settingsNo1Selected");
            settingsNo1BRect = new Rectangle(758, 144, settingsNo1Button.Width, settingsNo1Button.Height);
            settingsNo2Button = Content.Load<Texture2D>("settingsNo2Selected");
            settingsNo2BRect = new Rectangle(758, 229, settingsNo2Button.Width, settingsNo2Button.Height);
            settingsNo3Button = Content.Load<Texture2D>("settingsNo3Selected");
            settingsNo3BRect = new Rectangle(758, 314, settingsNo3Button.Width, settingsNo3Button.Height);

            settingsBButton = Content.Load<Texture2D>("backButton");
            settingsBBRect = new Rectangle(100, 475, settingsBButton.Width, settingsBButton.Height);

            missileTexture = Content.Load<Texture2D>("missileTexture");
            missileRect = new Rectangle(207, 33, missileTexture.Width, missileTexture.Height);
            missile2Texture = Content.Load<Texture2D>("missile2Texture");
            missile2Rect = new Rectangle(207, 33, missile2Texture.Width, missile2Texture.Height);
            laserTexture = Content.Load<Texture2D>("laserTexture");
            laserRect = new Rectangle(350, 490, laserTexture.Width, laserTexture.Height);

            enemyTex01 = Content.Load<Texture2D>("alienTex");
            bulletSprite = Content.Load<Texture2D>("laserTexture");
            enemies.Add(enemy = new EnemyManager(enemyTex01,new Vector2(400, 450), 2, bulletSprite,2,50,playerRect));
            //enemies.Add(enemy = new EnemyManager(enemyTex01, new Vector2(200, 100), 3, bulletSprite, 1, 50, playerRect));
            //enemies.Add(enemy = new EnemyManager(enemyTex01, new Vector2(200, 0), 4, bulletSprite, 5, 50, playerRect));

            gameModeBButton = Content.Load<Texture2D>("backButton");
            gameModeBBRect = new Rectangle(350, 490, gameModeBButton.Width, gameModeBButton.Height);
            gameModeNeddyVSBillyButton = Content.Load<Texture2D>("gameModeNeddyVSBilly");
            gameModeNVSBBRect = new Rectangle(239, 131, gameModeNeddyVSBillyButton.Width, gameModeNeddyVSBillyButton.Height);
            gameModeNeddyVSAlienButton = Content.Load<Texture2D>("gameModeNeddyVSAlien");
            gameModeNVSABRect = new Rectangle(445, 131, gameModeNeddyVSAlienButton.Width, gameModeNeddyVSAlienButton.Height);
            gameModeBillyVSAlienButton = Content.Load<Texture2D>("gameModeBillyVSAlien");
            gameModeBVSABRect = new Rectangle(651, 131, gameModeBillyVSAlienButton.Width, gameModeBillyVSAlienButton.Height);

            Floor = Content.Load<Texture2D>("Ground");
            floorRect = new Rectangle(0, 522, Floor.Width, Floor.Height);
            settingsMenuScreen = Content.Load<Texture2D>("settingsBackground");
            gameModeSelectionScreen = Content.Load<Texture2D>("gameModeSelectionBackground");
            gameLevelP1VAIScreen = Content.Load<Texture2D>("GameScreenBackground2");
            gameLevelP2VAIScreen = Content.Load<Texture2D>("GameScreenBackground2");
            gameLevelPVPScreen = Content.Load<Texture2D>("GameScreenBackground");
            // gameOverScreen = Content.Load<Texture2D>("gameOverBackground");
            // gameWinPVAIScreen = Content.Load<Texture2D>("gameWinPVAIBackground");
            // gameWinPVPPlayer1Screen = Content.Load<Texture2D>("gameWinPVPPlayer1Background");
            // gameWinPVPPlayer2Screen = Content.Load<Texture2D>("gameWinPVPPlayer2Background");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            KeyboardState ks = Keyboard.GetState();
            {
                switch (gameState)
                {
                    case GameState.mainMenu:
                        IsMouseVisible = true; // Makes the mouse visible to the player
                        //This is where the buttons have a hover effect on them. So if  the mouse cursor is over the button then make its opacity 1 else make it 0.5 of the button texture.
                        if (newGBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                        {
                            newGameOpacity = 1f;
                            settingsOpacity = 0.5f;
                            exitOpacity = 0.5f;
                        }
                        else
                        if (settingsBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                        {
                            newGameOpacity = 0.5f;
                            settingsOpacity = 1f;
                            exitOpacity = 0.5f;
                        }
                        else
                        if (exitGBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                        {
                            newGameOpacity = 0.5f;
                            settingsOpacity = 0.5f;
                            exitOpacity = 1f;
                        }
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            if (newGBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                gameState = GameState.gameModeSelection;
                            }
                            else
                            if (settingsBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                gameState = GameState.settingsMenu;
                            }
                            else
                            if (exitGBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                Exit();
                            }
                        }
                        break;
                    case GameState.settingsMenu:
                        IsMouseVisible = true;
                        if (settingsBBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                        {
                            backButtonSOpacity = 1f;
                        }
                        else
                        {
                            backButtonSOpacity = 0.5f;
                        }
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            if (settingsYes1BRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                Window.IsBorderless = true;
                                Yes1Opacity = 1f;
                                no1Opacity = 0.5f;
                            }
                            else
                            if (settingsNo1BRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                Window.IsBorderless = false;
                                no1Opacity = 1f;
                                Yes1Opacity = 0.5f;
                            }
                            else
                            if (settingsYes2BRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                Yes2Opacity = 1f;
                                no2Opacity = 0.5f;
                            }
                            else
                            if (settingsNo2BRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                no2Opacity = 1f;
                                Yes2Opacity = 0.5f;
                            }
                            else
                            if (settingsYes3BRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                Yes3Opacity = 1f;
                                no3Opacity = 0.5f;
                            }
                            else
                            if (settingsNo3BRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                no3Opacity = 1f;
                                Yes3Opacity = 0.5f;
                            }
                            if (settingsBBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                gameState = GameState.mainMenu;
                            }
                        }
                        break;
                    case GameState.gameModeSelection:
                        IsMouseVisible = true;
                        if (gameModeBBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                        {
                            backButtonGMOpacity = 1f;
                        }
                        else
                        {
                            backButtonGMOpacity = 0.5f;
                        }
                        if (gameModeNVSBBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                        {
                            gameMode1Opacity = 1f;
                            gameMode2Opacity = 0.75f;
                            gameMode3Opacity = 0.75f;
                        }
                        else
                        if (gameModeNVSABRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                        {
                            gameMode1Opacity = 0.75f;
                            gameMode2Opacity = 1f;
                            gameMode3Opacity = 0.75f;
                        }
                        else
                        if (gameModeBVSABRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                        {
                            gameMode1Opacity = 0.75f;
                            gameMode2Opacity = 0.75f;
                            gameMode3Opacity = 1f;
                        }

                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            if (gameModeNVSBBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                gameState = GameState.gameLevelPVP;
                            }
                            else
                            if (gameModeNVSABRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                gameState = GameState.gameLevelP1VAI;
                            }
                            else
                            if (gameModeBVSABRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                gameState = GameState.gameLevelP2VAI;
                            }
                            else
                            if (gameModeBBRect.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                            {
                                gameState = GameState.mainMenu;
                            }
                        }
                        break;
                    case GameState.gameLevelPVP:
                        IsMouseVisible = false;
                        //Screen bounds
                        ScreenBounds();

                        //Player controls
                        Player1Movement();
                        ShootPlayer1();
                        //Player controls
                        Player2Movement();
                        ShootPlayer2();
                        iwf.Update(gameTime, this);
                        if (CollidePVP())
                        {
                           // Exit();
                        }

                        break;
                    case GameState.gameLevelP1VAI:
                        IsMouseVisible = false;
                        //Screen bounds
                        ScreenBounds();

                        //Player controls
                        Player2Movement();
                        ShootPlayer2();

                        if (CollideP1VAI())
                        {
                           // Exit();
                        }

                        Window.Title = "Score = " + score;

                        iwf.Update(gameTime, this);
                        //Enemy A.I Alien controls
                        //AlienMovement();
                        //for (int i = 0; i < enemies.Count; i++)
                        //{
                        //    enemies[i].Update(gameTime, this);
                        //    if (laserRect.Intersects(enemies[i].rectangle))
                        //    {
                        //        enemies.Remove(enemies[i]);
                        //        score++;
                        //    }
                        //}
                        for (int i = 0; i < enemies.Count; i++)
                        {
                            enemies[i].Update(gameTime, this, playerRect);

                            if (bulletRect.Intersects(enemies[i].rectangle))
                            {
                                enemies.Remove(enemies[i]);
                                score++;
                            }
                        }
                        break;
                    case GameState.gameLevelP2VAI:
                        IsMouseVisible = false;
                        //Screen bounds
                        ScreenBounds();

                        //Player controls
                        Player1Movement();
                        ShootPlayer1();

                        if (CollideP2VAI())
                        {
                           // Exit();
                        }

                        //Enemy A.I Alien controls
                        //AlienMovement();
                        break;

                        //case GameState.gameOver:
                        //    if (ks.IsKeyDown(Keys.D1))
                        //    {
                        //        gameState = GameState.mainMenu;

                        //    }
                        //    if (ks.IsKeyDown(Keys.D2))
                        //    {
                        //        gameState = GameState.settingsMenu;

                        //    }
                        //    if (ks.IsKeyDown(Keys.D3))
                        //    {
                        //        gameState = GameState.gameModeSelection;

                        //    }
                        //    if (ks.IsKeyDown(Keys.D4))
                        //    {
                        //        gameState = GameState.gameLevelPVP;

                        //    }
                        //    if (ks.IsKeyDown(Keys.D5))
                        //    {
                        //        gameState = GameState.gameLevelPVAI;

                        //    }
                        //    if (ks.IsKeyDown(Keys.D6))
                        //    {
                        //        gameState = GameState.gameWon;

                        //    }
                        //    break;
                        //case GameState.gameWin:
                        //    if (ks.IsKeyDown(Keys.D1))
                        //    {
                        //        gameState = GameState.mainMenu;

                        //    }
                        //    if (ks.IsKeyDown(Keys.D2))
                        //    {
                        //        gameState = GameState.settingsMenu;

                        //    }
                        //    if (ks.IsKeyDown(Keys.D3))
                        //    {
                        //        gameState = GameState.gameModeSelection;

                        //    }
                        //    if (ks.IsKeyDown(Keys.D4))
                        //    {
                        //        gameState = GameState.gameLevelPVP;

                        //    }
                        //    if (ks.IsKeyDown(Keys.D5))
                        //    {
                        //        gameState = GameState.gameLevelPVAI;

                        //    }
                        //    if (ks.IsKeyDown(Keys.D6))
                        //    {
                        //        gameState = GameState.gameWon;

                        //    }
                        //    break;
                }

                base.Update(gameTime);
            }
        }

        void Player1Movement()
        {
            KeyboardState ks = Keyboard.GetState();
            //Player controls
            if (ks.IsKeyDown(Keys.Left))
            {
                playerRect.X -= (int)player1movementSpeed;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                playerRect.X += (int)player1movementSpeed;
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                playerRect.Y -= 3;
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                playerRect.Y += 3;
            }
            if (ks.IsKeyDown(Keys.K) || ks.IsKeyDown(Keys.Space))
            {
                ShootPlayer1();
            }
            if (ks.IsKeyUp(Keys.K) || ks.IsKeyUp(Keys.Space))
            {
                missileRect.X = -16;
                missileRect.Y = -32;
                missileDelay = 0;
            }
        }
        void Player2Movement()
        {

            //Player2 movement
            KeyboardState ks = Keyboard.GetState();
            {
                switch (player2FacingState)
                {
                    case Player2FacingState.facingP2Left:
                        {
                            if (ks.IsKeyDown(Keys.A))
                            {
                                player2RightRect.X -= (int)player2movementSpeed;
                            }
                            if (ks.IsKeyDown(Keys.D))
                            {
                                player2RightRect.X += (int)player2movementSpeed;
                            }
                            if (ks.IsKeyDown(Keys.W))
                            {
                                player2RightRect.Y -= 3;
                            }
                            if (ks.IsKeyDown(Keys.S))
                            {
                                player2RightRect.Y += 3;
                            }
                            if (ks.IsKeyDown(Keys.Q) || ks.IsKeyDown(Keys.Q) && ks.IsKeyDown(Keys.A) || ks.IsKeyDown(Keys.Q) && ks.IsKeyDown(Keys.D))
                            {
                                ShootPlayer2();
                            }
                            if (ks.IsKeyUp(Keys.Q) || ks.IsKeyUp(Keys.Q) && ks.IsKeyUp(Keys.A) || ks.IsKeyUp(Keys.Q) && ks.IsKeyUp(Keys.D))
                            {

                                laserDelay = 0;
                            }
                        }
                        break;

                    case Player2FacingState.facingP2Right:
                        {
                            if (ks.IsKeyDown(Keys.A))
                            {
                                player2RightRect.X -= (int)player2movementSpeed;
                            }
                            if (ks.IsKeyDown(Keys.D))
                            {
                                player2RightRect.X += (int)player2movementSpeed;
                            }
                            if (ks.IsKeyDown(Keys.W))
                            {
                                player2RightRect.Y -= 3;
                            }
                            if (ks.IsKeyDown(Keys.S))
                            {
                                player2RightRect.Y += 3;
                            }
                            if (ks.IsKeyDown(Keys.Q) || ks.IsKeyDown(Keys.Q) && ks.IsKeyDown(Keys.A) || ks.IsKeyDown(Keys.Q) && ks.IsKeyDown(Keys.D))
                            {
                                ShootPlayer2();
                            }
                            if (ks.IsKeyUp(Keys.Q) || ks.IsKeyUp(Keys.Q) && ks.IsKeyUp(Keys.A) || ks.IsKeyUp(Keys.Q) && ks.IsKeyUp(Keys.D))
                            {

                                laserDelay = 0;
                            }
                        }
                        break;

                }
            }
        }

        void ShootPlayer1()
        {
            KeyboardState ks = Keyboard.GetState();
            //Player controls
            if (ks.IsKeyDown(Keys.K))
            {
                if (missileDelay >= 0)
                {
                    missileRect = new Rectangle(missileStartPosRight.X + 180, missileStartPosRight.Y + 26, 32, 16);

                    missileStartPosRight.X += (int)missileVelocity;

                    missileDelay--;
                }
                if (missileDelay <= 0)
                {
                    missileStartPosRight = new Point(playerRect.X, playerRect.Y);
                    missileDelay = 100;
                }
            }
 
            //Player controls
            if (ks.IsKeyDown(Keys.J))
            {
                if (missileDelay >= 0)
                {
                    missileRect = new Rectangle(missileStartPosLeft.X + 180, missileStartPosLeft.Y + 26, 32, 16);

                    missileStartPosLeft.X += (int)missileVelocity;

                    missileDelay--;
                }

                if (missileDelay <= 0)
                {
                    missileStartPosLeft = new Point(playerRect.X - 200, playerRect.Y);
                    missileDelay = 100;
                }
            }
        }
        void ShootPlayer2()
        {
            KeyboardState ks = Keyboard.GetState();
            //Player controls
            if (ks.IsKeyDown(Keys.D) && ks.IsKeyDown(Keys.Q))
                if (laserDelay >= 0)
                {
                    laserRect = new Rectangle(laserStartPosD.X, laserStartPosD.Y, 16, 9);

                    laserStartPosD.X += (int)laserVelocity;

                    laserDelay--;

                }
            if (laserDelay <= 0)
            {
                laserStartPosD = new Point(player2RightRect.X, player2RightRect.Y);
                laserDelay = 50;
                laserWidth = 0f;
            }
            else
            if (ks.IsKeyDown(Keys.A) && ks.IsKeyDown(Keys.Q))
            {
                if (laserDelay >= 0)
                {
                    laserRect = new Rectangle(laserStartPosA.X, laserStartPosA.Y,16, 9);

                    laserStartPosA.X -= (int)laserVelocity;

                    laserDelay--;
                }
                if (laserDelay <= 0)
                {
                    laserStartPosA = new Point(player2LeftRect.X, player2LeftRect.Y);
                    laserDelay = 50;
                    laserWidth = 0f;
                }
            }
        }


        //void AlienMovement()
        //{
        //    KeyboardState ks = Keyboard.GetState();
        //    //Enemy A.I Alien controls
        //    if ())
        //    {
        //        playerRect.X -= (int)alienmovementSpeed;
        //    }
        //    if ())
        //    {
        //        playerRect.X += (int)alienmovementSpeed;
        //    }
        //    if ())
        //    {
        //        playerRect.Y -= 3;
        //    }
        //    if ())
        //    {
        //        playerRect.Y += 3;
        //    }
        //}

        void ScreenBounds()
        {
            //if player 1, player 2 and alien is off screen put it back on the window.
            if (playerRect.X < 0)
            {
                playerRect.X = 0;
            }
            if (playerRect.Y < 0)
            {
                playerRect.Y = 0;
            }
            if (player2RightRect.X < 0)
            {
                player2RightRect.X = 0;
            }
            if (player2RightRect.Y < 0)
            {
                player2RightRect.Y = 0;
            }
            if (alienRect.X < 0)
            {
                alienRect.X = 0;
            }
            if (alienRect.Y < 0)
            {
                alienRect.Y = 0;
            }
            if (playerRect.X > Window.ClientBounds.Width - 208)
            {
                playerRect.X = Window.ClientBounds.Width - 208;
            }
            if (player2RightRect.X > Window.ClientBounds.Width - 115)
            {
                player2RightRect.X = Window.ClientBounds.Width - 115;
            }
            if (alienRect.X > Window.ClientBounds.Width - 81)
            {
                alienRect.X = Window.ClientBounds.Width - 81;
            }
            if (playerRect.Y > 620 - 208)
            {
                playerRect.Y = 620 - 208;
            }
            if (player2RightRect.Y > 620 - 250)
            {
                player2RightRect.Y = 620 - 250;
            }
            if (alienRect.Y > 620 - alienTexture.Width)
            {
                alienRect.Y = 620 - alienTexture.Width;
            }
        }

        void DefaultScreenSize()
        {
            //Changes the default screen size
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
        }

        //void HealthPickUp()
        //{

        //}

        //void FireRateIncreasePickUp()
        //{

        //}

        //void ScoreRateIncreasePickUp()
        //{

        //}

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            switch (gameState)
            {
                case GameState.mainMenu:
                    spriteBatch.Draw(mainMenuScreen, Vector2.Zero, Color.White);
                    spriteBatch.Draw(newGameButton, newGBRect, Color.White * newGameOpacity);
                    spriteBatch.Draw(settingsButton, settingsBRect, Color.White * settingsOpacity);
                    spriteBatch.Draw(exitButton, exitGBRect, Color.White * exitOpacity);

                    break;
                case GameState.settingsMenu:
                    spriteBatch.Draw(settingsMenuScreen, Vector2.Zero, Color.White);
                    spriteBatch.Draw(settingsBButton, settingsBBRect, Color.White * backButtonSOpacity);
                    spriteBatch.Draw(settingsYes1Button, settingsYes1BRect, Color.White * Yes1Opacity);
                    spriteBatch.Draw(settingsYes2Button, settingsYes2BRect, Color.White * Yes2Opacity);
                    spriteBatch.Draw(settingsYes3Button, settingsYes3BRect, Color.White * Yes3Opacity);
                    spriteBatch.Draw(settingsNo1Button, settingsNo1BRect, Color.White * no1Opacity);
                    spriteBatch.Draw(settingsNo2Button, settingsNo2BRect, Color.White * no2Opacity);
                    spriteBatch.Draw(settingsNo3Button, settingsNo3BRect, Color.White * no3Opacity);
                    break;
                case GameState.gameModeSelection:
                    spriteBatch.Draw(gameModeSelectionScreen, Vector2.Zero, Color.White);
                    spriteBatch.Draw(gameModeBButton, gameModeBBRect, Color.White * backButtonGMOpacity);
                    spriteBatch.Draw(gameModeNeddyVSBillyButton, gameModeNVSBBRect, Color.White * gameMode1Opacity);
                    spriteBatch.Draw(gameModeNeddyVSAlienButton, gameModeNVSABRect, Color.White * gameMode2Opacity);
                    spriteBatch.Draw(gameModeBillyVSAlienButton, gameModeBVSABRect, Color.White * gameMode3Opacity);
                    break;
                case GameState.gameLevelPVP:
                    KeyboardState ks = Keyboard.GetState();
                    spriteBatch.Draw(gameLevelPVPScreen, Vector2.Zero, Color.White);
                    spriteBatch.Draw(Floor, floorRect, Color.White);
                    spriteBatch.Draw(neddyHealthBarOverlayPVP, neddyHBOPVPRect, Color.White);
                    spriteBatch.Draw(billyHealthBarOverlayPVP, billyHBOPVPRect, Color.White);
                    spriteBatch.Draw(missileTexture, missileRect, Color.White);
                    spriteBatch.Draw(missile2Texture, missile2Rect, Color.White);
                    spriteBatch.Draw(laserTexture, laserRect, Color.White);
                    spriteBatch.Draw(hpPickUp, hppuRect, Color.White);

                    iwf.Draw(spriteBatch);
                    // Finds the center of the string in coordinates inside the text rectangle
                    Vector2 textMiddlePoint = font.MeasureString("text") / 2;
                    // Places text in center of the screen
                    Vector2 position = new Vector2(40, 100);
                    spriteBatch.DrawString(font, "Score: ", position, Color.Yellow, 0, textMiddlePoint, 1.0f, SpriteEffects.None, 0.5f);
                    // Finds the center of the string in coordinates inside the text rectangle
                    Vector2 textMiddlePoint2 = font.MeasureString("text") / 2;
                    // Places text in center of the screen
                    Vector2 position2 = new Vector2(620, 100);
                    spriteBatch.DrawString(font, "Score: ", position2, Color.Yellow, 0, textMiddlePoint2, 1.0f, SpriteEffects.None, 0.5f);
                    if (ks.IsKeyDown(Keys.Left) && ks.IsKeyUp(Keys.Right))
                    {
                        spriteBatch.Draw(player1LeftTexture, playerRect, Color.White * player1LeftTexOpacity);
                        player1RightTexOpacity = 0f;
                        player1LeftTexOpacity = 1f;
                    }
                    else
                     if (ks.IsKeyDown(Keys.Right) && ks.IsKeyUp(Keys.Left))
                    {
                        spriteBatch.Draw(player1RightTexture, playerRect, Color.White * player1RightTexOpacity);
                        player1LeftTexOpacity = 0f;
                        player1RightTexOpacity = 1f;
                    }
                    else
                    if (ks.IsKeyUp(Keys.Right) && ks.IsKeyDown(Keys.Left))
                    {
                        spriteBatch.Draw(player1LeftTexture, playerRect, Color.White * player1LeftTexOpacity);
                        player1LeftTexOpacity = 1f;
                        player1RightTexOpacity = 0f;
                    }
                    else
                    if (ks.IsKeyDown(Keys.Right) && ks.IsKeyDown(Keys.Left))
                    {
                        spriteBatch.Draw(player1RightTexture, playerRect, Color.White * player1RightTexOpacity);
                        player1RightTexOpacity = 1f;
                        player1LeftTexOpacity = 0f;
                    }
                    else
                    if (ks.IsKeyUp(Keys.Right) && ks.IsKeyUp(Keys.Left))
                    {
                        spriteBatch.Draw(player1RightTexture, playerRect, Color.White * player1RightTexOpacity);
                        player1RightTexOpacity = 1f;
                        player1LeftTexOpacity = 0f;
                    }

                    if (ks.IsKeyDown(Keys.D) && ks.IsKeyUp(Keys.A))
                    {
                        spriteBatch.Draw(player2RightTexture, player2RightRect, Color.White * player2RightTexOpacity);
                        player2RightTexOpacity = 1f;
                        player2LeftTexOpacity = 0f;
                    }
                    else
                    if (ks.IsKeyDown(Keys.A) && ks.IsKeyUp(Keys.D))
                    {
                        spriteBatch.Draw(player2LeftTexture, player2RightRect, Color.White * player2LeftTexOpacity);
                        player2LeftTexOpacity = 1f;
                        player2RightTexOpacity = 0f;
                    }
                    else
                    if (ks.IsKeyUp(Keys.A) && ks.IsKeyDown(Keys.D))
                    {
                        spriteBatch.Draw(player2RightTexture, player2RightRect, Color.White * player2RightTexOpacity);
                        player2LeftTexOpacity = 0f;
                        player2RightTexOpacity = 1f;
                    }
                    else
                    if (ks.IsKeyDown(Keys.A) && ks.IsKeyDown(Keys.D))
                    {
                        spriteBatch.Draw(player2RightTexture, player2RightRect, Color.White * player2RightTexOpacity);
                        player2RightTexOpacity = 1f;
                        player2LeftTexOpacity = 0f;
                    }
                    else
                    if (ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.D))
                    {
                        spriteBatch.Draw(player2LeftTexture, player2RightRect, Color.White * player2LeftTexOpacity);
                        player2RightTexOpacity = 0f;
                        player2LeftTexOpacity = 1f;
                    }
                    break;
                case GameState.gameLevelP1VAI:
                    KeyboardState ks2 = Keyboard.GetState();
                    spriteBatch.Draw(gameLevelP1VAIScreen, Vector2.Zero, Color.White);
                    spriteBatch.Draw(Floor, floorRect, Color.White);
                    spriteBatch.Draw(neddyHealthBarOverlayPVAI, neddyHBOPVAIRect, Color.White);
                    spriteBatch.Draw(alienHealthBarOverlayPVAI, alienHBOPVAIRect, Color.White);
                    spriteBatch.Draw(laserTexture, laserRect, Color.White);
                    spriteBatch.Draw(bulletSprite, bulletRect, Color.White);
                    iwf.Draw(spriteBatch);
                    spriteBatch.Draw(hpPickUp, hppuRect, Color.White);
                    if (ks2.IsKeyDown(Keys.D) && ks2.IsKeyUp(Keys.A))
                    {
                        spriteBatch.Draw(player2RightTexture, player2RightRect, Color.White * player2RightTexOpacity);
                        player2RightTexOpacity = 1f;
                        player2LeftTexOpacity = 0f;
                    }
                    else
                   if (ks2.IsKeyDown(Keys.A) && ks2.IsKeyUp(Keys.D))
                    {
                        spriteBatch.Draw(player2LeftTexture, player2RightRect, Color.White * player2LeftTexOpacity);
                        player2LeftTexOpacity = 1f;
                        player2RightTexOpacity = 0f;
                    }
                    else
                   if (ks2.IsKeyUp(Keys.A) && ks2.IsKeyDown(Keys.D))
                    {
                        spriteBatch.Draw(player2RightTexture, player2RightRect, Color.White * player2RightTexOpacity);
                        player2LeftTexOpacity = 0f;
                        player2RightTexOpacity = 1f;
                    }
                    else
                   if (ks2.IsKeyDown(Keys.A) && ks2.IsKeyDown(Keys.D))
                    {
                        spriteBatch.Draw(player2RightTexture, player2RightRect, Color.White * player2RightTexOpacity);
                        player2RightTexOpacity = 1f;
                        player2LeftTexOpacity = 0f;
                    }
                    else
                   if (ks2.IsKeyUp(Keys.A) && ks2.IsKeyUp(Keys.D))
                    {
                        spriteBatch.Draw(player2RightTexture, player2RightRect, Color.White * player2RightTexOpacity);
                        player2RightTexOpacity = 1f;
                        player2LeftTexOpacity = 0f;
                    }
                    //spriteBatch.Draw(alienTexture, alienRect, Color.White);
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        enemies[i].Draw(spriteBatch);
                    }
                    break;
                case GameState.gameLevelP2VAI:
                    KeyboardState ks1 = Keyboard.GetState();
                    spriteBatch.Draw(gameLevelP2VAIScreen, Vector2.Zero, Color.White);
                    spriteBatch.Draw(Floor, floorRect, Color.White);
                    spriteBatch.Draw(billyHealthBarOverlayPVAI, billyHBOPVAIRect, Color.White);
                    spriteBatch.Draw(alienHealthBarOverlayPVAI, alienHBOPVAIRect, Color.White);
                    spriteBatch.Draw(missileTexture, missileRect, Color.White);
                    iwf.Draw(spriteBatch);
                    spriteBatch.Draw(hpPickUp, hppuRect, Color.White);

                    if (ks1.IsKeyDown(Keys.Left) && ks1.IsKeyUp(Keys.Right))
                    {
                        spriteBatch.Draw(player1RightTexture, playerRect, Color.White * player1RightTexOpacity);
                        player1RightTexOpacity = 1f;
                        player1LeftTexOpacity = 0f;
                    }
                    else
                     if (ks1.IsKeyDown(Keys.Right) && ks1.IsKeyUp(Keys.Left))
                    {
                        spriteBatch.Draw(player1LeftTexture, playerRect, Color.White * player1LeftTexOpacity);
                        player1LeftTexOpacity = 1f;
                        player1RightTexOpacity = 0f;
                    }
                    else
                     if (ks1.IsKeyUp(Keys.Right) && ks1.IsKeyDown(Keys.Left))
                    {
                        spriteBatch.Draw(player1RightTexture, playerRect, Color.White * player1RightTexOpacity);
                        player1LeftTexOpacity = 0f;
                        player1RightTexOpacity = 1f;
                    }
                    else
                     if (ks1.IsKeyDown(Keys.Right) && ks1.IsKeyDown(Keys.Left))
                    {
                        spriteBatch.Draw(player1RightTexture, playerRect, Color.White * player1RightTexOpacity);
                        player1RightTexOpacity = 1f;
                        player1LeftTexOpacity = 0f;
                    }
                    else
                     if (ks1.IsKeyUp(Keys.Right) && ks1.IsKeyUp(Keys.Left))
                    {
                        spriteBatch.Draw(player1RightTexture, playerRect, Color.White * player1RightTexOpacity);
                        player1RightTexOpacity = 1f;
                        player1LeftTexOpacity = 0f;
                    }
                    //spriteBatch.Draw(alienTexture, alienRect, Color.White);
                    break;
                    //case GameState.gameOver:
                    //    spriteBatch.Draw(gameOverScreen, Vector2.Zero, Color.White);
                    //    break;
                    //case GameState.gameWon:
                    //    spriteBatch.Draw(gameWonScreen, Vector2.Zero, Color.White);
                    //    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        protected bool CollidePVP()
        //This is where the collision of the rings and skull
        {
            Rectangle player1ColRect = new Rectangle(
                 (int)playerRect.X + 12,
                 (int)playerRect.Y + 5,
                 player1RightTexture.Height - (5 * 2),
                 player1RightTexture.Width - (5 * 2));

            Rectangle player2ColRect = new Rectangle(
                (int)player2RightRect.X - 60,
                (int)player2RightRect.Y + 32,
                 player2LeftTexture.Height - (5 * 2),
                 player2LeftTexture.Width - (5 * 2));

            return player1ColRect.Intersects(player2ColRect);
        }
        protected bool CollideP1VAI()
        {
            Rectangle player1ColRect = new Rectangle(
                 (int)playerRect.X + 12,
                 (int)playerRect.Y + 5,
                 player1RightTexture.Height - (5 * 2),
                 player1RightTexture.Width - (5 * 2));

            Rectangle alienColRect = new Rectangle(
                (int)alienRect.X - 60,
                (int)alienRect.Y + 32,
                 alienTexture.Height - (5 * 2),
                 alienTexture.Width - (5 * 2));

            return player1ColRect.Intersects(alienColRect);
        }
        protected bool CollideP2VAI()
        {
            Rectangle player2ColRect = new Rectangle(
                (int)player2RightRect.X - 60,
                (int)player2RightRect.Y + 32,
                 player2LeftTexture.Height - (5 * 2),
                 player2LeftTexture.Width - (5 * 2));

            Rectangle alienColRect = new Rectangle(
                (int)alienRect.X - 60,
                (int)alienRect.Y + 32,
                 alienTexture.Height - (5 * 2),
                 alienTexture.Width - (5 * 2));

            return player2ColRect.Intersects(alienColRect);
        }
    }
 }