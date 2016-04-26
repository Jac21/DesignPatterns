/*
The Decorator pattern isn't heavily tied to how objects are created but instead 
focuses on the problem of extending their functionality. Rather than just relying 
on prototypal inheritance, we work with a single base object and progressively 
add decorator objects which provide the additional capabilities. The idea is that 
rather than sub-classing, we add (decorate) properties or methods to a base object 
so it's a little more streamlined.
*/

// Example 1: Decorating Constructors With New Functionality

// a vehicle constructor
function Vehicle(vehicleType) {
	// some sane defaults
	this.vehicleType = vehicleType || "car";
	this.model = "default";
	this.license = "00000-000";
}

// Test instance for a basic vehicle
var testInstance = new Vehicle("car");
console.log(testInstance);

// Outputs:
// vehicle, car, model:default, license: 0000-000

// Let's create a new instance of a vehicle to be decorated
var truck = new Vehicle("truck");

// New functionality we're decorating vehicle with
truck.setModel = function(modelName) {
	this.model = modelName
};

truck.setColor = function(color) {
	this.color = color;
};

// Test the value setters and value assignments work correctly
truck.setModel("CAT");
truck.setColor("Yellow");

console.log(truck);

// Outputs:
// vehicle: truck, model: CAT, color: Yellow

// demonstrate "vehicle" is still unaltered
var secondInstance = new Vehicle("car");
console.log(secondInstance);

// Outputs:
// vehicle, car, model:default, license: 0000-000

// Example 2: Decorating Objects With Multiple Decorators

// the constructor to decorate
function MacBook() {
	this.cost = function() { return 9999; };
	this.screenSize = function() { return 11.6; };
}

// Decorator 1
function memory(macbook) {
	var v = macbook.cost();
	macbook.cost = function() {
		return v + 1000;
	};
}

// Decorator 2
function engraving(macbook) {
	var v = macbook.cost();
	macbook.cost = function() {
		return v + 1500;
	};
}

// Decorator 3
function insurance(macbook) {
	var v = macbook.cost();
	macbook.cost = function() {
		return v + 2000;
	};
}

var mb = new MacBook();
memory(mb);
engraving(mb);
insurance(mb);

// Outputs: 14499
console.log(mb.cost());

// Outputs: 11.6
console.log(mb.screenSize());

/*
Pseudo-classical Decorators


// Create interfaces using a pre-defined Interface
// constructor that accepts an interface name and
// skeleton methods to expose.
 
// In our reminder example summary() and placeOrder()
// represent functionality the interface should
// support
var reminder = new Interface( "List", ["summary", "placeOrder"] );
 
var properties = {
  name: "Remember to buy the milk",
  date: "05/06/2016",
  actions:{
    summary: function (){
      return "Remember to buy the milk, we are almost out!";
   },
    placeOrder: function (){
      return "Ordering milk from your local grocery store";
    }
  }
};
 
// Now create a constructor implementing the above properties
// and methods
 
function Todo( config ){
 
  // State the methods we expect to be supported
  // as well as the Interface instance being checked
  // against
 
  Interface.ensureImplements( config.actions, reminder );
 
  this.name = config.name;
  this.methods = config.actions;
 
}
 
// Create a new instance of our Todo constructor
 
var todoItem = new Todo( properties );
 
// Finally test to make sure these function correctly
 
console.log( todoItem.methods.summary() );
console.log( todoItem.methods.placeOrder() );
 
// Outputs:
// Remember to buy the milk, we are almost out!
// Ordering milk from your local grocery store
*/


/*
Abstract Decorators


var Macbook = new Interface( "Macbook",
  ["addEngraving",
  "addParallels",
  "add4GBRam",
  "add8GBRam",
  "addCase"]);
 
// A Macbook Pro might thus be represented as follows:
var MacbookPro = function(){
    // implements Macbook
};
 
MacbookPro.prototype = {
    addEngraving: function(){
    },
    addParallels: function(){
    },
    add4GBRam: function(){
    },
    add8GBRam:function(){
    },
    addCase: function(){
    },
    getPrice: function(){
      // Base price
      return 900.00;
    }
};
*/

// Macbook decorator abstract decorator class
 
var MacbookDecorator = function( macbook ){
 
    Interface.ensureImplements( macbook, Macbook );
    this.macbook = macbook;
 
};
 
MacbookDecorator.prototype = {
    addEngraving: function(){
        return this.macbook.addEngraving();
    },
    addParallels: function(){
        return this.macbook.addParallels();
    },
    add4GBRam: function(){
        return this.macbook.add4GBRam();
    },
    add8GBRam:function(){
        return this.macbook.add8GBRam();
    },
    addCase: function(){
        return this.macbook.addCase();
    },
    getPrice: function(){
        return this.macbook.getPrice();
    }
};


// First, define a way to extend an object a
// with the properties in object b. We'll use
// this shortly!
function extend( a, b ){
    for( var key in b )
        if( b.hasOwnProperty(key) )
            a[key] = b[key];
    return a;
}
 
var CaseDecorator = function( macbook ){
   this.macbook = macbook;
};
 
// Let's now extend (decorate) the CaseDecorator
// with a MacbookDecorator
extend( CaseDecorator, MacbookDecorator );
 
CaseDecorator.prototype.addCase = function(){
    return this.macbook.addCase() + "Adding case to macbook";
};
 
CaseDecorator.prototype.getPrice = function(){
    return this.macbook.getPrice() + 45.00;
};

// Instantiation of the macbook
var myMacbookPro = new MacbookPro();
 
// Outputs: 900.00
console.log( myMacbookPro.getPrice() );
 
// Decorate the macbook
var decoratedMacbookPro = new CaseDecorator( myMacbookPro );
 
// This will return 945.00
console.log( decoratedMacbookPro.getPrice() );