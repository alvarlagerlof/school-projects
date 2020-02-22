let buttonList = [
  {
    price: 20,
    reward: {
      cps: 2
    }
  },
  {
    price: 30,
    reward: {
      cpc: 2
    }
  }
];

let state = {
  cookies: 0,
  cps: 1,
  cpc: 1
};

const buttonContainer = document.querySelector(".button-container");
const stateText = document.querySelector(".state");
const getCookiesButton = document.querySelector(".get-cookies");

getCookiesButton.addEventListener("click", function() {
  state.cookies += state.cpc;
  renderCookies();
  renderState();
});

setInterval(function() {
  state.cookies += state.cps;
  renderState();
  renderCookies();
}, 1000);

function renderState() {
  stateText.innerHTML = `Du har ${state.cookies} kakor\nCps: ${state.cps}\nCpc: ${state.cpc}`;
}

function renderCookies() {
  buttonContainer.innerHTML = "";

  for (let i = 0; i < buttonList.length; i++) {
    const { price, reward } = buttonList[i];

    let button = document.createElement("button");
    button.innerHTML = `
            <p>Price: ${price} cookies</p>
            <p style="color: ${
              price > state.cookies ? "red" : "black"
            }">Reward ${
      reward.cpc
        ? reward.cpc + " cookies per click"
        : reward.cps + " cookies per second"
    } kr<p>
        `;

    button.addEventListener("click", function() {
      if (price <= state.cookies) {
        buttonList[i].price = Math.round(buttonList[i].price * 1.25);
        if (reward.cpc) {
          state.cookies -= price;
          state.cpc += reward.cpc;
        } else {
          state.cookies -= price;
          state.cps += reward.cps;
        }
        renderCookies();
        renderState();
      }
    });

    buttonContainer.appendChild(button);
  }
}
