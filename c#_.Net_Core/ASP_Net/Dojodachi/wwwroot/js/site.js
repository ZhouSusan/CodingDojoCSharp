var feed = document.getElementById("btn-Feed");
var messages = document.getElementById("message-box");
var mealsCount = document.getElementById("mealsCount");
var fullnessAmt = document.getElementById("fullnessAmt");
var play = document.getElementById("btn-Play");
var happinessAmt = document.getElementById("happinessAmt");
var energyAmt = document.getElementById("energyAmt");
var work = document.getElementById("btn-Work");
var sleep = document.getElementById("btn-Sleep");
var restart = document.getElementById("restart-btn");
var img = document.getElementById("pic-box");

feed.addEventListener("click", function () {
  fetch("/feed")
    .then((response) => response.json())
    .then((data) => {
      console.log(typeof data);
      console.log(data);
      if (data.message.includes("can't")) {
        messages.innerHTML = data.message;
      } else if (data.message.includes("not")) {
        mealsCount.innerHTML = parseInt(mealsCount.innerHTML) - 1;
        messages.innerHTML = data.message;
      } else if (data.message.includes("ate")) {
        fullnessAmt.innerHTML = data.amount;
        messages.innerHTML = data.message;
        mealsCount.innerHTML = parseInt(mealsCount.innerHTML) - 1;
      }
      img.src = "/img/sushi.jpg";
      WinOrLose();
    });
});

play.addEventListener("click", function () {
  fetch("/play")
    .then((response) => response.json())
    .then((data) => {
      console.log(typeof data);
      console.log(data);
      happinessAmt.innerHTML = data.happiness;
      energyAmt.innerHTML = data.energy;
      messages.innerHTML = data.message;
      img.src = "/img/playful.jfif";
      WinOrLose();
    });
});

work.addEventListener("click", function () {
  fetch("/work")
    .then((response) => response.json())
    .then((data) => {
      console.log(typeof data);
      console.log(data);
      mealsCount.innerHTML = data.meals;
      energyAmt.innerHTML = data.energy;
      messages.innerHTML = data.message;
      img.src = "/img/sushi.jpg";
      WinOrLose();
    });
});

sleep.addEventListener("click", function () {
  fetch("/sleep")
    .then((response) => response.json())
    .then((data) => {
      console.log(typeof data);
      console.log(data);
      fullnessAmt.innerHTML = data.fullness;
      energyAmt.innerHTML = data.energy;
      happinessAmt.innerHTML = data.happiness;
      messages.innerHTML = data.message;
      img.src = "/img/sleepy.jfif";
      WinOrLose();
    });
});

function WinOrLose() {
  if (
    fullnessAmt.innerHTML >= 100 &&
    energyAmt.innerHTML >= 100 &&
    happinessAmt.innerHTML >= 100
  ) {
    messages.innerHTML = "You Win!!!";
    restart.style = "display:block;";
  } else if (fullnessAmt.innerHTML <= 0 || happinessAmt.innerHTML <= 0) {
    messages.innerHTML = "You Lose!";
    restart.style = "display:block;";
  }
}
