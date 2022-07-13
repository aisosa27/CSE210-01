namespace Namespace {
    
    using constants;
    
    using Action = game.scripting.action.Action;
    
    using Point = game.shared.point.Point;
    
    using GameOver = game.casting.game_over_message.GameOver;
    
    using System;
    
    public static class Module {
        
        // 
        //     An update action that handles interactions between the actors.
        //     The responsibility of HandleCollisionsAction is to handle the situation when a cycle collides
        //     with its segments or the segments of the other cycle, or the game is over.
        //     Attributes:
        //     ---
        //         _is_game_over (boolean): Whether or not the game is over.
        //     
        public class HandleCollisionsAction
            : Action {
            
            public HandleCollisionsAction() {
                this._is_game_over = false;
                this._game_over_message = "";
            }
            
            // Executes the handle collisions action.
            //         Args:
            //         ---
            //             cast (Cast): The cast of Actors in the game.
            //             script (Script): The script of Actions in the game.
            //         
            public virtual object execute(object cast, object script) {
                if (!this._is_game_over) {
                    this._handle_segment_collision(cast);
                }
                this._handle_wall(cast);
                this._handle_game_over(cast);
            }
            
            // "Handles how the cycles interact with the walls
            //         Args:
            //         ---
            //             cast (Cast): The cast of Actors in the game.
            //         
            public virtual object _handle_wall(object cast) {
                var cycle_one = cast.get_first_actor("cycle_one");
                var cycle_two = cast.get_first_actor("cycle_two");
                cycle_one.wall(this._is_game_over);
                cycle_two.wall(this._is_game_over);
            }
            
            // Sets the game over flag if a cycle collides with one of its segments or the other
            //         cycle.
            //         Args:
            //         ---
            //             cast (Cast): The cast of Actors in the game.
            //         
            public virtual object _handle_segment_collision(object cast) {
                var score1 = cast.get_first_actor("score1");
                var score2 = cast.get_first_actor("score2");
                // Adjust for two players
                var cycle_one = cast.get_first_actor("cycle_one");
                var cycle_two = cast.get_first_actor("cycle_two");
                var cycle_one_head = cycle_one.get_cycle();
                var cycle_two_head = cycle_two.get_cycle();
                var segments_one = cycle_one.get_segments()[1];
                var segments_two = cycle_two.get_segments()[1];
                // Finds which user wins and displays their name
                // If cycle_two hits cycle_one's wall then displays cycle_one wins
                foreach (var segment_one in segments_one) {
                    if (cycle_two_head.get_position().equals(segment_one.get_position())) {
                        score2.reduce_points();
                        if (score2.get_points() < 1) {
                            this._game_over_message = "{cycle_one.get_name()} wins!";
                            this._is_game_over = true;
                        }
                    }
                    // If cycle_one hits its own wall then displays cycle_two wins
                    if (cycle_one_head.get_position().equals(segment_one.get_position())) {
                        score1.reduce_points();
                        if (score1.get_points() < 1) {
                            this._game_over_message = "{cycle_two.get_name()} wins!";
                            this._is_game_over = true;
                        }
                    }
                }
                // If cycle one hits cycle_two's wall then displays cycle_two wins
                foreach (var segment_two in segments_two) {
                    if (cycle_one_head.get_position().equals(segment_two.get_position())) {
                        score1.reduce_points();
                        if (score1.get_points() < 1) {
                            this._game_over_message = "{cycle_two.get_name()} wins!";
                            this._is_game_over = true;
                        }
                    }
                    // If cycle_two hits its own wall then displays cycle_one wins
                    if (cycle_two_head.get_position().equals(segment_two.get_position())) {
                        score2.reduce_points();
                        if (score2.get_points() < 1) {
                            this._game_over_message = "{cycle_one.get_name()} wins!";
                            this._is_game_over = true;
                        }
                    }
                }
                // If cycle_one hits cycle_two display cycle_one wins
                if (cycle_one_head.get_position().equals(cycle_two_head.get_position())) {
                    score1.reduce_points();
                    if (score1.get_points() < 1) {
                        this._game_over_message = "{cycle_two.get_name()} wins!";
                        this._is_game_over = true;
                    }
                }
                // If cycle_two hits cycle_one display cycle_one wins
                if (cycle_two_head.get_position().equals(cycle_one_head.get_position())) {
                    score2.reduce_points();
                    if (score2.get_points() < 1) {
                        this._game_over_message = "{cycle_one.get_name()} wins!";
                        this._is_game_over = true;
                    }
                }
                if (score1.get_points() == 0 && score2.get_points() == 0) {
                    this._game_over_message = "Tie!";
                    this._is_game_over = true;
                }
            }
            
            // Shows the 'game over' message and turns both cycles white if the game is over.
            //         Args:
            //         ---
            //             cast (Cast): The cast of Actors in the game.
            //         
            public virtual object _handle_game_over(object cast) {
                // Gets position for gameover message
                var x = Convert.ToInt32(constants.MAX_X / 2);
                var y = Convert.ToInt32(constants.MAX_Y / 2);
                var position = Point(x, y);
                if (this._is_game_over) {
                    var cycle_one = cast.get_first_actor("cycle_one");
                    var cycle_two = cast.get_first_actor("cycle_two");
                    // Gets segments for cycle one and two
                    var segments_one = cycle_one.get_segments();
                    var segments_two = cycle_two.get_segments();
                    // Creates gameover message
                    var game_over = GameOver();
                    game_over.set_position(position);
                    game_over.set_text(this._game_over_message);
                    game_over.set_font_size(50);
                    cast.add_actor("messages", game_over);
                    // Changes color of cycles to white after the game ends
                    foreach (var segment in segments_one) {
                        segment.set_color(constants.WHITE);
                    }
                    foreach (var segment in segments_two) {
                        segment.set_color(constants.WHITE);
                    }
                }
            }
        }
    }
}