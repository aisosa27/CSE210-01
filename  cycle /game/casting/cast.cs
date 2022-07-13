namespace Namespace {
    
    using System.Collections.Generic;
    
    public static class Module {
        
        // A collection of actors.
        //     The responsibility of a cast is to keep track of a collection of actors. It has methods for
        //     adding, removing and getting them by a group name.
        //     Attributes:
        //     ---
        //         _actors (dict): A dictionary of actors { key: group_name, value: a list of actors }
        //     
        public class Cast {
            
            public Cast() {
                this._actors = new Dictionary<object, object> {
                };
            }
            
            // Adds an actor to the given group.
            //         Args:
            //         ---
            //             group (string): The name of the group.
            //             actor (Actor): The actor to add.
            //         
            public virtual object add_actor(object group, object actor) {
                if (!this._actors.keys().Contains(group)) {
                    this._actors[group] = new List<object>();
                }
                if (!this._actors[group].Contains(actor)) {
                    this._actors[group].append(actor);
                }
            }
            
            // Gets the actors in the given group.
            //         Args:
            //         ---
            //             group (string): The name of the group.
            //         Returns:
            //         ---
            //             List: The actors in the group.
            //         
            public virtual object get_actors(object group) {
                var results = new List<object>();
                if (this._actors.keys().Contains(group)) {
                    results = this._actors[group].copy();
                }
                return results;
            }
            
            // Gets all of the actors in the cast.
            //         Returns:
            //         ---
            //             List: All of the actors in the cast.
            //         
            public virtual object get_all_actors() {
                var results = new List<object>();
                foreach (var group in this._actors) {
                    results.extend(this._actors[group]);
                }
                return results;
            }
            
            // Gets the first actor in the given group.
            //         Args:
            //         ---
            //             group (string): The name of the group.
            //         Returns:
            //         ---
            //             List: The first actor in the group.
            //         
            public virtual object get_first_actor(object group) {
                object result = null;
                if (this._actors.keys().Contains(group)) {
                    result = this._actors[group][0];
                }
                return result;
            }
            
            // Removes an actor from the given group.
            //         Args:
            //         ---
            //             group (string): The name of the group.
            //             actor (Actor): The actor to remove.
            //         
            public virtual object remove_actor(object group, object actor) {
                if (this._actors.Contains(group)) {
                    this._actors[group].remove(actor);
                }
            }
        }
    }
}