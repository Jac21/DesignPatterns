/*
* Revealing Module Pattern
* Came about from frustration regarding repeating the name of the main
* object when desired to call one public method from another or access
* public variables, disliked requirement for having to switch to object
* literal notation for things to be made public
*
* Simply define all of our functions and variables in the private scope
* and return an anonymous object with pointers to the private 
* functionality we wish to reveal as public
*/

var myRevealingModule = (function() {
	var privateVar = "Jeremy Cantu",
			publicVar = "Hey there!";

	function privateFunction() {
		console.log("Name:" + privateVar);
	}

	function publicSetName(strName) {
		privateVar = strName;
	}

	function publicGetName() {
		privateFunction();
	}

	// Reveal public pointers to
	// private functions and properties

	return {
		setName: publicSetName,
		greeting: publicVar,
		getName: publicGetName
	};
})();

// call setName function
myRevealingModule.setName("Tester McTest");

// output: Hey there!
console.log(myRevealingModule.greeting);

// output: Name: Tester McTest
myRevealingModule.getName();

// More specific naming scheme

var myRevealingModuleTwo = (function() {
	var privateCounter = 0;

	function privateFunction() {
		privateCounter++;
	}

	function publicFunction() {
		publicIncrement();
	}

	function publicIncrement() {
		privateFunction();
	}

	function publicGetCount() {
		console.log("Count:", privateCounter);
		return privateCounter;
	}

	// reveal public pointers to private
	// functions and properties

	return {
		start: publicFunction,
		increment: publicIncrement,
		count: publicGetCount
	};
})();

myRevealingModuleTwo.start();

// output: Count: 1
myRevealingModuleTwo.count();