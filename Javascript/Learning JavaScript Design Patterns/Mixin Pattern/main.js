/*
Mixins are classes which offer functionality that can be easily inherited by a 
sub-class or group of sub-classes for the purpose of function re-use.
*/

// Sub-classing

var Person = function(firstName, lastName) {
	this.firstName = firstName;
	this.lastName = lastName;
	this.gender = "male";
};

// a new instance of Person can then easily be created as follows:
var clark = new Person("Clark", "Kent");

// Define a subclass constructor for the "Superhero":
var Superhero = function(firstName, lastName, powers) {
	// invoke the superclass constructor on the new object
	// then use .call() to invoke the constructor as a method of
	// the object to be initialized.

	Person.call(this, firstName, lastName);

	// Finally, store their powers, a new array of traits not found in a
	// normal person
	this.powers = powers;
};

Superhero.prototype = Object.create(Person.prototype);
var superman = new Superhero("Clark", "Kent", ["flight", "heat-vision"]);
console.log(superman);	// outputs attributes

/*
*	Mixins
*/

var myMixins = {
	moveUp: function() {
		console.log("move up");
	},

	moveDown: function() {
		console.log("move down");
	},

	stop: function() {
		console.log("stop");
	}
};

/*
We can then easily extend the prototype of existing constructor functions to 
include this behavior using a helper such as the Underscore.js _.extend() method:

// A skeleton carAnimator constructor
function CarAnimator(){
  this.moveLeft = function(){
    console.log( "move left" );
  };
}
 
// A skeleton personAnimator constructor
function PersonAnimator(){
  this.moveRandomly = function(){  };
}
 
// Extend both constructors with our Mixin
_.extend( CarAnimator.prototype, myMixins );
_.extend( PersonAnimator.prototype, myMixins );
 
// Create a new instance of carAnimator
var myAnimator = new CarAnimator();
myAnimator.moveLeft();
myAnimator.moveDown();
myAnimator.stop();
 
// Outputs:
// move left
// move down
// stop! in the name of love!
*/

// Define a simple Car constructor
var Car = function ( settings ) {
 
    this.model = settings.model || "no model provided";
    this.color = settings.color || "no colour provided";
 
};
 
// Mixin
var Mixin = function () {};
 
Mixin.prototype = {
 
    driveForward: function () {
        console.log( "drive forward" );
    },
 
    driveBackward: function () {
        console.log( "drive backward" );
    },
 
    driveSideways: function () {
        console.log( "drive sideways" );
    }
 
};

// Extend an existing object with a method from another
function augment(receivingClass, givingClass) {
	// only provide certain methods
	if (arguments[2]) {
		for ( var i = 2, len = arguments.length; i < len; i++) {
			receivingClass.prototype[arguments[i]] = givingClass.prototype[arguments[i]];
		}
	}

	//provide all methods
	else {
		for (var methodName in givingClass.prototype) {
			// check to make sure the receiving class doesn't
      // have a method of the same name as the one currently
      // being processed
      if ( !Object.hasOwnProperty.call(receivingClass.prototype, methodName) ) {
                receivingClass.prototype[methodName] = givingClass.prototype[methodName];
        }

        // Alternatively (check prototype chain as well):
        // if ( !receivingClass.prototype[methodName] ) {
        // receivingClass.prototype[methodName] = givingClass.prototype[methodName];
        // }
		}
	}
}

// Augment the Car constructor to include "driveForward" and "driveBackward"
augment( Car, Mixin, "driveForward", "driveBackward" );
 
// Create a new Car
var myCar = new Car({
    model: "Ford Escort",
    color: "blue"
});
 
// Test to make sure we now have access to the methods
myCar.driveForward();
myCar.driveBackward();
 
// Outputs:
// drive forward
// drive backward
 
// We can also augment Car to include all functions from our mixin
// by not explicitly listing a selection of them
augment( Car, Mixin );
 
var mySportsCar = new Car({
    model: "Porsche",
    color: "red"
});
 
mySportsCar.driveSideways();
 
// Outputs:
// drive sideways