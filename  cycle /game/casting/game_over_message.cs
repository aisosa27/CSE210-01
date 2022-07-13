namespace Namespace {
    
    using constants;
    
    using Actor = game.casting.actor.Actor;
    
    public static class Module {
        
        // 
        //     Displays a Game Over Message
        //     Attributes:
        //     ---
        //         _color (constant): The color value the game over message is displayed in.
        //     
        public class GameOver
            : Actor {
            
            public GameOver() {
                this._color = constants.GREEN;
            }
            
            // Gets the actor's color as a tuple of three ints (r, g, b).
            //         Returns:
            //         ---
            //             Color: The actor's text color.
            //         
            public virtual object get_color() {
                return base.get_color();
            }
            
            // Updates the color to the given one.
            //         Args:
            //         ---
            //             color (Color): The given color.
            //         
            public virtual object set_color(object color) {
                return base.set_color(color);
            }
        }
    }
}