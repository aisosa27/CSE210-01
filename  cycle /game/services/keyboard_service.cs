namespace Namespace {
    
    using pyray;
    
    using System.Collections.Generic;
    
    public static class Module {
        
        // Detects player input.
        //     The responsibility of a KeyboardService is to indicate whether or not a key is up or down.
        //     Attributes:
        //     ---
        //         _keys (Dict[string, int]): The letter to key mapping.
        //     
        public class KeyboardService {
            
            public KeyboardService() {
                this._keys = new Dictionary<object, object> {
                };
                this._keys["w"] = pyray.KEY_W;
                this._keys["a"] = pyray.KEY_A;
                this._keys["s"] = pyray.KEY_S;
                this._keys["d"] = pyray.KEY_D;
                this._keys["i"] = pyray.KEY_I;
                this._keys["j"] = pyray.KEY_J;
                this._keys["k"] = pyray.KEY_K;
                this._keys["l"] = pyray.KEY_L;
            }
            
            // Checks if the given key is currently up.
            //         Args:
            //         ---
            //             key (string): The given key (w, a, s, d or i, j, k, l)
            //         
            public virtual object is_key_up(object key) {
                var pyray_key = this._keys[key.lower()];
                return pyray.is_key_up(pyray_key);
            }
            
            // Checks if the given key is currently down.
            //         Args:
            //         ---
            //             key (string): The given key (w, a, s, d or i, j, k, l)
            //         
            public virtual object is_key_down(object key) {
                var pyray_key = this._keys[key.lower()];
                return pyray.is_key_down(pyray_key);
            }
        }
    }
}