/*
* To demonstrate the Command pattern we're going to create a simple car purchasing service.
*/

(function() {
	var carManager = {

		// request information
		requestInfo: function(model, id) {
			return "The information for " + model + " with ID " + id + " is foobar";
		},

		// purchase the car
		buyVehicle: function(model, id) {
			return "You have successfully purchased Item " + id + ", a " + model;
		},

		// arrange a viewing
		arrangeViewing: function(model, id) {
			return "You have successfully booked a viewing of " + model + " ( " + id + " ) ";
		}
	};

	/*
	Let's now expand on our carManager so that our application of the Command pattern 
	results in the following: accept any named methods that can be performed on the carManager 
	object, passing along any data that might be used such as the Car model and ID.
	*/

	carManager.execute = function(name) {
		return carManager[name] && carManager[name].apply(carManager, [].slice.call(arguments, 1));
	};

	// Our final sample calls would thus look as follows:

	console.log(carManager.execute("arrangeViewing", "Ferrari", "14523"));
	console.log(carManager.execute("requestInfo", "Ford Mondeo", "54323"));
	console.log(carManager.execute("requestInfo", "Ford Escort", "34352"));
	console.log(carManager.execute("buyVehicle", "Tesla Tesla Tesla", "999999"));
})();

