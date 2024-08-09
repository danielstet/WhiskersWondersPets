
document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('form');

    const AnimalName = document.getElementById('animal_name');
    const AnimalNameParent = document.getElementById('animal_name_parent');
    const CharsPattern = /^[a-zA-Z]+$/;

    const AnimalAge = document.getElementById('animal_age');
    const AnimalAgeParent = document.getElementById('animal_age_parent');

    const NumberPattern = /^[0-9]+$/;

    const AnimalDesc = document.getElementById('animal_desc');
    const AnimalDescParent = document.getElementById('animal_desc_parent');

    const AnimalPicture = document.getElementById('animal_picture');
    const AnimalPictureParent = document.getElementById('animal_picture_parent');
    let PicValid = true;
    function validateName() {
        if (AnimalName.value.trim() === '') {
            setError(AnimalNameParent, 'Animal name is required');
            document.getElementById('animal_name').className = 'block px-2.5 pb-2.5 pt-4 w-full text-sm text-gray-900 bg-transparent rounded-lg border-1 appearance-none dark:text-white dark:border-red-500 border-red-600 dark:focus:border-red-500 focus:outline-none focus:ring-0 focus:border-red-600 peer';
            document.getElementById('animal_name_label').className = 'text-red-500 -translate-y-4 top-2 origin-[0] bg-white px-2 start-1 absolute z-10 scale-75 transform text-sm duration-300 peer-focus:px-2 peer-focus:text-red-600 peer-placeholder-shown:scale-100 peer-placeholder-shown:-translate-y-1/2 peer-placeholder-shown:top-1/2 peer-focus:top-2 peer-focus:scale-75 peer-focus:-translate-y-4 rtl:peer-focus:translate-x-1/4 rtl:peer-focus:left-auto';
            return false;
        } else if (!CharsPattern.test(AnimalName.value.trim())) {
            setError(AnimalNameParent, 'Only alphabetic letters are allowed');
            document.getElementById('animal_name').className = 'block px-2.5 pb-2.5 pt-4 w-full text-sm text-gray-900 bg-transparent rounded-lg border-1 appearance-none dark:text-white dark:border-red-500 border-red-600 dark:focus:border-red-500 focus:outline-none focus:ring-0 focus:border-red-600 peer';
            document.getElementById('animal_name_label').className = 'text-red-500 -translate-y-4 top-2 origin-[0] bg-white px-2 start-1 absolute z-10 scale-75 transform text-sm duration-300 peer-focus:px-2 peer-focus:text-red-600 peer-placeholder-shown:scale-100 peer-placeholder-shown:-translate-y-1/2 peer-placeholder-shown:top-1/2 peer-focus:top-2 peer-focus:scale-75 peer-focus:-translate-y-4 rtl:peer-focus:translate-x-1/4 rtl:peer-focus:left-auto';
            return false;
        }
        else {
            setSuccess(AnimalNameParent);
            document.getElementById('animal_name').className = 'px-2.5 pb-2.5 pt-4 text-gray-900 bg-transparent border-1 border-gray-300 peer block w-full appearance-none rounded-lg text-sm focus:outline-none focus:ring-0 focus:border-blue-600';
            document.getElementById('animal_name_label').className = 'text-gray-500 -translate-y-4 top-2 origin-[0] bg-white px-2 start-1 absolute z-10 scale-75 transform text-sm duration-300 peer-focus:px-2 peer-focus:text-blue-600 peer-placeholder-shown:scale-100 peer-placeholder-shown:-translate-y-1/2 peer-placeholder-shown:top-1/2 peer-focus:top-2 peer-focus:scale-75 peer-focus:-translate-y-4 rtl:peer-focus:translate-x-1/4 rtl:peer-focus:left-auto';
            return true;
        }
    }

    const validateAge = () => {
        if (AnimalAge.value.trim() === '') {
            setError(AnimalAgeParent, 'Please enter animal age');
            document.getElementById('animal_age').className = 'block px-2.5 pb-2.5 pt-4 w-full text-sm text-gray-900 bg-transparent rounded-lg border-1 appearance-none dark:text-white dark:border-red-500 border-red-600 dark:focus:border-red-500 focus:outline-none focus:ring-0 focus:border-red-600 peer';
            document.getElementById('animal_age_label').className = 'text-red-500 -translate-y-4 top-2 origin-[0] bg-white px-2 start-1 absolute z-10 scale-75 transform text-sm duration-300 peer-focus:px-2 peer-focus:text-red-600 peer-placeholder-shown:scale-100 peer-placeholder-shown:-translate-y-1/2 peer-placeholder-shown:top-1/2 peer-focus:top-2 peer-focus:scale-75 peer-focus:-translate-y-4 rtl:peer-focus:translate-x-1/4 rtl:peer-focus:left-auto';
            return false;
        }
        else if (AnimalAge.value.trim() <= 0) {
            setError(AnimalAgeParent, 'Age can not be negative');
            document.getElementById('animal_age').className = 'block px-2.5 pb-2.5 pt-4 w-full text-sm text-gray-900 bg-transparent rounded-lg border-1 appearance-none dark:text-white dark:border-red-500 border-red-600 dark:focus:border-red-500 focus:outline-none focus:ring-0 focus:border-red-600 peer';
            document.getElementById('animal_age_label').className = 'text-red-500 -translate-y-4 top-2 origin-[0] bg-white px-2 start-1 absolute z-10 scale-75 transform text-sm duration-300 peer-focus:px-2 peer-focus:text-red-600 peer-placeholder-shown:scale-100 peer-placeholder-shown:-translate-y-1/2 peer-placeholder-shown:top-1/2 peer-focus:top-2 peer-focus:scale-75 peer-focus:-translate-y-4 rtl:peer-focus:translate-x-1/4 rtl:peer-focus:left-auto';
            return false;
        }
        else if (AnimalAge.value.trim() > 15000) {
            setError(AnimalAgeParent, 'No animal can be that old');
            document.getElementById('animal_age').className = 'block px-2.5 pb-2.5 pt-4 w-full text-sm text-gray-900 bg-transparent rounded-lg border-1 appearance-none dark:text-white dark:border-red-500 border-red-600 dark:focus:border-red-500 focus:outline-none focus:ring-0 focus:border-red-600 peer';
            document.getElementById('animal_age_label').className = 'text-red-500 -translate-y-4 top-2 origin-[0] bg-white px-2 start-1 absolute z-10 scale-75 transform text-sm duration-300 peer-focus:px-2 peer-focus:text-red-600 peer-placeholder-shown:scale-100 peer-placeholder-shown:-translate-y-1/2 peer-placeholder-shown:top-1/2 peer-focus:top-2 peer-focus:scale-75 peer-focus:-translate-y-4 rtl:peer-focus:translate-x-1/4 rtl:peer-focus:left-auto';
            return false;
        }
        else if (!NumberPattern.test(AnimalAge.value.trim())) {
            setError(AnimalAgeParent, 'Age must contain only numbers');
            document.getElementById('animal_age').className = 'block px-2.5 pb-2.5 pt-4 w-full text-sm text-gray-900 bg-transparent rounded-lg border-1 appearance-none dark:text-white dark:border-red-500 border-red-600 dark:focus:border-red-500 focus:outline-none focus:ring-0 focus:border-red-600 peer';
            document.getElementById('animal_age_label').className = 'text-red-500 -translate-y-4 top-2 origin-[0] bg-white px-2 start-1 absolute z-10 scale-75 transform text-sm duration-300 peer-focus:px-2 peer-focus:text-red-600 peer-placeholder-shown:scale-100 peer-placeholder-shown:-translate-y-1/2 peer-placeholder-shown:top-1/2 peer-focus:top-2 peer-focus:scale-75 peer-focus:-translate-y-4 rtl:peer-focus:translate-x-1/4 rtl:peer-focus:left-auto';
            return false;
        }
        else {
            setSuccess(AnimalAgeParent);
            document.getElementById('animal_age').className = 'px-2.5 pb-2.5 pt-4 text-gray-900 bg-transparent border-1 border-gray-300 peer block w-full appearance-none rounded-lg text-sm focus:outline-none focus:ring-0 focus:border-blue-600';
            document.getElementById('animal_age_label').className = 'text-gray-500 -translate-y-4 top-2 origin-[0] bg-white px-2 start-1 absolute z-10 scale-75 transform text-sm duration-300 peer-focus:px-2 peer-focus:text-blue-600 peer-placeholder-shown:scale-100 peer-placeholder-shown:-translate-y-1/2 peer-placeholder-shown:top-1/2 peer-focus:top-2 peer-focus:scale-75 peer-focus:-translate-y-4 rtl:peer-focus:translate-x-1/4 rtl:peer-focus:left-auto';
            return true;
        }
    }

    const validateDesc = () => {
        if (AnimalDesc.value.trim() === '') {
            setError(AnimalDescParent, 'Animal description is required');
            document.getElementById('animal_desc').className = 'px-0 text-red-500 bg-white w-full border-0 text-sm focus:ring-0';
            document.getElementById('animal_desc_border').className = 'border-red-200 bg-red-50 h-72 w-full rounded-lg border';
            document.getElementById('animal_submit_btn').className = 'py-2.5 px-4 text-white bg-red-700 inline-flex items-center rounded-lg text-center text-xs font-medium hover:bg-red-800 focus:ring-4 focus:ring-red-200';
            return false;
        } else {
            setSuccess(AnimalDescParent);
            document.getElementById('animal_desc').className = 'px-0 text-gray-900 bg-white w-full border-0 text-sm focus:ring-0';
            document.getElementById('animal_desc_border').className = 'border-gray-200 bg-gray-50 h-72 w-full rounded-lg border';
            document.getElementById('animal_submit_btn').className = 'py-2.5 px-4 text-white bg-blue-700 inline-flex items-center rounded-lg text-center text-xs font-medium hover:bg-blue-800 focus:ring-4 focus:ring-blue-200';
            return true
        }
    }

    const validatePic = (e) => {
        const pic = e.target.files[0];
        if (pic.type.includes('image') || pic == null) {
            PicValid = true;
            setSuccess(AnimalPictureParent)
            return true
        } else {
            setError(AnimalPictureParent, 'file must be an image')
            PicValid = false;
            return false
        }
    }

    AnimalName.addEventListener('input', validateName);
    AnimalAge.addEventListener('input', validateAge);
    AnimalDesc.addEventListener('input', validateDesc);
    AnimalPicture.addEventListener('change', validatePic);



    form.addEventListener('submit', (event) => {
        const isAnimalValid = validateName();
        const isAgeValid = validateAge();
        const isDescValid = validateDesc();
        const isPicValid = PicValid;
        if (!isAnimalValid || !isAgeValid || !isDescValid || !isPicValid) {
            event.preventDefault(); // Prevent form submission if validation fails
        } else {
            event.preventDefault();
            Swal.fire({
                title: "Submit new Animal",
                icon: "question",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Yes, submit it!"
            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire({
                        title: "Confirmed!",
                        text: "The animal has been submited",
                        icon: "success"
                    });
                    setTimeout(() => {
                        const formData = new FormData(form);
                        fetch("http://localhost:5250/Admin/UpdateAnimal", {
                            method: 'POST',
                            body: formData
                        }).then(response => {
                            if (response.ok) {
                                Swal.fire({
                                    position: "top",
                                    icon: "success",
                                    title: "The animal has been created successfuly",
                                    showConfirmButton: false,
                                    timer: 1500
                                })
                                setTimeout(() => {
                                    // Refresh the page
                                    location.reload();
                                }, 1500);
                            } else {
                                return Swal.fire({
                                    title: "Error",
                                    text: "The animal has not been Added",
                                    icon: "error"
                                });
                            }
                        }).catch(error => {
                            console.error('Fetch error:', error);
                            Swal.fire({
                                title: "Error",
                                text: "There was a problem with the request",
                                icon: "error"
                            });
                        });
                    }, 1500);

                }
            });

        }
    });
});

const setError = (element, message) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');
    errorDisplay.innerText = message;
}

const setSuccess = (element) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');
    errorDisplay.innerText = '';
}

