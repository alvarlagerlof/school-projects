class Ball {
  color: string;
  private _diameter: number;

  constructor(color: string, diameter: number) {
    this.color = color;
    this._diameter = diameter;
  }

  get diameter() {
    return this._diameter;
  }

  set diameter(diameter: number) {
    // Could do validaton here
    this._diameter = diameter;
  }
}

let ball = new Ball("red", 10);

console.log(ball.color);
ball.color = "orange";
console.log(ball.color);

console.log(ball.diameter);
ball.diameter = 45;
console.log(ball.diameter);
