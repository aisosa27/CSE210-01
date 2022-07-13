namespace Namespace {
    
    using Action = game.scripting.action.Action;
    
    public static class Module {
        
        // 
        //     An update action that moves all the actors.
        //     The responsibility of MoveActorsAction is to move all the actors that have a velocity greater
        //     than zero.
        //     
        public class MoveActorsAction
            : Action {
            
            // Executes the move actors action.
            //         Args:
            //         ---
            //             cast (Cast): The cast of Actors in the game.
            //             script (Script): The script of Actions in the game.
            //         
            public virtual object execute(object cast, object script) {
                var actors = cast.get_all_actors();
                foreach (var actor in actors) {
                    actor.move_next();
                }
            }
        }
    }
}