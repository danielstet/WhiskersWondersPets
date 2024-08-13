
const deleteComment = (CommentId, AnimalId) => {
    Swal.fire({
        title: "Delete Comment",
        icon: "question",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(`http://localhost:5250/Admin/DeleteComment?id=${CommentId}&AnimalId=${AnimalId}`, {
                method: 'Post',
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(response => {
                if (response.ok) {
                    Swal.fire({
                        title: "Confirmed!",
                        text: "The comment has been deleted",
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