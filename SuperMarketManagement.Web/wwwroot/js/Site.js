function ShowSwal(title, text, icon) {
    swal.fire({
        title: title,
        text: text,
        icon: icon,
        confirmButtonText: 'باشه',
        html: text
    });
}

function ShowToast(title, icon) {
    event.preventDefault();
    var Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 5000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer);
            toast.addEventListener('mouseleave', Swal.resumeTimer);
        }
    });

    Toast.fire({
        icon: icon,
        title: title
    });
}
