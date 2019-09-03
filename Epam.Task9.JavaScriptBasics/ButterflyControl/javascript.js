let itemsToAdd = [];
let itemsToRemove = [];
let availableList = document.getElementById("available-list");
let selectedList = document.getElementById("selected-items");

availableList.addEventListener("click", (e) => {
    if (e.target!==e.currentTarget) {
        if (e.target.classList.contains("active")) {
            itemsToAdd.pop(e.target);
            e.target.classList.remove("active");
        } else {
            itemsToAdd.push(e.target);
            e.target.classList.add("active");
        }
    }   
});
//!e.target.classList.contains("list")
selectedList.addEventListener("click", (e) => {
    if (e.target!==e.currentTarget) {
        if (e.target.classList.contains("active")) {
            itemsToRemove.pop(e.target);
            e.target.classList.remove("active");
           
        } else {
            itemsToRemove.push(e.target);
            e.target.classList.add("active");
        }
    }
});

document.getElementById("add-one").addEventListener("click", (e) => {
    for(let i = 0; i < itemsToAdd.length; i++) {
        availableList.removeChild(itemsToAdd[i]);
        selectedList.appendChild(itemsToAdd[i]);
        toggleClass(itemsToAdd[i]);
    }
    itemsToAdd = [];
})

document.getElementById("remove-one").addEventListener("click", (e) => {
    for(let i = 0; i < itemsToRemove.length; i++) {
        selectedList.removeChild(itemsToRemove[i]);
        availableList.appendChild(itemsToRemove[i]);
        toggleClass(itemsToRemove[i]);
    }
    itemsToRemove = [];
})

document.getElementById("add-all").addEventListener("click", (e) => {
    availableList.querySelectorAll(".list-item").forEach(e => {
        selectedList.appendChild(e);
    });
})

document.getElementById("remove-all").addEventListener("click", (e) => {
    selectedList.querySelectorAll(".list-item").forEach(e => {
        availableList.appendChild(e);
    });
})

function toggleClass(element) {
    if (element.classList.contains("active")) {
        element.classList.remove("active");
    } else {
        element.classList.add("active");
    }
}