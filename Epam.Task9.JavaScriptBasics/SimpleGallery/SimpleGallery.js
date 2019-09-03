const path = "file:///C:/Users/Daria/Desktop/EPAM/XT_Q2/Epam.Task9.JavaScriptBasics/SimpleGallery/";
const regex = /\d+.(html)/;

let div = document.getElementById("timer");
let currentTime = 2;

const pages = ["1.html", "2.html", "3.html"];
currentPageIndex = pages.indexOf(regex.exec(window.location.href)[0]);
let interval = setInterval(startTimer, 1000);

let stopBtn = document.getElementById("stop");
stopBtn.addEventListener("click", () => {
    clearInterval(interval);
    console.log(currentTime);
})

let goBtn = document.getElementById("go");
goBtn.addEventListener("click", () => {
    interval = setInterval(startTimer, 1000);
})

function startTimer() {
    if (+div.innerHTML > 0) {
        currentTime--;
        div.innerHTML = currentTime;
    }
    if (+div.innerHTML === 0) {
        if (currentPageIndex !== pages.length - 1) {
        window.location.href = path + pages[currentPageIndex + 1];
        } else {
            window.location.href = path + pages[0];
        }
    }
}   