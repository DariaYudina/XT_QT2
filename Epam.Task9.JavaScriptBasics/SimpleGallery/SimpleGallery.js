const path = "file:///C:/Users/Daria/Desktop/EPAM/XT_Q2/Epam.Task9.JavaScriptBasics/SimpleGallery/";
const regex = /\d+.(html)/;

let div = document.getElementById("timer");
let currentTime = 5;

const pages = ["1.html", "2.html", "3.html"];
currentPageIndex = pages.indexOf(regex.exec(window.location.href)[0]);
if (currentPageIndex === pages.length - 1) {
    let isRestart = confirm("Press OK if you want to restart, Cancel if not");
    if (isRestart) {
        window.location.href = path + pages[0];
    } else {
        window.location.href = '/closekiosk';
    }
}
let interval = setInterval(startTimer, 1000);

let stopBtn = document.getElementById("stop");
stopBtn.addEventListener("click", () => {
    clearInterval(interval);
})

let goBtn = document.getElementById("go");
goBtn.addEventListener("click", () => {
    currentTime = 5;
    div.innerHTML = currentTime;
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

let nextBtn = document.getElementById("next");
nextBtn.addEventListener("click", () => {
    if (currentPageIndex !== pages.length - 1) {
        window.location.href = path + pages[currentPageIndex + 1];
    }
})

let prevBtn = document.getElementById("prev");
prevBtn.addEventListener("click", () => {
    if (currentPageIndex !== 0) {
        window.location.href = path + pages[currentPageIndex - 1];
    }
})