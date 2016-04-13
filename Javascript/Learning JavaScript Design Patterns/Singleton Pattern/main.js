/*
*	Singleton Pattern
*/

var mySingleton = (function() {

	// instance stores a reference to the singleton
	var instance;

	function init() {
		// singleton

		// private methods and variables
		function privateMethod() {
			console.log("I am private");
		}

		var privateVariable = "I'm also private";

		var privateRandomNumber = Math.random();

		return {
			// public methods and variables
			publicMethod: function() {
				console.log("The public can see me!");
			},

			publicProperty: "I am also public",

			getRandomNumber: function() {
				return privateRandomNumber;
			}
		};
	};

	return {
		// get the singleton instance if one exists
		// or create one if it doesn't
		getInstance: function() {
			if (!instance) {
				instance = init();
			}

			return instance;
		}
	};
})();

//

var myBadSingleton = (function() {

	// instance stores a reference to the singleton
	var instance;

	function init() {
		//singleton
		var privateRandomNumber = Math.random();

		return {
			getRandomNumber: function() {
				return privateRandomNumber;
			}
		};
	};

	return {
		// always create a new singletone instance
		getInstance: function() {
			instance = init();
			return instance;
		}
	};
})();

// Usage:

var singleA = mySingleton.getInstance();
var singleB = mySingleton.getInstance();
console.log(singleA.getRandomNumber() === singleB.getRandomNumber()); //true

var badSingleA = myBadSingleton.getInstance();
var badSingleB = myBadSingleton.getInstance();
console.log(badSingleA.getRandomNumber() !== badSingleB.getRandomNumber()); // true

/*
In practice, the Singleton pattern is useful when exactly one object is needed to 
coordinate others across a system. Here is one example with the pattern being used 
in this context:
*/

var SingletonTester = (function() {

	// options: an object containing configuration options for the singleton
	// e.g., var options = {name: "test", pointX: 5};
	function Singleton(options) {

		// set options to the options supplied
		// or an empty object if none are provided
		options = options || {};

		// set some properties for our singleton
		this.name = "SingletonTester";

		this.pointX = options.pointX || 6;

		this.pointY = options.pointY || 10;
	}

	// our instance holder
	var instance;

	// an emulation of static variables and methods
	var _static = {
		name: "SingletonTester",

		// Method for getting an instance. It returns
		// a singleton instance of a singleton object
		getInstance: function(options) {
			if(instance === undefined) {
				instance = new Singleton(options);
			}

			return instance;
		}
	};

	return _static;
})();

var singletonTest = SingletonTester.getInstance({
	pointX: 5
});

// log the output just to verify it is correct
// Outputs: SingletonTester
console.log(singletonTest.name);
// Outputs: 5
console.log(singletonTest.pointX);
// Outputs: 10
console.log(singletonTest.pointY);