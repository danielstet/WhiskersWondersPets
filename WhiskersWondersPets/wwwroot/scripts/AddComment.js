document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('form');

    form.addEventListener('submit', (event) => {
        event.preventDefault();
        const formData = new FormData(form);
        fetch("http://localhost:5250/Catalog/AddCommnet", {
            method: 'POST',
            body: formData
        }).then(response => {
            if (response.ok) {
                SuccessToast()
                setTimeout(() => {
                    location.reload();
                }, 1500)
            } else {
                FailureToast()
            }
        })
    });
});

const SuccessToast = () => {
    Swal.fire({
        position: "top",
        icon: "success",
        title: "The comment has been added",
        showConfirmButton: false,
        timer: 1500
    })
}
const FailureToast = () => {
    Swal.fire({
        position: "top",
        icon: "error",
        title: "Sorry, an error have accured try again later",
        showConfirmButton: false,
        timer: 1500
    })
}