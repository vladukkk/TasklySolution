document.addEventListener("DOMContentLoaded", function () {
    var stickyDiv = document.getElementById("filter-container");
    var stickyOffset = stickyDiv.offsetTop + stickyDiv.offsetHeight;

    window.addEventListener("scroll", function () {
        if (stickyOffset <= window.scrollY) {
            stickyDiv.classList.add("fixed", "animate__animated", "animate__fadeInDown");
        } else {
            stickyDiv.classList.remove("fixed", "animate__fadeInDown");
        }
    });
});
