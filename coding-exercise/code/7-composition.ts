interface VehicleConfig {
  model: string;
  fuel: number;
  color: string;
}

const driver = (state: VehicleConfig) => {
    return {
        drive: () => console.log(`${state.model} drove`);
    }
};

const flyer = (state: VehicleConfig) => {
    return {
        fly: () => console.log(`${state.model} flew`);
    }
};

const carFactory = (model: string, color: string) => {
  let state: VehicleConfig = {
    model,
    color,
    fuel: 100,
  };

  return { ...state, ...driver(state) };
};
