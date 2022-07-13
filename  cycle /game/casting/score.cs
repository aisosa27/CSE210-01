namespace Namespace {
    
    using constants;
    
    using Actor = game.casting.actor.Actor;
    
    using Point = game.shared.point.Point;
    
    public static class Module {
        
        // 
        //     A record of points made or lost.
        //     The responsibility of Score is to keep track of the points the player has earned.
        //     It contains methods for adding and getting points. Client should use get_text() to get a string
        //     representation of the points earned.
        //     Attributes:
        //     ---
        //         _points (int): The points earned in the game.
        //         position (Point): A point value to place each players score on the screen.
        //         _player_name (string): A string that will hold each players name.
        //         set_position (method): A method that sets the scores position on the screen.
        //         set_text (method): A method that displays each players name.
        //     
        public class Score
            : Actor {
            
            public Score() {
                this._points = 0;
                var position = Point(0, 0);
                this._player_name = "";
                this.set_text("{self._player_name}: {self._points}");
                this.set_position(position);
            }
            
            // Adds the given points to the running total and updates the text.
            //         Args:
            //         ---
            //             self (Score): An instance of Score.
            //             points (integer): The points to add.
            //         
            public virtual object add_points(object points) {
                this._points += points;
                this.set_text("{self._player_name}: {self._points}");
            }
            
            // Sets points for the user
            //         Returns:
            //         ---
            //             Integer: A point value for each player.
            //         
            public virtual object get_points() {
                return this._points;
            }
            
            // Reduces points for the user
            public virtual object reduce_points() {
                this._points -= 1;
                this.set_text("{self._player_name}: {self._points}");
            }
            
            // Sets the player's name
            //         Args:
            //         ---
            //             name (string): gets the user inputted name
            //         
            public virtual object set_player_name(object name) {
                this._player_name = name;
                this.set_text("{self._player_name}: {self._points}");
            }
        }
    }
}