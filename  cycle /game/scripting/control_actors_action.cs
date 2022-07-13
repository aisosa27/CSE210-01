namespace Namespace {
    
    using constants;
    
    using Action = game.scripting.action.Action;
    
    using Point = game.shared.point.Point;
    
    public static class Module {
        
        // 
        //     An input action that controls the cycle.
        //     The responsibility of ControlActorsAction is to get a direction and turn\
        //     a cycle to move in that direction depending on the key a player presses.
        //     Attributes:
        //     ---
        //         _keyboard_service (KeyboardService): An instance of KeyboardService.
        //         _cycle_one_direction (Point): The direction assigned to cycle_one. 
        //         _cycle_two_direction (Point): The direction assigned to cycle_two.
        //     
        public class ControlActorsAction
            : Action {
            
            public ControlActorsAction(object keyboard_service) {
                this._keyboard_service = keyboard_service;
                this._cycle_one_direction = Point(0, -constants.CELL_SIZE);
                this._cycle_two_direction = Point(0, -constants.CELL_SIZE);
            }
            
            // Executes the control actors action.
            //         Args:
            //         ---
            //             cast (Cast): The cast of Actors in the game.
            //             script (Script): The script of Actions in the game.
            //         
            public virtual object execute(object cast, object script) {
                // Cycle one keyboard Inputs
                // left
                if (this._keyboard_service.is_key_down("a")) {
                    this._cycle_one_direction = Point(-constants.CELL_SIZE, 0);
                }
                // right
                if (this._keyboard_service.is_key_down("d")) {
                    this._cycle_one_direction = Point(constants.CELL_SIZE, 0);
                }
                // up
                if (this._keyboard_service.is_key_down("w")) {
                    this._cycle_one_direction = Point(0, -constants.CELL_SIZE);
                }
                // down
                if (this._keyboard_service.is_key_down("s")) {
                    this._cycle_one_direction = Point(0, constants.CELL_SIZE);
                }
                var cycle_one = cast.get_first_actor("cycle_one");
                cycle_one.turn_cycle(this._cycle_one_direction);
                // Cycle two keyboard Inputs
                // left
                if (this._keyboard_service.is_key_down("j")) {
                    this._cycle_two_direction = Point(-constants.CELL_SIZE, 0);
                }
                // right
                if (this._keyboard_service.is_key_down("l")) {
                    this._cycle_two_direction = Point(constants.CELL_SIZE, 0);
                }
                // up
                if (this._keyboard_service.is_key_down("i")) {
                    this._cycle_two_direction = Point(0, -constants.CELL_SIZE);
                }
                // down
                if (this._keyboard_service.is_key_down("k")) {
                    this._cycle_two_direction = Point(0, constants.CELL_SIZE);
                }
                var cycle_two = cast.get_first_actor("cycle_two");
                cycle_two.turn_cycle(this._cycle_two_direction);
            }
        }
    }
}