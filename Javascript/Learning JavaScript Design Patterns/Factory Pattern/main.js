// The Factory Pattern

// Types.js - Constructors used behind the scenes

// a constructor for defining new cars
function Car(options) {

	// some defaults
	this.doors = options.doors || 4;
	this.state = options.state || "brand new";
	this.color = options.color || "silver";
}

// a constructor for defining new tracks
function Truck(options) {
	this.state = options.state || "used";
	this.wheelSize = options.wheelSize || "large";
	this.color = options.color || "blue";
}

// FactoryExample.js

// define a skeleton vehicle factory
function VehicleFactory() {}

// Define the prototypes and utlities for this factory

// our default vehicleClass is Car
VehicleFactory.prototype.vehicleClass = Car;

// Our Factory method for creating new Vehicle instances
VehicleFactory.prototype.createVehicle = function(options) {
	switch(options.vehicleType) {
		case "car":
			this.vehicleClass = Car;
			break;
		case "truck":
			this.vehicleClass = Truck;
			break;
		// defaults to VehicleFactory.prototype.vehicleClass (Car)
	}

	return new this.vehicleClass(options);
};

// Create an instance of our factory that makes cars
var carFactory = new VehicleFactory();
var car = carFactory.createVehicle( {
	vehicleType: "car",
	color: "yellow",
	doors: 6
});

// Test to confirm our car was created using the vehicleClass/prototype Car

// Outputs: true
console.log(car instanceof Car);

// Outputs: Car object of color "yellow", doors: 6 in a "brand new" state
console.log(car);

/*
*	Approach #1: Modify a VehicleFactory instance to use the Truck class
*/

// Create an instance of our factory that makes truck
var truckFactory = new VehicleFactory();
var truck = truckFactory.createVehicle( {
	state: "like new",
	vehicleType: "truck",
	color: "red",
	wheelSize: "large"
});

// Test to confirm our car was created using the vehicleClass/prototype Car

// Outputs: true
console.log(truck instanceof Truck);

// Outputs: Car object of color "yellow", doors: 6 in a "brand new" state
console.log(truck);

/*
*	Approach #2: Subclass VehicleFactory to create a factory class that builds Trucks
*/

function TruckFactory() {}
TruckFactory.prototype = new VehicleFactory();
TruckFactory.prototype.vehicleClass = Truck;

var truckFactory = new TruckFactory();
var myBigTruck = truckFactory.createVehicle( {
	state: "omg",
	color: "aqua",
	wheelSize: "monster"
});

console.log(myBigTruck instanceof Truck);
console.log(myBigTruck);

/*
When To Use The Factory Pattern

The Factory pattern can be especially useful when applied to the following situations:

When our object or component setup involves a high level of complexity

When we need to easily generate different instances of objects depending on the environment 
we are in

When we're working with many small objects or components that share the same properties

When composing objects with instances of other objects that need only satisfy an API 
contract (aka, duck typing) to work. This is useful for decoupling.
*/

/*
*	Abstract Factories
aims to encapsulate a group of individual factories with a common goal. It separates 
the details of implementation of a set of objects from their general usage.
*/

var abstractVehicleFactory = (function() {
	// storage for our vehicle types
	var types = {};

	return {
		getVehicle: function(type, customizations) {
			var Vehicle = types[type];

			return (Vehicle ? new Vehicle(customizations) : null);
		},

		registerVehicle: function(type, Vehicle) {
			var proto = Vehicle.prototype;

			// only register classes that fulfill the vehicle contract
			if (proto.drive && proto.breakDown) {
				types[type] = Vehicle;
			}

			return abstractVehicleFactory;
		}
	};
})();

// Usage:

abstractVehicleFactory.registerVehicle("car", Car);
abstractVehicleFactory.registerVehicle("truck", Truck);

// Instantiate a new car based on the abstract vehicle type
var car = abstractVehicleFactory.getVehicle("car", {
	color: "lime green",
	state: "like new"
});

// Instantiate a new truck in a similar manner
var truck = abstractVehicleFactory.getVehicle("truck", {
	wheelSize: "medium",
	color: "neon yellow"
});