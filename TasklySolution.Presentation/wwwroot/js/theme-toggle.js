document.addEventListener("DOMContentLoaded", function () {
    const themeToggleButton = document.getElementById("theme-toggle");
    const currentTheme = localStorage.getItem("theme") || "light";

    document.documentElement.setAttribute("data-theme", currentTheme);
    themeToggleButton.textContent = currentTheme === "dark" ? "☀️" : "🌙";

    themeToggleButton.addEventListener("click", function () {
        const newTheme = document.documentElement.getAttribute("data-theme") === "dark" ? "light" : "dark";
        document.documentElement.setAttribute("data-theme", newTheme);
        localStorage.setItem("theme", newTheme);
        themeToggleButton.textContent = newTheme === "dark" ? "☀️" : "🌙";
    });
});
