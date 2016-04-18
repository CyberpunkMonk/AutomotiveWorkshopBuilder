using System;
using System.Collections.Generic;
namespace AutomotiveFactory {
	/// <summary>
	/// MainApp startup class for Real-World 
	/// Builder Design Pattern.
	/// </summary>
	public class MainApp {
		/// <summary>
		/// Entry point into console application.
		/// </summary>
		public static void Main() {
			VehicleBuilder builder;
			// Create shop with vehicle builders
			Shop shop = new Shop();
			// Construct and display vehicles
			builder = new ScooterBuilder();
			shop.Construct(builder);
			builder.Vehicle.Show();
			builder = new CarBuilder();
			shop.Construct(builder);
			builder.Vehicle.Show();
			builder = new MotorCycleBuilder();
			shop.Construct(builder);
			builder.Vehicle.Show();
			// Wait for user
			Console.ReadKey();
		}
	}

	/// <summary>
	/// The 'Director' class
	/// </summary>
	class Shop {
		// Builder uses a complex series of steps
		/// <summary>
		/// Constructs the specified vehicle builder.
		/// </summary>
		/// <param name="vehicleBuilder">The vehicle builder.</param>
		public void Construct(VehicleBuilder vehicleBuilder) {
			vehicleBuilder.BuildFrame();
			vehicleBuilder.BuildEngine();
			vehicleBuilder.BuildWheels();
			vehicleBuilder.BuildDoors();
		}
	}

	/// <summary>
	/// The 'Builder' abstract class
	/// </summary>
	abstract class VehicleBuilder {
		protected Vehicle vehicle;
		// Gets vehicle instance
		/// <summary>
		/// Gets the vehicle.
		/// </summary>
		/// <value>
		/// The vehicle.
		/// </value>
		public Vehicle Vehicle {
			get { return vehicle; }
		}
		// Abstract build methods
		/// <summary>
		/// Builds the frame.
		/// </summary>
		public abstract void BuildFrame();
		/// <summary>
		/// Builds the engine.
		/// </summary>
		public abstract void BuildEngine();
		/// <summary>
		/// Builds the wheels.
		/// </summary>
		public abstract void BuildWheels();
		/// <summary>
		/// Builds the doors.
		/// </summary>
		public abstract void BuildDoors();
	}
	/// <summary>
	/// The 'ConcreteBuilder1' class
	/// </summary>
	class MotorCycleBuilder : VehicleBuilder {
		/// <summary>
		/// Initializes a new instance of the <see cref="MotorCycleBuilder"/> class.
		/// </summary>
		public MotorCycleBuilder() {
			vehicle = new Vehicle("MotorCycle");
		}
		/// <summary>
		/// Builds the frame.
		/// </summary>
		public override void BuildFrame() {
			vehicle["frame"] = "MotorCycle Frame";
		}
		/// <summary>
		/// Builds the engine.
		/// </summary>
		public override void BuildEngine() {
			vehicle["engine"] = "500 cc";
		}
		/// <summary>
		/// Builds the wheels.
		/// </summary>
		public override void BuildWheels() {
			vehicle["wheels"] = "2";
		}
		/// <summary>
		/// Builds the doors.
		/// </summary>
		public override void BuildDoors() {
			vehicle["doors"] = "0";
		}
	}

	/// <summary>
	/// The 'ConcreteBuilder2' class
	/// </summary>
	class CarBuilder : VehicleBuilder {
		/// <summary>
		/// Initializes a new instance of the <see cref="CarBuilder"/> class.
		/// </summary>
		public CarBuilder() {
			vehicle = new Vehicle("Car");
		}
		/// <summary>
		/// Builds the frame.
		/// </summary>
		public override void BuildFrame() {
			vehicle["frame"] = "Car Frame";
		}
		/// <summary>
		/// Builds the engine.
		/// </summary>
		public override void BuildEngine() {
			vehicle["engine"] = "2500 cc";
		}
		/// <summary>
		/// Builds the wheels.
		/// </summary>
		public override void BuildWheels() {
			vehicle["wheels"] = "4";
		}
		/// <summary>
		/// Builds the doors.
		/// </summary>
		public override void BuildDoors() {
			vehicle["doors"] = "4";
		}
	}
	/// <summary>
	/// The 'ConcreteBuilder3' class
	/// </summary>
	class ScooterBuilder : VehicleBuilder {
		/// <summary>
		/// Initializes a new instance of the <see cref="ScooterBuilder"/> class.
		/// </summary>
		public ScooterBuilder() {
			vehicle = new Vehicle("Scooter");
		}
		/// <summary>
		/// Builds the frame.
		/// </summary>
		public override void BuildFrame() {
			vehicle["frame"] = "Scooter Frame";
		}
		/// <summary>
		/// Builds the engine.
		/// </summary>
		public override void BuildEngine() {
			vehicle["engine"] = "50 cc";
		}
		/// <summary>
		/// Builds the wheels.
		/// </summary>
		public override void BuildWheels() {
			vehicle["wheels"] = "2";
		}
		/// <summary>
		/// Builds the doors.
		/// </summary>
		public override void BuildDoors() {
			vehicle["doors"] = "0";
		}
	}

	/// <summary>
	/// The 'Product' class
	/// </summary>
	class Vehicle {
		/// <summary>
		/// The _vehicle type
		/// </summary>
		private string _vehicleType;
		/// <summary>
		/// The _parts
		/// </summary>
		private Dictionary<string, string> _parts = new Dictionary<string, string>();

		// Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		/// <param name="vehicleType">Type of the vehicle.</param>
		public Vehicle(string vehicleType) {
			this._vehicleType = vehicleType;
		}

		// Indexer
		/// <summary>
		/// Gets or sets the <see cref="System.String"/> with the specified key.
		/// </summary>
		/// <value>
		/// The <see cref="System.String"/>.
		/// </value>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public string this[string key] {
			get { return _parts[key]; }
			set { _parts[key] = value; }
		}

		/// <summary>
		/// Shows this instance.
		/// </summary>
		public void Show() {
			Console.WriteLine("\n---------------------------");
			Console.WriteLine("Vehicle Type: {0}", _vehicleType);
			Console.WriteLine(" Frame : {0}", _parts["frame"]);
			Console.WriteLine(" Engine : {0}", _parts["engine"]);
			Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
			Console.WriteLine(" #Doors : {0}", _parts["doors"]);
		}
	}
}