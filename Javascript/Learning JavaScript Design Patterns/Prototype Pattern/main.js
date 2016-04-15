/*
*	Object.create
*/

var myCar = {
	name: "Ford Escort",

	drive: function() {
		console.log("Weee, I'm driving!");
	},

	panic: function() {
		console.log("Wait, how do you stop this thing?");
	}
};

// Use Object.create to instantiate a new car
var yourCar = Object.create(myCar);

// now we can see that one is a prototype of the other
console.log(yourCar.name);

/*
Object.create also allows us to easily implement advanced concepts such as 
differential inheritance where objects are able to directly inherit from 
other objects. We saw earlier that Object.create allows us to initialise 
object properties using the second supplied argument. For example:


var vehicle = {
	getModel: function() {
		console.log("The model of this vehicle is..." + this.model);
	}
};

var car = Object.create(vehicle, {
	"id": {
		value: MY_GLOBAL.nextId(),
		// writable: false, configurable: false by default
		enumerable:true
	},

	"model": {
		value: "Ford",
		enumerable: true
	}
});
*/

/*
*	Prototype pattern without Object.create
*/

var vehiclePrototype = {
	init: function (carModel) {
		this.model = carModel;
	},

	getModel: function() {
		console.log("The model of this vehicle is..." + this.model);
	}
};

function vehicle(model) {
	function F() {};
	F.prototype = vehiclePrototype;

	var f = new F();

	f.init(model);
	return f;
}

var car = vehicle("Ford Escort");
car.getModel();

// Alternative implementation

var beget = (function() {
	function F() {};

	return function(proto) {
		F.prototype = proto;
		return new F();
	};
})();

var newCar = beget(vehiclePrototype);
newCar.init("Tesla");
newCar.getModel();