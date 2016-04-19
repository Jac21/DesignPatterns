/*
*	Facade Pattern
*/

// unoptimized example, interface for listening to events cross-browser
// common method that can be used to check for existence of features

var addMyEvent = function( el,ev,fn ){
 
   if( el.addEventListener ){
            el.addEventListener( ev,fn, false );
      }else if(el.attachEvent){
            el.attachEvent( "on" + ev, fn );
      } else{
           el["on" + ev] = fn;
    }
 
};

/*
In a similar manner, we're all familiar with jQuery's $(document).ready(..). 
Internally, this is actually being powered by a method called bindReady(), 
which is doing this:

bindReady: function() {
    ...
    if ( document.addEventListener ) {
      // Use the handy event callback
      document.addEventListener( "DOMContentLoaded", DOMContentLoaded, false );
 
      // A fallback to window.onload, that will always work
      window.addEventListener( "load", jQuery.ready, false );
 
    // If IE event model is used
    } else if ( document.attachEvent ) {
 
      document.attachEvent( "onreadystatechange", DOMContentLoaded );
 
      // A fallback to window.onload, that will always work
      window.attachEvent( "onload", jQuery.ready );
               ...
*/

// Facade integrated with Module

var module = (function() {
	var _private = {
		i: 5,
		get: function() {
			console.log("current value:" + this.i);
		},
		set: function(val) {
			this.i = val;
		},
		run: function() {
			console.log("running");
		},
		jump: function() {
			console.log("jumping");
		}
	};

	return {
		facade: function(args) {
			_private.set(args.val);
			_private.get();
			if (args.run) {
				_private.run();
			} else if (args.jump) {
				_private.jump();
			}
		}
	}
}());

// Outputs: "current value: 10" and "running"
module.facade({run: false, val: 10, jump: true});