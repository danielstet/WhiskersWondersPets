
const deleteAnimal = (animalId) => {
    Swal.fire({
        title: "Delete Animal",
        icon: "question",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(`http://localhost:5250/Admin/DeleteAnimal?id=${animalId}`, {
                method: 'Post',
                headers: {
                    'Content-Type': 'application/json'
                }  
            }).then(response => {
                if (response.ok) {
                    Swal.fire({
                        title: "Confirmed!",
                        text: "The animal has been deleted",
                        icon: "success",
                        showConfirmButton: false
                    });
                    setTimeout(() => {
                        location.reload();
                    }, 1500)
                } else {
                    Swal.fire({
                        title: "Failure!",
                        text: "Something went very wrong",
                        icon: "error",
                        showConfirmButton: false
                    });
                }
                
            })
        }
    });
}