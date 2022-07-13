namespace Namespace {
    
    public static class Module {
        
        // A thing that is done.
        //     The responsibility of action is to do somthing that is integral or important in the game. Thus,
        //     it has one method, execute(), which should be overridden by derived classes.
        //     
        public class Action {
            
            // Executes something that is important in the game. This method should be overriden by
            //         derived classes.
            //         Args:
            //         ---
            //             cast (Cast): The cast of Actors in the game.
            //             script (Script): The script of Actions in the game.
            //         
            public virtual object execute(object cast, object script) {
            }
        }
    }
}