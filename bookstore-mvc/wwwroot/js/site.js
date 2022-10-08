// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const actBookBtn = document.querySelectorAll(".act-btn");
// const actBookList = document.querySelectorAll(".act-list");

actBookBtn.forEach(element => {
  element.addEventListener("click", function() {
    element.classList.toggle("active");
    const actBookList = element.parentNode.querySelector(".act-list");
    // actBookList.classList.toggle(".active-list");
    // const actBookList

    if (element.classList.contains("active")) {
      actBookList.style.display = "flex";
      console.log("yes");
    } else {
      actBookList.style.display = "none";
      console.log("no");
    }
  });
});


