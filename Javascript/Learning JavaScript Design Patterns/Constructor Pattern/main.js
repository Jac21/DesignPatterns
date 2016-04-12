/* https://addyosmani.com/resources/essentialjsdesignpatterns/book/#constructorpatternjavascript
*	Object Creation
*/

// three common ways to create new objects in JS

var newObject = {};
// or
var newObjectCreate = Object.create(Object.prototype);
// or
var newObjectDeclaration = new Object();

// four ways in which kets and values can be assigned to an object

// ECMAScript 3 compatible approaches

// 1. Dot syntax

// Set properties
newObject.someKey = "Hello, World";

// Get properties
var value = newObject.someKey;

// 2. Square bracket syntax

// Set properties
newObject["someKey"] = "Hello, World";

// Get properties
var value = newObject["someKey"];

// ECMAScript 5 only compatible approaches

// 3. Object.defineProperty

// Set properties
Object.defineProperty(newObject, "someKey", {
	value: "for more control of the property's behavior",
	writable: true,
	enumerable: true,
	configurable: true
});

// short hand
var defineProp = function (obj, key, value) {
	var config = {
		value: value,
		writable: true,
		enumerable: true,
		configurable: true
	};
	Object.defineProperty(obj, key, config);
};

// to use, we then create a new empty "person" object
var person = Object.create(Object.prototype);

// populate the object with properties
defineProp(person, "car", "Delorean");
defineProp(person, "dateOfBirth", "1981");
defineProp(person, "hasBeard", false);

console.log(person);
// outputs: object {car: "Delorean", dateOfBirth: "1981", hasBeard: false}

// 4. Object.defineProperties

// Set properties
Object.defineProperties(newObject, {
	"someKey": {
		value: "Hello World",
		writable: true
	},
	"anotherKey": {
		value: "Foo bar",
		writable: false
	}
});

// getting properties for 3 and 4 can be done using any of the options in 1 and 2

/*
*	Inheritance
*/

// usage:

// Create a race car driver that inherits from the person object
var driver = Object.create(person);

// Set some properties for the driver
defineProp(driver, "topSpeed", "100mph");

// Get an inherited property (1981)
console.log(driver.dateOfBirth);

// Get the property we set (100mph)
console.log(driver.topSpeed);

/*
*	Basic Constructors (Problems include difficulty in inheritance, toString is redefined)
*/

function Car(model, year, miles) {
	this.model = model;
	this.year = year;
	this.miles = miles;

	this.toString = function() {
		return this.model + " has done " + this.miles + " miles";
	};
}

// Usage:

// We can create new instances of the car
var civic = new Car("Honda Civic", 2009, 20000);
var mondeo = new Car("Ford Mondeo", 2010, 5000);

// and then test the toString method
console.log(civic.toString());
console.log(mondeo.toString());

/*
*	Constructor with Prototypes
*/

function Job(position, year, salary) {
	this.position = position;
	this.year = year;
	this.salary = salary;
}

// note here that we are using Object.prototype.newMethod rather than
// Object.prototype so as to avoid redifining the prototype object
Job.prototype.toString = function () {
	return this.position + " is the position and makes " + this.salary + " dollars.";
};

// Usage:

var developer = new Job("Software Developer", 2016, "100000");
var designer = new Job("UI Designer", 2017, "80000");

console.log(developer.toString());
console.log(designer.toString());