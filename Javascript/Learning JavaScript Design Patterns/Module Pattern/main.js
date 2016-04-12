/*
*	Object Literals
*/

var myModule = {
	myProperty: "someValue",

	// object literals can contain properties and methods.
	// e.g., we can define a further object for module configuration
	myConfig: {
		useCaching: true,
		language: "en"
	},

	// basic method
	saySomething: function() {
		console.log("Where in the world is Carmen Sandiego?");
	},

	// output a value based on the current configuration
	reportMyConfig: function() {
		console.log("Caching is: " + (this.myConfig.useCaching ? "enabled" : "disabled"));
	},

	// override the current configuration
	updateMyConfig : function(newConfig) {
		if (typeof newConfig === "object") {
			this.myConfig = newConfig;
			console.log(this.myConfig.language);
		}
	}
};

// outputs: Where in the world is Carmen Sandiego?
myModule.saySomething();

// outputs: Caching is: enabled
myModule.reportMyConfig();

// outputs: fr
myModule.updateMyConfig({
	language: "fr",
	useCaching: false
});

// outputs: Caching is: disabled
myModule.reportMyConfig();

/*
*	Module Pattern
*/

var testModule = (function() {
	var counter = 0;

	// existence of two methods are limited to module's closure,
	// only code able to access its scope are the two functions
	return {
		incrementCounter: function() {
			return counter++
		},

		resetCounter: function() {
			console.log("counter value prior to reset: " + counter);
			counter = 0;
		}
	};
})();

// Usage:

// increment counter
testModule.incrementCounter();

// check counter and result
testModule.resetCounter();

//

var myNamespace = (function() {
	var myPrivateVar, myPrivateMethod;

	// a private counter variable
	myPrivateVar = 0;

	// a private function which logs any argument
	myPrivateMethod = function(foo) {
		console.log(foo);
	};

	return {
		// a public variable
		myPublicVar: "foo",

		myPublicFunction: function(bar) {
			// increment our private counter
			myPrivateVar++;

			// call our private method using bar
			myPrivateMethod(bar);
		}
	}
})();

// 

var basketModule = (function () {
 
  // privates
 
  var basket = [];
 
  function doSomethingPrivate() {
    //...
  }
 
  function doSomethingElsePrivate() {
    //...
  }
 
  // Return an object exposed to the public
  return {
 
    // Add items to our basket
    addItem: function( values ) {
      basket.push(values);
    },
 
    // Get the count of items in the basket
    getItemCount: function () {
      return basket.length;
    },
 
    // Public alias to a private function
    doSomething: doSomethingPrivate,
 
    // Get the total value of items in the basket
    getTotal: function () {
 
      var q = this.getItemCount(),
          p = 0;
 
      while (q--) {
        p += basket[q].price;
      }
 
      return p;
    }
  };
})();

// basketModule returns an object with a public API we can use
basketModule.addItem({
	item: "bread",
	price: 0.5
});

basketModule.addItem({
	item: "butter",
	price: 0.3
});

// outputs: 2
console.log(basketModule.getItemCount());

// outputs: 0.8
console.log(basketModule.getTotal());

/*
*	Module Pattern Variations
*/

// import mixins
// demonstrates how globals can be passed in as arguments
// to our module's anonymous function (import them, locally alias)

// Global module
var myGlobalModule = (function (jQ, _) {
	function privateMethodOne() {
		//jQ(".container").html("test");
	}

	function privateMethodTwo() {
		//console.log(_.min([10, 5, 100, 2, 1000]));
	}

	return {
		publicMethod: function() {
			privateMethodOne();
		}
	};
	// pull in jquery and underscore
})(/*jQuery, _*/);

myGlobalModule.publicMethod();

// Exports
// allow us to declare globals without consuming them

// Global module
var myGlobalModuleTwo = (function () {
 
  // Module object
  var module = {},
    privateVariable = "Hello World";
 
  function privateMethod() {
    // ...
  }
 
  module.publicProperty = "Foobar";
  module.publicMethod = function () {
    console.log( privateVariable );
  };
 
  return module;
 
})();
