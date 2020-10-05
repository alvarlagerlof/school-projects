interface VehicleConfig {
  model: string;
  fuel: number;
  color: string;
}

const driver = (state: VehicleConfig) => {
  return {
    drive: () => console.log(`A ${state.color} ${state.model} drove`),
  };
};

const flyer = (state: VehicleConfig) => {
  return {
    fly: () => console.log(`A ${state.color} ${state.model} flew`),
  };
};

const carFactory = (model: string, color: string) => {
  let state: VehicleConfig = {
    model,
    color,
    fuel: 100,
  };

  return { ...state, ...driver(state) };
};

const planeFactory = (model: string, color: string) => {
  let state: VehicleConfig = {
    model,
    color,
    fuel: 100,
  };

  return { ...state, ...flyer(state) };
};

const flyingCarFactory = (model: string, color: string) => {
  let state: VehicleConfig = {
    model,
    color,
    fuel: 100,
  };

  return { ...state, ...driver(state), ...flyer(state) };
};

const car = carFactory("Volvo V70", "red");
car.drive();

const plane = planeFactory("Cessna 172", "green");
plane.fly();

const flyingCar = flyingCarFactory("Hyundai eVTOL", "white");
flyingCar.drive();
flyingCar.fly();
