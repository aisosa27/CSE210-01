namespace Namespace {
    
    using constants;
    
    using Color = game.shared.color.Color;
    
    using Point = game.shared.point.Point;
    
    public static class Module {
        
        // A visible, moveable thing that participates in the game.
        //     The responsibility of Actor is to keep track of its appearance, position and velocity in 2d
        //     space.
        //     Attributes:
        //         _text (string): The text to display
        //         _font_size (int): The font size to use.
        //         _color (Color): The color of the text.
        //         _position (Point): The screen coordinates.
        //         _velocity (Point): The speed and direction.
        //     
        public class Actor {
            
            public Actor() {
                this._text = "";
                this._font_size = 15;
                this._color = Color(255, 255, 255);
                this._position = Point(0, 0);
                this._velocity = Point(0, 0);
            }
            
            // Gets the actor's color as a tuple of three ints (r, g, b).
            //         Returns:
            //         ---
            //             Color: The actor's text color.
            //         
            public virtual object get_color() {
                return this._color;
            }
            
            // Gets the actor's font size.
            //         Returns:
            //         ---
            //             Point: The actor's font size.
            //         
            public virtual object get_font_size() {
                return this._font_size;
            }
            
            // Gets the actor's position in 2d space.
            //         Returns:
            //         ---
            //             Point: The actor's position in 2d space.
            //         
            public virtual object get_position() {
                return this._position;
            }
            
            // Gets the actor's textual representation.
            //         Returns:
            //         ---
            //             string: The actor's textual representation.
            //         
            public virtual object get_text() {
                return this._text;
            }
            
            // Gets the actor's speed and direction.
            //         Returns:
            //         ---
            //             Point: The actor's speed and direction.
            //         
            public virtual object get_velocity() {
                return this._velocity;
            }
            
            // Moves the actor to its next position according to its velocity. Will wrap the position
            //         from one side of the screen to the other when it reaches the given maximum x and y values.
            //         Args:
            //         ---
            //             max_x (int): The maximum x value.
            //             max_y (int): The maximum y value.
            //         
            public virtual object move_next() {
                var x = (this._position.get_x() + this._velocity.get_x()) % constants.MAX_X;
                var y = (this._position.get_y() + this._velocity.get_y()) % constants.MAX_Y;
                this._position = Point(x, y);
            }
            
            // Updates the color to the given one.
            //         Args:
            //         ---
            //             color (Color): The given color.
            //         
            public virtual object set_color(object color) {
                this._color = color;
            }
            
            // Updates the position to the given one.
            //         Args:
            //         ---
            //             position (Point): The given position.
            //         
            public virtual object set_position(object position) {
                this._position = position;
            }
            
            // Updates the font size to the given one.
            //         Args:
            //         ---
            //             font_size (int): The given font size.
            //         
            public virtual object set_font_size(object font_size) {
                this._font_size = font_size;
            }
            
            // Updates the text to the given value.
            //         Args:
            //         ---
            //             text (string): The given value.
            //         
            public virtual object set_text(object text) {
                this._text = text;
            }
            
            // Updates the velocity to the given one.
            //         Args:
            //         ---
            //             velocity (Point): The given velocity.
            //         
            public virtual object set_velocity(object velocity) {
                this._velocity = velocity;
            }
        }
    }
}