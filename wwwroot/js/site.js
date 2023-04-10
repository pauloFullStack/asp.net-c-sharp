// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

if (document.querySelectorAll('.close-alert')) {
    document.querySelectorAll('.close-alert').forEach((botao) => {
        botao.addEventListener('click', e => closeAlert(e))
    })
}


function closeAlert(e) {
    const classeName = e.target.parentElement.parentElement;
    classeName.classList.add('alert-fadeout');
    setTimeout(() => {
        document.querySelector(`.${classeName.classList[1]}`).style.display = 'none';
    }, 1000);

}