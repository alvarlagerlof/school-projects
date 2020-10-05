class Bullet {
  size: number;

  constructor(sizeMilliter: number) {
    this.size = sizeMilliter;
  }
}

class Gun {
  name: string;
  strength: number;
  bullets: Array<Bullet>;

  constructor(name: string, strength: number, bullets: Array<Bullet>) {
    this.name = name;
    this.strength = strength;
    this.bullets = bullets;
  }

  load(newBullets: Array<Bullet>) {
    this.bullets = [...this.bullets, ...newBullets];
  }

  shoot() {
    this.bullets.shift();
    console.log("Bang!");
  }
}

class ShotGun extends Gun {
  constructor(name: string, strength: number, bullets: Array<Bullet>) {
    super(name, strength, bullets);
  }

  shoot() {
    // Probably also with slightly random directions
    this.bullets.shift();
    this.bullets.shift();
    this.bullets.shift();
    this.bullets.shift();
    this.bullets.shift();
    console.log("Boom!");
  }
}

class Inventory {
  currentItem: number = 0;
  items: Array<Gun>;

  constructor(items: Array<Gun>) {
    this.items = items;
  }

  addItems(items: Array<Gun>) {
    this.items = [...this.items, ...items];
  }

  shoot() {
    this.items[this.currentItem].shoot();
  }

  changeSlot(number: number) {
    this.currentItem = Math.min(this.items.length - 1, Math.max(0, number));
  }
}

class Player {
  invetory: Inventory;

  constructor() {
    this.invetory = new Inventory([]);
    this.fillInventory();
  }

  fillInventory() {
    const genBullets = (amount: number, size: number): Array<Bullet> => {
      let array: Array<Bullet> = [];
      for (let i = 0; i++; i < amount) {
        array.push(new Bullet(size));
      }
      return array;
    };

    this.invetory.addItems([
      new Gun("Cool name", 50, genBullets(50, 10)),
      new ShotGun("Cool name", 5, genBullets(5, 12)),
    ]);
  }

  preformSomeActions() {
    this.invetory.shoot();
    this.invetory.changeSlot(1);
    this.invetory.shoot();
  }
}

let player = new Player();
player.preformSomeActions();
