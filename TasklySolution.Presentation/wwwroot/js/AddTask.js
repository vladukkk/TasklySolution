
document.addEventListener("DOMContentLoaded", function () {
    const dropdownButton = document.getElementById("selected-priority");
    const dropdownList = document.getElementById("priorities-list");
    const priorityInput = document.getElementById("priorityId");

    if (!dropdownButton || !dropdownList || !priorityInput) return;

    dropdownButton.addEventListener("click", function (event) {
        event.preventDefault();
        dropdownList.style.display = (dropdownList.style.display === "block") ? "none" : "block";
    });

    document.addEventListener("click", function (e) {
        if (!dropdownButton.contains(e.target) && !dropdownList.contains(e.target)) {
            dropdownList.style.display = "none";
        }
    })

    document.querySelectorAll(".custom-priority").forEach(item => {
        item.addEventListener("click", function () {
            let text = item.innerText.trim();
            let color = item.getAttribute("data-color");
            let id = item.getAttribute("data-id");

            dropdownButton.innerText = text;
            dropdownButton.style.backgroundColor = color;
            dropdownButton.style.color = "#FFF";
            priorityInput.value = id;

            dropdownList.style.display = "none";
        });
    });

});

document.addEventListener("DOMContentLoaded", function () {

    const selectTagBtn = document.getElementById("select-tag");
    const dropDownTagsList = document.getElementById("tags-list");

    if (!selectTagBtn || !dropDownTagsList) return;

    selectTagBtn.addEventListener("click", function () {
        dropDownTagsList.style.display = dropDownTagsList.style.display === "block" ? "none" : "block";
    });

    document.addEventListener("click", function (e) {
        if (!selectTagBtn.contains(e.target) && !dropDownTagsList.contains(e.target)) {
            dropDownTagsList.style.display = "none";
        }
    });
});