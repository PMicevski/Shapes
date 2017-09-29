using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Drawing myDrawing;

            myDrawing = new Drawing();

            ShapeKind kindToAdd;
            kindToAdd = ShapeKind.Circle;

            
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            
            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,0);

                //Draw onto the screen
                myDrawing.Draw();

                if (SwinGame.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SwinGame.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SwinGame.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {                    
                    Shape newShape;
                    
                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            newShape = new Circle();                           
                            break;
                        case ShapeKind.Line:
                            newShape = new Line();
                            break;
                        default:
                            newShape = new Rectangle();                     
                            break;                    
                    }
                    myDrawing.AddShape(newShape);
                }

                if (SwinGame.KeyTyped(KeyCode.SpaceKey))
                {
                    Color randomColour = SwinGame.RandomRGBColor(255);
                    myDrawing.Background = randomColour;                   
                }
                
                if (SwinGame.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapeAt(SwinGame.MousePosition());
                }

                if (SwinGame.KeyTyped(KeyCode.BackspaceKey) || SwinGame.KeyTyped(KeyCode.DeleteKey))
                {
                    List<Shape> myShapes = myDrawing.SelectedShapes;
                    foreach(Shape s in myShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }

                SwinGame.RefreshScreen(60);
            }
        }
    }
}